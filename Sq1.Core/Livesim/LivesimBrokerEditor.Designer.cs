﻿using System;
using System.Drawing;
using System.ComponentModel;
using System.ComponentModel.Design;

using Sq1.Core.Broker;

namespace Sq1.Core.Livesim {
	[ToolboxBitmap(typeof(LivesimBrokerEditor), "BrokerLivesimEditor")]
	[Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
	public partial class LivesimBrokerEditor : BrokerEditor {
		#region Component Designer generated code
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txt_PartialFillPercentageFilledMax;
		private System.Windows.Forms.TextBox txt_PartialFillPercentageFilledMin;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.CheckBox cbx_PartialFillEnabled;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txt_PartialFillHappensOncePerQuoteMax;
		private System.Windows.Forms.TextBox txt_PartialFillHappensOncePerQuoteMin;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txt_OutOfOrderFillDeliveredXordersLaterMax;
		private System.Windows.Forms.TextBox txt_OutOfOrderFillDeliveredXordersLaterMin;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox cbx_OutOfOrderFillEnabled;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txt_OutOfOrderFillHappensOncePerQuoteMax;
		private System.Windows.Forms.TextBox txt_OutOfOrderFillHappensOncePerQuoteMin;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox grp_orderRejectionRate;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.CheckBox cbx_OrderRejectionEnabled;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txt_OrderRejectionHappensOncePerXordersMax;
		private System.Windows.Forms.TextBox txt_OrderRejectionHappensOncePerXordersMin;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox txt_PriceDeviationForMarketOrdersPercentageOfBestPriceMax;
		private System.Windows.Forms.TextBox txt_PriceDeviationForMarketOrdersPercentageOfBestPriceMin;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.CheckBox cbx_PriceDeviationForMarketOrdersEnabled;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox txt_PriceDeviationForMarketOrdersHappensOncePerXordersMax;
		private System.Windows.Forms.TextBox txt_PriceDeviationForMarketOrdersHappensOncePerXordersMin;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.GroupBox grp_BrokerAdapterDisconnect;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox txt_AdaperDisconnectReconnectsAfterMillisMax;
		private System.Windows.Forms.TextBox txt_AdaperDisconnectReconnectsAfterMillisMin;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.CheckBox cbx_AdaperDisconnectEnabled;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.TextBox txt_AdaperDisconnectHappensOncePerQuoteMax;
		private System.Windows.Forms.TextBox txt_AdaperDisconnectHappensOncePerQuoteMin;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.GroupBox gbx_DelayBeforeFill;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.CheckBox cbx_DelayBeforeFillEnabled;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.TextBox txt_DelayBeforeFillMillisMax;
		private System.Windows.Forms.TextBox txt_DelayBeforeFillMillisMin;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.GroupBox grp_KillPendingDelay;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.CheckBox cbx_KillPendingDelayEnabled;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.TextBox txt_KillPendingDelay_max;
		private System.Windows.Forms.TextBox txt_KillPendingDelay_min;
		private System.Windows.Forms.Label lbl_KillPendingDelay;
		private void InitializeComponent() {
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txt_PartialFillPercentageFilledMax = new System.Windows.Forms.TextBox();
			this.txt_PartialFillPercentageFilledMin = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.cbx_PartialFillEnabled = new System.Windows.Forms.CheckBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txt_PartialFillHappensOncePerQuoteMax = new System.Windows.Forms.TextBox();
			this.txt_PartialFillHappensOncePerQuoteMin = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.grp_orderRejectionRate = new System.Windows.Forms.GroupBox();
			this.label13 = new System.Windows.Forms.Label();
			this.cbx_OrderRejectionEnabled = new System.Windows.Forms.CheckBox();
			this.label14 = new System.Windows.Forms.Label();
			this.txt_OrderRejectionHappensOncePerXordersMax = new System.Windows.Forms.TextBox();
			this.txt_OrderRejectionHappensOncePerXordersMin = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.txt_PriceDeviationForMarketOrdersPercentageOfBestPriceMax = new System.Windows.Forms.TextBox();
			this.txt_PriceDeviationForMarketOrdersPercentageOfBestPriceMin = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.cbx_PriceDeviationForMarketOrdersEnabled = new System.Windows.Forms.CheckBox();
			this.label20 = new System.Windows.Forms.Label();
			this.txt_PriceDeviationForMarketOrdersHappensOncePerXordersMax = new System.Windows.Forms.TextBox();
			this.txt_PriceDeviationForMarketOrdersHappensOncePerXordersMin = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.grp_BrokerAdapterDisconnect = new System.Windows.Forms.GroupBox();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.txt_AdaperDisconnectReconnectsAfterMillisMax = new System.Windows.Forms.TextBox();
			this.txt_AdaperDisconnectReconnectsAfterMillisMin = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.cbx_AdaperDisconnectEnabled = new System.Windows.Forms.CheckBox();
			this.label26 = new System.Windows.Forms.Label();
			this.txt_AdaperDisconnectHappensOncePerQuoteMax = new System.Windows.Forms.TextBox();
			this.txt_AdaperDisconnectHappensOncePerQuoteMin = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txt_OutOfOrderFillDeliveredXordersLaterMax = new System.Windows.Forms.TextBox();
			this.txt_OutOfOrderFillDeliveredXordersLaterMin = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.cbx_OutOfOrderFillEnabled = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txt_OutOfOrderFillHappensOncePerQuoteMax = new System.Windows.Forms.TextBox();
			this.txt_OutOfOrderFillHappensOncePerQuoteMin = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.gbx_DelayBeforeFill = new System.Windows.Forms.GroupBox();
			this.label28 = new System.Windows.Forms.Label();
			this.cbx_DelayBeforeFillEnabled = new System.Windows.Forms.CheckBox();
			this.label29 = new System.Windows.Forms.Label();
			this.txt_DelayBeforeFillMillisMax = new System.Windows.Forms.TextBox();
			this.txt_DelayBeforeFillMillisMin = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.grp_KillPendingDelay = new System.Windows.Forms.GroupBox();
			this.label31 = new System.Windows.Forms.Label();
			this.cbx_KillPendingDelayEnabled = new System.Windows.Forms.CheckBox();
			this.label32 = new System.Windows.Forms.Label();
			this.txt_KillPendingDelay_max = new System.Windows.Forms.TextBox();
			this.txt_KillPendingDelay_min = new System.Windows.Forms.TextBox();
			this.lbl_KillPendingDelay = new System.Windows.Forms.Label();
			this.gbx_TransactionStatusAfterOrderStatus = new System.Windows.Forms.GroupBox();
			this.label33 = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.txt_TransactionStatusAfterOrderStatusDelayAfterFillMax = new System.Windows.Forms.TextBox();
			this.txt_TransactionStatusAfterOrderStatusDelayAfterFillMin = new System.Windows.Forms.TextBox();
			this.label35 = new System.Windows.Forms.Label();
			this.label36 = new System.Windows.Forms.Label();
			this.cbx_TransactionStatusAfterOrderStatusEnabled = new System.Windows.Forms.CheckBox();
			this.label37 = new System.Windows.Forms.Label();
			this.txt_TransactionStatusAfterOrderStatusHappensOncePerOrdersMax = new System.Windows.Forms.TextBox();
			this.txt_TransactionStatusAfterOrderStatusHappensOncePerOrdersMin = new System.Windows.Forms.TextBox();
			this.label38 = new System.Windows.Forms.Label();
			this.gbx_KillerTransactionCallbackAfterVictimFilled = new System.Windows.Forms.GroupBox();
			this.label39 = new System.Windows.Forms.Label();
			this.label40 = new System.Windows.Forms.Label();
			this.txt_KillerTransactionCallbackAfterVictimFilled_delayMax = new System.Windows.Forms.TextBox();
			this.txt_KillerTransactionCallbackAfterVictimFilled_delayMin = new System.Windows.Forms.TextBox();
			this.label41 = new System.Windows.Forms.Label();
			this.label42 = new System.Windows.Forms.Label();
			this.cbx_KillerTransactionCallbackAfterVictimFilled_enabled = new System.Windows.Forms.CheckBox();
			this.label43 = new System.Windows.Forms.Label();
			this.txt_KillerTransactionCallbackAfterVictimFilled_happensMax = new System.Windows.Forms.TextBox();
			this.txt_KillerTransactionCallbackAfterVictimFilled_happensMin = new System.Windows.Forms.TextBox();
			this.label44 = new System.Windows.Forms.Label();
			this.groupBox2.SuspendLayout();
			this.grp_orderRejectionRate.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.grp_BrokerAdapterDisconnect.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.gbx_DelayBeforeFill.SuspendLayout();
			this.grp_KillPendingDelay.SuspendLayout();
			this.gbx_TransactionStatusAfterOrderStatus.SuspendLayout();
			this.gbx_KillerTransactionCallbackAfterVictimFilled.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.txt_PartialFillPercentageFilledMax);
			this.groupBox2.Controls.Add(this.txt_PartialFillPercentageFilledMin);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.cbx_PartialFillEnabled);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.txt_PartialFillHappensOncePerQuoteMax);
			this.groupBox2.Controls.Add(this.txt_PartialFillHappensOncePerQuoteMin);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Enabled = false;
			this.groupBox2.Location = new System.Drawing.Point(3, 379);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(356, 90);
			this.groupBox2.TabIndex = 28;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Partial Fills";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 17);
			this.label1.TabIndex = 28;
			this.label1.Text = "Happens once per";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(165, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 15);
			this.label2.TabIndex = 27;
			this.label2.Text = "to";
			// 
			// txt_PartialFillPercentageFilledMax
			// 
			this.txt_PartialFillPercentageFilledMax.Location = new System.Drawing.Point(183, 45);
			this.txt_PartialFillPercentageFilledMax.Name = "txt_PartialFillPercentageFilledMax";
			this.txt_PartialFillPercentageFilledMax.Size = new System.Drawing.Size(33, 20);
			this.txt_PartialFillPercentageFilledMax.TabIndex = 39;
			this.txt_PartialFillPercentageFilledMax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// txt_PartialFillPercentageFilledMin
			// 
			this.txt_PartialFillPercentageFilledMin.Location = new System.Drawing.Point(129, 45);
			this.txt_PartialFillPercentageFilledMin.Name = "txt_PartialFillPercentageFilledMin";
			this.txt_PartialFillPercentageFilledMin.Size = new System.Drawing.Size(30, 20);
			this.txt_PartialFillPercentageFilledMin.TabIndex = 38;
			this.txt_PartialFillPercentageFilledMin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(222, 46);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(93, 17);
			this.label9.TabIndex = 26;
			this.label9.Text = "% order size";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(6, 48);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(107, 17);
			this.label10.TabIndex = 23;
			this.label10.Text = "How much gets filled";
			// 
			// cbx_PartialFillEnabled
			// 
			this.cbx_PartialFillEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cbx_PartialFillEnabled.Checked = true;
			this.cbx_PartialFillEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbx_PartialFillEnabled.Location = new System.Drawing.Point(6, 68);
			this.cbx_PartialFillEnabled.Name = "cbx_PartialFillEnabled";
			this.cbx_PartialFillEnabled.Size = new System.Drawing.Size(344, 17);
			this.cbx_PartialFillEnabled.TabIndex = 40;
			this.cbx_PartialFillEnabled.Text = "Enable Random Partial Fills";
			this.cbx_PartialFillEnabled.UseVisualStyleBackColor = true;
			this.cbx_PartialFillEnabled.CheckedChanged += new System.EventHandler(this.anyCheckBox_CheckedChanged);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(165, 22);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(16, 15);
			this.label11.TabIndex = 22;
			this.label11.Text = "to";
			// 
			// txt_PartialFillHappensOncePerQuoteMax
			// 
			this.txt_PartialFillHappensOncePerQuoteMax.Location = new System.Drawing.Point(183, 19);
			this.txt_PartialFillHappensOncePerQuoteMax.Name = "txt_PartialFillHappensOncePerQuoteMax";
			this.txt_PartialFillHappensOncePerQuoteMax.Size = new System.Drawing.Size(33, 20);
			this.txt_PartialFillHappensOncePerQuoteMax.TabIndex = 37;
			this.txt_PartialFillHappensOncePerQuoteMax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// txt_PartialFillHappensOncePerQuoteMin
			// 
			this.txt_PartialFillHappensOncePerQuoteMin.Location = new System.Drawing.Point(129, 19);
			this.txt_PartialFillHappensOncePerQuoteMin.Name = "txt_PartialFillHappensOncePerQuoteMin";
			this.txt_PartialFillHappensOncePerQuoteMin.Size = new System.Drawing.Size(30, 20);
			this.txt_PartialFillHappensOncePerQuoteMin.TabIndex = 36;
			this.txt_PartialFillHappensOncePerQuoteMin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(222, 20);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(93, 17);
			this.label12.TabIndex = 20;
			this.label12.Text = "orders processed";
			// 
			// grp_orderRejectionRate
			// 
			this.grp_orderRejectionRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grp_orderRejectionRate.Controls.Add(this.label13);
			this.grp_orderRejectionRate.Controls.Add(this.cbx_OrderRejectionEnabled);
			this.grp_orderRejectionRate.Controls.Add(this.label14);
			this.grp_orderRejectionRate.Controls.Add(this.txt_OrderRejectionHappensOncePerXordersMax);
			this.grp_orderRejectionRate.Controls.Add(this.txt_OrderRejectionHappensOncePerXordersMin);
			this.grp_orderRejectionRate.Controls.Add(this.label15);
			this.grp_orderRejectionRate.Location = new System.Drawing.Point(3, 131);
			this.grp_orderRejectionRate.Name = "grp_orderRejectionRate";
			this.grp_orderRejectionRate.Size = new System.Drawing.Size(356, 64);
			this.grp_orderRejectionRate.TabIndex = 30;
			this.grp_orderRejectionRate.TabStop = false;
			this.grp_orderRejectionRate.Text = "Order Rejection Rate";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(6, 20);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(107, 17);
			this.label13.TabIndex = 34;
			this.label13.Text = "Happens once per";
			// 
			// cbx_OrderRejectionEnabled
			// 
			this.cbx_OrderRejectionEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cbx_OrderRejectionEnabled.Checked = true;
			this.cbx_OrderRejectionEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbx_OrderRejectionEnabled.Location = new System.Drawing.Point(6, 40);
			this.cbx_OrderRejectionEnabled.Name = "cbx_OrderRejectionEnabled";
			this.cbx_OrderRejectionEnabled.Size = new System.Drawing.Size(344, 17);
			this.cbx_OrderRejectionEnabled.TabIndex = 35;
			this.cbx_OrderRejectionEnabled.Text = "Enable Random Order Rejection";
			this.cbx_OrderRejectionEnabled.UseVisualStyleBackColor = true;
			this.cbx_OrderRejectionEnabled.CheckedChanged += new System.EventHandler(this.anyCheckBox_CheckedChanged);
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(165, 20);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(16, 15);
			this.label14.TabIndex = 33;
			this.label14.Text = "to";
			// 
			// txt_OrderRejectionHappensOncePerXordersMax
			// 
			this.txt_OrderRejectionHappensOncePerXordersMax.Location = new System.Drawing.Point(183, 17);
			this.txt_OrderRejectionHappensOncePerXordersMax.Name = "txt_OrderRejectionHappensOncePerXordersMax";
			this.txt_OrderRejectionHappensOncePerXordersMax.Size = new System.Drawing.Size(33, 20);
			this.txt_OrderRejectionHappensOncePerXordersMax.TabIndex = 34;
			this.txt_OrderRejectionHappensOncePerXordersMax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// txt_OrderRejectionHappensOncePerXordersMin
			// 
			this.txt_OrderRejectionHappensOncePerXordersMin.Location = new System.Drawing.Point(129, 17);
			this.txt_OrderRejectionHappensOncePerXordersMin.Name = "txt_OrderRejectionHappensOncePerXordersMin";
			this.txt_OrderRejectionHappensOncePerXordersMin.Size = new System.Drawing.Size(30, 20);
			this.txt_OrderRejectionHappensOncePerXordersMin.TabIndex = 33;
			this.txt_OrderRejectionHappensOncePerXordersMin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(222, 20);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(89, 17);
			this.label15.TabIndex = 31;
			this.label15.Text = "orders processed";
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.label16);
			this.groupBox4.Controls.Add(this.label17);
			this.groupBox4.Controls.Add(this.txt_PriceDeviationForMarketOrdersPercentageOfBestPriceMax);
			this.groupBox4.Controls.Add(this.txt_PriceDeviationForMarketOrdersPercentageOfBestPriceMin);
			this.groupBox4.Controls.Add(this.label18);
			this.groupBox4.Controls.Add(this.label19);
			this.groupBox4.Controls.Add(this.cbx_PriceDeviationForMarketOrdersEnabled);
			this.groupBox4.Controls.Add(this.label20);
			this.groupBox4.Controls.Add(this.txt_PriceDeviationForMarketOrdersHappensOncePerXordersMax);
			this.groupBox4.Controls.Add(this.txt_PriceDeviationForMarketOrdersHappensOncePerXordersMin);
			this.groupBox4.Controls.Add(this.label21);
			this.groupBox4.Enabled = false;
			this.groupBox4.Location = new System.Drawing.Point(3, 560);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(356, 91);
			this.groupBox4.TabIndex = 29;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Market Order Fill Price <=> Best Bid/Ask Deviation";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(6, 22);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(107, 17);
			this.label16.TabIndex = 28;
			this.label16.Text = "Happens once per";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(165, 48);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(16, 15);
			this.label17.TabIndex = 27;
			this.label17.Text = "to";
			// 
			// txt_PriceDeviationForMarketOrdersPercentageOfBestPriceMax
			// 
			this.txt_PriceDeviationForMarketOrdersPercentageOfBestPriceMax.Location = new System.Drawing.Point(183, 45);
			this.txt_PriceDeviationForMarketOrdersPercentageOfBestPriceMax.Name = "txt_PriceDeviationForMarketOrdersPercentageOfBestPriceMax";
			this.txt_PriceDeviationForMarketOrdersPercentageOfBestPriceMax.Size = new System.Drawing.Size(33, 20);
			this.txt_PriceDeviationForMarketOrdersPercentageOfBestPriceMax.TabIndex = 49;
			this.txt_PriceDeviationForMarketOrdersPercentageOfBestPriceMax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// txt_PriceDeviationForMarketOrdersPercentageOfBestPriceMin
			// 
			this.txt_PriceDeviationForMarketOrdersPercentageOfBestPriceMin.Location = new System.Drawing.Point(129, 45);
			this.txt_PriceDeviationForMarketOrdersPercentageOfBestPriceMin.Name = "txt_PriceDeviationForMarketOrdersPercentageOfBestPriceMin";
			this.txt_PriceDeviationForMarketOrdersPercentageOfBestPriceMin.Size = new System.Drawing.Size(30, 20);
			this.txt_PriceDeviationForMarketOrdersPercentageOfBestPriceMin.TabIndex = 48;
			this.txt_PriceDeviationForMarketOrdersPercentageOfBestPriceMin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(222, 48);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(93, 17);
			this.label18.TabIndex = 26;
			this.label18.Text = "% best price";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(6, 48);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(107, 17);
			this.label19.TabIndex = 23;
			this.label19.Text = "Price Deviation +/-";
			// 
			// cbx_PriceDeviationForMarketOrdersEnabled
			// 
			this.cbx_PriceDeviationForMarketOrdersEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cbx_PriceDeviationForMarketOrdersEnabled.Checked = true;
			this.cbx_PriceDeviationForMarketOrdersEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbx_PriceDeviationForMarketOrdersEnabled.Location = new System.Drawing.Point(6, 70);
			this.cbx_PriceDeviationForMarketOrdersEnabled.Name = "cbx_PriceDeviationForMarketOrdersEnabled";
			this.cbx_PriceDeviationForMarketOrdersEnabled.Size = new System.Drawing.Size(344, 17);
			this.cbx_PriceDeviationForMarketOrdersEnabled.TabIndex = 50;
			this.cbx_PriceDeviationForMarketOrdersEnabled.Text = "Enable Random Market Order Fill Price <=> Best Bid/Ask Deviation";
			this.cbx_PriceDeviationForMarketOrdersEnabled.UseVisualStyleBackColor = true;
			this.cbx_PriceDeviationForMarketOrdersEnabled.CheckedChanged += new System.EventHandler(this.anyCheckBox_CheckedChanged);
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(165, 22);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(16, 15);
			this.label20.TabIndex = 22;
			this.label20.Text = "to";
			// 
			// txt_PriceDeviationForMarketOrdersHappensOncePerXordersMax
			// 
			this.txt_PriceDeviationForMarketOrdersHappensOncePerXordersMax.Location = new System.Drawing.Point(183, 19);
			this.txt_PriceDeviationForMarketOrdersHappensOncePerXordersMax.Name = "txt_PriceDeviationForMarketOrdersHappensOncePerXordersMax";
			this.txt_PriceDeviationForMarketOrdersHappensOncePerXordersMax.Size = new System.Drawing.Size(33, 20);
			this.txt_PriceDeviationForMarketOrdersHappensOncePerXordersMax.TabIndex = 47;
			this.txt_PriceDeviationForMarketOrdersHappensOncePerXordersMax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// txt_PriceDeviationForMarketOrdersHappensOncePerXordersMin
			// 
			this.txt_PriceDeviationForMarketOrdersHappensOncePerXordersMin.Location = new System.Drawing.Point(129, 19);
			this.txt_PriceDeviationForMarketOrdersHappensOncePerXordersMin.Name = "txt_PriceDeviationForMarketOrdersHappensOncePerXordersMin";
			this.txt_PriceDeviationForMarketOrdersHappensOncePerXordersMin.Size = new System.Drawing.Size(30, 20);
			this.txt_PriceDeviationForMarketOrdersHappensOncePerXordersMin.TabIndex = 46;
			this.txt_PriceDeviationForMarketOrdersHappensOncePerXordersMin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(222, 22);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(93, 17);
			this.label21.TabIndex = 20;
			this.label21.Text = "market orders";
			// 
			// grp_BrokerAdapterDisconnect
			// 
			this.grp_BrokerAdapterDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grp_BrokerAdapterDisconnect.Controls.Add(this.label22);
			this.grp_BrokerAdapterDisconnect.Controls.Add(this.label23);
			this.grp_BrokerAdapterDisconnect.Controls.Add(this.txt_AdaperDisconnectReconnectsAfterMillisMax);
			this.grp_BrokerAdapterDisconnect.Controls.Add(this.txt_AdaperDisconnectReconnectsAfterMillisMin);
			this.grp_BrokerAdapterDisconnect.Controls.Add(this.label24);
			this.grp_BrokerAdapterDisconnect.Controls.Add(this.label25);
			this.grp_BrokerAdapterDisconnect.Controls.Add(this.cbx_AdaperDisconnectEnabled);
			this.grp_BrokerAdapterDisconnect.Controls.Add(this.label26);
			this.grp_BrokerAdapterDisconnect.Controls.Add(this.txt_AdaperDisconnectHappensOncePerQuoteMax);
			this.grp_BrokerAdapterDisconnect.Controls.Add(this.txt_AdaperDisconnectHappensOncePerQuoteMin);
			this.grp_BrokerAdapterDisconnect.Controls.Add(this.label27);
			this.grp_BrokerAdapterDisconnect.Enabled = false;
			this.grp_BrokerAdapterDisconnect.Location = new System.Drawing.Point(3, 651);
			this.grp_BrokerAdapterDisconnect.Name = "grp_BrokerAdapterDisconnect";
			this.grp_BrokerAdapterDisconnect.Size = new System.Drawing.Size(356, 94);
			this.grp_BrokerAdapterDisconnect.TabIndex = 31;
			this.grp_BrokerAdapterDisconnect.TabStop = false;
			this.grp_BrokerAdapterDisconnect.Text = "Broker Adapter Disconnect";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(6, 22);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(107, 17);
			this.label22.TabIndex = 28;
			this.label22.Text = "Happens once per";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(165, 48);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(16, 15);
			this.label23.TabIndex = 27;
			this.label23.Text = "to";
			// 
			// txt_AdaperDisconnectReconnectsAfterMillisMax
			// 
			this.txt_AdaperDisconnectReconnectsAfterMillisMax.Location = new System.Drawing.Point(183, 45);
			this.txt_AdaperDisconnectReconnectsAfterMillisMax.Name = "txt_AdaperDisconnectReconnectsAfterMillisMax";
			this.txt_AdaperDisconnectReconnectsAfterMillisMax.Size = new System.Drawing.Size(33, 20);
			this.txt_AdaperDisconnectReconnectsAfterMillisMax.TabIndex = 54;
			this.txt_AdaperDisconnectReconnectsAfterMillisMax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// txt_AdaperDisconnectReconnectsAfterMillisMin
			// 
			this.txt_AdaperDisconnectReconnectsAfterMillisMin.Location = new System.Drawing.Point(129, 45);
			this.txt_AdaperDisconnectReconnectsAfterMillisMin.Name = "txt_AdaperDisconnectReconnectsAfterMillisMin";
			this.txt_AdaperDisconnectReconnectsAfterMillisMin.Size = new System.Drawing.Size(30, 20);
			this.txt_AdaperDisconnectReconnectsAfterMillisMin.TabIndex = 53;
			this.txt_AdaperDisconnectReconnectsAfterMillisMin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(222, 48);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(93, 17);
			this.label24.TabIndex = 26;
			this.label24.Text = "milliSeconds";
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(6, 48);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(107, 17);
			this.label25.TabIndex = 23;
			this.label25.Text = "ReConnect after";
			// 
			// cbx_AdaperDisconnectEnabled
			// 
			this.cbx_AdaperDisconnectEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cbx_AdaperDisconnectEnabled.Checked = true;
			this.cbx_AdaperDisconnectEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbx_AdaperDisconnectEnabled.Location = new System.Drawing.Point(6, 70);
			this.cbx_AdaperDisconnectEnabled.Name = "cbx_AdaperDisconnectEnabled";
			this.cbx_AdaperDisconnectEnabled.Size = new System.Drawing.Size(344, 17);
			this.cbx_AdaperDisconnectEnabled.TabIndex = 55;
			this.cbx_AdaperDisconnectEnabled.Text = "Enable Random Broker Adapter Disconnect";
			this.cbx_AdaperDisconnectEnabled.UseVisualStyleBackColor = true;
			this.cbx_AdaperDisconnectEnabled.CheckedChanged += new System.EventHandler(this.anyCheckBox_CheckedChanged);
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(165, 22);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(16, 15);
			this.label26.TabIndex = 22;
			this.label26.Text = "to";
			// 
			// txt_AdaperDisconnectHappensOncePerQuoteMax
			// 
			this.txt_AdaperDisconnectHappensOncePerQuoteMax.Location = new System.Drawing.Point(183, 19);
			this.txt_AdaperDisconnectHappensOncePerQuoteMax.Name = "txt_AdaperDisconnectHappensOncePerQuoteMax";
			this.txt_AdaperDisconnectHappensOncePerQuoteMax.Size = new System.Drawing.Size(33, 20);
			this.txt_AdaperDisconnectHappensOncePerQuoteMax.TabIndex = 52;
			this.txt_AdaperDisconnectHappensOncePerQuoteMax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// txt_AdaperDisconnectHappensOncePerQuoteMin
			// 
			this.txt_AdaperDisconnectHappensOncePerQuoteMin.Location = new System.Drawing.Point(129, 19);
			this.txt_AdaperDisconnectHappensOncePerQuoteMin.Name = "txt_AdaperDisconnectHappensOncePerQuoteMin";
			this.txt_AdaperDisconnectHappensOncePerQuoteMin.Size = new System.Drawing.Size(30, 20);
			this.txt_AdaperDisconnectHappensOncePerQuoteMin.TabIndex = 51;
			this.txt_AdaperDisconnectHappensOncePerQuoteMin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(222, 22);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(93, 17);
			this.label27.TabIndex = 20;
			this.label27.Text = "quotes generated";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txt_OutOfOrderFillDeliveredXordersLaterMax);
			this.groupBox1.Controls.Add(this.txt_OutOfOrderFillDeliveredXordersLaterMin);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.cbx_OutOfOrderFillEnabled);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.txt_OutOfOrderFillHappensOncePerQuoteMax);
			this.groupBox1.Controls.Add(this.txt_OutOfOrderFillHappensOncePerQuoteMin);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Enabled = false;
			this.groupBox1.Location = new System.Drawing.Point(3, 469);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(356, 91);
			this.groupBox1.TabIndex = 30;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Out-of-order Fill Delivery (Callback Coming After Next Fill)";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(107, 17);
			this.label3.TabIndex = 28;
			this.label3.Text = "Happens once per";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(165, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(16, 15);
			this.label4.TabIndex = 27;
			this.label4.Text = "to";
			// 
			// txt_OutOfOrderFillDeliveredXordersLaterMax
			// 
			this.txt_OutOfOrderFillDeliveredXordersLaterMax.Location = new System.Drawing.Point(183, 45);
			this.txt_OutOfOrderFillDeliveredXordersLaterMax.Name = "txt_OutOfOrderFillDeliveredXordersLaterMax";
			this.txt_OutOfOrderFillDeliveredXordersLaterMax.Size = new System.Drawing.Size(33, 20);
			this.txt_OutOfOrderFillDeliveredXordersLaterMax.TabIndex = 44;
			this.txt_OutOfOrderFillDeliveredXordersLaterMax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// txt_OutOfOrderFillDeliveredXordersLaterMin
			// 
			this.txt_OutOfOrderFillDeliveredXordersLaterMin.Location = new System.Drawing.Point(129, 45);
			this.txt_OutOfOrderFillDeliveredXordersLaterMin.Name = "txt_OutOfOrderFillDeliveredXordersLaterMin";
			this.txt_OutOfOrderFillDeliveredXordersLaterMin.Size = new System.Drawing.Size(30, 20);
			this.txt_OutOfOrderFillDeliveredXordersLaterMin.TabIndex = 43;
			this.txt_OutOfOrderFillDeliveredXordersLaterMin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(222, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(93, 17);
			this.label5.TabIndex = 26;
			this.label5.Text = "orders later";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 48);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(107, 17);
			this.label6.TabIndex = 23;
			this.label6.Text = "Fill Msg Arrives";
			// 
			// cbx_OutOfOrderFillEnabled
			// 
			this.cbx_OutOfOrderFillEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cbx_OutOfOrderFillEnabled.Checked = true;
			this.cbx_OutOfOrderFillEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbx_OutOfOrderFillEnabled.Location = new System.Drawing.Point(6, 68);
			this.cbx_OutOfOrderFillEnabled.Name = "cbx_OutOfOrderFillEnabled";
			this.cbx_OutOfOrderFillEnabled.Size = new System.Drawing.Size(344, 17);
			this.cbx_OutOfOrderFillEnabled.TabIndex = 45;
			this.cbx_OutOfOrderFillEnabled.Text = "Enable Random Out-of-order Fill Delivery";
			this.cbx_OutOfOrderFillEnabled.UseVisualStyleBackColor = true;
			this.cbx_OutOfOrderFillEnabled.CheckedChanged += new System.EventHandler(this.anyCheckBox_CheckedChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(165, 22);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(16, 15);
			this.label7.TabIndex = 22;
			this.label7.Text = "to";
			// 
			// txt_OutOfOrderFillHappensOncePerQuoteMax
			// 
			this.txt_OutOfOrderFillHappensOncePerQuoteMax.Location = new System.Drawing.Point(183, 19);
			this.txt_OutOfOrderFillHappensOncePerQuoteMax.Name = "txt_OutOfOrderFillHappensOncePerQuoteMax";
			this.txt_OutOfOrderFillHappensOncePerQuoteMax.Size = new System.Drawing.Size(33, 20);
			this.txt_OutOfOrderFillHappensOncePerQuoteMax.TabIndex = 42;
			this.txt_OutOfOrderFillHappensOncePerQuoteMax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// txt_OutOfOrderFillHappensOncePerQuoteMin
			// 
			this.txt_OutOfOrderFillHappensOncePerQuoteMin.Location = new System.Drawing.Point(129, 19);
			this.txt_OutOfOrderFillHappensOncePerQuoteMin.Name = "txt_OutOfOrderFillHappensOncePerQuoteMin";
			this.txt_OutOfOrderFillHappensOncePerQuoteMin.Size = new System.Drawing.Size(30, 20);
			this.txt_OutOfOrderFillHappensOncePerQuoteMin.TabIndex = 41;
			this.txt_OutOfOrderFillHappensOncePerQuoteMin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(222, 22);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(93, 17);
			this.label8.TabIndex = 20;
			this.label8.Text = "orders processed";
			// 
			// gbx_DelayBeforeFill
			// 
			this.gbx_DelayBeforeFill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gbx_DelayBeforeFill.Controls.Add(this.label28);
			this.gbx_DelayBeforeFill.Controls.Add(this.cbx_DelayBeforeFillEnabled);
			this.gbx_DelayBeforeFill.Controls.Add(this.label29);
			this.gbx_DelayBeforeFill.Controls.Add(this.txt_DelayBeforeFillMillisMax);
			this.gbx_DelayBeforeFill.Controls.Add(this.txt_DelayBeforeFillMillisMin);
			this.gbx_DelayBeforeFill.Controls.Add(this.label30);
			this.gbx_DelayBeforeFill.Location = new System.Drawing.Point(3, 3);
			this.gbx_DelayBeforeFill.Name = "gbx_DelayBeforeFill";
			this.gbx_DelayBeforeFill.Size = new System.Drawing.Size(356, 65);
			this.gbx_DelayBeforeFill.TabIndex = 32;
			this.gbx_DelayBeforeFill.TabStop = false;
			this.gbx_DelayBeforeFill.Text = "Order Fill Delay";
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(6, 20);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(107, 17);
			this.label28.TabIndex = 34;
			this.label28.Text = "Delay before fill";
			// 
			// cbx_DelayBeforeFillEnabled
			// 
			this.cbx_DelayBeforeFillEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cbx_DelayBeforeFillEnabled.Checked = true;
			this.cbx_DelayBeforeFillEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbx_DelayBeforeFillEnabled.Location = new System.Drawing.Point(6, 41);
			this.cbx_DelayBeforeFillEnabled.Name = "cbx_DelayBeforeFillEnabled";
			this.cbx_DelayBeforeFillEnabled.Size = new System.Drawing.Size(344, 17);
			this.cbx_DelayBeforeFillEnabled.TabIndex = 32;
			this.cbx_DelayBeforeFillEnabled.Text = "Enable Random Order Fill Delay";
			this.cbx_DelayBeforeFillEnabled.UseVisualStyleBackColor = true;
			this.cbx_DelayBeforeFillEnabled.CheckedChanged += new System.EventHandler(this.anyCheckBox_CheckedChanged);
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(165, 20);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(16, 15);
			this.label29.TabIndex = 33;
			this.label29.Text = "to";
			// 
			// txt_DelayBeforeFillMillisMax
			// 
			this.txt_DelayBeforeFillMillisMax.Location = new System.Drawing.Point(183, 17);
			this.txt_DelayBeforeFillMillisMax.Name = "txt_DelayBeforeFillMillisMax";
			this.txt_DelayBeforeFillMillisMax.Size = new System.Drawing.Size(33, 20);
			this.txt_DelayBeforeFillMillisMax.TabIndex = 31;
			this.txt_DelayBeforeFillMillisMax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// txt_DelayBeforeFillMillisMin
			// 
			this.txt_DelayBeforeFillMillisMin.Location = new System.Drawing.Point(129, 17);
			this.txt_DelayBeforeFillMillisMin.Name = "txt_DelayBeforeFillMillisMin";
			this.txt_DelayBeforeFillMillisMin.Size = new System.Drawing.Size(30, 20);
			this.txt_DelayBeforeFillMillisMin.TabIndex = 30;
			this.txt_DelayBeforeFillMillisMin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(222, 21);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(68, 17);
			this.label30.TabIndex = 31;
			this.label30.Text = "milliSeconds";
			// 
			// grp_KillPendingDelay
			// 
			this.grp_KillPendingDelay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grp_KillPendingDelay.Controls.Add(this.label31);
			this.grp_KillPendingDelay.Controls.Add(this.cbx_KillPendingDelayEnabled);
			this.grp_KillPendingDelay.Controls.Add(this.label32);
			this.grp_KillPendingDelay.Controls.Add(this.txt_KillPendingDelay_max);
			this.grp_KillPendingDelay.Controls.Add(this.txt_KillPendingDelay_min);
			this.grp_KillPendingDelay.Controls.Add(this.lbl_KillPendingDelay);
			this.grp_KillPendingDelay.Location = new System.Drawing.Point(3, 67);
			this.grp_KillPendingDelay.Name = "grp_KillPendingDelay";
			this.grp_KillPendingDelay.Size = new System.Drawing.Size(356, 65);
			this.grp_KillPendingDelay.TabIndex = 35;
			this.grp_KillPendingDelay.TabStop = false;
			this.grp_KillPendingDelay.Text = "Order KillPending Delay";
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(6, 20);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(107, 17);
			this.label31.TabIndex = 34;
			this.label31.Text = "Delay before kill";
			// 
			// cbx_KillPendingDelayEnabled
			// 
			this.cbx_KillPendingDelayEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cbx_KillPendingDelayEnabled.Checked = true;
			this.cbx_KillPendingDelayEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbx_KillPendingDelayEnabled.Location = new System.Drawing.Point(6, 41);
			this.cbx_KillPendingDelayEnabled.Name = "cbx_KillPendingDelayEnabled";
			this.cbx_KillPendingDelayEnabled.Size = new System.Drawing.Size(344, 17);
			this.cbx_KillPendingDelayEnabled.TabIndex = 32;
			this.cbx_KillPendingDelayEnabled.Text = "Enable Random Order KillPending Delay";
			this.cbx_KillPendingDelayEnabled.UseVisualStyleBackColor = true;
			this.cbx_KillPendingDelayEnabled.CheckedChanged += new System.EventHandler(this.anyCheckBox_CheckedChanged);
			// 
			// label32
			// 
			this.label32.Location = new System.Drawing.Point(165, 20);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(16, 15);
			this.label32.TabIndex = 33;
			this.label32.Text = "to";
			// 
			// txt_KillPendingDelay_max
			// 
			this.txt_KillPendingDelay_max.Location = new System.Drawing.Point(183, 17);
			this.txt_KillPendingDelay_max.Name = "txt_KillPendingDelay_max";
			this.txt_KillPendingDelay_max.Size = new System.Drawing.Size(33, 20);
			this.txt_KillPendingDelay_max.TabIndex = 31;
			this.txt_KillPendingDelay_max.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// txt_KillPendingDelay_min
			// 
			this.txt_KillPendingDelay_min.Location = new System.Drawing.Point(129, 17);
			this.txt_KillPendingDelay_min.Name = "txt_KillPendingDelay_min";
			this.txt_KillPendingDelay_min.Size = new System.Drawing.Size(30, 20);
			this.txt_KillPendingDelay_min.TabIndex = 30;
			this.txt_KillPendingDelay_min.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// lbl_KillPendingDelay
			// 
			this.lbl_KillPendingDelay.Location = new System.Drawing.Point(222, 21);
			this.lbl_KillPendingDelay.Name = "lbl_KillPendingDelay";
			this.lbl_KillPendingDelay.Size = new System.Drawing.Size(68, 17);
			this.lbl_KillPendingDelay.TabIndex = 31;
			this.lbl_KillPendingDelay.Text = "milliSeconds";
			// 
			// gbx_TransactionStatusAfterOrderStatus
			// 
			this.gbx_TransactionStatusAfterOrderStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gbx_TransactionStatusAfterOrderStatus.Controls.Add(this.label33);
			this.gbx_TransactionStatusAfterOrderStatus.Controls.Add(this.label34);
			this.gbx_TransactionStatusAfterOrderStatus.Controls.Add(this.txt_TransactionStatusAfterOrderStatusDelayAfterFillMax);
			this.gbx_TransactionStatusAfterOrderStatus.Controls.Add(this.txt_TransactionStatusAfterOrderStatusDelayAfterFillMin);
			this.gbx_TransactionStatusAfterOrderStatus.Controls.Add(this.label35);
			this.gbx_TransactionStatusAfterOrderStatus.Controls.Add(this.label36);
			this.gbx_TransactionStatusAfterOrderStatus.Controls.Add(this.cbx_TransactionStatusAfterOrderStatusEnabled);
			this.gbx_TransactionStatusAfterOrderStatus.Controls.Add(this.label37);
			this.gbx_TransactionStatusAfterOrderStatus.Controls.Add(this.txt_TransactionStatusAfterOrderStatusHappensOncePerOrdersMax);
			this.gbx_TransactionStatusAfterOrderStatus.Controls.Add(this.txt_TransactionStatusAfterOrderStatusHappensOncePerOrdersMin);
			this.gbx_TransactionStatusAfterOrderStatus.Controls.Add(this.label38);
			this.gbx_TransactionStatusAfterOrderStatus.Location = new System.Drawing.Point(3, 197);
			this.gbx_TransactionStatusAfterOrderStatus.Name = "gbx_TransactionStatusAfterOrderStatus";
			this.gbx_TransactionStatusAfterOrderStatus.Size = new System.Drawing.Size(356, 90);
			this.gbx_TransactionStatusAfterOrderStatus.TabIndex = 41;
			this.gbx_TransactionStatusAfterOrderStatus.TabStop = false;
			this.gbx_TransactionStatusAfterOrderStatus.Text = "TransactionStatus After OrderStatus";
			// 
			// label33
			// 
			this.label33.Location = new System.Drawing.Point(6, 22);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(107, 17);
			this.label33.TabIndex = 28;
			this.label33.Text = "Happens once per";
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(165, 48);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(16, 15);
			this.label34.TabIndex = 27;
			this.label34.Text = "to";
			// 
			// txt_TransactionStatusAfterOrderStatusDelayAfterFillMax
			// 
			this.txt_TransactionStatusAfterOrderStatusDelayAfterFillMax.Location = new System.Drawing.Point(183, 45);
			this.txt_TransactionStatusAfterOrderStatusDelayAfterFillMax.Name = "txt_TransactionStatusAfterOrderStatusDelayAfterFillMax";
			this.txt_TransactionStatusAfterOrderStatusDelayAfterFillMax.Size = new System.Drawing.Size(33, 20);
			this.txt_TransactionStatusAfterOrderStatusDelayAfterFillMax.TabIndex = 39;
			this.txt_TransactionStatusAfterOrderStatusDelayAfterFillMax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// txt_TransactionStatusAfterOrderStatusDelayAfterFillMin
			// 
			this.txt_TransactionStatusAfterOrderStatusDelayAfterFillMin.Location = new System.Drawing.Point(129, 45);
			this.txt_TransactionStatusAfterOrderStatusDelayAfterFillMin.Name = "txt_TransactionStatusAfterOrderStatusDelayAfterFillMin";
			this.txt_TransactionStatusAfterOrderStatusDelayAfterFillMin.Size = new System.Drawing.Size(30, 20);
			this.txt_TransactionStatusAfterOrderStatusDelayAfterFillMin.TabIndex = 38;
			this.txt_TransactionStatusAfterOrderStatusDelayAfterFillMin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// label35
			// 
			this.label35.Location = new System.Drawing.Point(222, 46);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(93, 17);
			this.label35.TabIndex = 26;
			this.label35.Text = "milliSeconds";
			// 
			// label36
			// 
			this.label36.Location = new System.Drawing.Point(6, 48);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(107, 17);
			this.label36.TabIndex = 23;
			this.label36.Text = "Delay after OrderFill";
			// 
			// cbx_TransactionStatusAfterOrderStatusEnabled
			// 
			this.cbx_TransactionStatusAfterOrderStatusEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cbx_TransactionStatusAfterOrderStatusEnabled.Checked = true;
			this.cbx_TransactionStatusAfterOrderStatusEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbx_TransactionStatusAfterOrderStatusEnabled.Location = new System.Drawing.Point(6, 68);
			this.cbx_TransactionStatusAfterOrderStatusEnabled.Name = "cbx_TransactionStatusAfterOrderStatusEnabled";
			this.cbx_TransactionStatusAfterOrderStatusEnabled.Size = new System.Drawing.Size(344, 17);
			this.cbx_TransactionStatusAfterOrderStatusEnabled.TabIndex = 40;
			this.cbx_TransactionStatusAfterOrderStatusEnabled.Text = "Enable Random TransactionStatus After OrderStatus";
			this.cbx_TransactionStatusAfterOrderStatusEnabled.UseVisualStyleBackColor = true;
			this.cbx_TransactionStatusAfterOrderStatusEnabled.CheckedChanged += new System.EventHandler(this.anyCheckBox_CheckedChanged);
			// 
			// label37
			// 
			this.label37.Location = new System.Drawing.Point(165, 22);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(16, 15);
			this.label37.TabIndex = 22;
			this.label37.Text = "to";
			// 
			// txt_TransactionStatusAfterOrderStatusHappensOncePerOrdersMax
			// 
			this.txt_TransactionStatusAfterOrderStatusHappensOncePerOrdersMax.Location = new System.Drawing.Point(183, 19);
			this.txt_TransactionStatusAfterOrderStatusHappensOncePerOrdersMax.Name = "txt_TransactionStatusAfterOrderStatusHappensOncePerOrdersMax";
			this.txt_TransactionStatusAfterOrderStatusHappensOncePerOrdersMax.Size = new System.Drawing.Size(33, 20);
			this.txt_TransactionStatusAfterOrderStatusHappensOncePerOrdersMax.TabIndex = 37;
			this.txt_TransactionStatusAfterOrderStatusHappensOncePerOrdersMax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// txt_TransactionStatusAfterOrderStatusHappensOncePerOrdersMin
			// 
			this.txt_TransactionStatusAfterOrderStatusHappensOncePerOrdersMin.Location = new System.Drawing.Point(129, 19);
			this.txt_TransactionStatusAfterOrderStatusHappensOncePerOrdersMin.Name = "txt_TransactionStatusAfterOrderStatusHappensOncePerOrdersMin";
			this.txt_TransactionStatusAfterOrderStatusHappensOncePerOrdersMin.Size = new System.Drawing.Size(30, 20);
			this.txt_TransactionStatusAfterOrderStatusHappensOncePerOrdersMin.TabIndex = 36;
			this.txt_TransactionStatusAfterOrderStatusHappensOncePerOrdersMin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// label38
			// 
			this.label38.Location = new System.Drawing.Point(222, 20);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(93, 17);
			this.label38.TabIndex = 20;
			this.label38.Text = "orders processed";
			// 
			// gbx_KillerTransactionCallbackAfterVictimFilled
			// 
			this.gbx_KillerTransactionCallbackAfterVictimFilled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gbx_KillerTransactionCallbackAfterVictimFilled.Controls.Add(this.label39);
			this.gbx_KillerTransactionCallbackAfterVictimFilled.Controls.Add(this.label40);
			this.gbx_KillerTransactionCallbackAfterVictimFilled.Controls.Add(this.txt_KillerTransactionCallbackAfterVictimFilled_delayMax);
			this.gbx_KillerTransactionCallbackAfterVictimFilled.Controls.Add(this.txt_KillerTransactionCallbackAfterVictimFilled_delayMin);
			this.gbx_KillerTransactionCallbackAfterVictimFilled.Controls.Add(this.label41);
			this.gbx_KillerTransactionCallbackAfterVictimFilled.Controls.Add(this.label42);
			this.gbx_KillerTransactionCallbackAfterVictimFilled.Controls.Add(this.cbx_KillerTransactionCallbackAfterVictimFilled_enabled);
			this.gbx_KillerTransactionCallbackAfterVictimFilled.Controls.Add(this.label43);
			this.gbx_KillerTransactionCallbackAfterVictimFilled.Controls.Add(this.txt_KillerTransactionCallbackAfterVictimFilled_happensMax);
			this.gbx_KillerTransactionCallbackAfterVictimFilled.Controls.Add(this.txt_KillerTransactionCallbackAfterVictimFilled_happensMin);
			this.gbx_KillerTransactionCallbackAfterVictimFilled.Controls.Add(this.label44);
			this.gbx_KillerTransactionCallbackAfterVictimFilled.Location = new System.Drawing.Point(3, 288);
			this.gbx_KillerTransactionCallbackAfterVictimFilled.Name = "gbx_KillerTransactionCallbackAfterVictimFilled";
			this.gbx_KillerTransactionCallbackAfterVictimFilled.Size = new System.Drawing.Size(356, 90);
			this.gbx_KillerTransactionCallbackAfterVictimFilled.TabIndex = 42;
			this.gbx_KillerTransactionCallbackAfterVictimFilled.TabStop = false;
			this.gbx_KillerTransactionCallbackAfterVictimFilled.Text = "KillerTransactionCallback After VictimFilled";
			// 
			// label39
			// 
			this.label39.Location = new System.Drawing.Point(6, 22);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(107, 17);
			this.label39.TabIndex = 28;
			this.label39.Text = "Happens once per";
			// 
			// label40
			// 
			this.label40.Location = new System.Drawing.Point(165, 48);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(16, 15);
			this.label40.TabIndex = 27;
			this.label40.Text = "to";
			// 
			// txt_KillerTransactionCallbackAfterVictimFilled_delayMax
			// 
			this.txt_KillerTransactionCallbackAfterVictimFilled_delayMax.Location = new System.Drawing.Point(183, 45);
			this.txt_KillerTransactionCallbackAfterVictimFilled_delayMax.Name = "txt_KillerTransactionCallbackAfterVictimFilled_delayMax";
			this.txt_KillerTransactionCallbackAfterVictimFilled_delayMax.Size = new System.Drawing.Size(33, 20);
			this.txt_KillerTransactionCallbackAfterVictimFilled_delayMax.TabIndex = 39;
			this.txt_KillerTransactionCallbackAfterVictimFilled_delayMax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// txt_KillerTransactionCallbackAfterVictimFilled_delayMin
			// 
			this.txt_KillerTransactionCallbackAfterVictimFilled_delayMin.Location = new System.Drawing.Point(129, 45);
			this.txt_KillerTransactionCallbackAfterVictimFilled_delayMin.Name = "txt_KillerTransactionCallbackAfterVictimFilled_delayMin";
			this.txt_KillerTransactionCallbackAfterVictimFilled_delayMin.Size = new System.Drawing.Size(30, 20);
			this.txt_KillerTransactionCallbackAfterVictimFilled_delayMin.TabIndex = 38;
			this.txt_KillerTransactionCallbackAfterVictimFilled_delayMin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// label41
			// 
			this.label41.Location = new System.Drawing.Point(222, 46);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(93, 17);
			this.label41.TabIndex = 26;
			this.label41.Text = "milliSeconds";
			// 
			// label42
			// 
			this.label42.Location = new System.Drawing.Point(6, 48);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(115, 17);
			this.label42.TabIndex = 23;
			this.label42.Text = "Delay after VictimFilled";
			// 
			// cbx_KillerTransactionCallbackAfterVictimFilled_enabled
			// 
			this.cbx_KillerTransactionCallbackAfterVictimFilled_enabled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cbx_KillerTransactionCallbackAfterVictimFilled_enabled.Checked = true;
			this.cbx_KillerTransactionCallbackAfterVictimFilled_enabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbx_KillerTransactionCallbackAfterVictimFilled_enabled.Location = new System.Drawing.Point(6, 68);
			this.cbx_KillerTransactionCallbackAfterVictimFilled_enabled.Name = "cbx_KillerTransactionCallbackAfterVictimFilled_enabled";
			this.cbx_KillerTransactionCallbackAfterVictimFilled_enabled.Size = new System.Drawing.Size(344, 17);
			this.cbx_KillerTransactionCallbackAfterVictimFilled_enabled.TabIndex = 40;
			this.cbx_KillerTransactionCallbackAfterVictimFilled_enabled.Text = "Enable Random KillerTransactionCallback After VictimFilled";
			this.cbx_KillerTransactionCallbackAfterVictimFilled_enabled.UseVisualStyleBackColor = true;
			this.cbx_KillerTransactionCallbackAfterVictimFilled_enabled.CheckedChanged += new System.EventHandler(this.anyCheckBox_CheckedChanged);
			// 
			// label43
			// 
			this.label43.Location = new System.Drawing.Point(165, 22);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(16, 15);
			this.label43.TabIndex = 22;
			this.label43.Text = "to";
			// 
			// txt_KillerTransactionCallbackAfterVictimFilled_happensMax
			// 
			this.txt_KillerTransactionCallbackAfterVictimFilled_happensMax.Location = new System.Drawing.Point(183, 19);
			this.txt_KillerTransactionCallbackAfterVictimFilled_happensMax.Name = "txt_KillerTransactionCallbackAfterVictimFilled_happensMax";
			this.txt_KillerTransactionCallbackAfterVictimFilled_happensMax.Size = new System.Drawing.Size(33, 20);
			this.txt_KillerTransactionCallbackAfterVictimFilled_happensMax.TabIndex = 37;
			this.txt_KillerTransactionCallbackAfterVictimFilled_happensMax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// txt_KillerTransactionCallbackAfterVictimFilled_happensMin
			// 
			this.txt_KillerTransactionCallbackAfterVictimFilled_happensMin.Location = new System.Drawing.Point(129, 19);
			this.txt_KillerTransactionCallbackAfterVictimFilled_happensMin.Name = "txt_KillerTransactionCallbackAfterVictimFilled_happensMin";
			this.txt_KillerTransactionCallbackAfterVictimFilled_happensMin.Size = new System.Drawing.Size(30, 20);
			this.txt_KillerTransactionCallbackAfterVictimFilled_happensMin.TabIndex = 36;
			this.txt_KillerTransactionCallbackAfterVictimFilled_happensMin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.anyTextBox_KeyUp);
			// 
			// label44
			// 
			this.label44.Location = new System.Drawing.Point(222, 20);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(93, 17);
			this.label44.TabIndex = 20;
			this.label44.Text = "killer orders";
			// 
			// LivesimBrokerEditor
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.AutoScroll = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.gbx_KillerTransactionCallbackAfterVictimFilled);
			this.Controls.Add(this.gbx_TransactionStatusAfterOrderStatus);
			this.Controls.Add(this.grp_KillPendingDelay);
			this.Controls.Add(this.gbx_DelayBeforeFill);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grp_BrokerAdapterDisconnect);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.grp_orderRejectionRate);
			this.Controls.Add(this.groupBox2);
			this.Name = "LivesimBrokerEditor";
			this.Size = new System.Drawing.Size(362, 746);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.grp_orderRejectionRate.ResumeLayout(false);
			this.grp_orderRejectionRate.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.grp_BrokerAdapterDisconnect.ResumeLayout(false);
			this.grp_BrokerAdapterDisconnect.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.gbx_DelayBeforeFill.ResumeLayout(false);
			this.gbx_DelayBeforeFill.PerformLayout();
			this.grp_KillPendingDelay.ResumeLayout(false);
			this.grp_KillPendingDelay.PerformLayout();
			this.gbx_TransactionStatusAfterOrderStatus.ResumeLayout(false);
			this.gbx_TransactionStatusAfterOrderStatus.PerformLayout();
			this.gbx_KillerTransactionCallbackAfterVictimFilled.ResumeLayout(false);
			this.gbx_KillerTransactionCallbackAfterVictimFilled.PerformLayout();
			this.ResumeLayout(false);

		}
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}
		#endregion

		private System.Windows.Forms.GroupBox gbx_TransactionStatusAfterOrderStatus;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.TextBox txt_TransactionStatusAfterOrderStatusDelayAfterFillMax;
		private System.Windows.Forms.TextBox txt_TransactionStatusAfterOrderStatusDelayAfterFillMin;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.CheckBox cbx_TransactionStatusAfterOrderStatusEnabled;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.TextBox txt_TransactionStatusAfterOrderStatusHappensOncePerOrdersMax;
		private System.Windows.Forms.TextBox txt_TransactionStatusAfterOrderStatusHappensOncePerOrdersMin;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.GroupBox gbx_KillerTransactionCallbackAfterVictimFilled;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.TextBox txt_KillerTransactionCallbackAfterVictimFilled_delayMax;
		private System.Windows.Forms.TextBox txt_KillerTransactionCallbackAfterVictimFilled_delayMin;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.CheckBox cbx_KillerTransactionCallbackAfterVictimFilled_enabled;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.TextBox txt_KillerTransactionCallbackAfterVictimFilled_happensMax;
		private System.Windows.Forms.TextBox txt_KillerTransactionCallbackAfterVictimFilled_happensMin;
		private System.Windows.Forms.Label label44;
	}
}