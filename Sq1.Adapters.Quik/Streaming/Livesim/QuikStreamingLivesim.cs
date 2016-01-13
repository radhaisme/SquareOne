﻿using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Threading;

using NDde.Client;
using Newtonsoft.Json;

using Sq1.Core;
using Sq1.Core.Support;
using Sq1.Core.Livesim;
using Sq1.Core.DataFeed;
using Sq1.Core.Streaming;
using Sq1.Core.Backtesting;
using Sq1.Core.Execution;

using Sq1.Adapters.Quik;

namespace Sq1.Adapters.Quik.Streaming.Livesim {
	[SkipInstantiationAt(Startup = true)]		// overriding LivesimStreaming's TRUE to have QuikStreamingLivesim appear in DataSourceEditor
	public partial class QuikStreamingLivesim : LivesimStreaming {
		[JsonIgnore]	string	reasonToExist =    "1) use LivesimForm as control "
												+ "2) instantiate QuikStreaming and make it run its DDE server "
												+ "3) push quotes generated using DDE client";

		[JsonIgnore]	string	ddeTopicsPrefix = "QuikLiveSim-";

		[JsonIgnore]	public	QuikLivesimBatchPublisher	QuikLivesimBatchPublisher;

		[JsonIgnore]			ConcurrentDictionaryGeneric<double, double> LevelTwoAsks	{ get { return base.StreamingDataSnapshot.LevelTwoAsks; } }
		[JsonIgnore]			ConcurrentDictionaryGeneric<double, double> LevelTwoBids	{ get { return base.StreamingDataSnapshot.LevelTwoBids; } }

		[JsonIgnore]	public	QuikStreaming	QuikStreamingOriginal						{ get { return base.StreamingAdapterOriginal as QuikStreaming; } }
		[JsonIgnore]			bool			ddeWasStarted_preLivesim;

		public QuikStreamingLivesim() : base(true) {
			base.Name = "QuikStreamingLivesim-InstantiatedFromDll";
			//base.Icon = (Bitmap)Sq1.Adapters.Quik.Streaming.Livesim.Properties.Resources.imgQuikStreamingLivesim;

			//NO_DESERIALIZATION_WILL_THROW_YOULL_NULLIFY_ME_IN_UpstreamConnect YES_I_PROVOKE_NPE__NEED_TO_KNOW_WHERE_SNAPSHOT_IS_USED WILL_POINT_IT_TO_QUIK_REAL_STREAMING_IN_UpstreamConnect_LivesimStarting()
			//this.StreamingDataSnapshot = null;

			this.Level2generator = new LevelTwoGenerator();		// this one has it's own LevelTwoAsks,LevelTwoBids NOT_REDIRECTED to StreamingDatasnapshot => sending Level2 via DDE to QuikStreaming.StreamingDatasnapshot
		}

		public void InitializeDataSource(LivesimDataSource livesimDataSource, bool subscribeSolidifier = true) {
			base.Name = "QuikStreamingLivesim-initializedWithLivesimDataSource";
			//base.Icon = (Bitmap)Sq1.Adapters.Quik.Streaming.Livesim.Properties.Resources.imgQuikStreamingLivesim;
			base.InitializeDataSource(livesimDataSource, subscribeSolidifier);
		}

		//public override void Initialize(DataSource deserializedDataSource) {
		//    base.Name = "QuikStreamingLivesim";
		//    base.Initialize(deserializedDataSource);
		//}

		protected override void SolidifierAllSymbolsSubscribe() {
			string msg = "OTHERWIZE_BASE_WILL_SUBSCRIBE_SOLIDIFIER LIVESIM_MUST_NOT_SAVE_ANY_BARS";
		}

		public override void UpstreamConnect_LivesimStarting() {
			string msig = " //UpstreamConnect_LivesimStarting(" + this.ToString() + ")";

			this.ddeWasStarted_preLivesim = this.QuikStreamingOriginal.StreamingConnected;

			//this.QuikStreamingOriginal.SolidifierUnsubscribeOneSymbol_imLivesimming();
			base.SubstituteDistributorForSymbolsLivesimming_extractChartIntoSeparateDistributor();


			this.QuikStreamingOriginal.InitializeDataSource(base.Livesimulator.DataSourceAsLivesimNullUnsafe, false);	//LivesimDataSource having LivesimBacktester and no-solidifier DataDistributor
			if (this.ddeWasStarted_preLivesim == false) {
				this.QuikStreamingOriginal.UpstreamConnect();
			}

			// MarketLive checks for LastQuote, which I don't save anymore in QuikStreamingLivesim
			// QuikStreamingLivesim is a handicap without StreamingDataSnapshot; normally Snap is maintained by
			// 1) DataDistributorChart.StreamingDataSnapshot.LastQuoteCloneInitialize(symbol)
			//		but QuikStreamingLivesim.DataDistributor is donated to the Puppet
			// 2) StreamingAdapter(base).PushQuoteGenerated(): StreamingDataSnapshot.LastQuoteCloneSetForSymbol(quote);
			//		but QuikStreamingLivesim doesnt invoke base.PushQuoteGenerated(quote) because it shoots the quote to DDE and doesnt deal with Distributor
			//if (this.StreamingDataSnapshot != null) {
			//    string msg1 = "MUST_BE_NULL__ONLY_INITIALIZED_FOR_MarketLive_FOR_A_LIVESIM_SESSION__OTHERWIZE_MUST_BE_NULL";
			//    Assembler.PopupException(msg1);
			//}
			this.StreamingDataSnapshot = this.QuikStreamingOriginal.StreamingDataSnapshot;

			this.QuikLivesimBatchPublisher = new QuikLivesimBatchPublisher(this);
			this.QuikLivesimBatchPublisher.ConnectAll();
			//string msg = "ALL_DDE_CLIENTS_CONNECTED[" + this.QuikStreamingPuppet.DdeServiceName + "] TOPICS[" + this.QuikStreamingPuppet.DdeBatchSubscriber.TopicsAsString + "]";
			//Assembler.PopupException(msg + msig, null, false);
		}

		public override void UpstreamDisconnect_LivesimEnded() {
			string msig = " //UpstreamDisconnect_LivesimEnded(" + this.ToString() + ")";
			string msg = "Disposing QuikStreaming with prefixed DDE tables [...]";
			Assembler.PopupException(msg + msig, null, false);
			this.QuikLivesimBatchPublisher.DisconnectAll();
			this.QuikLivesimBatchPublisher.DisposeAll();
			if (this.ddeWasStarted_preLivesim == false) {
				this.QuikStreamingOriginal.UpstreamDisconnect();	// not disposed, QuikStreaming.ddeServerStart() is reusable
			}
			//this.QuikStreamingOriginal.SolidifierSubscribeOneSymbol_iFinishedLivesimming();
			base.SubstituteDistributorForSymbolsLivesimming_restoreOriginalDistributor();

			// YES_I_PROVOKE_NPE__NEED_TO_KNOW_WHERE_SNAPSHOT_IS_USED WILL_POINT_IT_TO_QUIK_REAL_STREAMING_IN_UpstreamConnect_LivesimStarting()
			// NO_LEAVE_IT__SECOND_LIVESIM_RUN_THROWS_NPE_IN_base.InitializeFromDataSource() this.StreamingDataSnapshot = null;

			// ALREADY_AUTO_DISCONNECTED_AFTER_LAST_CLIENT_DISCONNECTED? this.QuikStreamingPuppet.UpstreamDisconnect();
		}

		public override void PushQuoteGenerated(QuoteGenerated quote) {
			//second Livesim gets NPE - fixed but the caveat is when you clicked on "stopping" disabled button, new livesim restarts with lots of NPE...)
			if (base.Livesimulator.RequestingBacktestAbort.WaitOne(0) == true) {
				string msg = "MUST_NEVER_HAPPEN PUSHING_QUOTE_DENERATED_AFTER_LIVESIM_REQUESTED_TO_STOP";
				Assembler.PopupException(msg);
				return;
			}
			if (base.Livesimulator.BacktestAborted.WaitOne(0) == true) {
				string msg = "MUST_NEVER_HAPPEN PUSHING_QUOTE_DENERATED_AFTER_LIVESIM_CONFIRMED_TO_STOP";
				Assembler.PopupException(msg);
				return;
			}


			#region otherwize LivesimulatorForm.PAUSE button doesn't pause livesim (copypaste from LivesimStreaming)
			bool isUnpaused = this.Unpaused.WaitOne(0);
			if (isUnpaused == false) {
				string msg = "QuikLIVESTREAMING_CAUGHT_PAUSE_BUTTON_PRESSED_IN_LIVESIM_CONTROL";
				//Assembler.PopupException(msg, null, false);
				this.Unpaused.WaitOne();	// 1CORE=100% while Livesim Paused


				string msg2 = "QuikLIVESTREAMING_CAUGHT_UNPAUSE_BUTTON_PRESSED_IN_LIVESIM_CONTROL";
				//Assembler.PopupException(msg2, null, false);
			}

			base.Livesimulator.LivesimStreamingIsSleepingNow_ReportersAndExecutionHaveTimeToRebuild = true;
			base.LivesimStreamingSpoiler.Spoil_priorTo_PushQuoteGenerated();

			if (quote.IamInjectedToFillPendingAlerts) {
				string msg = "PROOF_THAT_IM_SERVING_ALL_QUOTES__REGULAR_AND_INJECTED";
			}
			#endregion

			//LivesimStreaming.cs does {base.PushQuoteGenerated(quote);} here

			if (this.QuikLivesimBatchPublisher == null) {
				string msg = "AVOIDING_NPE QuikLivesimBatchPublisher_WANST_CREATED_NORMALLY_IN_UpstreamConnect_LivesimStarting()";
				Assembler.PopupException(msg);
				//DONT_EVEN_WANNA_TRY_DEALOCK base.Livesimulator.AbortRunningBacktestWaitAborted();
				base.Livesimulator.RequestingBacktestAbort.Set();
			}

			
			// FUNDAMENTAL: QuikStreamingLivesim doesn't use base.DataDitstributor AT ALL; I push to the DDE and I expect the QuikStreaming to:
			// 1. extract only chart subscribed to bars and quotes for the Symbol-livesimming
			// 2. assign this new DataDistributor to QuikStreamingOriginal; restore old DataDistributor+Streaming at the Livesim end/abort
			// 3. other charts open for the livesimming Symbol (same or different timeframes) won't receive anything
			// 4. solidifiers for original datasource timeframe won't receive anything

			string msg1 = "I_PREFER_TO_PUSH_LEVEL2_NOW__BEFORE_base.PushQuoteGenerated(quote)";
			//v3 REDIRECTING_PushQuoteGenerated_RADICAL_PARENT_DETACHED base.Level2generator.GenerateAndStoreInStreamingSnap(quote);
			base.Level2generator.GenerateForQuote(quote);
			this.QuikLivesimBatchPublisher.SendLevelTwo_DdeClientPokesDdeServer_waitServerProcessed(base.Level2generator.LevelTwoAsks, base.Level2generator.LevelTwoBids);
			this.QuikLivesimBatchPublisher.SendQuote_DdeClientPokesDdeServer_waitServerProcessed(quote);

			#region otherwize injectQuotesToFillPendings doesn't get invoked (copypaste from LivesimStreaming)
			AlertList notYetScheduled = base.LivesimBrokerSnap.AlertsNotYetScheduledForDelayedFillBy(quote);
			if (notYetScheduled.Count > 0) {
				if (quote.ParentBarStreaming != null) {
					string msg = "I_MUST_HAVE_IT_UNATTACHED_HERE";
					//Assembler.PopupException(msg);
				}
				base.LivesimBroker.ConsumeQuoteOfStreamingBarToFillPending(quote, notYetScheduled);
			} else {
				string msg = "NO_NEED_TO_PING_BROKER_EACH_NEW_QUOTE__EVERY_PENDING_ALREADY_SCHEDULED";
			}

			base.LivesimStreamingSpoiler.Spoil_after_PushQuoteGenerated();
			this.Livesimulator.LivesimStreamingIsSleepingNow_ReportersAndExecutionHaveTimeToRebuild = false;
			#endregion
		}

		public override StreamingEditor StreamingEditorInitialize(IDataSourceEditor dataSourceEditor) {
			string msg = "YOU_FORGOT_TO_SET_[SkipInstantiationAt(Startup=true)]_FOR " + this.GetType()
				+ " LIVESIM_STREAMING_ADAPTERS_SHOULD_NOT_HAVE_ANY_EDITORS__SETTINGS_ARE_EDITED_IN_LIVESIM_FORM";
			throw new Exception(msg);
		}
	}
}
