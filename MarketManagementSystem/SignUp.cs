using DataAcessLayerMarketManagetment.Entities;
using DataAcessLayerMarketManagetment.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketManagementSystem
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void linkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            
                if ((txtUserName.Text != "") & (txtEmpNID.Text != "") & (txtPassword.Text != "") & (txtPhoneNum.Text != "") & (txtAge.Text !=""))
                {
                    if (Convert.ToInt32(txtAge.Text) >= 18)
                    {
                        if (txtPassword.Text == txtConfirmPassword.Text)
                        {
                            EemployeeInfo eemployeeInfo = new EemployeeInfo();


                            try { eemployeeInfo.Name = txtUserName.Text; }
                            catch { }

                            try { eemployeeInfo.Email = txtEmail.Text; }
                            catch { }

                            try { eemployeeInfo.NID = txtEmpNID.Text; }
                            catch { }

                            try { eemployeeInfo.PhoneNo = txtPhoneNum.Text; }
                            catch { }


                            OemployeeInfo oemployeeInfo = new OemployeeInfo(eemployeeInfo);
                            int effectedRows = oemployeeInfo.SignUpEmp(eemployeeInfo);
                            new Home1().Show();
                            this.Hide();
                            MessageBox.Show("Account Created");
                            effectedRows = oemployeeInfo.CopyEmp(eemployeeInfo);


                        }
                        else
                        {
                            MessageBox.Show("Confirm password was not correct");
                        }
                    }
                    else
                    {
                        MessageBox.Show("You are not eligable for this job");
                    }
                }
                else
                {
                    MessageBox.Show("All filed must be filled");
                }
            
            

            


        }

        private void linkLogIn2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new LogIn().Show();
            this.Hide();
        }

        private void linkAdSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Admin_Sign_up().Show();
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime from = dateTimePicker1.Value;
            DateTime current = DateTime.Now;
            TimeSpan timeSpan = current - from;
            txtAge.Text = (timeSpan.TotalDays / 365).ToString("0");
        }

        private void txtUserName_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter Valid User Name";
        }

        private void txtEmail_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter Valid Email";
        }

        private void dateTimePicker1_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter your date of birth as per your documents";
        }

        private void txtAge_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "your age sould be 18 or above";
        }

        private void txtPassword_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter Password Using Upper case, lower case and special character(ex:@ ,%,#)";
        }

        private void txtPhoneNum_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter your valid phone number";
        }

        private void comboRegion_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter your region where you leave";
        }

        private void txtEmpNID_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter your 17 digit NID card number";
        }
    }
}
