using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using BooBox;

namespace BooBoxServer {
	public partial class MainFrm : Form {

		// TODO: Save window state and size between sessions.

		#region Form Variables
		private Boolean ConfigLoaded = false;
		private ContextMenu MusicLibraryCM = new ContextMenu();
		#endregion

		#region Form Functions
		public MainFrm() {
			InitializeComponent();
		}
		private void PopulatePlaylistComb() {
			PlaylistComb.Items.Clear();
			String[] tempString = PlaylistManager.ListPlaylists();
			for (int i = 0; i < tempString.Length; i++) {
				PlaylistComb.Items.Add(tempString[i]);
			}
		}
		private void SaveCurrentPlaylist() {
			List<SongInfo> tempSIL = new List<SongInfo>();
			for (int i = 0; i < PlaylistDGV.RowCount; i++) {
				tempSIL.Add((SongInfo)PlaylistDGV.Rows[i].Tag);
				PlaylistDGV.Rows[i].Cells[0].Value = i;
			}
			PlaylistManager.OverwritePlaylistByName(tempSIL, PlaylistComb.SelectedItem.ToString().Substring(0, PlaylistComb.SelectedItem.ToString().LastIndexOf(" (")));
			PlaylistComb.Text = PlaylistComb.SelectedItem.ToString().Substring(0, PlaylistComb.SelectedItem.ToString().LastIndexOf(" (")) + " (" + PlaylistDGV.Rows.Count + ")";
		}
		private void UpdatePlaylistButtons() {
			if (PlaylistDGV.SelectedRows.Count > 0) {
				ArrayList SelectionAL = new ArrayList();
				for (int i = 0; i < PlaylistDGV.SelectedRows.Count; i++) { SelectionAL.Add(PlaylistDGV.SelectedRows[i].Index); }
				SelectionAL.Sort();
				UpCmd.Enabled = true;
				ToTopCmd.Enabled = true;
				DownCmd.Enabled = true;
				ToBottomCmd.Enabled = true;
				DelCmd.Enabled = true;
				if ((int)SelectionAL[0] == 0) {
					UpCmd.Enabled = false;
					ToTopCmd.Enabled = false;
				}
				if ((int)SelectionAL[SelectionAL.Count - 1] == (PlaylistDGV.Rows.Count - 1)) {
					DownCmd.Enabled = false;
					ToBottomCmd.Enabled = false;
				}
			} else {
				UpCmd.Enabled = false;
				ToTopCmd.Enabled = false;
				DownCmd.Enabled = false;
				ToBottomCmd.Enabled = false;
				DelCmd.Enabled = false;
			}
		}
		#endregion

		#region Form Delegates
		public delegate void PushSettingsToFormDelegate();
		public void PushSettingsToForm() {
			if (this.InvokeRequired) {
				this.Invoke(new PushSettingsToFormDelegate(PushSettingsToForm));
			} else {
				this.Text = "BooBox Server : " + Config.Instance.ServerName;
				if (Config.Instance.PasswordRequired == false) {
					ChangeServerPasswordMenuItem.Enabled = false; ToggleServerPasswordMenuItem.Text = "Enable Server Password";
				} else {
					ChangeServerPasswordMenuItem.Enabled = true; ToggleServerPasswordMenuItem.Text = "Disable Server Password";
				}
				if (Config.Instance.DataBufferSize == 512) {
					Bytes512MenuItem.Checked = true; Bytes1024MenuItem.Checked = false; Bytes2048MenuItem.Checked = false; Bytes4096MenuItem.Checked = false; Bytes8192MenuItem.Checked = false;
				} else if (Config.Instance.DataBufferSize == 1024) {
					Bytes512MenuItem.Checked = false; Bytes1024MenuItem.Checked = true; Bytes2048MenuItem.Checked = false; Bytes4096MenuItem.Checked = false; Bytes8192MenuItem.Checked = false;
				} else if (Config.Instance.DataBufferSize == 2048) {
					Bytes512MenuItem.Checked = false; Bytes1024MenuItem.Checked = false; Bytes2048MenuItem.Checked = true; Bytes4096MenuItem.Checked = false; Bytes8192MenuItem.Checked = false;
				} else if (Config.Instance.DataBufferSize == 4096) {
					Bytes512MenuItem.Checked = false; Bytes1024MenuItem.Checked = false; Bytes2048MenuItem.Checked = false; Bytes4096MenuItem.Checked = true; Bytes8192MenuItem.Checked = false;
				} else if (Config.Instance.DataBufferSize == 8192) {
					Bytes512MenuItem.Checked = false; Bytes1024MenuItem.Checked = false; Bytes2048MenuItem.Checked = false; Bytes4096MenuItem.Checked = false; Bytes8192MenuItem.Checked = true;
				}
				ToolStripDropDownItem RemoveFolderItem = (ToolStripDropDownItem)((ToolStripDropDownItem)MenuStrip.Items["FileMenuHeader"]).DropDownItems["RemoveFolderFromLibraryMenuItem"];
				RemoveFolderItem.DropDownItems.Clear();
				ToolStripMenuItem[] RemoveFolderItemArr = new ToolStripMenuItem[Config.Instance.LibraryFolderList.Count];
				for (int i = 0; i < Config.Instance.LibraryFolderList.Count; i++) {
					RemoveFolderItemArr[i] = new ToolStripMenuItem();
					RemoveFolderItemArr[i].Name = "RemoveItem" + i;
					RemoveFolderItemArr[i].Tag = Config.Instance.LibraryFolderList[i];
					RemoveFolderItemArr[i].Text = "Remove \"" + Config.Instance.LibraryFolderList[i] + "\"";
					RemoveFolderItemArr[i].Click += new EventHandler(MenuRemoveFolderClickHandler);
				}
				RemoveFolderItem.DropDownItems.AddRange(RemoveFolderItemArr);
			}
		}
		public delegate void UpdateStatusProgressBarDelegate(String Mode, int Param);
		public void UpdateStatusProgressBar(String Mode, int Param) {
			if (this.InvokeRequired) {
				this.Invoke(new UpdateStatusProgressBarDelegate(UpdateStatusProgressBar), Mode, Param);
			} else {
				if (Mode == "SetMax") {
					ProgressBarStatusStrip.Maximum = Param;
				} else if (Mode == "SetMin") {
					ProgressBarStatusStrip.Minimum = Param;
				} else if (Mode == "Increment") {
					ProgressBarStatusStrip.Increment(Param);
				} else if (Mode == "Reset") {
					ProgressBarStatusStrip.Value = 0;
				}
			}
		}
		public delegate void UpdateStatusLabelDelegate(String StatusText);
		public void UpdateStatusLabel(String StatusText) {
			if (this.InvokeRequired) {
				this.Invoke(new UpdateStatusLabelDelegate(UpdateStatusLabel), StatusText);
			} else {
				ProgressBarLblStatusStrip.Text = StatusText;
			}
		}
		public delegate void UpdateMusicLibraryDGVDelegate(List<SongInfo> SongList);
		public void UpdateMusicLibraryDGV(List<SongInfo> SongList) {
			if (this.InvokeRequired) {
				Thread WorkerThread = new Thread(delegate() { this.Invoke(new UpdateMusicLibraryDGVDelegate(UpdateMusicLibraryDGV), SongList); }); WorkerThread.Start();
			} else {
				int newRowNum, artistCount = 0, albumCount = 0;
				ArrayList artistList = new ArrayList();
				ArrayList albumList = new ArrayList();
				MusicLibraryDGV.Rows.Clear();
				for (int i = 0; i < SongList.Count; i++) {
					newRowNum = MusicLibraryDGV.Rows.Add();
					MusicLibraryDGV.Rows[newRowNum].Cells[0].Value = SongList[i].Title;
					MusicLibraryDGV.Rows[newRowNum].Cells[1].Value = Functions.StringArrToDelimitedStr(SongList[i].AlbumArtists, "; ");
					MusicLibraryDGV.Rows[newRowNum].Cells[2].Value = SongList[i].Album;
					MusicLibraryDGV.Rows[newRowNum].Cells[3].Value = Functions.MillisecondsToHumanReadable(SongList[i].PlayLength);
					MusicLibraryDGV.Rows[newRowNum].Cells[4].Value = Functions.BytesToHumanReadable(SongList[i].FileLength, 1);
					MusicLibraryDGV.Rows[newRowNum].Cells[5].Value = SongList[i].PlayCount;
					MusicLibraryDGV.Rows[newRowNum].Cells[6].Value = Functions.StringArrToDelimitedStr(SongList[i].Genres, "; ");
					MusicLibraryDGV.Rows[newRowNum].Cells[7].Value = SongList[i].Track;
					MusicLibraryDGV.Rows[newRowNum].Cells[8].Value = SongList[i].Year;
					MusicLibraryDGV.Rows[newRowNum].Cells[9].Value = SongList[i].Comment;
					MusicLibraryDGV.Rows[newRowNum].Cells[10].Value = SongList[i].FileName;
					MusicLibraryDGV.Rows[newRowNum].Cells[11].Value = SongList[i].PlayLength.ToString("00000000");
					MusicLibraryDGV.Rows[newRowNum].Cells[12].Value = SongList[i].FileLength.ToString("000000000");
					MusicLibraryDGV.Rows[newRowNum].Cells[13].Value = SongList[i].PlayCount.ToString("000000");
					MusicLibraryDGV.Rows[newRowNum].Cells[14].Value = SongList[i].Track.ToString("00000");
					MusicLibraryDGV.Rows[newRowNum].Cells[15].Value = SongList[i].Year.ToString("00000");
					if (!artistList.Contains(MusicLibraryDGV.Rows[newRowNum].Cells[1].Value)) {
						artistCount++;
						artistList.Add(MusicLibraryDGV.Rows[newRowNum].Cells[1].Value);
					}
					if (!albumList.Contains(SongList[i].Album)) {
						albumCount++;
						albumList.Add(SongList[i].Album);
					}
					MusicLibraryDGV.Rows[newRowNum].Tag = SongList[i];
				}
				MusicLibraryDGV.Sort(MusicLibraryDGV.Columns[0], ListSortDirection.Ascending);
				MusicLibraryDGV.Columns[0].HeaderText = "Title (" + SongList.Count + ")";
				MusicLibraryDGV.Columns[1].HeaderText = "Artists (" + artistCount + ")";
				MusicLibraryDGV.Columns[2].HeaderText = "Album (" + albumCount + ")";
			}
		}
		public delegate void UpdatePlaylistDGVDelegate(List<SongInfo> SongList);
		public void UpdatePlaylistDGV(List<SongInfo> SongList) {
			if (this.InvokeRequired) {
				Thread WorkerThread = new Thread(delegate() { this.Invoke(new UpdatePlaylistDGVDelegate(UpdatePlaylistDGV), SongList); }); WorkerThread.Start();
			} else {
				int newRowNum, artistCount = 0, albumCount = 0;
				ArrayList artistList = new ArrayList();
				ArrayList albumList = new ArrayList();
				PlaylistDGV.Rows.Clear();
				for (int i = 0; i < SongList.Count; i++) {
					newRowNum = PlaylistDGV.Rows.Add();
					PlaylistDGV.Rows[newRowNum].Cells[0].Value = i;
					PlaylistDGV.Rows[newRowNum].Cells[1].Value = SongList[i].Title;
					PlaylistDGV.Rows[newRowNum].Cells[2].Value = Functions.StringArrToDelimitedStr(SongList[i].AlbumArtists, "; ");
					PlaylistDGV.Rows[newRowNum].Cells[3].Value = SongList[i].Album;
					PlaylistDGV.Rows[newRowNum].Cells[4].Value = Functions.MillisecondsToHumanReadable(SongList[i].PlayLength);
					PlaylistDGV.Rows[newRowNum].Cells[5].Value = Functions.BytesToHumanReadable(SongList[i].FileLength, 1);
					PlaylistDGV.Rows[newRowNum].Cells[6].Value = SongList[i].PlayCount;
					PlaylistDGV.Rows[newRowNum].Cells[7].Value = Functions.StringArrToDelimitedStr(SongList[i].Genres, "; ");
					PlaylistDGV.Rows[newRowNum].Cells[8].Value = SongList[i].Track;
					PlaylistDGV.Rows[newRowNum].Cells[9].Value = SongList[i].Year;
					PlaylistDGV.Rows[newRowNum].Cells[10].Value = SongList[i].Comment;
					PlaylistDGV.Rows[newRowNum].Cells[11].Value = SongList[i].FileName;
					PlaylistDGV.Rows[newRowNum].Cells[12].Value = SongList[i].PlayLength.ToString("00000000");
					PlaylistDGV.Rows[newRowNum].Cells[13].Value = SongList[i].FileLength.ToString("000000000");
					PlaylistDGV.Rows[newRowNum].Cells[14].Value = SongList[i].PlayCount.ToString("000000");
					PlaylistDGV.Rows[newRowNum].Cells[15].Value = SongList[i].Track.ToString("00000");
					PlaylistDGV.Rows[newRowNum].Cells[16].Value = SongList[i].Year.ToString("00000");
					if (!artistList.Contains(PlaylistDGV.Rows[newRowNum].Cells[2].Value)) {
						artistCount++;
						artistList.Add(PlaylistDGV.Rows[newRowNum].Cells[2].Value);
					}
					if (!albumList.Contains(SongList[i].Album)) {
						albumCount++;
						albumList.Add(SongList[i].Album);
					}
					PlaylistDGV.Rows[newRowNum].Tag = SongList[i];
				}
				PlaylistDGV.Columns[1].HeaderText = "Title (" + SongList.Count + ")";
				PlaylistDGV.Columns[2].HeaderText = "Artists (" + artistCount + ")";
				PlaylistDGV.Columns[3].HeaderText = "Album (" + albumCount + ")";
				UpdatePlaylistButtons();
			}
		}
		#endregion

		#region Form Event Handlers
		private void MainFrm_Load(object sender, EventArgs e) {
			Forms.MainFrm = this;
			Log.AddStatusText("BooBox Server started.");
			ToolStripManager.Renderer = new ToolStripProfessionalRenderer(new MenuStripNoGradient());
			#region FirstRunFrm Stuff
			if (Config.Instance.Configured == false) {
				Log.AddStatusText("No configuration file loaded. Assuming new installation. Starting the First Run Wizard.");
				FirstRunFrm FirstRunFrm = new FirstRunFrm();
				FirstRunFrm.ShowDialog();
				ConfigLoaded = true;
			} else {
				ConfigLoaded = true;
			}
			#endregion
			Library.LoadSettings();
			PlaylistManager.PlaylistList = Config.Instance.PlaylistList;
			PushSettingsToForm();
			PopulatePlaylistComb();
			MusicLibraryDGV.ClearSelection();
			CommInfo.StartListening();
		}
		private void MainFrm_Resize(object sender, EventArgs e) {
			#region Vertical Calculations
			// Exact Calculation: 0.3922480620155039
			LibraryGrp.Height = Convert.ToInt32(this.Height * 0.3923);
			PlaylistComb.Top = LibraryGrp.Top + LibraryGrp.Height + 6;
			AddToPlaylistCmd.Top = PlaylistComb.Top - 2;
			DeletePlaylistCmd.Top = PlaylistComb.Top - 2;
			NewPlaylistCmd.Top = PlaylistComb.Top - 2;
			PlaylistGrp.Top = PlaylistComb.Top + 27;
			PlaylistGrp.Height = this.Height - PlaylistGrp.Top - 65;
			// Exact Calculation: 0.2119815668202765
			int PlaylistButtonHeight = Convert.ToInt32((PlaylistDGV.Height - 23) * 0.212);
			ToTopCmd.Height = PlaylistButtonHeight;
			UpCmd.Height = PlaylistButtonHeight;
			DelCmd.Height = Convert.ToInt32((PlaylistDGV.Height - 23) * 0.1521);
			DownCmd.Height = PlaylistButtonHeight;
			ToBottomCmd.Height = PlaylistButtonHeight;
			UpCmd.Top = ToTopCmd.Top + ToTopCmd.Height + 6;
			DelCmd.Top = UpCmd.Top + UpCmd.Height + 6;
			DownCmd.Top = DelCmd.Top + DelCmd.Height + 6;
			ToBottomCmd.Top = DownCmd.Top + DownCmd.Height + 6;
			#endregion
		}
		private void MainFrm_FormClosed(object sender, FormClosedEventArgs e) {
			Library.SaveSettings();
			Config.Instance.PlaylistList = PlaylistManager.PlaylistList;
			Config.Instance.Save();
			Log.AddStatusText("BooBox Server close by user.");
			Log.CloseLog();
		}
		#endregion

		#region Menu Item Event Handlers
		private void AddFolderToLibraryMenuItem_Click(object sender, EventArgs e) {
			FolderBrowserDialog.ShowDialog();
			String SelectedPath = FolderBrowserDialog.SelectedPath;
			if (SelectedPath != "") {
				if (SelectedPath.Substring(SelectedPath.Length - 1, 1) != "\\") {
					SelectedPath += "\\";
				}
				Thread WorkerThread = new Thread(delegate() { Library.AddFolder(SelectedPath); }); WorkerThread.Start();
			}
			FolderBrowserDialog.Reset();
		}
		private void RebuildLibraryMenuItem_Click(object sender, EventArgs e) {
			DialogResult tempMSResult = MessageBox.Show("Rebuilding your library can be very dangerous. Songs are uniqely identified to clients via ID3 Tags. If an ID3 Tag of a file has been changed since it was added to the library it will most likely break any instance of that song in your user's playlists.\n\nDo you REALLY want to rebuild your library?", "Really rebuild music library?", MessageBoxButtons.YesNo);
			if (tempMSResult == DialogResult.Yes) {
				Thread WorkerThread = new Thread(delegate() { Library.RebuildLibrary(); }); WorkerThread.Start();
			}
		}
		private void MenuRemoveFolderClickHandler(object sender, EventArgs e) {
			ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
			Library.RemoveFolder(clickedItem.Tag.ToString());
		}
		private void AboutMenuItem_Click(object sender, EventArgs e) {
			AboutFrm AboutFrm = new AboutFrm();
			AboutFrm.Show();
		}
		private void SaveSettingsMenuItem_Click(object sender, EventArgs e) {
			Config.Instance.Save();
		}
		private void ExportSettingsMenuItem_Click(object sender, EventArgs e) {
			SaveFileDialog.ShowDialog();
			String SaveFileAs = SaveFileDialog.FileName;
			if (SaveFileAs != "") {
				Config.Instance.Save(SaveFileAs);
			}
		}
		private void ImportSettingsMenuItem_Click(object sender, EventArgs e) {
			OpenFileDialog.ShowDialog();
			String OpenFilename = OpenFileDialog.FileName;
			if (OpenFilename != "") {
				Config.Instance.Load(OpenFilename);
			}
		}
		private void ExitMenuItem_Click(object sender, EventArgs e) {
			this.Close();
		}
		private void HelpMenuItem_Click(object sender, EventArgs e) {
			MessageBox.Show("Help not yet implemented.");
		}
		private void Bytes512MenuItem_Click(object sender, EventArgs e) {
			Log.AddStatusText("Changed Data Buffer Size from " + Config.Instance.DataBufferSize.ToString() + " bytes to 512 bytes.");
			Config.Instance.DataBufferSize = 512;
			PushSettingsToForm();
		}
		private void Bytes1024MenuItem_Click(object sender, EventArgs e) {
			Log.AddStatusText("Changed Data Buffer Size from " + Config.Instance.DataBufferSize.ToString() + " bytes to 1024 bytes.");
			Config.Instance.DataBufferSize = 1024;
			PushSettingsToForm();
		}
		private void Bytes2048MenuItem_Click(object sender, EventArgs e) {
			Log.AddStatusText("Changed Data Buffer Size from " + Config.Instance.DataBufferSize.ToString() + " bytes to 2048 bytes.");
			Config.Instance.DataBufferSize = 2048;
			PushSettingsToForm();
		}
		private void Bytes4096MenuItem_Click(object sender, EventArgs e) {
			Log.AddStatusText("Changed Data Buffer Size from " + Config.Instance.DataBufferSize.ToString() + " bytes to 4096 bytes.");
			Config.Instance.DataBufferSize = 4096;
			PushSettingsToForm();
		}
		private void Bytes8192MenuItem_Click(object sender, EventArgs e) {
			Log.AddStatusText("Changed Data Buffer Size from " + Config.Instance.DataBufferSize.ToString() + " bytes to 8192 bytes.");
			Config.Instance.DataBufferSize = 8192;
			PushSettingsToForm();
		}
		private void ChangeServerNameMenuItem_Click(object sender, EventArgs e) {
			InputBoxResult ServerRequestBox = InputBox.Show(
				"Enter a Server Name:\n\nThis will be used to uniquely identify you to a Client.",
				"Server Name Entry"
			);
			if (ServerRequestBox.ReturnCode == DialogResult.OK) {
				if (ServerRequestBox.Text.Length > 200) {
					MessageBox.Show("Server name may not be longer than 200 characters. Server name has not been changed.");
				} else {
					Log.AddStatusText("Changed server name from \"" + Config.Instance.ServerName + "\" to \"" + ServerRequestBox.Text + "\".");
					Config.Instance.ServerName = ServerRequestBox.Text;
					Config.Instance.Save();
				}
			}
			PushSettingsToForm();
		}
		private void ChangeListeningPortsMenuItem_Click(object sender, EventArgs e) {
			InputBoxResult PortRequestBox = InputBox.Show("Enter a new port for Information communications:", "Information Port Entry");
			if (PortRequestBox.ReturnCode == DialogResult.OK) {
				int tempPortInfo = Convert.ToInt32(PortRequestBox.Text);
				if ((tempPortInfo < 1) || (tempPortInfo > 65535)) {
					MessageBox.Show("Your Information Port number is invalid. Please choose a port between 1 and 65535. The port has not been changed.");
				} else {
					Log.AddStatusText("Changed Information Port from \"" + Config.Instance.CommInfoPort + "\" to \"" + tempPortInfo.ToString() + "\".");
					Config.Instance.CommInfoPort = tempPortInfo;
				}
			}
			PortRequestBox = InputBox.Show("Enter a new port for Transfer communications:", "Transfer Port Entry");
			if (PortRequestBox.ReturnCode == DialogResult.OK) {
				int tempPortInfo = Convert.ToInt32(PortRequestBox.Text);
				if ((tempPortInfo < 1) || (tempPortInfo > 65535)) {
					MessageBox.Show("Your Transfer Port number is invalid. Please choose a port between 1 and 65535. The port has not been changed.");
				} else {
					Log.AddStatusText("Changed Transfer Port from \"" + Config.Instance.CommStreamPort + "\" to \"" + tempPortInfo.ToString() + "\".");
					Config.Instance.CommStreamPort = tempPortInfo;
				}
			}
			Config.Instance.Save();
		}
		private void ToggleServerPasswordMenuItem_Click(object sender, EventArgs e) {
			if (Config.Instance.PasswordRequired == false) {
				Config.Instance.PasswordRequired = true;
				Log.AddStatusText("Enabled server password protection.");
			} else {
				Config.Instance.PasswordRequired = false;
				Log.AddStatusText("Disable server password protection.");
			}
			PushSettingsToForm();
		}
		private void ChangeServerPasswordMenuItem_Click(object sender, EventArgs e) {
			InputBoxResult PasswordRequestBox = InputBox.Show(
				"Please specify the a new password:",
				"Server Password Entry"
			);
			if (PasswordRequestBox.ReturnCode == DialogResult.OK) {
				if (PasswordRequestBox.Text.Length > 50) {
					MessageBox.Show("Your password must be less than 50 characters in length. Password has not been changed.");
				} else {
					Log.AddStatusText("Changed server password from \"" + Config.Instance.ServerPassword + "\" to \"" + PasswordRequestBox.Text + "\".");
					Config.Instance.ServerName = PasswordRequestBox.Text;
					Config.Instance.Save();
				}
			}
			PushSettingsToForm();
		}
		#endregion

		#region MusicLibraryDGV Event Handlers
		private void MusicLibraryDGV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
			MusicLibraryDGV.Columns[3].HeaderCell.SortGlyphDirection = SortOrder.None;
			MusicLibraryDGV.Columns[4].HeaderCell.SortGlyphDirection = SortOrder.None;
			MusicLibraryDGV.Columns[5].HeaderCell.SortGlyphDirection = SortOrder.None;
			MusicLibraryDGV.Columns[7].HeaderCell.SortGlyphDirection = SortOrder.None;
			MusicLibraryDGV.Columns[8].HeaderCell.SortGlyphDirection = SortOrder.None;
			if (e.ColumnIndex == 3) {
				#region Play Length Column
				if (MusicLibraryDGV.SortOrder == SortOrder.Ascending) {
					MusicLibraryDGV.Sort(MusicLibraryDGV.Columns[11], ListSortDirection.Descending);
					MusicLibraryDGV.Columns[3].HeaderCell.SortGlyphDirection = SortOrder.Descending;
				} else if (MusicLibraryDGV.SortOrder == SortOrder.Descending) {
					MusicLibraryDGV.Sort(MusicLibraryDGV.Columns[11], ListSortDirection.Ascending);
					MusicLibraryDGV.Columns[3].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
				}
				#endregion
			} else if (e.ColumnIndex == 4) {
				#region File Length Column
				if (MusicLibraryDGV.SortOrder == SortOrder.Ascending) {
					MusicLibraryDGV.Sort(MusicLibraryDGV.Columns[12], ListSortDirection.Descending);
					MusicLibraryDGV.Columns[4].HeaderCell.SortGlyphDirection = SortOrder.Descending;
				} else if (MusicLibraryDGV.SortOrder == SortOrder.Descending) {
					MusicLibraryDGV.Sort(MusicLibraryDGV.Columns[12], ListSortDirection.Ascending);
					MusicLibraryDGV.Columns[4].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
				}
				#endregion
			} else if (e.ColumnIndex == 5) {
				#region Play Count Column
				if (MusicLibraryDGV.SortOrder == SortOrder.Ascending) {
					MusicLibraryDGV.Sort(MusicLibraryDGV.Columns[13], ListSortDirection.Descending);
					MusicLibraryDGV.Columns[5].HeaderCell.SortGlyphDirection = SortOrder.Descending;
				} else if (MusicLibraryDGV.SortOrder == SortOrder.Descending) {
					MusicLibraryDGV.Sort(MusicLibraryDGV.Columns[13], ListSortDirection.Ascending);
					MusicLibraryDGV.Columns[5].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
				}
				#endregion
			} else if (e.ColumnIndex == 7) {
				#region Track Column
				if (MusicLibraryDGV.SortOrder == SortOrder.Ascending) {
					MusicLibraryDGV.Sort(MusicLibraryDGV.Columns[14], ListSortDirection.Descending);
					MusicLibraryDGV.Columns[7].HeaderCell.SortGlyphDirection = SortOrder.Descending;
				} else if (MusicLibraryDGV.SortOrder == SortOrder.Descending) {
					MusicLibraryDGV.Sort(MusicLibraryDGV.Columns[14], ListSortDirection.Ascending);
					MusicLibraryDGV.Columns[7].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
				}
				#endregion
			} else if (e.ColumnIndex == 8) {
				#region Year Column
				if (MusicLibraryDGV.SortOrder == SortOrder.Ascending) {
					MusicLibraryDGV.Sort(MusicLibraryDGV.Columns[15], ListSortDirection.Descending);
					MusicLibraryDGV.Columns[8].HeaderCell.SortGlyphDirection = SortOrder.Descending;
				} else if (MusicLibraryDGV.SortOrder == SortOrder.Descending) {
					MusicLibraryDGV.Sort(MusicLibraryDGV.Columns[15], ListSortDirection.Ascending);
					MusicLibraryDGV.Columns[8].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
				}
				#endregion
			}
		}
		private void MusicLibraryDGV_SelectionChanged(object sender, EventArgs e) {
			if (PlaylistComb.SelectedIndex != -1) { AddToPlaylistCmd.Enabled = true; }
			LibraryGrp.Text = "Music Library (" + MusicLibraryDGV.SelectedRows.Count + " Selected)";
		}
		private void MusicLibraryDGV_MouseUp(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Right) {
				MusicLibraryCM.MenuItems.Clear();
				MenuItem[] tempAddBySongCMMI = new MenuItem[PlaylistManager.PlaylistList.Count];
				for (int i = 0; i < PlaylistManager.PlaylistList.Count; i++) {
					tempAddBySongCMMI[i] = new MenuItem();
					tempAddBySongCMMI[i].Text = PlaylistManager.PlaylistList[i].Name;
					tempAddBySongCMMI[i].Click += new EventHandler(AddBySongCMMI_Click);
				}
				if (MusicLibraryDGV.SelectedRows.Count == 1) {
					MusicLibraryCM.MenuItems.Add("View Extended Song Info", new EventHandler(ViewExtendedSongInfoCMMI_Click)).Enabled = true;
					MusicLibraryCM.MenuItems.Add("-");
					MusicLibraryCM.MenuItems.Add("Add Selected Song To Playlist", tempAddBySongCMMI).Enabled = true;
				} else if (MusicLibraryDGV.SelectedRows.Count > 1) {
					MusicLibraryCM.MenuItems.Add("View Extended Song Info", new EventHandler(ViewExtendedSongInfoCMMI_Click)).Enabled = false;
					MusicLibraryCM.MenuItems.Add("-");
					MusicLibraryCM.MenuItems.Add("Add Selected Songs To Playlist", tempAddBySongCMMI).Enabled = true;
				} else {
					MusicLibraryCM.MenuItems.Add("View Extended Song Info", new EventHandler(ViewExtendedSongInfoCMMI_Click)).Enabled = false;
					MusicLibraryCM.MenuItems.Add("-");
					MusicLibraryCM.MenuItems.Add("Add Selected Song(s) To Playlist", tempAddBySongCMMI).Enabled = false;
				}
				MusicLibraryCM.MenuItems.Add("-");
				if (MusicLibraryDGV.SelectedRows.Count == 1) {
					MusicLibraryCM.MenuItems.Add("Select All By Selected Artist", new EventHandler(SelectAllByArtistCMMI_Click)).Enabled = true;
					MusicLibraryCM.MenuItems.Add("Select All In Selected Album", new EventHandler(SelectAllInAlbumCMMI_Click)).Enabled = true;
					MusicLibraryCM.MenuItems.Add("Select All In Selected Song's Folder", new EventHandler(SelectAllInFolderCMMI_Click)).Enabled = true;
					MusicLibraryCM.MenuItems.Add("Select All Matching Selected Song's Genre", new EventHandler(SelectAllInGenreCMMI_Click)).Enabled = true;
				} else {
					MusicLibraryCM.MenuItems.Add("Select All By Selected Artist", new EventHandler(SelectAllByArtistCMMI_Click)).Enabled = false;
					MusicLibraryCM.MenuItems.Add("Select All In Selected Album", new EventHandler(SelectAllInAlbumCMMI_Click)).Enabled = false;
					MusicLibraryCM.MenuItems.Add("Select All In Selected Song's Folder", new EventHandler(SelectAllInFolderCMMI_Click)).Enabled = false;
					MusicLibraryCM.MenuItems.Add("Select All Matching Selected Song's Genre", new EventHandler(SelectAllInGenreCMMI_Click)).Enabled = false;
				}
				MusicLibraryCM.MenuItems.Add("-");
				if (MusicLibraryDGV.SelectedRows.Count == 0) {
					MusicLibraryCM.MenuItems.Add("Clear Selection", new EventHandler(ClearSelectionCMMI_Click)).Enabled = false;
				} else {
					MusicLibraryCM.MenuItems.Add("Clear Selection", new EventHandler(ClearSelectionCMMI_Click)).Enabled = true;
				}
				MusicLibraryDGV.ContextMenu = MusicLibraryCM;
				MusicLibraryCM.Show(MusicLibraryDGV, new Point(e.X, e.Y));
			}
		}
		private void ViewExtendedSongInfoCMMI_Click(object sender, EventArgs e) {
			SongInfo tempSongInfo = (SongInfo)MusicLibraryDGV.SelectedRows[0].Tag;
			MessageBox.Show(
				"Extended Song Information\n" +
				"\n" +
				"Title: " + tempSongInfo.Title + "\n" +
				"Artist(s): " + Functions.StringArrToDelimitedStr(tempSongInfo.AlbumArtists, "; ") + "\n" +
				"Album: " + tempSongInfo.Album + "\n" +
				"Length: " + Functions.MillisecondsToHumanReadable(tempSongInfo.PlayLength) + "\n" +
				"Track: " + tempSongInfo.Track.ToString() + " of " + tempSongInfo.TrackCount.ToString() + "\n" +
				"Year: " + tempSongInfo.Year + "\n" +
				"Bitrate: " + tempSongInfo.BitRate.ToString() + "kbps\n" +
				"Genre(s): " + Functions.StringArrToDelimitedStr(tempSongInfo.Genres, "; ") + "\n" +
				"Comment: " + tempSongInfo.Comment + "\n" +
				"Play Count: " + tempSongInfo.PlayCount + "\n" +
				"Filename: " + tempSongInfo.FileName + "\n" +
				"Filesize: " + Functions.BytesToHumanReadable(tempSongInfo.FileLength, 3) + "\n" +
				"Metadata Size: " + Functions.BytesToHumanReadable(tempSongInfo.StartByte, 3) + "\n" +
				"Audio Data Range: " + Functions.BytesToHumanReadable(tempSongInfo.StartByte, 3) + " - " + Functions.BytesToHumanReadable(tempSongInfo.EndByte, 3) + "\n"
			);
		}
		private void AddBySongCMMI_Click(object sender, EventArgs e) {
			String playlistName = ((MenuItem)sender).Text;
			List<SongInfo> tempSIL = new List<SongInfo>();
			for (int i = 0; i < MusicLibraryDGV.SelectedRows.Count; i++) {
				tempSIL.Add((SongInfo)MusicLibraryDGV.SelectedRows[i].Tag);
			}
			int successfulCount = PlaylistManager.AddSongInfoListToPlaylist(tempSIL, playlistName);
			UpdatePlaylistDGV(PlaylistManager.GetPlaylistListByName(playlistName));
			UpdateStatusLabel("Added " + successfulCount + " songs (" + (tempSIL.Count - successfulCount) + " duplicates skipped) to the \"" + playlistName + "\" playlist.");
		}
		private void SelectAllByArtistCMMI_Click(object sender, EventArgs e) {
			String tempCompare = MusicLibraryDGV.SelectedRows[0].Cells[1].Value.ToString();
			for (int i = 0; i < MusicLibraryDGV.Rows.Count; i++) {
				if (MusicLibraryDGV.Rows[i].Cells[1].Value != null) {
					if (MusicLibraryDGV.Rows[i].Cells[1].Value.ToString() == tempCompare) {
						MusicLibraryDGV.Rows[i].Selected = true;
					}
				}
			}
		}
		private void SelectAllInAlbumCMMI_Click(object sender, EventArgs e) {
			String tempCompare = MusicLibraryDGV.SelectedRows[0].Cells[2].Value.ToString();
			for (int i = 0; i < MusicLibraryDGV.Rows.Count; i++) {
				if (MusicLibraryDGV.Rows[i].Cells[2].Value != null) {
					if (MusicLibraryDGV.Rows[i].Cells[2].Value.ToString() == tempCompare) {
						MusicLibraryDGV.Rows[i].Selected = true;
					}
				}
			}
		}
		private void SelectAllInFolderCMMI_Click(object sender, EventArgs e) {
			String tempCompare = MusicLibraryDGV.SelectedRows[0].Cells[10].Value.ToString();
			tempCompare = System.IO.Path.GetDirectoryName(tempCompare);
			Console.WriteLine(tempCompare);
			for (int i = 0; i < MusicLibraryDGV.Rows.Count; i++) {
				if (MusicLibraryDGV.Rows[i].Cells[10].Value != null) {
					if (System.IO.Path.GetDirectoryName(MusicLibraryDGV.Rows[i].Cells[10].Value.ToString()) == tempCompare) {
						MusicLibraryDGV.Rows[i].Selected = true;
					}
				}
			}
		}
		private void SelectAllInGenreCMMI_Click(object sender, EventArgs e) {
			String[] strSplit = new String[] { "; " };
			String[] srcGenres = MusicLibraryDGV.SelectedRows[0].Cells[6].Value.ToString().Split(strSplit, StringSplitOptions.RemoveEmptyEntries);
			String[] testGenres;
			foreach (String temp in srcGenres) { Console.WriteLine("-" + temp + "-"); }
			for (int i = 0; i < MusicLibraryDGV.Rows.Count; i++) {
				if (MusicLibraryDGV.Rows[i].Cells[6].Value != null) {
					testGenres = MusicLibraryDGV.Rows[i].Cells[6].Value.ToString().Split(strSplit, StringSplitOptions.RemoveEmptyEntries);
					for (int x = 0; x < testGenres.Length; x++) {
						for (int y = 0; y < srcGenres.Length; y++) {
							if (testGenres[x] == srcGenres[y]) {
								MusicLibraryDGV.Rows[i].Selected = true;
								break;
							}
						}
					}
				}
			}
		}
		private void ClearSelectionCMMI_Click(object sender, EventArgs e) {
			MusicLibraryDGV.ClearSelection();
			AddToPlaylistCmd.Enabled = false;
		}
		#endregion

		#region PlaylistDGV Event Handlers
		private void PlaylistDGV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
			PlaylistDGV.Columns[4].HeaderCell.SortGlyphDirection = SortOrder.None;
			PlaylistDGV.Columns[5].HeaderCell.SortGlyphDirection = SortOrder.None;
			PlaylistDGV.Columns[6].HeaderCell.SortGlyphDirection = SortOrder.None;
			PlaylistDGV.Columns[8].HeaderCell.SortGlyphDirection = SortOrder.None;
			PlaylistDGV.Columns[9].HeaderCell.SortGlyphDirection = SortOrder.None;
			if (e.ColumnIndex == 4) {
				#region Play Length Column
				if (PlaylistDGV.SortOrder == SortOrder.Ascending) {
					PlaylistDGV.Sort(PlaylistDGV.Columns[12], ListSortDirection.Descending);
					PlaylistDGV.Columns[4].HeaderCell.SortGlyphDirection = SortOrder.Descending;
				} else {
					PlaylistDGV.Sort(PlaylistDGV.Columns[12], ListSortDirection.Ascending);
					PlaylistDGV.Columns[4].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
				}
				#endregion
			} else if (e.ColumnIndex == 5) {
				#region File Length Column
				if (PlaylistDGV.SortOrder == SortOrder.Ascending) {
					PlaylistDGV.Sort(PlaylistDGV.Columns[13], ListSortDirection.Descending);
					PlaylistDGV.Columns[5].HeaderCell.SortGlyphDirection = SortOrder.Descending;
				} else {
					PlaylistDGV.Sort(PlaylistDGV.Columns[13], ListSortDirection.Ascending);
					PlaylistDGV.Columns[5].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
				}
				#endregion
			} else if (e.ColumnIndex == 6) {
				#region Play Count Column
				if (PlaylistDGV.SortOrder == SortOrder.Ascending) {
					PlaylistDGV.Sort(PlaylistDGV.Columns[14], ListSortDirection.Descending);
					PlaylistDGV.Columns[6].HeaderCell.SortGlyphDirection = SortOrder.Descending;
				} else {
					PlaylistDGV.Sort(PlaylistDGV.Columns[14], ListSortDirection.Ascending);
					PlaylistDGV.Columns[6].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
				}
				#endregion
			} else if (e.ColumnIndex == 8) {
				#region Track Column
				if (PlaylistDGV.SortOrder == SortOrder.Ascending) {
					PlaylistDGV.Sort(PlaylistDGV.Columns[15], ListSortDirection.Descending);
					PlaylistDGV.Columns[8].HeaderCell.SortGlyphDirection = SortOrder.Descending;
				} else {
					PlaylistDGV.Sort(PlaylistDGV.Columns[15], ListSortDirection.Ascending);
					PlaylistDGV.Columns[8].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
				}
				#endregion
			} else if (e.ColumnIndex == 9) {
				#region Year Column
				if (PlaylistDGV.SortOrder == SortOrder.Ascending) {
					PlaylistDGV.Sort(PlaylistDGV.Columns[16], ListSortDirection.Descending);
					PlaylistDGV.Columns[9].HeaderCell.SortGlyphDirection = SortOrder.Descending;
				} else {
					PlaylistDGV.Sort(PlaylistDGV.Columns[16], ListSortDirection.Ascending);
					PlaylistDGV.Columns[9].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
				}
				#endregion
			}
			SaveCurrentPlaylist();
		}
		private void PlaylistDGV_SelectionChanged(object sender, EventArgs e) {
			UpdatePlaylistButtons();
			PlaylistGrp.Text = "Playlist (" + PlaylistDGV.SelectedRows.Count + " Selected)";
		}
		#endregion

		#region PlaylistComb Event Handlers
		private void PlaylistComb_SelectedIndexChanged(object sender, EventArgs e) {
			DeletePlaylistCmd.Enabled = true;
			if (MusicLibraryDGV.SelectedRows.Count > 0) { AddToPlaylistCmd.Enabled = true; }
			if (PlaylistComb.SelectedIndex != -1) {
				UpdatePlaylistDGV(PlaylistManager.GetPlaylistListByName(PlaylistComb.SelectedItem.ToString().Substring(0, PlaylistComb.SelectedItem.ToString().LastIndexOf(" ("))));
				UpCmd.Enabled = false; ToTopCmd.Enabled = false; DownCmd.Enabled = true; ToBottomCmd.Enabled = true; DelCmd.Enabled = true;
				PlaylistDGV.Focus();
			} else {
				PlaylistDGV.Rows.Clear();
				UpCmd.Enabled = false; ToTopCmd.Enabled = false; DownCmd.Enabled = false; ToBottomCmd.Enabled = false; DelCmd.Enabled = false;
			}
		}
		private void PlaylistComb_KeyPress(object sender, KeyPressEventArgs e) {
			e.Handled = true;
		}
		private void PlaylistComb_Click(object sender, EventArgs e) {
			PopulatePlaylistComb();
		}
		#endregion

		#region Playlist Button Event Handlers
		private void NewPlaylistCmd_Click(object sender, EventArgs e) {
			InputBoxResult PlaylistRequestBox = InputBox.Show(
				"Enter a name for your playlist:",
				"Playlist Name Entry"
			);
			if (PlaylistRequestBox.ReturnCode == DialogResult.OK) {
				if (PlaylistRequestBox.Text.Length > 200) {
					MessageBox.Show("Playlist names may not be longer than 200 characters. Playlist has not been created.");
				} else {
					Log.AddStatusText("Created playlist: " + PlaylistRequestBox.Text);
					Boolean playlistCreationSuccessful = PlaylistManager.CreatePlaylist(PlaylistRequestBox.Text);
					if (playlistCreationSuccessful) {
						PopulatePlaylistComb();
						for (int i = 0; i < PlaylistComb.Items.Count; i++) {
							if (PlaylistComb.Items[i].ToString().Substring(0, PlaylistComb.Items[i].ToString().LastIndexOf(" (")) == PlaylistRequestBox.Text) {
								PlaylistComb.SelectedIndex = i;
								break;
							}
						}
					}
				}
			}
		}
		private void DeletePlaylistCmd_Click(object sender, EventArgs e) {
			UpdateStatusLabel("Deleted the \"" + PlaylistComb.SelectedItem.ToString().Substring(0, PlaylistComb.SelectedItem.ToString().LastIndexOf(" (")) + "\" playlist.");
			PlaylistManager.DeletePlaylistByName(PlaylistComb.SelectedItem.ToString().Substring(0, PlaylistComb.SelectedItem.ToString().LastIndexOf(" (")));
			PlaylistComb.SelectedIndex = -1;
			PopulatePlaylistComb();
		}
		private void AddToPlaylistCmd_Click(object sender, EventArgs e) {
			List<SongInfo> tempSIL = new List<SongInfo>();
			for (int i = 0; i < MusicLibraryDGV.SelectedRows.Count; i++) {
				tempSIL.Add((SongInfo)MusicLibraryDGV.SelectedRows[i].Tag);
			}
			int successfulCount = PlaylistManager.AddSongInfoListToPlaylist(tempSIL, PlaylistComb.SelectedItem.ToString().Substring(0, PlaylistComb.SelectedItem.ToString().LastIndexOf(" (")));
			UpdatePlaylistDGV(PlaylistManager.GetPlaylistListByName(PlaylistComb.SelectedItem.ToString().Substring(0, PlaylistComb.SelectedItem.ToString().LastIndexOf(" ("))));
			UpdateStatusLabel("Added " + successfulCount + " songs (" + (tempSIL.Count - successfulCount) + " duplicates skipped) to the \"" + PlaylistComb.SelectedItem.ToString().Substring(0, PlaylistComb.SelectedItem.ToString().LastIndexOf(" (")) + "\" playlist.");
		}
		private void ToTopCmd_Click(object sender, EventArgs e) {
			ArrayList SelectionAL = new ArrayList();
			for (int i = 0; i < PlaylistDGV.SelectedRows.Count; i++) { SelectionAL.Add(PlaylistDGV.SelectedRows[i].Index); }
			SelectionAL.Sort();
			int topIndex = (int)SelectionAL[0];
			DataGridViewRow tempDGVR;
			for (int i = SelectionAL.Count - 1; i > -1; i--) {
				tempDGVR = PlaylistDGV.Rows[(int)SelectionAL[i]];
				PlaylistDGV.Rows.RemoveAt((int)SelectionAL[i]);
				PlaylistDGV.Rows.Insert(0, tempDGVR);
			}
			PlaylistDGV.ClearSelection();
			for (int i = 0; i < SelectionAL.Count; i++) { PlaylistDGV.Rows[i].Selected = true; }
			SaveCurrentPlaylist();
		}
		private void UpCmd_Click(object sender, EventArgs e) {
			ArrayList SelectionAL = new ArrayList();
			for (int i = 0; i < PlaylistDGV.SelectedRows.Count; i++) { SelectionAL.Add(PlaylistDGV.SelectedRows[i].Index); }
			SelectionAL.Sort();
			int topIndex = (int)SelectionAL[0];
			DataGridViewRow tempDGVR;
			for (int i = 0; i < SelectionAL.Count; i++) {
				tempDGVR = PlaylistDGV.Rows[(int)SelectionAL[i]];
				PlaylistDGV.Rows.RemoveAt((int)SelectionAL[i]);
				PlaylistDGV.Rows.Insert((int)SelectionAL[i] - 1, tempDGVR);
			}
			PlaylistDGV.ClearSelection();
			for (int i = 0; i < SelectionAL.Count; i++) { PlaylistDGV.Rows[(int)SelectionAL[i] - 1].Selected = true; }
			SaveCurrentPlaylist();
		}
		private void DelCmd_Click(object sender, EventArgs e) {
			ArrayList SelectionAL = new ArrayList();
			for (int i = 0; i < PlaylistDGV.SelectedRows.Count; i++) { SelectionAL.Add(PlaylistDGV.SelectedRows[i].Index); }
			SelectionAL.Sort();
			int topIndex = (int)SelectionAL[0];
			for (int i = SelectionAL.Count - 1; i > -1; i--) { PlaylistDGV.Rows.RemoveAt((int)SelectionAL[i]); }
			SaveCurrentPlaylist();
			int[] tempAttributeCount = PlaylistManager.GetAttributeCountByName(PlaylistComb.SelectedItem.ToString().Substring(0, PlaylistComb.SelectedItem.ToString().LastIndexOf(" (")));
			PlaylistDGV.Columns[1].HeaderText = "Title (" + tempAttributeCount[0] + ")";
			PlaylistDGV.Columns[2].HeaderText = "Artists (" + tempAttributeCount[1] + ")";
			PlaylistDGV.Columns[3].HeaderText = "Album (" + tempAttributeCount[2] + ")";
			if (PlaylistDGV.Rows.Count > 0) {
				if (topIndex == 0) {
					PlaylistDGV.CurrentCell = PlaylistDGV.Rows[0].Cells[0];
				} else if (topIndex == PlaylistDGV.Rows.Count) {
					PlaylistDGV.CurrentCell = PlaylistDGV.Rows[topIndex - 1].Cells[0];
				} else {
					PlaylistDGV.CurrentCell = PlaylistDGV.Rows[topIndex].Cells[0];
				}
			} else {
				DelCmd.Enabled = false;
			}
		}
		private void DownCmd_Click(object sender, EventArgs e) {
			ArrayList SelectionAL = new ArrayList();
			for (int i = 0; i < PlaylistDGV.SelectedRows.Count; i++) { SelectionAL.Add(PlaylistDGV.SelectedRows[i].Index); }
			SelectionAL.Sort();
			int topIndex = (int)SelectionAL[0];
			DataGridViewRow tempDGVR;
			for (int i = SelectionAL.Count - 1; i > -1; i--) {
				tempDGVR = PlaylistDGV.Rows[(int)SelectionAL[i]];
				PlaylistDGV.Rows.RemoveAt((int)SelectionAL[i]);
				PlaylistDGV.Rows.Insert((int)SelectionAL[i] + 1, tempDGVR);
			}
			PlaylistDGV.ClearSelection();
			for (int i = 0; i < SelectionAL.Count; i++) { PlaylistDGV.Rows[(int)SelectionAL[i] + 1].Selected = true; }
			SaveCurrentPlaylist();
		}
		private void ToBottomCmd_Click(object sender, EventArgs e) {
			ArrayList SelectionAL = new ArrayList();
			for (int i = 0; i < PlaylistDGV.SelectedRows.Count; i++) { SelectionAL.Add(PlaylistDGV.SelectedRows[i].Index); }
			SelectionAL.Sort();
			int topIndex = (int)SelectionAL[0];
			DataGridViewRow tempDGVR;
			for (int i = 0; i < SelectionAL.Count; i++) {
				tempDGVR = PlaylistDGV.Rows[(int)SelectionAL[i] - i];
				PlaylistDGV.Rows.RemoveAt((int)SelectionAL[i] - i);
				PlaylistDGV.Rows.Insert(PlaylistDGV.Rows.Count, tempDGVR);
			}
			PlaylistDGV.ClearSelection();
			for (int i = 0; i < SelectionAL.Count; i++) { PlaylistDGV.Rows[PlaylistDGV.Rows.Count - 1 - i].Selected = true; }
			SaveCurrentPlaylist();
		}
		#endregion

		private void DebugCmd_Click(object sender, EventArgs e) {
			PlaylistManager.PrintPlaylistTree();
		}

	}
}
