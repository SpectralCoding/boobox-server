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
			this.HelpMenuHeader = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.ExportSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ImportSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OptionsHeaderMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.ProgressBarStatusStrip = new System.Windows.Forms.ToolStripProgressBar();
			this.ProgressBarLblStatusStrip = new System.Windows.Forms.ToolStripStatusLabel();
			this.MenuStrip.SuspendLayout();
			this.StatusStrip.SuspendLayout();
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
			this.MenuStrip.Size = new System.Drawing.Size(706, 24);
			this.MenuStrip.TabIndex = 0;
			// 
			// FileMenuHeader
			// 
			this.FileMenuHeader.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveSettingsMenuItem,
            this.toolStripMenuItem2,
            this.ExportSettingsMenuItem,
            this.ImportSettingsMenuItem,
            this.toolStripMenuItem3,
            this.ExitMenuItem});
			this.FileMenuHeader.Name = "FileMenuHeader";
			this.FileMenuHeader.Size = new System.Drawing.Size(37, 20);
			this.FileMenuHeader.Text = "&File";
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
			this.HelpMenuItem.Size = new System.Drawing.Size(152, 22);
			this.HelpMenuItem.Text = "&Help";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
			// 
			// AboutMenuItem
			// 
			this.AboutMenuItem.Name = "AboutMenuItem";
			this.AboutMenuItem.Size = new System.Drawing.Size(152, 22);
			this.AboutMenuItem.Text = "&About";
			this.AboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
			// 
			// SaveSettingsMenuItem
			// 
			this.SaveSettingsMenuItem.Name = "SaveSettingsMenuItem";
			this.SaveSettingsMenuItem.Size = new System.Drawing.Size(164, 22);
			this.SaveSettingsMenuItem.Text = "&Save Settings...";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(161, 6);
			// 
			// ExportSettingsMenuItem
			// 
			this.ExportSettingsMenuItem.Name = "ExportSettingsMenuItem";
			this.ExportSettingsMenuItem.Size = new System.Drawing.Size(164, 22);
			this.ExportSettingsMenuItem.Text = "&Export Settings...";
			// 
			// ImportSettingsMenuItem
			// 
			this.ImportSettingsMenuItem.Name = "ImportSettingsMenuItem";
			this.ImportSettingsMenuItem.Size = new System.Drawing.Size(164, 22);
			this.ImportSettingsMenuItem.Text = "&Import Settings...";
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(161, 6);
			// 
			// ExitMenuItem
			// 
			this.ExitMenuItem.Name = "ExitMenuItem";
			this.ExitMenuItem.Size = new System.Drawing.Size(164, 22);
			this.ExitMenuItem.Text = "E&xit";
			// 
			// OptionsHeaderMenu
			// 
			this.OptionsHeaderMenu.Name = "OptionsHeaderMenu";
			this.OptionsHeaderMenu.Size = new System.Drawing.Size(61, 20);
			this.OptionsHeaderMenu.Text = "&Options";
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBarStatusStrip,
            this.ProgressBarLblStatusStrip});
			this.StatusStrip.Location = new System.Drawing.Point(0, 299);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(706, 22);
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
			this.ProgressBarLblStatusStrip.Size = new System.Drawing.Size(39, 17);
			this.ProgressBarLblStatusStrip.Text = "Ready";
			// 
			// MainFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(706, 321);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.MenuStrip);
			this.MainMenuStrip = this.MenuStrip;
			this.Name = "MainFrm";
			this.Text = "BooBox Server : Name";
			this.MenuStrip.ResumeLayout(false);
			this.MenuStrip.PerformLayout();
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
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
	}
}

