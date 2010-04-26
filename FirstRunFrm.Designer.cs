namespace BooBoxServer {
	partial class FirstRunFrm {
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
			this.LogoPicBox = new System.Windows.Forms.PictureBox();
			this.LineLbl = new System.Windows.Forms.Label();
			this.TitleLbl = new System.Windows.Forms.Label();
			this.NextCmd = new System.Windows.Forms.Button();
			this.BackCmd = new System.Windows.Forms.Button();
			this.DescriptionLbl = new System.Windows.Forms.Label();
			this.InputOneTxt = new System.Windows.Forms.TextBox();
			this.InputTwoTxt = new System.Windows.Forms.TextBox();
			this.CheckBox = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.LogoPicBox)).BeginInit();
			this.SuspendLayout();
			// 
			// LogoPicBox
			// 
			this.LogoPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.LogoPicBox.Location = new System.Drawing.Point(12, 12);
			this.LogoPicBox.Name = "LogoPicBox";
			this.LogoPicBox.Size = new System.Drawing.Size(125, 338);
			this.LogoPicBox.TabIndex = 0;
			this.LogoPicBox.TabStop = false;
			// 
			// LineLbl
			// 
			this.LineLbl.BackColor = System.Drawing.Color.Black;
			this.LineLbl.Location = new System.Drawing.Point(143, 7);
			this.LineLbl.Name = "LineLbl";
			this.LineLbl.Size = new System.Drawing.Size(1, 348);
			this.LineLbl.TabIndex = 1;
			// 
			// TitleLbl
			// 
			this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TitleLbl.Location = new System.Drawing.Point(150, 12);
			this.TitleLbl.Name = "TitleLbl";
			this.TitleLbl.Size = new System.Drawing.Size(322, 20);
			this.TitleLbl.TabIndex = 2;
			this.TitleLbl.Text = "Title";
			// 
			// NextCmd
			// 
			this.NextCmd.Location = new System.Drawing.Point(397, 327);
			this.NextCmd.Name = "NextCmd";
			this.NextCmd.Size = new System.Drawing.Size(75, 23);
			this.NextCmd.TabIndex = 3;
			this.NextCmd.Text = "Next >";
			this.NextCmd.UseVisualStyleBackColor = true;
			this.NextCmd.Click += new System.EventHandler(this.NextCmd_Click);
			// 
			// BackCmd
			// 
			this.BackCmd.Enabled = false;
			this.BackCmd.Location = new System.Drawing.Point(316, 327);
			this.BackCmd.Name = "BackCmd";
			this.BackCmd.Size = new System.Drawing.Size(75, 23);
			this.BackCmd.TabIndex = 4;
			this.BackCmd.Text = "< Back";
			this.BackCmd.UseVisualStyleBackColor = true;
			this.BackCmd.Click += new System.EventHandler(this.BackCmd_Click);
			// 
			// DescriptionLbl
			// 
			this.DescriptionLbl.Location = new System.Drawing.Point(151, 47);
			this.DescriptionLbl.Name = "DescriptionLbl";
			this.DescriptionLbl.Size = new System.Drawing.Size(321, 277);
			this.DescriptionLbl.TabIndex = 5;
			this.DescriptionLbl.Text = "Description";
			this.DescriptionLbl.Click += new System.EventHandler(this.DescriptionLbl_Click);
			// 
			// InputOneTxt
			// 
			this.InputOneTxt.Location = new System.Drawing.Point(154, 175);
			this.InputOneTxt.Name = "InputOneTxt";
			this.InputOneTxt.Size = new System.Drawing.Size(318, 20);
			this.InputOneTxt.TabIndex = 6;
			this.InputOneTxt.Visible = false;
			// 
			// InputTwoTxt
			// 
			this.InputTwoTxt.Location = new System.Drawing.Point(154, 201);
			this.InputTwoTxt.Name = "InputTwoTxt";
			this.InputTwoTxt.Size = new System.Drawing.Size(318, 20);
			this.InputTwoTxt.TabIndex = 7;
			this.InputTwoTxt.Visible = false;
			// 
			// CheckBox
			// 
			this.CheckBox.AutoSize = true;
			this.CheckBox.Location = new System.Drawing.Point(154, 227);
			this.CheckBox.Name = "CheckBox";
			this.CheckBox.Size = new System.Drawing.Size(142, 17);
			this.CheckBox.TabIndex = 8;
			this.CheckBox.Text = "Enable Server Password";
			this.CheckBox.UseVisualStyleBackColor = true;
			this.CheckBox.Visible = false;
			this.CheckBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
			// 
			// FirstRunFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 362);
			this.Controls.Add(this.CheckBox);
			this.Controls.Add(this.InputTwoTxt);
			this.Controls.Add(this.InputOneTxt);
			this.Controls.Add(this.DescriptionLbl);
			this.Controls.Add(this.BackCmd);
			this.Controls.Add(this.NextCmd);
			this.Controls.Add(this.TitleLbl);
			this.Controls.Add(this.LineLbl);
			this.Controls.Add(this.LogoPicBox);
			this.Name = "FirstRunFrm";
			this.ShowInTaskbar = false;
			this.Text = "BooBox Server : First Run Wizard";
			this.Load += new System.EventHandler(this.FirstRunFrm_Load);
			((System.ComponentModel.ISupportInitialize)(this.LogoPicBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox LogoPicBox;
		private System.Windows.Forms.Label LineLbl;
		private System.Windows.Forms.Label TitleLbl;
		private System.Windows.Forms.Button NextCmd;
		private System.Windows.Forms.Button BackCmd;
		private System.Windows.Forms.Label DescriptionLbl;
		private System.Windows.Forms.TextBox InputOneTxt;
		private System.Windows.Forms.TextBox InputTwoTxt;
		private System.Windows.Forms.CheckBox CheckBox;
	}
}