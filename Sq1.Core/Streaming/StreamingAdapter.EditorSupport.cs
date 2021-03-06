using System;

using Newtonsoft.Json;

using Sq1.Core.DataFeed;

namespace Sq1.Core.Streaming {
	public partial class StreamingAdapter {
		[JsonIgnore]	public			IDataSourceEditor	DataSourceEditor			{ get; protected set; }
		[JsonIgnore]	protected		StreamingEditor		StreamingEditorInstance;
		[JsonIgnore]	public virtual	bool				EditorInstanceInitialized	{ get { return (this.StreamingEditorInstance != null); } }
		[JsonIgnore]	public virtual	StreamingEditor		EditorInstance				{ get {
				if (this.StreamingEditorInstance == null) {
					string msg = "you didn't invoke StreamingEditorInitialize() prior to accessing EditorInstance property";
					throw new Exception(msg);
				}
				return this.StreamingEditorInstance;
			} }

		[JsonIgnore]	public			string				NameWithVersion						{ get {
			string version = "UNKNOWN";
			var fullNameSplitted = this.GetType().Assembly.FullName.Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);
			if (fullNameSplitted.Length >= 1) version = fullNameSplitted[1];
			if (version.Length >= "Version=".Length) version = version.TrimStart("Version=".ToCharArray());
			return this.Name + " v." + version;
		} }

		public virtual StreamingEditor StreamingEditorInitialize(IDataSourceEditor dataSourceEditor) {
			throw new Exception("please override StreamingAdapter::StreamingEditorInitialize():"
				+ " 1) use base.StreamingEditorInitializeHelper()"
				+ " 2) do base.streamingEditorInstance=new FoobarStreamingEditor()");
		}
		public void StreamingEditorInitializeHelper(IDataSourceEditor dataSourceEditor) {
			if (this.DataSourceEditor != null) {
				if (this.DataSourceEditor == dataSourceEditor) return;
				string msg = "this.dataSourceEditor!=null, already initialized; should I overwrite it with another instance you provided?...";
				throw new Exception(msg);
			}
			this.DataSourceEditor = dataSourceEditor;
		}

	}
}
