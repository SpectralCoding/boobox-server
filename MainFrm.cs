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

		#region Form Variables
		private Boolean ConfigLoaded = false;
		#endregion

		#region Form Functions
		public MainFrm() {
			InitializeComponent();
		}
		private void PushSettingsToForm() {
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
		#endregion

		#region Form Delegates
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
				}
				MusicLibraryDGV.Sort(MusicLibraryDGV.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
				MusicLibraryDGV.Columns[0].HeaderText = "Title (" + SongList.Count + ")";
				MusicLibraryDGV.Columns[1].HeaderText = "Artists (" + artistCount + ")";
				MusicLibraryDGV.Columns[2].HeaderText = "Album (" + albumCount + ")";
			}
		}
		#endregion

		#region MusicLibraryDGV Event Handlers
		private void MusicLibraryDGV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
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
			} else {
				MusicLibraryDGV.Columns[3].HeaderCell.SortGlyphDirection = SortOrder.None;
				MusicLibraryDGV.Columns[4].HeaderCell.SortGlyphDirection = SortOrder.None;
				MusicLibraryDGV.Columns[5].HeaderCell.SortGlyphDirection = SortOrder.None;
				MusicLibraryDGV.Columns[7].HeaderCell.SortGlyphDirection = SortOrder.None;
				MusicLibraryDGV.Columns[8].HeaderCell.SortGlyphDirection = SortOrder.None;
			}
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
			PushSettingsToForm();
		}
		private void RebuildLibraryMenuItem_Click(object sender, EventArgs e) {
			Thread WorkerThread = new Thread(delegate() { Library.RebuildLibrary(); });
			WorkerThread.Start();
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

		#region Form Event Handlers
		private void MainFrm_Load(object sender, EventArgs e) {
			Forms.MainFrm = this;
			Log.AddStatusText("BooBox Server started.");
			ToolStripManager.Renderer = new ToolStripProfessionalRenderer(new MenuStripNoGradient());
			if (Config.Instance.Configured == false) {
				Log.AddStatusText("No configuration file loaded. Assuming new installation. Starting the First Run Wizard.");
				FirstRunFrm FirstRunFrm = new FirstRunFrm();
				FirstRunFrm.ShowDialog();
				ConfigLoaded = true;
			} else {
				ConfigLoaded = true;
			}
			Library.LoadSettings();
			PushSettingsToForm();
			CommInfo.StartListening();
		}
		private void MainFrm_Resize(object sender, EventArgs e) {
			#region Horizontal Calculations
			//LibraryGrp.Width = this.Width - 28;
			//LibraryDGV.Width = LibraryGrp.Width - 12;
			//PlaylistComb.Width = this.Width - 307;
			//AddToPlaylistCmd.Left = this.Width - 289;
			//DeletePlaylistCmd.Left = this.Width - 198;
			//NewPlaylistCmd.Left = this.Width - 107;
			//PlaylistGrp.Width = this.Width - 28;
			//PlaylistDGV.Width = PlaylistGrp.Width - 51;
			//ToTopCmd.Left = PlaylistGrp.Width - 39;
			//UpCmd.Left = PlaylistGrp.Width - 39;
			//DelCmd.Left = PlaylistGrp.Width - 39;
			//DownCmd.Left = PlaylistGrp.Width - 39;
			//ToBottomCmd.Left = PlaylistGrp.Width - 39;
			#endregion
			#region Vertical Calculations
			// Exact Calculation: 0.3922480620155039
			LibraryGrp.Height = Convert.ToInt32(this.Height * 0.3923);
			//LibraryDGV.Height = LibraryGrp.Height - 26;
			PlaylistComb.Top = LibraryGrp.Top + LibraryGrp.Height + 6;
			AddToPlaylistCmd.Top = PlaylistComb.Top - 2;
			DeletePlaylistCmd.Top = PlaylistComb.Top - 2;
			NewPlaylistCmd.Top = PlaylistComb.Top - 2;
			PlaylistGrp.Top = PlaylistComb.Top + 27;
			PlaylistGrp.Height = this.Height - PlaylistGrp.Top - 65;
			//PlaylistDGV.Height = PlaylistGrp.Height - 26;
			// Exact Calculation: 0.2119815668202765
			int PlaylistButtonHeight = Convert.ToInt32((PlaylistDGV.Height - 23) * 0.212);
			ToTopCmd.Height = PlaylistButtonHeight;
			UpCmd.Height = PlaylistButtonHeight;
			// Exact Calculation: 0.152073732718894
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
			Config.Instance.Save();
			Log.AddStatusText("BooBox Server close by user.");
			Log.CloseLog();
		}
		#endregion

		private void DebugCmd_Click(object sender, EventArgs e) {
			FirstRunFrm FirstRunFrm = new FirstRunFrm();
			FirstRunFrm.ShowDialog();
		}


	}
}
