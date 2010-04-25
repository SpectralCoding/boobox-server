using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BooBox;

namespace BooBoxServer {
	public partial class MainFrm : Form {

		#region Form Delegates
		public delegate void ChangeFormStateDelegate(String FormState);
		public void UpdateFormState(String FormState) {
			if (this.InvokeRequired) {
				this.Invoke(new ChangeFormStateDelegate(UpdateFormState), FormState);
			} else {
				if (FormState == "Minimize") {
					this.WindowState = FormWindowState.Minimized;
				} else if (FormState == "Normal") {
					this.WindowState = FormWindowState.Normal;
				}
			}
		}
		#endregion

		private Boolean ConfigLoaded = false;

		public MainFrm() {
			InitializeComponent();
		}

		private void AboutMenuItem_Click(object sender, EventArgs e) {
			AboutFrm AboutFrm = new AboutFrm();
			AboutFrm.Show();
		}

		private void MainFrm_Load(object sender, EventArgs e) {
			Forms.MainFrm = this;
			Log.AddStatusText("BooBox Server started.");
			ToolStripManager.Renderer = new ToolStripProfessionalRenderer(new MenuStripNoGradient());
			if (Config.Instance.Configured == false) {
				Log.AddStatusText("No configuration file loaded. Assuming new installation. Starting the First Run Wizard.");
				FirstRunFrm FirstRunFrm = new FirstRunFrm();
				FirstRunFrm.Show();
				this.WindowState = FormWindowState.Minimized;
			} else {
				ConfigLoaded = true;
			}
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

		private void DebugCmd_Click(object sender, EventArgs e) {
			FirstRunFrm FirstRunFrm = new FirstRunFrm();
			FirstRunFrm.Show();
		}

		private void MainFrm_FormClosed(object sender, FormClosedEventArgs e) {
			Config.Instance.Save();
			Log.AddStatusText("BooBox Server close by user.");
			Log.CloseLog();
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
		}

		private void Bytes1024MenuItem_Click(object sender, EventArgs e) {
			Log.AddStatusText("Changed Data Buffer Size from " + Config.Instance.DataBufferSize.ToString() + " bytes to 1024 bytes.");
			Config.Instance.DataBufferSize = 1024;
		}

		private void Bytes2048MenuItem_Click(object sender, EventArgs e) {
			Log.AddStatusText("Changed Data Buffer Size from " + Config.Instance.DataBufferSize.ToString() + " bytes to 2048 bytes.");
			Config.Instance.DataBufferSize = 2048;
		}

		private void Bytes4096MenuItem_Click(object sender, EventArgs e) {
			Log.AddStatusText("Changed Data Buffer Size from " + Config.Instance.DataBufferSize.ToString() + " bytes to 4096 bytes.");
			Config.Instance.DataBufferSize = 4096;
		}

		private void Bytes8192MenuItem_Click(object sender, EventArgs e) {
			Log.AddStatusText("Changed Data Buffer Size from " + Config.Instance.DataBufferSize.ToString() + " bytes to 8192 bytes.");
			Config.Instance.DataBufferSize = 8192;
		}

		private void ChangeServerNameMenuItem_Click(object sender, EventArgs e) {
			InputBoxResult ServerRequestBox = InputBox.Show(
				"Enter a Server Name:\n\nThis will be used to uniquely identify you to a Client.",
				"Server Name Entry"
			);
			if (ServerRequestBox.ReturnCode == DialogResult.OK) {
				Log.AddStatusText("Changed server name from \"" + Config.Instance.ServerName + "\" to \"" + ServerRequestBox.Text + "\".");
				Config.Instance.ServerName = ServerRequestBox.Text;
				Config.Instance.Save();
			}
		}
	}

}
