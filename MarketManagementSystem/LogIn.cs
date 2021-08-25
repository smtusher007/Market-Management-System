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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtName.Text == "market" & txtPass.Text == "123")
            {
                new Home1().Show();
                this.Hide();
            }
            else if(txtName.Text == "market" || txtPass.Text == "123")
            {
                MessageBox.Show("User or Password is incorrect");
            }
            else
            {
                MessageBox.Show("Access Denied");
            }
        }

        private void linkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new SignUp().Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Admin_Log_in().Show();
            this.Hide();
        }

        private void txtName_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter Valid User Name";
        }

        private void txtPass_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter Valid Password";
        }
    }
}
