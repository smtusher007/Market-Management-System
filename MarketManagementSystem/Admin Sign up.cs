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
    public partial class Admin_Sign_up : Form
    {
        public Admin_Sign_up()
        {
            InitializeComponent();
        }

       

        private void linkAdSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
                if (txtAdName.Text != "" & txtAdEmail.Text != "" & txtAdNID.Text != "" & txtAdPass.Text != "" & txtAdPhoneNo.Text != "" & txtAdConfirmPass.Text != "")
                {
                    if (Convert.ToInt32(txtAge.Text) >= 18)
                    {
                        if (txtAdPass.Text == txtAdConfirmPass.Text)
                        {
                            EAdmin eAdmin = new EAdmin();
                            eAdmin.Adname = txtAdName.Text;
                            eAdmin.AdEmail = txtAdEmail.Text;
                            eAdmin.AdNID = txtAdNID.Text;
                            eAdmin.AdPhoneNo = txtAdPhoneNo.Text;
                            eAdmin.AdAdress = txtAdAdress.Text;

                            OAdmin oAdmin = new OAdmin(eAdmin);
                            int effectedRows = oAdmin.AdSignUp(eAdmin);
                            new Home2().Show();
                            this.Hide();
                            MessageBox.Show("Account created");
                        }
                        else
                        {
                            MessageBox.Show("Confirm Password not correct");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your age is not eligable");
                    }


                }
                else
                {
                    MessageBox.Show("Every field should be filled");
                }
            
            
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            new Admin_Log_in().Show();
            this.Hide();
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime from = dateTimePicker1.Value;
            DateTime current = DateTime.Now;
            TimeSpan timeSpan = current - from;
            txtAge.Text = (timeSpan.TotalDays / 365).ToString("0");
        }

        private void txtAdName_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter Your Full Name";
        }

        private void txtAdEmail_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter a Valid Email";
        }

        private void dateTimePicker1_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter Your Date of Birth as per your documents";
        }

        private void txtAge_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Your age should be 18 or above";
        }

        private void txtAdPass_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter Password Using Upper case, lower case and special character(ex:@ ,%,#)";
        }

        private void txtAdPhoneNo_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter your valid phone number";
        }

        private void txtAdAdress_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter your adress as per your NID";
        }

        private void txtAdNID_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter your 17 digit NID card number";
        }

        private void linkAdSignUp_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Sign up for this system";
        }


    }
}
