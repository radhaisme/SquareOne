﻿using System;
using System.Collections.Generic;

using Sq1.Adapters.Quik.Streaming.Dde.XlDde;

namespace Sq1.Adapters.Quik.Streaming.Dde {
	public class DdeTableTrades : XlDdeTable {
		protected override string DdeConsumerClassName { get { return "DdeTableTrades"; } }

		public DdeTableTrades(string topic, QuikStreaming quikStreaming, List<XlColumn> columns) : base(topic, quikStreaming, columns) {}

		protected override void IncomingTableRow_convertToDataStructure(XlRowParsed row) {
			QuikTrade quikTrade			= new QuikTrade(this.DdeConsumerClassName + " Topic[" + base.Topic + "]");

			quikTrade.Symbol			= (string)row["SECCODE"];
			quikTrade.SymbolClass		= (string)row["CLASSCODE"];
			//quikTrade.ServerTime		= new DateTime(rowParsed["TRADEDATE"] + " " + rowParsed["TRADETIME"]);

			quikTrade.Price				= (double)row["PRICE"];
			quikTrade.Quantity			= (double)row["QTY"];

			// HOW IT CAN BE ONLY BUY OR SELL? IT'S BOTH SIMULTANEOUSLY! IT CAN ONLY BE ONE OF THE TWO:
			// 1) it was filled at bid (passive buyer  got filled by active crossmarket seller) or
			// 2) it was filled at ask (passive seller got filled by active crossmarket buyer)
			quikTrade.BoughtTrue_SoldFalse	= (string)row["BUYSELL"] == "Купля" ? true : false;

			// 1) I can have a monitor here;
			// 2) I should check all orders I'm waiting for the fill;
			// 3) the FILL notification should go to QuikBroker, despite we got information about our fill from Dde listened by Streaming
			base.QuikStreaming.TradeDeliveredDdeCallback(quikTrade);
		}
	}
}