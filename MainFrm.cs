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
		public MainFrm() {
			InitializeComponent();
		}

		private void AboutMenuItem_Click(object sender, EventArgs e) {
			AboutFrm AboutFrm = new AboutFrm();
			AboutFrm.Show();
		}

		private void MainFrm_Load(object sender, EventArgs e) {

			ToolStripManager.Renderer = new ToolStripProfessionalRenderer(new MenuStripNoGradient());
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
			Log.CloseLog();
		}
	}
}
