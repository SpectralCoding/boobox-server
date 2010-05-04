using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BooBox;

namespace BooBoxServer {
	public static class PlaylistManager {
		public static List<LocalPlaylist> LocalPlaylistList = new List<LocalPlaylist>();

		/// <summary>
		/// Creates a Playlist with the specified Name.
		/// </summary>
		/// <param name="Name">Name of new Playlist</param>
		/// <returns>Boolean revealing whether or not the Playlist was successfully created</returns>
		public static Boolean CreatePlaylist(String Name) {
			for (int i = 0; i < LocalPlaylistList.Count; i++) {
				if (LocalPlaylistList[i].Name == Name) {
					MessageBox.Show("A playlist with the name \"" + Name + "\" already exists. New playlist not added.");
					return false;
				}
			}
			LocalPlaylist tempPlaylist = new LocalPlaylist();
			tempPlaylist.Name = Name;
			tempPlaylist.GUID = Guid.NewGuid().ToString();
			LocalPlaylistList.Add(tempPlaylist);
			return true;
		}

		/// <summary>
		/// Gets a Playlist's SongInfo list from the playlist name.
		/// </summary>
		/// <param name="PlaylistName">Name of playlist sought</param>
		/// <returns>List of SongInfo objects inside the playlist</returns>
		public static List<SongInfo> GetPlaylistListByName(String PlaylistName) {
			for (int i = 0; i < LocalPlaylistList.Count; i++) {
				if (LocalPlaylistList[i].Name == PlaylistName) {
					return LocalPlaylistList[i].SongList;
				}
			}
			return new List<SongInfo>();
		}

		/// <summary>
		/// Returns a LocalPlaylist object given its name.
		/// </summary>
		/// <param name="PlaylistName">Name of LocalPlaylist to return.</param>
		/// <returns>LocalPlaylist object</returns>
		public static LocalPlaylist GetPlaylistByName(String PlaylistName) {
			for (int i = 0; i < LocalPlaylistList.Count; i++) {
				if (LocalPlaylistList[i].Name == PlaylistName) {
					return LocalPlaylistList[i];
				}
			}
			return new LocalPlaylist();
		}

		/// <summary>
		/// Returns a LocalPlaylist object related to a Playlist GUID.
		/// </summary>
		/// <param name="PlaylistGUID">GUID of the playlist being sought</param>
		/// <returns>LocalPlaylist object</returns>
		public static LocalPlaylist GetLocalPlaylistFromGUID(String PlaylistGUID) {
			for (int i = 0; i < LocalPlaylistList.Count; i++) {
				if (LocalPlaylistList[i].GUID == PlaylistGUID) {
					return LocalPlaylistList[i];
				}
			}
			return (new LocalPlaylist());
		}

		/// <summary>
		/// Deletes a playlist by name.
		/// </summary>
		/// <param name="PlaylistGUID">GUID of playlist to delete</param>
		public static void DeletePlaylist(String PlaylistGUID) {
			for (int i = 0; i < LocalPlaylistList.Count; i++) {
				if (LocalPlaylistList[i].GUID == PlaylistGUID) {
					LocalPlaylistList.RemoveAt(i);
					return;
				}
			}
		}

		/// <summary>
		/// Adds a list of SongInfo objects to a playlist by playlist name.
		/// </summary>
		/// <param name="SongInfoList">List of SongInfo objects</param>
		/// <param name="PlaylistGUID">GUID of playlist to add songs to</param>
		/// <returns>Integer revealing number of songs successfully added to the playlist.</returns>
		public static int AddSongInfoListToPlaylist(List<SongInfo> SongInfoList, String PlaylistGUID) {
			int successfulCount = 0;
			int indexToEdit = -1;
			for (int i = 0; i < LocalPlaylistList.Count; i++) {
				if (LocalPlaylistList[i].GUID == PlaylistGUID) {
					indexToEdit = i;
					break;
				}
			}
			for (int i = 0; i < SongInfoList.Count; i++) {
				if (LocalPlaylistList[indexToEdit].AddSongToList(SongInfoList[i])) { successfulCount++; }
			}
			return successfulCount;
		}

		/// <summary>
		/// Overwrited the playlist related to PlaylistName with SongInfoList's contents.
		/// </summary>
		/// <param name="SongInfoList">List of SongInfo objects to populate the playlist with</param>
		/// <param name="PlaylistName">Name of playlist to overwrite</param>
		public static void OverwritePlaylistByName(List<SongInfo> SongInfoList, String PlaylistName) {
			for (int i = 0; i < LocalPlaylistList.Count; i++) {
				if (LocalPlaylistList[i].Name == PlaylistName) {
					LocalPlaylistList[i].SongList = SongInfoList;
					return;
				}
			}
		}

		/// <summary>
		/// Returns an int[] array containing attribute count data for a specific playlist.
		/// </summary>
		/// <param name="PlaylistName">Name of playlist to search for</param>
		/// <returns>int[0] = Total Songs, int[1] = Unique Artists, int[2] = Unique Albums</returns>
		public static int[] GetAttributeCountByName(String PlaylistName) {
			for (int i = 0; i < LocalPlaylistList.Count; i++) {
				if (LocalPlaylistList[i].Name == PlaylistName) {
					return LocalPlaylistList[i].GetAttributeCount();
				}
			}
			int[] tempReturn = { 0, 0, 0 };
			return tempReturn;
		}

	}
}
