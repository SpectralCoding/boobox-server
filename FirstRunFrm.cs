using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BooBoxServer {
	public partial class FirstRunFrm : Form {

		private int CurrentPage = 0;

		private void UpdateWizard() {
			if (CurrentPage != 0) {
				BackCmd.Enabled = true;
			} else {
				BackCmd.Enabled = false;
			}
			if (CurrentPage == 1) {
				TitleLbl.Text = "Step 2: Server Name";
				DescriptionLbl.Text = "Your BooBox Server Name will be used to uniquely identify your server to it's users. Try to choose a name that is unique and adequately describes your server's contents.\n\nExamples:\n\t\"Joe's Classic Rock Server\"\n\"Mark's General Music Server\"\n\nEnter a server name below and click 'Next'!";
				InputTxt.Visible = true;
			}

		}

		public FirstRunFrm() {
			InitializeComponent();
		}

		private void FirstRunFrm_Load(object sender, EventArgs e) {
			TitleLbl.Text = "Step 1: Welcome!";
			DescriptionLbl.Text = "Welcome to the BooBox Server First Run Wizard!\n\nThis wizard will allow you to specify several basic configuration options for your BooBox Server.\n\nYou can change all information specified in this wizard at a later point by choosing the appropriate option from one the Options menu found at the top of your server's interface.\n\nClick 'Next' to continue!";
		}

		private void NextCmd_Click(object sender, EventArgs e) {
			CurrentPage++;
			UpdateWizard();
		}

		private void BackCmd_Click(object sender, EventArgs e) {
			CurrentPage--;
			UpdateWizard();
		}
	}
}
