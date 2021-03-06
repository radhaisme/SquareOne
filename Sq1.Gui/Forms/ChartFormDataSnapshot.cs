﻿using System;

using Sq1.Charting;
using Sq1.Core;
using Sq1.Core.StrategyBase;
using Sq1.Core.Charting;

using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sq1.Gui.Forms {
	public class ChartFormDataSnapshot {
		[JsonProperty]	public string StrategyGuidJsonCheck;
		[JsonProperty]	public string StrategyNameJsonCheck;
		[JsonProperty]	public string StrategyAbsPathJsonCheck;
		
		[JsonIgnore]	int chartSerno;
		[JsonProperty]	public int ChartSerno {
			get { return this.chartSerno; }
			set {
				if (value == -1) return;
				if (value == this.chartSerno) return;
				if (this.chartSerno != -1) {
					string msg = "this.chartSerno[" + this.chartSerno + "] => value[" + value + "]"
						+ ": ChartSerno can be initialized only once in a lifetime"
						+ "(init-once from ChartFormManager.Initialize() after deserialization)";
					//throw new Exception(msg);
					Assembler.PopupException(msg);
				}
				this.chartSerno = value;
			}
		}

		[JsonProperty]	public ContextChart ContextChart;
		[JsonProperty]	public string ContextChartCommentJsonCheck { get {
			string ret = "THIS_CHARTFORM_CONTAINS_STRATEGY_SO_this.ContextChart_IS_NULL check [" + this.StrategyAbsPathJsonCheck + "], ScriptContextCurrentName[?Default?]";

				// KISS lazy to figure out if I assigned a derived-casted-to-parent-before-assignment - will AS work or I have to use GetType() / typeof....
				//ContextScript contextScript = this.ContextChart as ContextScript;
				//if (contextScript == null) return ret;

				if (this.ContextChart == null) return ret;

				ret = "THIS_CHARTFORM_HAS_NO_STRATEGY_ATTACHED_SO_this.ContextChart_CONTAINS_CURRENT_BARSCALEINTEVAL_DATARANGE";
				return ret;
			} }
		

		[JsonIgnore]			ChartSettingsTemplated chartSettingsTemplated;		// not saved/restored during severe storms in ChartSettings' structure (avoiding Json deserialization exceptions by JsonIgnoring it)
		[JsonIgnore]	public	ChartSettingsTemplated ChartSettingsTemplated {
			get {
				if (this.chartSettingsTemplated == null) {
					if (string.IsNullOrEmpty(this.ChartSettingsName)) this.ChartSettingsName = ChartSettingsTemplated.NAME_DEFAULT;
					this.chartSettingsTemplated = Assembler.InstanceInitialized.RepositoryJsonChartSettings.ChartSettingsFind_nullUnsafe(this.ChartSettingsName);
					if (this.chartSettingsTemplated == null) this.chartSettingsTemplated = new ChartSettingsTemplated();
				}
				return this.chartSettingsTemplated;
			}
		}
		[JsonProperty]			string chartSettingsName;
		[JsonIgnore]	public	string ChartSettingsName {
			get {
				if (string.IsNullOrEmpty(this.chartSettingsName)) this.chartSettingsName = ChartSettingsTemplated.NAME_DEFAULT;
				return this.chartSettingsName;
			}
			set {
				if (this.chartSettingsName == value) return;
				this.chartSettingsName = value;
				this.chartSettingsTemplated = null;	// trigger reload
			}
		}

		[JsonProperty]	public	ChartSettingsIndividual ChartSettingsIndividual;

		public ChartFormDataSnapshot() {
			this.chartSerno = -1;
			this.StrategyGuidJsonCheck		= "NOT_INITIALIZED ChartFormManager.Initialize()";
			this.StrategyNameJsonCheck		= "NOT_INITIALIZED ChartFormManager.Initialize()";
			this.StrategyAbsPathJsonCheck	= "NOT_INITIALIZED ChartFormManager.Initialize()";
			//this.ContextChart = new ContextChart();	// should be nullified when a strategy is loaded to the chart

			this.ChartSettingsIndividual = new ChartSettingsIndividual();
		}
		
	}
}
