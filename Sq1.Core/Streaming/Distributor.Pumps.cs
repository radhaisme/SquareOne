﻿using System;

namespace Sq1.Core.Streaming {
	public partial class Distributor<STREAMING_CONSUMER_CHILD> {

		internal int TwoLiveRealPumps_Pause_whileSymbolLivesimming(string symbolLivesimming, string reasonForNewDistributor) {
			string msig = " //TwoLiveRealPumps_Pause_whileSymbolLivesimming(" + symbolLivesimming + "," + reasonForNewDistributor + ") DISTRIBUTOR[" + this.ReasonIwasCreated + "]";
			string msg = "I_REFUSE_TO_PAUSE_PUMP ";
			int paused = 0;
			if (this.ChannelsBySymbol.ContainsKey(symbolLivesimming) == false) {
				msg += "CHANNEL_DOESNT_EXIST_FOR_SYMBOL";
				Assembler.PopupException(msg + msig);
				return paused;
			}
			SymbolChannel<STREAMING_CONSUMER_CHILD> channel = this.ChannelsBySymbol[symbolLivesimming];


			if (channel.PumpQuote_nullWhenBacktesting == null) {
				msg += "PUMP_NULL_ONLY_WHEN_BACKTESTING_QUOTE";
				Assembler.PopupException(msg + msig);
				return paused;
			}
			if (channel.PumpQuote_nullWhenBacktesting.Paused) {
				msg += "PUSHING_THREAD_ALREADY_PAUSED_QUOTE";
				Assembler.PopupException(msg + msig);
				return paused;
			}
			channel.PumpQuote_nullWhenBacktesting.PusherPause_waitUntilPaused();
			//channel.QuotePump_nullUnsafe.WaitUntilPaused();
			msg = "PUMP_UNPAUSED_CONFIRMED_QUOTE";
			Assembler.PopupException(msg + msig, null, false);
			paused++;


			if (this is DistributorSolidifier) return paused;

			if (channel.PumpLevelTwo == null) {
				msg += "PUMP_NULL_ONLY_WHEN_BACKTESTING_LEVEL_TWO";
				Assembler.PopupException(msg + msig);
				return paused;
			}
			if (channel.PumpLevelTwo.Paused) {
				msg += "PUSHING_THREAD_ALREADY_PAUSED_LEVEL_TWO";
				Assembler.PopupException(msg + msig);
				return paused;
			}
			channel.PumpLevelTwo.PusherPause_waitUntilPaused();
			//channel.QuotePump_nullUnsafe.WaitUntilPaused();
			msg = "PUMP_UNPAUSED_CONFIRMED_LEVEL_TWO";
			Assembler.PopupException(msg + msig, null, false);
			paused++;


			return paused;
		}
		internal int TwoLiveRealPumps_Unpause_afterSymbolLivesimmed(string symbolLivesimming, string reasonForStoppingReplacedDistributor) {
			string msig = " //TwoLiveRealPumps_Unpause_afterSymbolLivesimmed(" + symbolLivesimming + "," + reasonForStoppingReplacedDistributor + ") DISTRIBUTOR[" + this.ReasonIwasCreated + "]";
			string msg = "I_REFUSE_TO_UNPAUSE_PUMP ";
			int unpaused = 0;
			if (this.ChannelsBySymbol.ContainsKey(symbolLivesimming) == false) {
				msg += "CHANNEL_DOESNT_EXIST_FOR_SYMBOL";
				Assembler.PopupException(msg + msig);
				return unpaused;
			}
			SymbolChannel<STREAMING_CONSUMER_CHILD> channel = this.ChannelsBySymbol[symbolLivesimming];


			if (channel.PumpQuote_nullWhenBacktesting == null) {
				msg += "PUMP_NULL_ONLY_WHEN_BACKTESTING_QUOTE";
				Assembler.PopupException(msg + msig);
				return unpaused;
			}
			if (channel.PumpQuote_nullWhenBacktesting.Paused == false) {
				msg += "PUSHING_THREAD_NOT_PAUSED_QUOTE";
				Assembler.PopupException(msg + msig);
				return unpaused;
			}
			channel.PumpQuote_nullWhenBacktesting.PusherUnpause_waitUntilUnpaused();
			//channel.QuotePump_nullUnsafe.WaitUntilUnpaused();
			msg = "PUMP_UNPAUSED_CONFIRMED_QUOTE";
			Assembler.PopupException(msg + msig, null, false);
			unpaused++;


			if (this is DistributorSolidifier) return unpaused;

			if (channel.PumpLevelTwo == null) {
				msg += "PUMP_NULL_ONLY_WHEN_BACKTESTING_LEVEL_TWO";
				Assembler.PopupException(msg + msig);
				return unpaused;
			}
			if (channel.PumpLevelTwo.Paused == false) {
				msg += "PUSHING_THREAD_NOT_PAUSED_LEVEL_TWO";
				Assembler.PopupException(msg + msig);
				return unpaused;
			}
			channel.PumpLevelTwo.PusherUnpause_waitUntilUnpaused();
			//channel.QuotePump_nullUnsafe.WaitUntilUnpaused();
			msg = "PUMP_UNPAUSED_CONFIRMED_LEVEL_TWO";
			Assembler.PopupException(msg + msig, null, false);
			unpaused++;

			return unpaused;
		}
		internal int TwoLiveRealPumps_Stop_forSymbolLivesimTerminatedAborted(string symbolLivesimming, string reasonForStoppingReplacedDistributor) {
			string msig = " //TwoLiveRealPumps_Stop_forSymbolLivesimTerminatedAborted(" + symbolLivesimming + "," + reasonForStoppingReplacedDistributor + ") DISTRIBUTOR[" + this.ReasonIwasCreated + "]";
			string msg = "I_REFUSE_TO_STOP_PUMP ";
			int stopped = 0;
			if (this.ChannelsBySymbol.ContainsKey(symbolLivesimming) == false) {
				msg += "CHANNEL_DOESNT_EXIST_FOR_SYMBOL";
				msg += " SUBSCRIBE_CHART_TO_BARS_BEFORE_LIVESIMMING__REMOVE_ORANGE";
				Assembler.PopupException(msg + msig);
				return stopped;
			}
			SymbolChannel<STREAMING_CONSUMER_CHILD> channel = this.ChannelsBySymbol[symbolLivesimming];

	
			if (channel.PumpQuote_nullWhenBacktesting == null) {
				msg += "PUMP_NULL_ONLY_WHEN_BACKTESTING_QUOTE";
				Assembler.PopupException(msg + msig);
				return stopped;
			}
			if (channel.PumpQuote_nullWhenBacktesting.IsPushingThreadStarted == false) {
				msg += "PUSHING_THREAD_NOT_STARTED_QUOTE";
				Assembler.PopupException(msg + msig);
				return stopped;
			}
			channel.PumpQuote_nullWhenBacktesting.PushingThread_Stop_waitConfirmed();
			msg = "PUMP_STOPPED_CONFIRMED_QUOTE";
			Assembler.PopupException(msg + msig, null, false);
			stopped++;


			if (this is DistributorSolidifier) return stopped;

			if (channel.PumpLevelTwo == null) {
				msg += "PUMP_NULL_ONLY_WHEN_BACKTESTING_LEVEL_TWO";
				Assembler.PopupException(msg + msig);
				return stopped;
			}
			if (channel.PumpLevelTwo.IsPushingThreadStarted == false) {
				msg += "PUSHING_THREAD_NOT_STARTED_LEVEL_TWO";
				Assembler.PopupException(msg + msig);
				return stopped;
			}
			channel.PumpLevelTwo.PushingThread_Stop_waitConfirmed();
			msg = "PUMP_STOPPED_CONFIRMED_LEVEL_TWO";
			Assembler.PopupException(msg + msig, null, false);
			stopped++;

			return stopped;
		}
		
		internal int TwoPushingPumpsPerSymbol_Pause_forAllSymbol_duringLivesimmingOne(string reasonForNewDistributor) {
			int paused = 0;
			foreach (string symbol in this.ChannelsBySymbol.Keys) {
				paused += this.TwoLiveRealPumps_Pause_whileSymbolLivesimming(symbol, reasonForNewDistributor);
			}
			return paused;
		}

		internal int TwoPushingPumpsPerSymbol_Unpause_forAllSymbol_afterLivesimmingOne(string reasonForNewDistributor) {
			int unpaused = 0;
			foreach (string symbol in this.ChannelsBySymbol.Keys) {
				unpaused += this.TwoLiveRealPumps_Unpause_afterSymbolLivesimmed(symbol, reasonForNewDistributor);
			}
			return unpaused;
		}

	}
}