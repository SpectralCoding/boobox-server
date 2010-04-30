﻿namespace BooBoxServer {
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
			this.MusicLibraryDGV = new System.Windows.Forms.DataGridView();
			this.TitleMLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ArtistsMLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AlbumMLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LengthMLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.SizeMLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PlaysMLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.GenresMLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TrackMLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.YearMLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CommentMLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FilenameMLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LengthHiddenMLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FilesizeHiddenMLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PlaysHiddenMLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TrackHiddenMLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.YearHiddenMLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PlaylistGrp = new System.Windows.Forms.GroupBox();
			this.PlaylistDGV = new System.Windows.Forms.DataGridView();
			this.NumberPLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TitlePLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ArtistsPLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AlbumPLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LengthPLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.SizePLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PlaysPLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.GenresPLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TrackPLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.YearPLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CommentPLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FilenamePLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LengthHiddenPLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FilesizeHiddenPLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PlaysHiddenPLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TrackHiddenPLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.YearHiddenPLDGVColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DelCmd = new System.Windows.Forms.Button();
			this.ToBottomCmd = new System.Windows.Forms.Button();
			this.DownCmd = new System.Windows.Forms.Button();
			this.UpCmd = new System.Windows.Forms.Button();
			this.ToTopCmd = new System.Windows.Forms.Button();
			this.PlaylistComb = new System.Windows.Forms.ComboBox();
			this.AddToPlaylistCmd = new System.Windows.Forms.Button();
			this.DeletePlaylistCmd = new System.Windows.Forms.Button();
			this.NewPlaylistCmd = new System.Windows.Forms.Button();
			this.DebugCmd = new System.Windows.Forms.Button();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.MenuStrip.SuspendLayout();
			this.StatusStrip.SuspendLayout();
			this.LibraryGrp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MusicLibraryDGV)).BeginInit();
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
			this.SaveSettingsMenuItem.Click += new System.EventHandler(this.SaveSettingsMenuItem_Click);
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
			this.AddFolderToLibraryMenuItem.Click += new System.EventHandler(this.AddFolderToLibraryMenuItem_Click);
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
			this.RebuildLibraryMenuItem.Click += new System.EventHandler(this.RebuildLibraryMenuItem_Click);
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
			this.ExportSettingsMenuItem.Click += new System.EventHandler(this.ExportSettingsMenuItem_Click);
			// 
			// ImportSettingsMenuItem
			// 
			this.ImportSettingsMenuItem.Name = "ImportSettingsMenuItem";
			this.ImportSettingsMenuItem.Size = new System.Drawing.Size(227, 22);
			this.ImportSettingsMenuItem.Text = "&Import Settings...";
			this.ImportSettingsMenuItem.Click += new System.EventHandler(this.ImportSettingsMenuItem_Click);
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
			this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
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
			this.Bytes512MenuItem.Click += new System.EventHandler(this.Bytes512MenuItem_Click);
			// 
			// Bytes1024MenuItem
			// 
			this.Bytes1024MenuItem.Name = "Bytes1024MenuItem";
			this.Bytes1024MenuItem.Size = new System.Drawing.Size(221, 22);
			this.Bytes1024MenuItem.Text = "1024 Bytes";
			this.Bytes1024MenuItem.Click += new System.EventHandler(this.Bytes1024MenuItem_Click);
			// 
			// Bytes2048MenuItem
			// 
			this.Bytes2048MenuItem.Name = "Bytes2048MenuItem";
			this.Bytes2048MenuItem.Size = new System.Drawing.Size(221, 22);
			this.Bytes2048MenuItem.Text = "2048 Bytes";
			this.Bytes2048MenuItem.Click += new System.EventHandler(this.Bytes2048MenuItem_Click);
			// 
			// Bytes4096MenuItem
			// 
			this.Bytes4096MenuItem.Name = "Bytes4096MenuItem";
			this.Bytes4096MenuItem.Size = new System.Drawing.Size(221, 22);
			this.Bytes4096MenuItem.Text = "4096 Bytes (Recommended)";
			this.Bytes4096MenuItem.Click += new System.EventHandler(this.Bytes4096MenuItem_Click);
			// 
			// Bytes8192MenuItem
			// 
			this.Bytes8192MenuItem.Name = "Bytes8192MenuItem";
			this.Bytes8192MenuItem.Size = new System.Drawing.Size(221, 22);
			this.Bytes8192MenuItem.Text = "8192 Bytes";
			this.Bytes8192MenuItem.Click += new System.EventHandler(this.Bytes8192MenuItem_Click);
			// 
			// ChangeServerNameMenuItem
			// 
			this.ChangeServerNameMenuItem.Name = "ChangeServerNameMenuItem";
			this.ChangeServerNameMenuItem.Size = new System.Drawing.Size(203, 22);
			this.ChangeServerNameMenuItem.Text = "Change Server Name";
			this.ChangeServerNameMenuItem.Click += new System.EventHandler(this.ChangeServerNameMenuItem_Click);
			// 
			// ChangeListeningPortsMenuItem
			// 
			this.ChangeListeningPortsMenuItem.Name = "ChangeListeningPortsMenuItem";
			this.ChangeListeningPortsMenuItem.Size = new System.Drawing.Size(203, 22);
			this.ChangeListeningPortsMenuItem.Text = "Change Listening Ports";
			this.ChangeListeningPortsMenuItem.Click += new System.EventHandler(this.ChangeListeningPortsMenuItem_Click);
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
			this.ToggleServerPasswordMenuItem.Click += new System.EventHandler(this.ToggleServerPasswordMenuItem_Click);
			// 
			// ChangeServerPasswordMenuItem
			// 
			this.ChangeServerPasswordMenuItem.Name = "ChangeServerPasswordMenuItem";
			this.ChangeServerPasswordMenuItem.Size = new System.Drawing.Size(203, 22);
			this.ChangeServerPasswordMenuItem.Text = "Change Server Password";
			this.ChangeServerPasswordMenuItem.Click += new System.EventHandler(this.ChangeServerPasswordMenuItem_Click);
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
			this.HelpMenuItem.Click += new System.EventHandler(this.HelpMenuItem_Click);
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
			this.LibraryGrp.Controls.Add(this.MusicLibraryDGV);
			this.LibraryGrp.Location = new System.Drawing.Point(6, 27);
			this.LibraryGrp.Name = "LibraryGrp";
			this.LibraryGrp.Size = new System.Drawing.Size(699, 253);
			this.LibraryGrp.TabIndex = 2;
			this.LibraryGrp.TabStop = false;
			this.LibraryGrp.Text = "Music Library";
			// 
			// MusicLibraryDGV
			// 
			this.MusicLibraryDGV.AllowUserToAddRows = false;
			this.MusicLibraryDGV.AllowUserToDeleteRows = false;
			this.MusicLibraryDGV.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
			this.MusicLibraryDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.MusicLibraryDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MusicLibraryDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
			this.MusicLibraryDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.MusicLibraryDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TitleMLDGVColumn,
            this.ArtistsMLDGVColumn,
            this.AlbumMLDGVColumn,
            this.LengthMLDGVColumn,
            this.SizeMLDGVColumn,
            this.PlaysMLDGVColumn,
            this.GenresMLDGVColumn,
            this.TrackMLDGVColumn,
            this.YearMLDGVColumn,
            this.CommentMLDGVColumn,
            this.FilenameMLDGVColumn,
            this.LengthHiddenMLDGVColumn,
            this.FilesizeHiddenMLDGVColumn,
            this.PlaysHiddenMLDGVColumn,
            this.TrackHiddenMLDGVColumn,
            this.YearHiddenMLDGVColumn});
			this.MusicLibraryDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.MusicLibraryDGV.Location = new System.Drawing.Point(6, 19);
			this.MusicLibraryDGV.Name = "MusicLibraryDGV";
			this.MusicLibraryDGV.RowHeadersVisible = false;
			this.MusicLibraryDGV.RowTemplate.Height = 18;
			this.MusicLibraryDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.MusicLibraryDGV.ShowEditingIcon = false;
			this.MusicLibraryDGV.Size = new System.Drawing.Size(687, 227);
			this.MusicLibraryDGV.TabIndex = 25;
			this.MusicLibraryDGV.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.MusicLibraryDGV_ColumnHeaderMouseClick);
			this.MusicLibraryDGV.SelectionChanged += new System.EventHandler(this.MusicLibraryDGV_SelectionChanged);
			this.MusicLibraryDGV.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MusicLibraryDGV_MouseUp);
			// 
			// TitleMLDGVColumn
			// 
			this.TitleMLDGVColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.TitleMLDGVColumn.FillWeight = 200F;
			this.TitleMLDGVColumn.HeaderText = "Title";
			this.TitleMLDGVColumn.MinimumWidth = 200;
			this.TitleMLDGVColumn.Name = "TitleMLDGVColumn";
			// 
			// ArtistsMLDGVColumn
			// 
			this.ArtistsMLDGVColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ArtistsMLDGVColumn.HeaderText = "Artists";
			this.ArtistsMLDGVColumn.MinimumWidth = 100;
			this.ArtistsMLDGVColumn.Name = "ArtistsMLDGVColumn";
			// 
			// AlbumMLDGVColumn
			// 
			this.AlbumMLDGVColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.AlbumMLDGVColumn.HeaderText = "Album";
			this.AlbumMLDGVColumn.MinimumWidth = 125;
			this.AlbumMLDGVColumn.Name = "AlbumMLDGVColumn";
			// 
			// LengthMLDGVColumn
			// 
			this.LengthMLDGVColumn.HeaderText = "Length";
			this.LengthMLDGVColumn.MinimumWidth = 65;
			this.LengthMLDGVColumn.Name = "LengthMLDGVColumn";
			this.LengthMLDGVColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.LengthMLDGVColumn.Width = 65;
			// 
			// SizeMLDGVColumn
			// 
			this.SizeMLDGVColumn.HeaderText = "Size";
			this.SizeMLDGVColumn.MinimumWidth = 52;
			this.SizeMLDGVColumn.Name = "SizeMLDGVColumn";
			this.SizeMLDGVColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.SizeMLDGVColumn.Width = 52;
			// 
			// PlaysMLDGVColumn
			// 
			this.PlaysMLDGVColumn.HeaderText = "Plays";
			this.PlaysMLDGVColumn.MinimumWidth = 57;
			this.PlaysMLDGVColumn.Name = "PlaysMLDGVColumn";
			this.PlaysMLDGVColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.PlaysMLDGVColumn.Width = 57;
			// 
			// GenresMLDGVColumn
			// 
			this.GenresMLDGVColumn.HeaderText = "Genres";
			this.GenresMLDGVColumn.MinimumWidth = 50;
			this.GenresMLDGVColumn.Name = "GenresMLDGVColumn";
			// 
			// TrackMLDGVColumn
			// 
			this.TrackMLDGVColumn.HeaderText = "Track";
			this.TrackMLDGVColumn.MinimumWidth = 60;
			this.TrackMLDGVColumn.Name = "TrackMLDGVColumn";
			this.TrackMLDGVColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.TrackMLDGVColumn.Width = 60;
			// 
			// YearMLDGVColumn
			// 
			this.YearMLDGVColumn.HeaderText = "Year";
			this.YearMLDGVColumn.MinimumWidth = 54;
			this.YearMLDGVColumn.Name = "YearMLDGVColumn";
			this.YearMLDGVColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.YearMLDGVColumn.Width = 54;
			// 
			// CommentMLDGVColumn
			// 
			this.CommentMLDGVColumn.HeaderText = "Comment";
			this.CommentMLDGVColumn.MinimumWidth = 50;
			this.CommentMLDGVColumn.Name = "CommentMLDGVColumn";
			this.CommentMLDGVColumn.Width = 150;
			// 
			// FilenameMLDGVColumn
			// 
			this.FilenameMLDGVColumn.HeaderText = "Filename";
			this.FilenameMLDGVColumn.MinimumWidth = 50;
			this.FilenameMLDGVColumn.Name = "FilenameMLDGVColumn";
			this.FilenameMLDGVColumn.Width = 150;
			// 
			// LengthHiddenMLDGVColumn
			// 
			this.LengthHiddenMLDGVColumn.HeaderText = "LengthHidden";
			this.LengthHiddenMLDGVColumn.Name = "LengthHiddenMLDGVColumn";
			this.LengthHiddenMLDGVColumn.Visible = false;
			// 
			// FilesizeHiddenMLDGVColumn
			// 
			this.FilesizeHiddenMLDGVColumn.HeaderText = "FilesizeHidden";
			this.FilesizeHiddenMLDGVColumn.Name = "FilesizeHiddenMLDGVColumn";
			this.FilesizeHiddenMLDGVColumn.Visible = false;
			// 
			// PlaysHiddenMLDGVColumn
			// 
			this.PlaysHiddenMLDGVColumn.HeaderText = "PlaysHidden";
			this.PlaysHiddenMLDGVColumn.Name = "PlaysHiddenMLDGVColumn";
			this.PlaysHiddenMLDGVColumn.Visible = false;
			// 
			// TrackHiddenMLDGVColumn
			// 
			this.TrackHiddenMLDGVColumn.HeaderText = "TrackHidden";
			this.TrackHiddenMLDGVColumn.Name = "TrackHiddenMLDGVColumn";
			this.TrackHiddenMLDGVColumn.Visible = false;
			// 
			// YearHiddenMLDGVColumn
			// 
			this.YearHiddenMLDGVColumn.HeaderText = "YearHidden";
			this.YearHiddenMLDGVColumn.Name = "YearHiddenMLDGVColumn";
			this.YearHiddenMLDGVColumn.Visible = false;
			// 
			// PlaylistGrp
			// 
			this.PlaylistGrp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.PlaylistGrp.Controls.Add(this.PlaylistDGV);
			this.PlaylistGrp.Controls.Add(this.DelCmd);
			this.PlaylistGrp.Controls.Add(this.ToBottomCmd);
			this.PlaylistGrp.Controls.Add(this.DownCmd);
			this.PlaylistGrp.Controls.Add(this.UpCmd);
			this.PlaylistGrp.Controls.Add(this.ToTopCmd);
			this.PlaylistGrp.Location = new System.Drawing.Point(6, 313);
			this.PlaylistGrp.Name = "PlaylistGrp";
			this.PlaylistGrp.Size = new System.Drawing.Size(699, 267);
			this.PlaylistGrp.TabIndex = 3;
			this.PlaylistGrp.TabStop = false;
			this.PlaylistGrp.Text = "Playlist";
			// 
			// PlaylistDGV
			// 
			this.PlaylistDGV.AllowUserToAddRows = false;
			this.PlaylistDGV.AllowUserToDeleteRows = false;
			this.PlaylistDGV.AllowUserToResizeRows = false;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
			this.PlaylistDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
			this.PlaylistDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.PlaylistDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
			this.PlaylistDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.PlaylistDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumberPLDGVColumn,
            this.TitlePLDGVColumn,
            this.ArtistsPLDGVColumn,
            this.AlbumPLDGVColumn,
            this.LengthPLDGVColumn,
            this.SizePLDGVColumn,
            this.PlaysPLDGVColumn,
            this.GenresPLDGVColumn,
            this.TrackPLDGVColumn,
            this.YearPLDGVColumn,
            this.CommentPLDGVColumn,
            this.FilenamePLDGVColumn,
            this.LengthHiddenPLDGVColumn,
            this.FilesizeHiddenPLDGVColumn,
            this.PlaysHiddenPLDGVColumn,
            this.TrackHiddenPLDGVColumn,
            this.YearHiddenPLDGVColumn});
			this.PlaylistDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.PlaylistDGV.Location = new System.Drawing.Point(6, 19);
			this.PlaylistDGV.Name = "PlaylistDGV";
			this.PlaylistDGV.RowHeadersVisible = false;
			this.PlaylistDGV.RowTemplate.Height = 18;
			this.PlaylistDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.PlaylistDGV.ShowEditingIcon = false;
			this.PlaylistDGV.Size = new System.Drawing.Size(648, 241);
			this.PlaylistDGV.TabIndex = 26;
			this.PlaylistDGV.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.PlaylistDGV_ColumnHeaderMouseClick);
			this.PlaylistDGV.SelectionChanged += new System.EventHandler(this.PlaylistDGV_SelectionChanged);
			// 
			// NumberPLDGVColumn
			// 
			this.NumberPLDGVColumn.HeaderText = "#";
			this.NumberPLDGVColumn.MinimumWidth = 34;
			this.NumberPLDGVColumn.Name = "NumberPLDGVColumn";
			this.NumberPLDGVColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.NumberPLDGVColumn.Width = 34;
			// 
			// TitlePLDGVColumn
			// 
			this.TitlePLDGVColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.TitlePLDGVColumn.FillWeight = 200F;
			this.TitlePLDGVColumn.HeaderText = "Title";
			this.TitlePLDGVColumn.MinimumWidth = 200;
			this.TitlePLDGVColumn.Name = "TitlePLDGVColumn";
			// 
			// ArtistsPLDGVColumn
			// 
			this.ArtistsPLDGVColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ArtistsPLDGVColumn.HeaderText = "Artists";
			this.ArtistsPLDGVColumn.MinimumWidth = 100;
			this.ArtistsPLDGVColumn.Name = "ArtistsPLDGVColumn";
			// 
			// AlbumPLDGVColumn
			// 
			this.AlbumPLDGVColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.AlbumPLDGVColumn.HeaderText = "Album";
			this.AlbumPLDGVColumn.MinimumWidth = 125;
			this.AlbumPLDGVColumn.Name = "AlbumPLDGVColumn";
			// 
			// LengthPLDGVColumn
			// 
			this.LengthPLDGVColumn.HeaderText = "Length";
			this.LengthPLDGVColumn.MinimumWidth = 65;
			this.LengthPLDGVColumn.Name = "LengthPLDGVColumn";
			this.LengthPLDGVColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.LengthPLDGVColumn.Width = 65;
			// 
			// SizePLDGVColumn
			// 
			this.SizePLDGVColumn.HeaderText = "Size";
			this.SizePLDGVColumn.MinimumWidth = 52;
			this.SizePLDGVColumn.Name = "SizePLDGVColumn";
			this.SizePLDGVColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.SizePLDGVColumn.Width = 52;
			// 
			// PlaysPLDGVColumn
			// 
			this.PlaysPLDGVColumn.HeaderText = "Plays";
			this.PlaysPLDGVColumn.MinimumWidth = 57;
			this.PlaysPLDGVColumn.Name = "PlaysPLDGVColumn";
			this.PlaysPLDGVColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.PlaysPLDGVColumn.Width = 57;
			// 
			// GenresPLDGVColumn
			// 
			this.GenresPLDGVColumn.HeaderText = "Genres";
			this.GenresPLDGVColumn.MinimumWidth = 50;
			this.GenresPLDGVColumn.Name = "GenresPLDGVColumn";
			// 
			// TrackPLDGVColumn
			// 
			this.TrackPLDGVColumn.HeaderText = "Track";
			this.TrackPLDGVColumn.MinimumWidth = 60;
			this.TrackPLDGVColumn.Name = "TrackPLDGVColumn";
			this.TrackPLDGVColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.TrackPLDGVColumn.Width = 60;
			// 
			// YearPLDGVColumn
			// 
			this.YearPLDGVColumn.HeaderText = "Year";
			this.YearPLDGVColumn.MinimumWidth = 54;
			this.YearPLDGVColumn.Name = "YearPLDGVColumn";
			this.YearPLDGVColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.YearPLDGVColumn.Width = 54;
			// 
			// CommentPLDGVColumn
			// 
			this.CommentPLDGVColumn.HeaderText = "Comment";
			this.CommentPLDGVColumn.MinimumWidth = 50;
			this.CommentPLDGVColumn.Name = "CommentPLDGVColumn";
			this.CommentPLDGVColumn.Width = 150;
			// 
			// FilenamePLDGVColumn
			// 
			this.FilenamePLDGVColumn.HeaderText = "Filename";
			this.FilenamePLDGVColumn.MinimumWidth = 50;
			this.FilenamePLDGVColumn.Name = "FilenamePLDGVColumn";
			this.FilenamePLDGVColumn.Width = 150;
			// 
			// LengthHiddenPLDGVColumn
			// 
			this.LengthHiddenPLDGVColumn.HeaderText = "LengthHidden";
			this.LengthHiddenPLDGVColumn.Name = "LengthHiddenPLDGVColumn";
			this.LengthHiddenPLDGVColumn.Visible = false;
			// 
			// FilesizeHiddenPLDGVColumn
			// 
			this.FilesizeHiddenPLDGVColumn.HeaderText = "FilesizeHidden";
			this.FilesizeHiddenPLDGVColumn.Name = "FilesizeHiddenPLDGVColumn";
			this.FilesizeHiddenPLDGVColumn.Visible = false;
			// 
			// PlaysHiddenPLDGVColumn
			// 
			this.PlaysHiddenPLDGVColumn.HeaderText = "PlaysHidden";
			this.PlaysHiddenPLDGVColumn.Name = "PlaysHiddenPLDGVColumn";
			this.PlaysHiddenPLDGVColumn.Visible = false;
			// 
			// TrackHiddenPLDGVColumn
			// 
			this.TrackHiddenPLDGVColumn.HeaderText = "TrackHidden";
			this.TrackHiddenPLDGVColumn.Name = "TrackHiddenPLDGVColumn";
			this.TrackHiddenPLDGVColumn.Visible = false;
			// 
			// YearHiddenPLDGVColumn
			// 
			this.YearHiddenPLDGVColumn.HeaderText = "YearHidden";
			this.YearHiddenPLDGVColumn.Name = "YearHiddenPLDGVColumn";
			this.YearHiddenPLDGVColumn.Visible = false;
			// 
			// DelCmd
			// 
			this.DelCmd.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.DelCmd.Enabled = false;
			this.DelCmd.Location = new System.Drawing.Point(660, 123);
			this.DelCmd.Name = "DelCmd";
			this.DelCmd.Size = new System.Drawing.Size(33, 33);
			this.DelCmd.TabIndex = 12;
			this.DelCmd.Text = "Del";
			this.DelCmd.UseVisualStyleBackColor = true;
			this.DelCmd.Click += new System.EventHandler(this.DelCmd_Click);
			// 
			// ToBottomCmd
			// 
			this.ToBottomCmd.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.ToBottomCmd.Enabled = false;
			this.ToBottomCmd.Location = new System.Drawing.Point(660, 214);
			this.ToBottomCmd.Name = "ToBottomCmd";
			this.ToBottomCmd.Size = new System.Drawing.Size(33, 46);
			this.ToBottomCmd.TabIndex = 14;
			this.ToBottomCmd.Text = "\\/ \\/";
			this.ToBottomCmd.UseVisualStyleBackColor = true;
			this.ToBottomCmd.Click += new System.EventHandler(this.ToBottomCmd_Click);
			// 
			// DownCmd
			// 
			this.DownCmd.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.DownCmd.Enabled = false;
			this.DownCmd.Location = new System.Drawing.Point(660, 162);
			this.DownCmd.Name = "DownCmd";
			this.DownCmd.Size = new System.Drawing.Size(33, 46);
			this.DownCmd.TabIndex = 13;
			this.DownCmd.Text = "\\/";
			this.DownCmd.UseVisualStyleBackColor = true;
			this.DownCmd.Click += new System.EventHandler(this.DownCmd_Click);
			// 
			// UpCmd
			// 
			this.UpCmd.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.UpCmd.Enabled = false;
			this.UpCmd.Location = new System.Drawing.Point(660, 71);
			this.UpCmd.Name = "UpCmd";
			this.UpCmd.Size = new System.Drawing.Size(33, 46);
			this.UpCmd.TabIndex = 11;
			this.UpCmd.Text = "/\\";
			this.UpCmd.UseVisualStyleBackColor = true;
			this.UpCmd.Click += new System.EventHandler(this.UpCmd_Click);
			// 
			// ToTopCmd
			// 
			this.ToTopCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ToTopCmd.Enabled = false;
			this.ToTopCmd.Location = new System.Drawing.Point(660, 19);
			this.ToTopCmd.Name = "ToTopCmd";
			this.ToTopCmd.Size = new System.Drawing.Size(33, 46);
			this.ToTopCmd.TabIndex = 10;
			this.ToTopCmd.Text = "/\\ /\\";
			this.ToTopCmd.UseVisualStyleBackColor = true;
			this.ToTopCmd.Click += new System.EventHandler(this.ToTopCmd_Click);
			// 
			// PlaylistComb
			// 
			this.PlaylistComb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.PlaylistComb.FormattingEnabled = true;
			this.PlaylistComb.Location = new System.Drawing.Point(12, 286);
			this.PlaylistComb.Name = "PlaylistComb";
			this.PlaylistComb.Size = new System.Drawing.Size(420, 21);
			this.PlaylistComb.Sorted = true;
			this.PlaylistComb.TabIndex = 4;
			this.PlaylistComb.SelectedIndexChanged += new System.EventHandler(this.PlaylistComb_SelectedIndexChanged);
			this.PlaylistComb.Click += new System.EventHandler(this.PlaylistComb_Click);
			this.PlaylistComb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PlaylistComb_KeyPress);
			// 
			// AddToPlaylistCmd
			// 
			this.AddToPlaylistCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.AddToPlaylistCmd.Enabled = false;
			this.AddToPlaylistCmd.Location = new System.Drawing.Point(438, 284);
			this.AddToPlaylistCmd.Name = "AddToPlaylistCmd";
			this.AddToPlaylistCmd.Size = new System.Drawing.Size(85, 23);
			this.AddToPlaylistCmd.TabIndex = 5;
			this.AddToPlaylistCmd.Text = "Add To Playlist";
			this.AddToPlaylistCmd.UseVisualStyleBackColor = true;
			this.AddToPlaylistCmd.Click += new System.EventHandler(this.AddToPlaylistCmd_Click);
			// 
			// DeletePlaylistCmd
			// 
			this.DeletePlaylistCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.DeletePlaylistCmd.Enabled = false;
			this.DeletePlaylistCmd.Location = new System.Drawing.Point(529, 284);
			this.DeletePlaylistCmd.Name = "DeletePlaylistCmd";
			this.DeletePlaylistCmd.Size = new System.Drawing.Size(85, 23);
			this.DeletePlaylistCmd.TabIndex = 6;
			this.DeletePlaylistCmd.Text = "Delete Playlist";
			this.DeletePlaylistCmd.UseVisualStyleBackColor = true;
			this.DeletePlaylistCmd.Click += new System.EventHandler(this.DeletePlaylistCmd_Click);
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
			this.NewPlaylistCmd.Click += new System.EventHandler(this.NewPlaylistCmd_Click);
			// 
			// DebugCmd
			// 
			this.DebugCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.DebugCmd.Location = new System.Drawing.Point(636, -2);
			this.DebugCmd.Name = "DebugCmd";
			this.DebugCmd.Size = new System.Drawing.Size(75, 23);
			this.DebugCmd.TabIndex = 8;
			this.DebugCmd.Text = "Debug";
			this.DebugCmd.UseVisualStyleBackColor = true;
			this.DebugCmd.Click += new System.EventHandler(this.DebugCmd_Click);
			// 
			// OpenFileDialog
			// 
			this.OpenFileDialog.FileName = "openFileDialog1";
			// 
			// MainFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(711, 607);
			this.Controls.Add(this.DebugCmd);
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
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFrm_FormClosed);
			this.Load += new System.EventHandler(this.MainFrm_Load);
			this.Resize += new System.EventHandler(this.MainFrm_Resize);
			this.MenuStrip.ResumeLayout(false);
			this.MenuStrip.PerformLayout();
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			this.LibraryGrp.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MusicLibraryDGV)).EndInit();
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
		private System.Windows.Forms.DataGridView MusicLibraryDGV;
		private System.Windows.Forms.Button DebugCmd;
		private System.Windows.Forms.OpenFileDialog OpenFileDialog;
		private System.Windows.Forms.SaveFileDialog SaveFileDialog;
		private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
		private System.Windows.Forms.DataGridViewTextBoxColumn TitleMLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn ArtistsMLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn AlbumMLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn LengthMLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn SizeMLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn PlaysMLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn GenresMLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn TrackMLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn YearMLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn CommentMLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn FilenameMLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn LengthHiddenMLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn FilesizeHiddenMLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn PlaysHiddenMLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn TrackHiddenMLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn YearHiddenMLDGVColumn;
		private System.Windows.Forms.DataGridView PlaylistDGV;
		private System.Windows.Forms.DataGridViewTextBoxColumn NumberPLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn TitlePLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn ArtistsPLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn AlbumPLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn LengthPLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn SizePLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn PlaysPLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn GenresPLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn TrackPLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn YearPLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn CommentPLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn FilenamePLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn LengthHiddenPLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn FilesizeHiddenPLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn PlaysHiddenPLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn TrackHiddenPLDGVColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn YearHiddenPLDGVColumn;
	}
}

