using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using BooBox;

namespace BooBoxServer {
	public sealed class Config {
		//public ArrayList LibraryFolderList = new ArrayList();
		//public List<MusicFile> LibraryList = new List<MusicFile>();
		public int CommInfoPort = 1337;
		public int CommStreamPort = 1338;
		public String ServerName = "";
		public Boolean PasswordRequired = false;
		public String ServerPassword = "";
		public int DataBufferSize = 4096;
		public String GUID = Guid.NewGuid().ToString();

		#region Configuration Save/Load/Singleton Stuff
		Config() { }

		/// <summary>
		/// Saves configuration to a the configuration file.
		/// </summary>
		public void Save() {
			XmlSerializer XmlSerializer = new XmlSerializer(typeof(Config));
			TextWriter TextWriter = new StreamWriter(@"BooBoxServer.xml");
			XmlSerializer.Serialize(TextWriter, this);
			TextWriter.Close();
			Log.AddStatusText("Configuration saved");
		}

		/// <summary>
		/// Loads configuration from the configuration file.
		/// </summary>
		/// <returns></returns>
		internal static Config Load() {
			if (File.Exists("BooBoxServer.xml")) {
				XmlSerializer XmlSerializer = new XmlSerializer(typeof(Config));
				Log.AddStatusText("Configuration loaded from file.");
				using (TextReader TextReader = new StreamReader("BooBoxServer.xml"))
					return (Config)XmlSerializer.Deserialize(TextReader);
			} else {
				Log.AddStatusText("Configuration file nonexistant, loading blank configuration.");
				return new Config();
			}
		}

		public static Config Instance { get { return Nested.instance; } }

		class Nested {
			static Nested() { }
			internal static readonly Config instance = Config.Load();
		}
		#endregion
	}
}
