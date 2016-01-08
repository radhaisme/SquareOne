﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Sq1.Core;
using Sq1.Core.Broker;
using Sq1.Core.DataFeed;
using Sq1.Core.DataTypes;
using Sq1.Core.Streaming;
using Sq1.Core.Support;
using Sq1.Core.Repositories;

using WeifenLuo.WinFormsUI.Docking;

namespace Sq1.Widgets.DataSourceEditor {
	public partial class DataSourceEditorControl : UserControl, IDataSourceEditor {
		public string DataSourceName { get {
				if (this.dataSourceIamEditing == null) return "NO_DATASOURCE_LOADED_FOR_EDITING";
				return this.dataSourceIamEditing.Name;
			} }

		public	DockPanel								MainFormDockPanel_forDdeMonitor	{ get; private set; }

		public	Dictionary<string, StreamingAdapter>	StreamingAdaptersByName			{ get; private set; }
		public	Dictionary<string, BrokerAdapter>		BrokerAdaptersByName			{ get; private set; }

				RepositoryJsonDataSource				repositoryJsonDataSource;
				RepositorySerializerMarketInfo			repositoryMarketInfo;
				OrderProcessor							orderProcessor;
				DataSource								dataSourceIamEditing;

		string symbolsDefault;
		string windowTitleDefault;

		public DataSourceEditorControl() {
			this.symbolsDefault = "RIZ2,RIH3";
			InitializeComponent();
		}

		public void InitializeContext(
				Dictionary<string, StreamingAdapter>	streamingAdaptersByName,
				Dictionary<string, BrokerAdapter>		brokerAdaptersByName,
				RepositoryJsonDataSource				repositoryJsonDataSourcePassed,
				RepositorySerializerMarketInfo			repositorySerializerMarketInfoPassed,
				OrderProcessor							orderProcessorPassed
			) {
			this.StreamingAdaptersByName			= streamingAdaptersByName;
			this.BrokerAdaptersByName				= brokerAdaptersByName;
			this.repositoryJsonDataSource			= repositoryJsonDataSourcePassed;
			this.repositoryMarketInfo				= repositorySerializerMarketInfoPassed;
			this.orderProcessor						= orderProcessorPassed;
		}
		public void Initialize(DataSource dsEdit, DockPanel mainFormDockPanel) {
			this.MainFormDockPanel_forDdeMonitor = mainFormDockPanel;

			if (dsEdit == null) {
				throw new Exception("DataSourceEditor can not create the DataSource; pass an existing datasource for editing, not NULL");
			}
			this.dataSourceIamEditing = dsEdit;
			if (this.Parent != null) {
				this.Parent.Text = "DataSourceEdit :: " + dataSourceIamEditing.Name;
			} else {
				this.Text = dataSourceIamEditing.Name;
			}
			if (this.dataSourceIamEditing.Name != windowTitleDefault) {
				this.txtDataSourceName.Text = this.dataSourceIamEditing.Name;
			}
			this.txtSymbols.Text = this.dataSourceIamEditing.SymbolsCSV;
			this.PopulateScaleIntervalFromDataSource();
			this.PopulateStreamingBrokerListViewsFromDataSource();


			if (this.dataSourceIamEditing.StreamingAdapter != null) {
				this.highlightStreamingByName(this.dataSourceIamEditing.StreamingAdapter.GetType().Name);
			} else {
				this.highlightStreamingByName(StreamingAdapter.NO_STREAMING_ADAPTER);
			}

			if (this.dataSourceIamEditing.BrokerAdapter != null) {
				this.highlightBrokerByName(this.dataSourceIamEditing.BrokerAdapter.GetType().Name);
			} else {
				this.highlightBrokerByName(BrokerAdapter.NO_BROKER_ADAPTER);
			}

			this.marketInfoEditor.Initialize(dataSourceIamEditing, this.repositoryJsonDataSource, this.repositoryMarketInfo);


			RepositoryJsonDataSource dsRepo = this.repositoryJsonDataSource;
			dsRepo.OnItemRemovedDone -= new EventHandler<NamedObjectJsonEventArgs<DataSource>>(repositoryJsonDataSource_OnDataSourceDeleted_closeDataSourceEditor);
			dsRepo.OnItemRemovedDone += new EventHandler<NamedObjectJsonEventArgs<DataSource>>(repositoryJsonDataSource_OnDataSourceDeleted_closeDataSourceEditor);

			dsRepo.OnItemRenamed -= new EventHandler<NamedObjectJsonEventArgs<DataSource>>(repositoryJsonDataSource_OnDataSourceRenamed_refreshTitle);
			dsRepo.OnItemRenamed += new EventHandler<NamedObjectJsonEventArgs<DataSource>>(repositoryJsonDataSource_OnDataSourceRenamed_refreshTitle);

			dsRepo.OnSymbolAdded -= new EventHandler<DataSourceSymbolEventArgs>(repositoryJsonDataSource_OnSymbolAddedRenamedRemoved_refreshSymbolsTextarea);
			dsRepo.OnSymbolAdded += new EventHandler<DataSourceSymbolEventArgs>(repositoryJsonDataSource_OnSymbolAddedRenamedRemoved_refreshSymbolsTextarea);

			dsRepo.OnSymbolRemovedDone -= new EventHandler<DataSourceSymbolEventArgs>(repositoryJsonDataSource_OnSymbolAddedRenamedRemoved_refreshSymbolsTextarea);
			dsRepo.OnSymbolRemovedDone += new EventHandler<DataSourceSymbolEventArgs>(repositoryJsonDataSource_OnSymbolAddedRenamedRemoved_refreshSymbolsTextarea);

			dsRepo.OnSymbolRenamed -= new EventHandler<DataSourceSymbolRenamedEventArgs>(repositoryJsonDataSource_OnSymbolAddedRenamedRemoved_refreshSymbolsTextarea);
			dsRepo.OnSymbolRenamed += new EventHandler<DataSourceSymbolRenamedEventArgs>(repositoryJsonDataSource_OnSymbolAddedRenamedRemoved_refreshSymbolsTextarea);
		}

		public void PopulateScaleIntervalFromDataSource() {
			this.cmbScale.Items.Clear();
			int indexSelected = 0;
			int i = 0;
			foreach (BarScale barScale in Enum.GetValues(typeof(BarScale))) {
				this.cmbScale.Items.Add(barScale.ToString());
				if (this.dataSourceIamEditing.ScaleInterval == null) {
					if (barScale == BarScale.Unknown) indexSelected = i;  
				} else {
					if (this.dataSourceIamEditing.ScaleInterval.Scale == barScale) indexSelected = i;
				}
				i++;
			}
			this.cmbScale.SelectedIndex = indexSelected;
			if (this.dataSourceIamEditing.ScaleInterval != null) {
				this.nmrInterval.Value = dataSourceIamEditing.ScaleInterval.Interval;
			}
		}
		public void PopulateStreamingBrokerListViewsFromDataSource() {
			if (base.IsDisposed) {
				string msg = "base.IsDisposed=true for DataSourceEditorForm::PopulateStaticStreamingBrokerListViewsFromDataSource()";
				Assembler.PopupException(msg);
				return;
			}
			
			this.lvStreamingAdapters.Items.Clear();
			ListViewItem lviAbsentStreaming = new ListViewItem() {
				Text = StreamingAdapter.NO_STREAMING_ADAPTER,
				Name = StreamingAdapter.NO_STREAMING_ADAPTER,
			};
			this.lvStreamingAdapters.Items.Add(lviAbsentStreaming);
			foreach (StreamingAdapter streamingAdapterPrototype in StreamingAdaptersByName.Values) {
				try {
					StreamingAdapter streamingAdapterInstance = null;	// streamingAdapterPrototype;
					if (dataSourceIamEditing.StreamingAdapter != null && dataSourceIamEditing.StreamingAdapter.GetType().FullName == streamingAdapterPrototype.GetType().FullName) {
						streamingAdapterInstance = dataSourceIamEditing.StreamingAdapter;
					}
					// I still want to get a new instance, so if user choses it, I'll Initialize() it and put into serialize-able DataSource
					if (streamingAdapterInstance == null) {
						streamingAdapterInstance = (StreamingAdapter)Activator.CreateInstance(streamingAdapterPrototype.GetType());
					}

					if (streamingAdapterInstance.EditorInstanceInitialized == false) {
						try {
							streamingAdapterInstance.StreamingEditorInitialize(this);
						} catch (Exception e) {
							string msg = "can't initialize streamingAdapterInstance[" + streamingAdapterInstance + "]";
							Assembler.PopupException(msg, e);
							return;
						}
					}

					ListViewItem lvi = new ListViewItem() {
						Text = streamingAdapterInstance.Name,
						Name = streamingAdapterInstance.GetType().Name,
						Tag = streamingAdapterInstance
					};
					if (streamingAdapterInstance.Icon != null) {
						this.imglStreamingAdapters.Images.Add(streamingAdapterInstance.Icon);
						lvi.ImageIndex = this.imglStreamingAdapters.Images.Count - 1;
					}
					this.lvStreamingAdapters.Items.Add(lvi);
				} catch (Exception e) {
					Assembler.PopupException(null, e);
					return;
				}
			}

			this.lvBrokerAdapters.Items.Clear();
			ListViewItem lviAbsentBroker = new ListViewItem() {
				Text = BrokerAdapter.NO_BROKER_ADAPTER,
				Name = BrokerAdapter.NO_BROKER_ADAPTER,
			};
			this.lvBrokerAdapters.Items.Add(lviAbsentBroker);
			foreach (BrokerAdapter brokerAdapterPrototype in BrokerAdaptersByName.Values) {
				try {
					BrokerAdapter brokerAdapterInstance = null;	// brokerAdapterPrototype;
					if (dataSourceIamEditing.BrokerAdapter != null && dataSourceIamEditing.BrokerAdapter.GetType().FullName == brokerAdapterPrototype.GetType().FullName) {
						brokerAdapterInstance = dataSourceIamEditing.BrokerAdapter;
					}
					// I still want to get a new instance, so if user choses it, I'll Initialize() it and put into serialize-able DataSource
					if (brokerAdapterInstance == null) {
						brokerAdapterInstance = (BrokerAdapter)Activator.CreateInstance(brokerAdapterPrototype.GetType());
					}

					if (brokerAdapterInstance.EditorInstanceInitialized == false) {
						try {
							brokerAdapterInstance.BrokerEditorInitialize(this);
						} catch (Exception e) {
							string msg = "can't initialize brokerAdapterInstance[" + brokerAdapterInstance + "]";
							Assembler.PopupException(msg, e);
							return;
						}
					}

					//if (this.DataSource == null) return;	//changing market for ASCII DataProvider
					//this.DataSource.DataSourceManager.DataSourceSaveTreeviewRefill(this.DataSource);


					ListViewItem lvi = new ListViewItem() {
						Text = brokerAdapterInstance.Name,
						Name = brokerAdapterInstance.GetType().Name,
						Tag = brokerAdapterInstance
					};
					if (brokerAdapterInstance.Icon != null) {
						this.imglBrokerAdapters.Images.Add(brokerAdapterInstance.Icon);
						lvi.ImageIndex = this.imglBrokerAdapters.Images.Count - 1;
					}
					this.lvBrokerAdapters.Items.Add(lvi);
				} catch (Exception e) {
					Assembler.PopupException(null, e);
					return;
				}
			}
		}
		void highlightStreamingByName(string streamingName) {
			int streamingIndex = this.lvStreamingAdapters.Items.IndexOfKey(streamingName);
			if (streamingIndex < 0) {
				string msg = "streamingName[" + streamingName + "] not found in this.lvStreamingAdapters";
				Assembler.PopupException(msg);
				return;
			}
			this.lvStreamingAdapters.Items[streamingIndex].Selected = true;
			lvStreamingAdapters_SelectedIndexChanged(null, null);
		}
		void highlightBrokerByName(string brokerName) {
			int brokerIndex = this.lvBrokerAdapters.Items.IndexOfKey(brokerName);
			if (brokerIndex < 0) {
				string msg = "brokerName[" + brokerName + "] not found in this.lvBrokerAdapters";
				Assembler.PopupException(msg);
				return;
			}
			this.lvBrokerAdapters.Items[brokerIndex].Selected = true;
			lvBrokerAdapters_SelectedIndexChanged(null, null);
		}
		public void ApplyEditorsToDataSource() {
			if (this.txtDataSourceName.Text == "") {
				string msg = "Please provide Name for this new DataSet";
				Assembler.PopupException(msg);
				this.txtDataSourceName.Focus();
				return;
			}
//			DataSource foundSameName = Assembler.Instance.RepositoryJsonDataSource.DataSourceFind(this.txtDataSourceName.Text);
//			if (foundSameName != null) {
//				string msg = "DataSource[" + this.txtDataSourceName.Text + "] existed before; Overwrite?";
//				DialogResult dialogResult = MessageBox.Show(msg, "DataSource [" + this.txtDataSourceName.Text + "] already exists", MessageBoxButtons.YesNoCancel);
//				switch (dialogResult) {
//					case System.Windows.Forms.DialogResult.Cancel:
//					case DialogResult.No:
//						this.txtDataSourceName.SelectAll();
//						this.txtDataSourceName.Focus();
//						return;
//					case DialogResult.Yes:
//						Assembler.Instance.RepositoryJsonDataSource.SerializeSingle(ds);
//						base.DialogResult = System.Windows.Forms.DialogResult.OK;
//						return;
//				}
//			}

			this.dataSourceIamEditing.Name = this.txtDataSourceName.Text;
			this.dataSourceIamEditing.Symbols = SymbolParser.ParseSymbols(this.txtSymbols.Text);
			this.dataSourceIamEditing.ScaleInterval.StringsCachedInvalidate();

			if (this.dataSourceIamEditing.StreamingAdapter	!= null) this.dataSourceIamEditing.StreamingAdapter	.EditorInstance.PushEditedSettingsToStreamingAdapter();
			if (this.dataSourceIamEditing.BrokerAdapter		!= null) this.dataSourceIamEditing.BrokerAdapter	.EditorInstance.PushEditedSettingsToBrokerAdapter();

			// for DataSource, nothing changed, but providers were assigned by user clicks, so DS will Initialize() each
			this.dataSourceIamEditing.Initialize(this.repositoryJsonDataSource.AbsPath, this.orderProcessor);
			this.repositoryJsonDataSource.SerializeSingle(dataSourceIamEditing);

			try {
				this.RaiseDataSourceEdited_updateDataSourcesTreeControl();
			} catch (Exception ex) {
				string msg = "SOMETHING_HAPPENED_TO_DataSourcesTreeControl.PopulateIconForDataSource()";
				Assembler.PopupException(msg, ex);
			}

			try {
				//LOOKS_LIKE_STARTS_BACKTESTING_BEFORE_DSEDITOR_CLOSED
				//USER_HAS_X_TO_CLOSE_THIS_WINDOW this.btnCancel_Click(this, null);
				this.dataSourceIamEditing.RaiseDataSourceEdited_chartsDisplayedShouldRunBacktestAgain();
			} catch (Exception ex) {
				string msg = "SOMETHING_HAPPENED_TO_ChartFormManager.PopulateSelectorsFromCurrentChartOrScriptContextLoadBarsSaveBacktestIfStrategy()";
				Assembler.PopupException(msg, ex);
			}
		}
	}
}
