using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using BooBox;

namespace BooBoxServer {
	public static class Library {
		private static ArrayList FolderList = new ArrayList();
		private static List<SongInfo> SongList = new List<SongInfo>();

		/// <summary>
		/// Saves settings to the Config object.
		/// </summary>
		public static void SaveSettings() {
			Config.Instance.LibrarySongList = SongList;
			Config.Instance.LibraryFolderList = FolderList;
		}

		/// <summary>
		/// Loads Library from the Config object.
		/// </summary>
		public static void LoadSettings() {
			SongList = Config.Instance.LibrarySongList;
			FolderList = Config.Instance.LibraryFolderList;
		}

		/// <summary>
		/// Rebuilds the Library based on the folder list in the Library.
		/// </summary>
		public static void RebuildLibrary() {
			Log.AddStatusText("Initiated a Library rebuild. Music Library erased.");
			SongList.Clear();
			for (int i = 0; i < FolderList.Count; i++) {
				AddFolder(FolderList[i].ToString());
			}
			Log.AddStatusText("Library rebuild finished.");
		}

		/// <summary>
		/// Adds a folder to the Library.
		/// </summary>
		/// <param name="FolderToAdd">String containing the Directory Path to add.</param>
		public static void AddFolder(String FolderToAdd) {
			Boolean fileExistsInLibrary;
			Log.AddStatusText("Adding folder to Library: " + FolderToAdd);
			SongInfo tempSongInfo;
			// If directory exists continue, if not print an error to the log.
			if (!Directory.Exists(FolderToAdd)) { Log.AddStatusText("Directory (" + FolderToAdd + ") does not exist. Skipping."); } else {
				// Add folder to the list if not already in the list.
				if (!FolderList.Contains(FolderToAdd)) { FolderList.Add(FolderToAdd); }
				ArrayList TempFileList = new ArrayList();
				// Begin listing all *.mp3 files in current directory
				TempFileList = Functions.RecursiveDirctoryListing(FolderToAdd, "*.mp3");
				Forms.MainFrm.UpdateStatusProgressBar("SetMax", TempFileList.Count);
				for (int i = 0; i < TempFileList.Count; i++) {
					fileExistsInLibrary = false;
					Forms.MainFrm.UpdateStatusProgressBar("Increment", 1);
					Forms.MainFrm.UpdateStatusLabel("Adding file to Library (" + i + "/" + (TempFileList.Count - 1) + ")... " + Convert.ToInt32((Convert.ToDouble(i) / (TempFileList.Count - 1)) * 100) + "%");
					// Pull the Tag data from the current file
					TagLib.File ID3Tag = TagLib.File.Create(TempFileList[i].ToString());
					if ((ID3Tag.Tag.Title != "") && (ID3Tag.Tag.Title != null) && (ID3Tag.Tag.AlbumArtists.Length > 0) && (ID3Tag.Tag.Album != "")) {
						// Create the SongInfo object from the ID3Tag
						tempSongInfo = Functions.ID3ToSongInfo(ID3Tag, Config.Instance.GUID);
						// Determine if the file has already been added to the Library. If not add it to the Library, if so print an error to the log.
						for (int x = 0; x < SongList.Count; x++) { if (SongList[x].MD5 == tempSongInfo.MD5) { fileExistsInLibrary = true; break; } }
						if (fileExistsInLibrary == false) {
							SongList.Add(tempSongInfo);
						} else {
							Log.AddStatusText("File already in Library, skipping: " + tempSongInfo.FileName);
						}
					}
				}
				Forms.MainFrm.UpdateStatusProgressBar("Reset", 0);
				Forms.MainFrm.UpdateStatusLabel("Ready");
				SaveSettings();
			}
		}

		/// <summary>
		/// Removes a folder from the folder list and removes all songs within that folder from the Library.
		/// </summary>
		/// <param name="FolderToRemove">String representing the path to remove.</param>
		public static void RemoveFolder(String FolderToRemove) {
			for (int i = 0; i < SongList.Count; i++) {
				if (SongList[i].FileName.StartsWith(FolderToRemove)) {
					Log.AddStatusText("Removed file: " + SongList[i].FileName);
					SongList.RemoveAt(i);
					i--;
				}
			}
			for (int i = 0; i < FolderList.Count; i++) {
				if (FolderList[i].ToString().StartsWith(FolderToRemove)) {
					Log.AddStatusText("Removed folder: " + FolderList[i].ToString());
					FolderList.RemoveAt(i);
					i--;
				}
			}
		}

	}
}
