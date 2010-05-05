using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BooBox;

namespace BooBoxServer {
	public static class StreamManager {
		private static Dictionary<String, SongInfo> SongInfoDict = new Dictionary<String, SongInfo>();

		public static String AddSongRequest(SongInfo inputSongInfo) {
			String tempSIGUID = Guid.NewGuid().ToString();
			SongInfoDict.Add(tempSIGUID, inputSongInfo);
			return tempSIGUID;
		}

		public static Boolean KeyIsValid(String SongKey) {
			return SongInfoDict.ContainsKey(SongKey);
		}

		public static SongInfo GetAndRemoveKey(String SongKey) {
			SongInfo tempSI = SongInfoDict[SongKey];
			SongInfoDict.Remove(SongKey);
			return tempSI;
		}

	}
}
