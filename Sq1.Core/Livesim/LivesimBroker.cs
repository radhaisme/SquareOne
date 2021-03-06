﻿using System;
using System.Collections.Generic;
using System.Drawing;

using Newtonsoft.Json;

using Sq1.Core.Accounting;
using Sq1.Core.Broker;
using Sq1.Core.Execution;
using Sq1.Core.StrategyBase;
using Sq1.Core.DataTypes;
using Sq1.Core.DataFeed;
using Sq1.Core.Support;

namespace Sq1.Core.Livesim {
	// I_WANT_LIVESIM_STREAMING_BROKER_BE_AUTOASSIGNED_AND_VISIBLE_IN_DATASOURCE_EDITOR [SkipInstantiationAt(Startup = true)]
	[SkipInstantiationAt(Startup = true)]
	public abstract partial class LivesimBroker : BrokerAdapter, IDisposable {
		[JsonIgnore]	public		ScriptExecutor				ScriptExecutor							{ get; private set; }
		[JsonIgnore]	public		LivesimMarketsim			LivesimMarketsim						{ get; protected set; }

		[JsonIgnore]	public		List<Order>					OrdersSubmitted_forOneLivesimBacktest	{ get; private set; }
		[JsonIgnore]	protected	LivesimDataSource			LivesimDataSource						{ get { return base.DataSource as LivesimDataSource; } }
		[JsonIgnore]	public		LivesimBrokerSettings		LivesimBrokerSettings					{ get { return this.ScriptExecutor.Strategy.LivesimBrokerSettings; } }
		[JsonIgnore]	public		LivesimBrokerDataSnapshot	DataSnapshot;
		[JsonIgnore]	public		LivesimBrokerSpoiler		LivesimBrokerSpoiler					{ get; protected set; }

		[JsonIgnore]	public		override bool				EmittingCapable							{ get { return true; } }
		[JsonIgnore]				object						threadEntryLockToHaveQuoteSentToThread;

		public LivesimBroker(string reasonToExist) : base(reasonToExist) {
			base.Name									= "LivesimBroker";
			this.LivesimMarketsim						= new LivesimMarketsim(this);
			base.AccountAutoPropagate					= new Account("LIVESIM_ACCOUNT", -1000);
			base.AccountAutoPropagate.Initialize(this);
			this.OrdersSubmitted_forOneLivesimBacktest	= new List<Order>();
			this.LivesimBrokerSpoiler					= new LivesimBrokerSpoiler(this);
			this.threadEntryLockToHaveQuoteSentToThread	= new object();
		}
		public virtual void InitializeLivesim(LivesimDataSource livesimDataSource, OrderProcessor orderProcessor) {
			base.DataSource		= livesimDataSource;
			this.DataSnapshot	= new LivesimBrokerDataSnapshot(this.LivesimDataSource);
			//v1 base.InitializeDataSource_inverse(livesimDataSource, this.LivesimDataSource.StreamingAsLivesim_nullUnsafe,  orderProcessor);
			//v3
			if (this.LivesimDataSource.StreamingAsLivesim_nullUnsafe == null) {
				if (this.LivesimDataSource.StreamingAdapter == null) {
					string msg1 = "I_REFUSE_TO_INITIALIZE_BROKER_WITH_NULL_STREAMING";
					Assembler.PopupException(msg1, null, true);
					return;
				}
				if (this.LivesimDataSource.StreamingAdapter is LivesimBroker) {
					string msg1 = "I_REFUSE_TO_INITIALIZE_BROKER_MUST_BE_BROKER_ORIGINAL_HERE";
					Assembler.PopupException(msg1, null, true);
					return;
				}
				string msg = "LIVESIM_BROKER_ALREADY_REFERRING_TO_STREAMING_ORIGINAL_DDE THATS_WHAT_I_WANTED";
				Assembler.PopupException(msg, null, false);
				base.InitializeDataSource_inverse(this.LivesimDataSource, this.LivesimDataSource.StreamingAdapter, orderProcessor);
				orderProcessor.DataSnapshot.Clear_onLivesimStart__TODO_saveAndRestoreIfLivesimLaunchedDuringLive();
				return;
			}
			//v2
			if (this.LivesimDataSource.StreamingAsLivesim_nullUnsafe.StreamingOriginal != null) {
				base.InitializeDataSource_inverse(this.LivesimDataSource, this.LivesimDataSource.StreamingAsLivesim_nullUnsafe.StreamingOriginal, orderProcessor);
			} else {
				base.InitializeDataSource_inverse(this.LivesimDataSource, this.LivesimDataSource.StreamingAsLivesim_nullUnsafe, orderProcessor);
			}
			// mirroring 10 lines above; but when does it run?...
			orderProcessor.DataSnapshot.Clear_onLivesimStart__TODO_saveAndRestoreIfLivesimLaunchedDuringLive();
		}
		internal void InitializeMarketsim(ScriptExecutor scriptExecutor) {
			this.ScriptExecutor = scriptExecutor;
			this.LivesimMarketsim.Initialize(this.ScriptExecutor);
		}
		public override BrokerEditor BrokerEditorInitialize(IDataSourceEditor dataSourceEditor) {
			LivesimBrokerEditorEmpty emptyEditor = new LivesimBrokerEditorEmpty();
			emptyEditor.Initialize(this, dataSourceEditor);
			this.BrokerEditorInstance = emptyEditor;
			return emptyEditor;
		}

		public override void Dispose() {
			if (base.IsDisposed) {
				string msg = "ALREADY_DISPOSED__DONT_INVOKE_ME_TWICE  " + this.ToString();
				Assembler.PopupException(msg);
				return;
			}
			if (this.LivesimDataSource != null) {
				if (this.LivesimDataSource.IsDisposed == false) {
					this.LivesimDataSource.Dispose();
				} else {
					string msg = "ITS_OKAY this.livesimDataSource might have been already disposed by LivesimStreaming.Dispose()";
				}
			} else {
				string msg = "WEIRD_LivesimDataSource=NULL " + this.ToString();
				Assembler.PopupException(msg);
			}
			if (this.DataSnapshot != null) { 
				if (this.DataSnapshot.IsDisposed == false) {
					this.DataSnapshot.Dispose();
				}
			} else {
				string msg = "ARE_YOU_SWITCHING_WORKSPACES? LivesimBroker.DataSnapshot=NULL HERE";
				Assembler.PopupException(msg);
			}
			base.DataSource		= null;
			this.DataSnapshot	= null;
			base.IsDisposed		= true;
		}

		public override void Broker_connect(string reasonToConnect = "") {
			string msig = " //Broker_connect(" + this.ToString() + ")";
			string msg = "LIVESIM_CHILDREN_SHOULD_NEVER_RECEIVE_UpstreamConnect()";
			//Assembler.PopupException(msg + msig, null, false);
			string why = "I simulate Terminal_Connected on first order, and each next spoiledDisconnect(); but LivesimDataSource.json doesnt exist";
			base.ConnectionState_update(ConnectionState.Broker_TerminalConnected_22, reasonToConnect + msig);
		}
		public override void Broker_disconnect(string reasonForDisconnect = "UNKNONWN_reasonForDisconnect") {
			string msig = " //Broker_disconnect(" + this.ToString() + ")";
			string msg = "LIVESIM_CHILDREN_WILL_RECEIVE_UpstreamDisonnect()_FROM_SPOILERS__OVERRIDDEN_WILL_TUNNEL_TO_QUIK_ORIGINAL";
			//Assembler.PopupException(msg + msig, null, false);
			base.ConnectionState_update(ConnectionState.Broker_TerminalDisconnected, reasonForDisconnect + msig);
		}
		

		public override Color GetBackGroundColor_forOrderStateMessage_nullUnsafe(OrderStateMessage osm) {
			Color ret = Color.Empty;
			if (osm.Message.Contains(TESTING_BY_OWN_LIVESIM)) {
				ret = Assembler.InstanceInitialized.ColorBackgroundRed_forPositionLoss;
			}
			return ret;
		}

	}
}