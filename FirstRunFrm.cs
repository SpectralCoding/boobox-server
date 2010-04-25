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
		private int PreviousPage = 0;
		private String tempServerName = "";
		private Boolean tempServerPasswordChk = false;
		private String tempServerPassword = "";
		private int tempPortInfo = 1337;
		private int tempPortTrans = 1338;

		private void UpdateWizard() {
			InputOneTxt.Visible = false;
			InputTwoTxt.Visible = false;
			InputOneTxt.Enabled = true;
			InputTwoTxt.Enabled = true;
			CheckBox.Visible = false;
			NextCmd.Text = "Next >";
			if (CurrentPage != 0) { BackCmd.Enabled = true; } else { BackCmd.Enabled = false; }
			if (CurrentPage < 0) { CurrentPage = 0; } else if (CurrentPage > 5) { CurrentPage = 5; }
			if (CurrentPage == 0) {
				#region Step 1: Welcome!
				TitleLbl.Text = "Step 1: Welcome!";
				DescriptionLbl.Text = "Welcome to the BooBox Server First Run Wizard!\n\nThis wizard will allow you to specify several basic configuration options for your BooBox Server.\n\nYou can change all information specified in this wizard at a later point by choosing the appropriate option from one the Options menu found at the top of your server's interface.\n\nClick 'Next' to continue!";
				#endregion
			} else if (CurrentPage == 1) {
				#region Step 2: Server Name
				TitleLbl.Text = "Step 2: Server Name";
				DescriptionLbl.Text = "Your BooBox Server Name will be used to uniquely identify your server to it's users. Try to choose a name that is unique and adequately describes your server's contents.\n\nExamples:\n\"Joe's Classic Rock Server\"\n\"Mark's General Music Server\"\n\nEnter a server name below and click 'Next':";
				InputOneTxt.Text = tempServerName;
				InputOneTxt.Top = 175; InputOneTxt.Left = 154; InputOneTxt.Width = 318;
				InputOneTxt.Visible = true;
				#endregion
			} else if (CurrentPage == 2) {
				#region Step 3: Server Password
				if (PreviousPage == 1) { tempServerName = InputOneTxt.Text; }
				if (tempServerName == "") {
					CurrentPage--;
					UpdateWizard();
					MessageBox.Show("Server name may not be blank. Type a valid server name to continue.");
				} else if (tempServerName.Length > 200) {
					CurrentPage--;
					UpdateWizard();
					MessageBox.Show("Server name may not be longer than 200 characters. Type a valid server name to continue.");
				} else {
					TitleLbl.Text = "Step 3: Server Password";
					DescriptionLbl.Text = "Your BooBox Server allows for the option of password protecting your server against unauthorized access. This feature is popular with those server administrators who wish to run a private server for their organization.\n\nIf you would like to specify a password check the box below and enter a password in the box then click 'Next'. If not, simply click 'Next'.";
					CheckBox.Top = 175;
					InputOneTxt.Top = 200; InputOneTxt.Left = 154; InputOneTxt.Width = 318;
					CheckBox.Checked = tempServerPasswordChk;
					InputOneTxt.Text = tempServerPassword;
					InputOneTxt.Enabled = CheckBox.Checked;
					CheckBox.Visible = true;
					InputOneTxt.Visible = true;
				}
				#endregion
			} else if (CurrentPage == 3) {
				#region Step 4: Listening Ports
				if (PreviousPage == 2) {
					tempServerPasswordChk = CheckBox.Checked;
					tempServerPassword = InputOneTxt.Text;
				}
				if ((tempServerPasswordChk == true) && (tempServerPassword == "")) {
					CurrentPage--;
					UpdateWizard();
					MessageBox.Show("You have specified that this server should have a password\nbut have not specified one. Either disable the password or enter\none to continue.");
				} else if ((tempServerPasswordChk == true) && (tempServerPassword.Length > 50)) {
					CurrentPage--;
					UpdateWizard();
					MessageBox.Show("Your password must be less than 50 characters in length.");
				} else {
					TitleLbl.Text = "Step 4: Listening Ports";
					DescriptionLbl.Text = "Your BooBox Server will need to listen for incomming connections on certain ports. If you go through a router or other such device it will be necessary to forward these ports to your computer before your clients can successfully connect to your server.\n\nTwo ports are required:\n1) Information Port, and\n2) Transfer Port\n\nPlease specify the ports below and click 'Next':\n\n\nInformation Port:\n\n    Transfer Port:";
					InputOneTxt.Text = tempPortInfo.ToString();
					InputTwoTxt.Text = tempPortTrans.ToString();
					InputOneTxt.Top = 200; InputOneTxt.Width = 100; InputOneTxt.Left = 237;
					InputTwoTxt.Top = 225; InputTwoTxt.Width = 100; InputTwoTxt.Left = 237;
					InputOneTxt.Visible = true;
					InputTwoTxt.Visible = true;
				}
				#endregion
			} else if (CurrentPage == 4) {
				#region Step 5: Finished!
				if (PreviousPage == 3) {
					tempPortInfo = Convert.ToInt32(InputOneTxt.Text);
					tempPortTrans = Convert.ToInt32(InputTwoTxt.Text);
				}
				if ((tempPortInfo < 1) || (tempPortInfo > 65535)) {
					CurrentPage--;
					UpdateWizard();
					MessageBox.Show("Your Information Port number is invalid. Please choose a port between 1 and 65535.");
				} else if ((tempPortTrans < 1) || (tempPortTrans > 65535)) {
					CurrentPage--;
					UpdateWizard();
					MessageBox.Show("Your Transfer Port number is invalid. Please choose a port between 1 and 65535.");
				} else {
					TitleLbl.Text = "Step 5: Finished!";
					DescriptionLbl.Text = "Initial configuration of your BooBox Server has been successfully completed!\n\nAll configuration options you have specified in this First Run Wizard can be changed at any point by choosing the appropriate option from the Options menu at the top of your server's interface.\n\nYou may now add a folder to your Music Library by choosing \"Add Folder to Library\" from the File menu.\n\n Click 'Finish' and enjoy!";
					NextCmd.Text = "Finish";
				}
				#endregion
			} else if (CurrentPage == 5) {
				NextCmd.Text = "Finish";
				Config.Instance.CommInfoPort = tempPortInfo;
				Config.Instance.CommStreamPort = tempPortTrans;
				Config.Instance.PasswordRequired = tempServerPasswordChk;
				Config.Instance.ServerPassword = tempServerPassword;
				Config.Instance.ServerName = tempServerName;
				Config.Instance.Configured = true;
				Config.Instance.Save();
				Forms.MainFrm.UpdateFormState("Normal");
				this.Close();
			}
		}

		public FirstRunFrm() {
			InitializeComponent();
		}

		private void FirstRunFrm_Load(object sender, EventArgs e) {
			Forms.FirstRunFrm = this;
			TitleLbl.Text = "Step 1: Welcome!";
			DescriptionLbl.Text = "Welcome to the BooBox Server First Run Wizard!\n\nThis wizard will allow you to specify several basic configuration options for your BooBox Server.\n\nYou can change all information specified in this wizard at a later point by choosing the appropriate option from one the Options menu found at the top of your server's interface.\n\nClick 'Next' to continue!";
		}

		private void NextCmd_Click(object sender, EventArgs e) {
			PreviousPage = CurrentPage;
			CurrentPage++;
			UpdateWizard();
		}

		private void BackCmd_Click(object sender, EventArgs e) {
			PreviousPage = CurrentPage;
			CurrentPage--;
			UpdateWizard();
		}

		private void CheckBox_CheckedChanged(object sender, EventArgs e) {
			InputOneTxt.Enabled = CheckBox.Checked;
		}
	}
}
