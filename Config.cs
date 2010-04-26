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
		public ArrayList LibraryFolderList = new ArrayList();
		public List<SongInfo> LibrarySongList = new List<SongInfo>();
		public int CommInfoPort = 1337;
		public int CommStreamPort = 1338;
		public String ServerName = "";
		public Boolean PasswordRequired = false;
		public String ServerPassword = "";
		public int DataBufferSize = 4096;
		public String GUID = Guid.NewGuid().ToString();
		public Boolean Configured = false;



		#region Configuration Save/Load/Singleton Stuff
		Config() { }

		/// <summary>
		/// Saves configuration to the configuration file.
		/// </summary>
		public void Save() {
			XmlSerializer XmlSerializer = new XmlSerializer(typeof(Config));
			TextWriter TextWriter = new StreamWriter(@"BooBoxServer.xml");
			XmlSerializer.Serialize(TextWriter, this);
			TextWriter.Close();
			Log.AddStatusText("Configuration saved");
		}

		/// <summary>
		/// Saves configuration to a configuration file.
		/// </summary>
		/// <param name="Filename">Filename to save Configuration as</param>
		public void Save(String Filename) {
			XmlSerializer XmlSerializer = new XmlSerializer(typeof(Config));
			TextWriter TextWriter = new StreamWriter(Filename);
			XmlSerializer.Serialize(TextWriter, this);
			TextWriter.Close();
			Log.AddStatusText("Configuration exported: " + Filename);
		}

		/// <summary>
		/// Loads configuration from a configuration file.
		/// </summary>
		/// <param name="Filename">Filename to load configuration from</param>
		/// <returns></returns>
		public void Load(String Filename) {
			if (File.Exists(Filename)) {
				XmlSerializer XmlSerializer = new XmlSerializer(typeof(Config));
				Log.AddStatusText("Configuration loaded from file: " + Filename);
				using (TextReader TextReader = new StreamReader(Filename))
					Config.Instance = (Config)XmlSerializer.Deserialize(TextReader);
			}
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

		public static Config Instance {
			get { return Nested.instance; }
			set { Nested.instance = value; }
		}

		class Nested {
			static Nested() { }
			internal static Config instance = Config.Load();
		}
		#endregion
	}

	public static class Forms {
		public static MainFrm MainFrm;
		public static FirstRunFrm FirstRunFrm;
	}

}
