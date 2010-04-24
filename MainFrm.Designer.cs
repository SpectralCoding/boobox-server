namespace BooBoxServer {
	partial class MainFrm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.MenuStrip = new System.Windows.Forms.MenuStrip();
			this.FileMenuHeader = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.AddFolderToLibraryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.RemoveFolderFromLibraryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.RebuildLibraryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.ExportSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ImportSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OptionsHeaderMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.DataBufferSizeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Bytes512MenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Bytes1024MenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Bytes2048MenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Bytes4096MenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Bytes8192MenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ChangeServerNameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ChangeListeningPortsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.ToggleServerPasswordMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ChangeServerPasswordMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpMenuHeader = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.ProgressBarStatusStrip = new System.Windows.Forms.ToolStripProgressBar();
			this.ProgressBarLblStatusStrip = new System.Windows.Forms.ToolStripStatusLabel();
			this.LibraryGrp = new System.Windows.Forms.GroupBox();
			this.LibraryDGV = new System.Windows.Forms.DataGridView();
			this.PlaylistGrp = new System.Windows.Forms.GroupBox();
			this.DelCmd = new System.Windows.Forms.Button();
			this.ToBottomCmd = new System.Windows.Forms.Button();
			this.DownCmd = new System.Windows.Forms.Button();
			this.UpCmd = new System.Windows.Forms.Button();
			this.ToTopCmd = new System.Windows.Forms.Button();
			this.PlaylistDGV = new System.Windows.Forms.DataGridView();
			this.PlaylistComb = new System.Windows.Forms.ComboBox();
			this.AddToPlaylistCmd = new System.Windows.Forms.Button();
			this.DeletePlaylistCmd = new System.Windows.Forms.Button();
			this.NewPlaylistCmd = new System.Windows.Forms.Button();
			this.MenuStrip.SuspendLayout();
			this.StatusStrip.SuspendLayout();
			this.LibraryGrp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LibraryDGV)).BeginInit();
			this.PlaylistGrp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PlaylistDGV)).BeginInit();
			this.SuspendLayout();
			// 
			// MenuStrip
			// 
			this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuHeader,
            this.OptionsHeaderMenu,
            this.HelpMenuHeader});
			this.MenuStrip.Location = new System.Drawing.Point(0, 0);
			this.MenuStrip.Name = "MenuStrip";
			this.MenuStrip.Size = new System.Drawing.Size(711, 24);
			this.MenuStrip.TabIndex = 0;
			// 
			// FileMenuHeader
			// 
			this.FileMenuHeader.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveSettingsMenuItem,
            this.toolStripMenuItem2,
            this.AddFolderToLibraryMenuItem,
            this.RemoveFolderFromLibraryMenuItem,
            this.RebuildLibraryMenuItem,
            this.toolStripMenuItem4,
            this.ExportSettingsMenuItem,
            this.ImportSettingsMenuItem,
            this.toolStripMenuItem3,
            this.ExitMenuItem});
			this.FileMenuHeader.Name = "FileMenuHeader";
			this.FileMenuHeader.Size = new System.Drawing.Size(37, 20);
			this.FileMenuHeader.Text = "&File";
			// 
			// SaveSettingsMenuItem
			// 
			this.SaveSettingsMenuItem.Name = "SaveSettingsMenuItem";
			this.SaveSettingsMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.SaveSettingsMenuItem.Size = new System.Drawing.Size(227, 22);
			this.SaveSettingsMenuItem.Text = "&Save Settings...";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(224, 6);
			// 
			// AddFolderToLibraryMenuItem
			// 
			this.AddFolderToLibraryMenuItem.Name = "AddFolderToLibraryMenuItem";
			this.AddFolderToLibraryMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.AddFolderToLibraryMenuItem.Size = new System.Drawing.Size(227, 22);
			this.AddFolderToLibraryMenuItem.Text = "&Add Folder to Library";
			// 
			// RemoveFolderFromLibraryMenuItem
			// 
			this.RemoveFolderFromLibraryMenuItem.Name = "RemoveFolderFromLibraryMenuItem";
			this.RemoveFolderFromLibraryMenuItem.Size = new System.Drawing.Size(227, 22);
			this.RemoveFolderFromLibraryMenuItem.Text = "&Remove Folder from Library";
			// 
			// RebuildLibraryMenuItem
			// 
			this.RebuildLibraryMenuItem.Name = "RebuildLibraryMenuItem";
			this.RebuildLibraryMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
			this.RebuildLibraryMenuItem.Size = new System.Drawing.Size(227, 22);
			this.RebuildLibraryMenuItem.Text = "Re&build Library";
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(224, 6);
			// 
			// ExportSettingsMenuItem
			// 
			this.ExportSettingsMenuItem.Name = "ExportSettingsMenuItem";
			this.ExportSettingsMenuItem.Size = new System.Drawing.Size(227, 22);
			this.ExportSettingsMenuItem.Text = "&Export Settings...";
			// 
			// ImportSettingsMenuItem
			// 
			this.ImportSettingsMenuItem.Name = "ImportSettingsMenuItem";
			this.ImportSettingsMenuItem.Size = new System.Drawing.Size(227, 22);
			this.ImportSettingsMenuItem.Text = "&Import Settings...";
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(224, 6);
			// 
			// ExitMenuItem
			// 
			this.ExitMenuItem.Name = "ExitMenuItem";
			this.ExitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.ExitMenuItem.Size = new System.Drawing.Size(227, 22);
			this.ExitMenuItem.Text = "E&xit";
			// 
			// OptionsHeaderMenu
			// 
			this.OptionsHeaderMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataBufferSizeMenuItem,
            this.ChangeServerNameMenuItem,
            this.ChangeListeningPortsMenuItem,
            this.toolStripMenuItem5,
            this.ToggleServerPasswordMenuItem,
            this.ChangeServerPasswordMenuItem});
			this.OptionsHeaderMenu.Name = "OptionsHeaderMenu";
			this.OptionsHeaderMenu.Size = new System.Drawing.Size(61, 20);
			this.OptionsHeaderMenu.Text = "&Options";
			// 
			// DataBufferSizeMenuItem
			// 
			this.DataBufferSizeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Bytes512MenuItem,
            this.Bytes1024MenuItem,
            this.Bytes2048MenuItem,
            this.Bytes4096MenuItem,
            this.Bytes8192MenuItem});
			this.DataBufferSizeMenuItem.Name = "DataBufferSizeMenuItem";
			this.DataBufferSizeMenuItem.Size = new System.Drawing.Size(203, 22);
			this.DataBufferSizeMenuItem.Text = "Data Buffer Size";
			// 
			// Bytes512MenuItem
			// 
			this.Bytes512MenuItem.Name = "Bytes512MenuItem";
			this.Bytes512MenuItem.Size = new System.Drawing.Size(221, 22);
			this.Bytes512MenuItem.Text = "512 Bytes";
			// 
			// Bytes1024MenuItem
			// 
			this.Bytes1024MenuItem.Name = "Bytes1024MenuItem";
			this.Bytes1024MenuItem.Size = new System.Drawing.Size(221, 22);
			this.Bytes1024MenuItem.Text = "1024 Bytes";
			// 
			// Bytes2048MenuItem
			// 
			this.Bytes2048MenuItem.Name = "Bytes2048MenuItem";
			this.Bytes2048MenuItem.Size = new System.Drawing.Size(221, 22);
			this.Bytes2048MenuItem.Text = "2048 Bytes";
			// 
			// Bytes4096MenuItem
			// 
			this.Bytes4096MenuItem.Name = "Bytes4096MenuItem";
			this.Bytes4096MenuItem.Size = new System.Drawing.Size(221, 22);
			this.Bytes4096MenuItem.Text = "4096 Bytes (Recommended)";
			// 
			// Bytes8192MenuItem
			// 
			this.Bytes8192MenuItem.Name = "Bytes8192MenuItem";
			this.Bytes8192MenuItem.Size = new System.Drawing.Size(221, 22);
			this.Bytes8192MenuItem.Text = "8192 Bytes";
			// 
			// ChangeServerNameMenuItem
			// 
			this.ChangeServerNameMenuItem.Name = "ChangeServerNameMenuItem";
			this.ChangeServerNameMenuItem.Size = new System.Drawing.Size(203, 22);
			this.ChangeServerNameMenuItem.Text = "Change Server Name";
			// 
			// ChangeListeningPortsMenuItem
			// 
			this.ChangeListeningPortsMenuItem.Name = "ChangeListeningPortsMenuItem";
			this.ChangeListeningPortsMenuItem.Size = new System.Drawing.Size(203, 22);
			this.ChangeListeningPortsMenuItem.Text = "Change Listening Ports";
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(200, 6);
			// 
			// ToggleServerPasswordMenuItem
			// 
			this.ToggleServerPasswordMenuItem.Name = "ToggleServerPasswordMenuItem";
			this.ToggleServerPasswordMenuItem.Size = new System.Drawing.Size(203, 22);
			this.ToggleServerPasswordMenuItem.Text = "Enable Server Password";
			// 
			// ChangeServerPasswordMenuItem
			// 
			this.ChangeServerPasswordMenuItem.Name = "ChangeServerPasswordMenuItem";
			this.ChangeServerPasswordMenuItem.Size = new System.Drawing.Size(203, 22);
			this.ChangeServerPasswordMenuItem.Text = "Change Server Password";
			// 
			// HelpMenuHeader
			// 
			this.HelpMenuHeader.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpMenuItem,
            this.toolStripMenuItem1,
            this.AboutMenuItem});
			this.HelpMenuHeader.Name = "HelpMenuHeader";
			this.HelpMenuHeader.Size = new System.Drawing.Size(44, 20);
			this.HelpMenuHeader.Text = "&Help";
			// 
			// HelpMenuItem
			// 
			this.HelpMenuItem.Name = "HelpMenuItem";
			this.HelpMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
			this.HelpMenuItem.Size = new System.Drawing.Size(118, 22);
			this.HelpMenuItem.Text = "&Help";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(115, 6);
			// 
			// AboutMenuItem
			// 
			this.AboutMenuItem.Name = "AboutMenuItem";
			this.AboutMenuItem.Size = new System.Drawing.Size(118, 22);
			this.AboutMenuItem.Text = "&About";
			this.AboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBarStatusStrip,
            this.ProgressBarLblStatusStrip});
			this.StatusStrip.Location = new System.Drawing.Point(0, 585);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(711, 22);
			this.StatusStrip.TabIndex = 1;
			this.StatusStrip.Text = "statusStrip1";
			// 
			// ProgressBarStatusStrip
			// 
			this.ProgressBarStatusStrip.AutoSize = false;
			this.ProgressBarStatusStrip.Name = "ProgressBarStatusStrip";
			this.ProgressBarStatusStrip.Size = new System.Drawing.Size(100, 16);
			// 
			// ProgressBarLblStatusStrip
			// 
			this.ProgressBarLblStatusStrip.Name = "ProgressBarLblStatusStrip";
			this.ProgressBarLblStatusStrip.Size = new System.Drawing.Size(157, 17);
			this.ProgressBarLblStatusStrip.Text = "Ready (# Clients Connected)";
			// 
			// LibraryGrp
			// 
			this.LibraryGrp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LibraryGrp.Controls.Add(this.LibraryDGV);
			this.LibraryGrp.Location = new System.Drawing.Point(6, 27);
			this.LibraryGrp.Name = "LibraryGrp";
			this.LibraryGrp.Size = new System.Drawing.Size(699, 253);
			this.LibraryGrp.TabIndex = 2;
			this.LibraryGrp.TabStop = false;
			this.LibraryGrp.Text = "Music Library";
			// 
			// LibraryDGV
			// 
			this.LibraryDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LibraryDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.LibraryDGV.Location = new System.Drawing.Point(6, 19);
			this.LibraryDGV.Name = "LibraryDGV";
			this.LibraryDGV.Size = new System.Drawing.Size(687, 227);
			this.LibraryDGV.TabIndex = 0;
			// 
			// PlaylistGrp
			// 
			this.PlaylistGrp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.PlaylistGrp.Controls.Add(this.DelCmd);
			this.PlaylistGrp.Controls.Add(this.ToBottomCmd);
			this.PlaylistGrp.Controls.Add(this.DownCmd);
			this.PlaylistGrp.Controls.Add(this.UpCmd);
			this.PlaylistGrp.Controls.Add(this.ToTopCmd);
			this.PlaylistGrp.Controls.Add(this.PlaylistDGV);
			this.PlaylistGrp.Location = new System.Drawing.Point(6, 313);
			this.PlaylistGrp.Name = "PlaylistGrp";
			this.PlaylistGrp.Size = new System.Drawing.Size(699, 267);
			this.PlaylistGrp.TabIndex = 3;
			this.PlaylistGrp.TabStop = false;
			this.PlaylistGrp.Text = "Playlist";
			// 
			// DelCmd
			// 
			this.DelCmd.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.DelCmd.Location = new System.Drawing.Point(660, 123);
			this.DelCmd.Name = "DelCmd";
			this.DelCmd.Size = new System.Drawing.Size(33, 33);
			this.DelCmd.TabIndex = 12;
			this.DelCmd.Text = "Del";
			this.DelCmd.UseVisualStyleBackColor = true;
			// 
			// ToBottomCmd
			// 
			this.ToBottomCmd.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.ToBottomCmd.Location = new System.Drawing.Point(660, 214);
			this.ToBottomCmd.Name = "ToBottomCmd";
			this.ToBottomCmd.Size = new System.Drawing.Size(33, 46);
			this.ToBottomCmd.TabIndex = 14;
			this.ToBottomCmd.Text = "\\/ \\/";
			this.ToBottomCmd.UseVisualStyleBackColor = true;
			// 
			// DownCmd
			// 
			this.DownCmd.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.DownCmd.Location = new System.Drawing.Point(660, 162);
			this.DownCmd.Name = "DownCmd";
			this.DownCmd.Size = new System.Drawing.Size(33, 46);
			this.DownCmd.TabIndex = 13;
			this.DownCmd.Text = "\\/";
			this.DownCmd.UseVisualStyleBackColor = true;
			// 
			// UpCmd
			// 
			this.UpCmd.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.UpCmd.Location = new System.Drawing.Point(660, 71);
			this.UpCmd.Name = "UpCmd";
			this.UpCmd.Size = new System.Drawing.Size(33, 46);
			this.UpCmd.TabIndex = 11;
			this.UpCmd.Text = "/\\";
			this.UpCmd.UseVisualStyleBackColor = true;
			// 
			// ToTopCmd
			// 
			this.ToTopCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ToTopCmd.Location = new System.Drawing.Point(660, 19);
			this.ToTopCmd.Name = "ToTopCmd";
			this.ToTopCmd.Size = new System.Drawing.Size(33, 46);
			this.ToTopCmd.TabIndex = 10;
			this.ToTopCmd.Text = "/\\ /\\";
			this.ToTopCmd.UseVisualStyleBackColor = true;
			// 
			// PlaylistDGV
			// 
			this.PlaylistDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.PlaylistDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.PlaylistDGV.Location = new System.Drawing.Point(6, 19);
			this.PlaylistDGV.Name = "PlaylistDGV";
			this.PlaylistDGV.Size = new System.Drawing.Size(648, 241);
			this.PlaylistDGV.TabIndex = 1;
			// 
			// PlaylistComb
			// 
			this.PlaylistComb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.PlaylistComb.FormattingEnabled = true;
			this.PlaylistComb.Location = new System.Drawing.Point(12, 286);
			this.PlaylistComb.Name = "PlaylistComb";
			this.PlaylistComb.Size = new System.Drawing.Size(420, 21);
			this.PlaylistComb.TabIndex = 4;
			// 
			// AddToPlaylistCmd
			// 
			this.AddToPlaylistCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.AddToPlaylistCmd.Location = new System.Drawing.Point(438, 284);
			this.AddToPlaylistCmd.Name = "AddToPlaylistCmd";
			this.AddToPlaylistCmd.Size = new System.Drawing.Size(85, 23);
			this.AddToPlaylistCmd.TabIndex = 5;
			this.AddToPlaylistCmd.Text = "Add To Playlist";
			this.AddToPlaylistCmd.UseVisualStyleBackColor = true;
			// 
			// DeletePlaylistCmd
			// 
			this.DeletePlaylistCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.DeletePlaylistCmd.Location = new System.Drawing.Point(529, 284);
			this.DeletePlaylistCmd.Name = "DeletePlaylistCmd";
			this.DeletePlaylistCmd.Size = new System.Drawing.Size(85, 23);
			this.DeletePlaylistCmd.TabIndex = 6;
			this.DeletePlaylistCmd.Text = "Delete Playlist";
			this.DeletePlaylistCmd.UseVisualStyleBackColor = true;
			// 
			// NewPlaylistCmd
			// 
			this.NewPlaylistCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.NewPlaylistCmd.Location = new System.Drawing.Point(620, 284);
			this.NewPlaylistCmd.Name = "NewPlaylistCmd";
			this.NewPlaylistCmd.Size = new System.Drawing.Size(85, 23);
			this.NewPlaylistCmd.TabIndex = 7;
			this.NewPlaylistCmd.Text = "New Playlist";
			this.NewPlaylistCmd.UseVisualStyleBackColor = true;
			// 
			// MainFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(711, 607);
			this.Controls.Add(this.NewPlaylistCmd);
			this.Controls.Add(this.DeletePlaylistCmd);
			this.Controls.Add(this.AddToPlaylistCmd);
			this.Controls.Add(this.PlaylistComb);
			this.Controls.Add(this.PlaylistGrp);
			this.Controls.Add(this.LibraryGrp);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.MenuStrip);
			this.MainMenuStrip = this.MenuStrip;
			this.MinimumSize = new System.Drawing.Size(500, 645);
			this.Name = "MainFrm";
			this.Text = "BooBox Server : Name";
			this.Load += new System.EventHandler(this.MainFrm_Load);
			this.Resize += new System.EventHandler(this.MainFrm_Resize);
			this.MenuStrip.ResumeLayout(false);
			this.MenuStrip.PerformLayout();
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			this.LibraryGrp.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.LibraryDGV)).EndInit();
			this.PlaylistGrp.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PlaylistDGV)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MenuStrip;
		private System.Windows.Forms.ToolStripMenuItem FileMenuHeader;
		private System.Windows.Forms.ToolStripMenuItem HelpMenuHeader;
		private System.Windows.Forms.ToolStripMenuItem HelpMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
		private System.Windows.Forms.ToolStripMenuItem SaveSettingsMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem ExportSettingsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ImportSettingsMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
		private System.Windows.Forms.ToolStripMenuItem OptionsHeaderMenu;
		private System.Windows.Forms.StatusStrip StatusStrip;
		private System.Windows.Forms.ToolStripProgressBar ProgressBarStatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel ProgressBarLblStatusStrip;
		private System.Windows.Forms.GroupBox LibraryGrp;
		private System.Windows.Forms.GroupBox PlaylistGrp;
		private System.Windows.Forms.DataGridView LibraryDGV;
		private System.Windows.Forms.DataGridView PlaylistDGV;
		private System.Windows.Forms.ComboBox PlaylistComb;
		private System.Windows.Forms.Button AddToPlaylistCmd;
		private System.Windows.Forms.Button DelCmd;
		private System.Windows.Forms.Button ToBottomCmd;
		private System.Windows.Forms.Button DownCmd;
		private System.Windows.Forms.Button UpCmd;
		private System.Windows.Forms.Button ToTopCmd;
		private System.Windows.Forms.Button DeletePlaylistCmd;
		private System.Windows.Forms.Button NewPlaylistCmd;
		private System.Windows.Forms.ToolStripMenuItem AddFolderToLibraryMenuItem;
		private System.Windows.Forms.ToolStripMenuItem RemoveFolderFromLibraryMenuItem;
		private System.Windows.Forms.ToolStripMenuItem RebuildLibraryMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem DataBufferSizeMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Bytes512MenuItem;
		private System.Windows.Forms.ToolStripMenuItem Bytes1024MenuItem;
		private System.Windows.Forms.ToolStripMenuItem Bytes2048MenuItem;
		private System.Windows.Forms.ToolStripMenuItem Bytes4096MenuItem;
		private System.Windows.Forms.ToolStripMenuItem Bytes8192MenuItem;
		private System.Windows.Forms.ToolStripMenuItem ChangeServerNameMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ChangeListeningPortsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ChangeServerPasswordMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToggleServerPasswordMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
	}
}

