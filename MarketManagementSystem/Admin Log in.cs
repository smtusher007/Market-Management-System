﻿using System;
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
    public partial class Admin_Log_in : Form
    {
        public Admin_Log_in()
        {
            InitializeComponent();
        }

        private void linkAdLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            
            if (txtAdminId.Text == "oop2" & txtAdminPass.Text =="123")
            {
                new Home2().Show();
                this.Hide();
            }
            else if(txtAdminId.Text =="oop2" || txtAdminPass.Text=="123")
            {
                MessageBox.Show("User name or password is incorrect");
            }
            else 
            {
                MessageBox.Show("Access Denied");
            }
        }

        private void linkUserLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new LogIn().Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Admin_Sign_up().Show();
            this.Hide();
        }

        private void txtAdminId_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter Valid User Name";
        }

        private void txtAdminPass_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter Valid Password";
        }

        private void linkAdLogin_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Log in as an Admin";
        }
    }
}
