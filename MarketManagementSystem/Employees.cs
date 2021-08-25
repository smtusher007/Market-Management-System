using DataAcessLayerMarketManagetment.Entities;
using DataAcessLayerMarketManagetment.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketManagementSystem
{
    public partial class Employees : Form
    {

        public Employees()
        {
            InitializeComponent();
        }

        private void linkBackEmp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Home2().Show();
            this.Hide();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            EemployeeInfo eemployeeInfo = new EemployeeInfo();
            try { eemployeeInfo.Position = txtEmpPost.Text;
                eemployeeInfo.NID = txtAssignNID.Text;
                txtAssignNID.Clear();
                txtEmpPost.Clear();
            }
            catch { }

            OemployeeInfo oemployeeInfo = new OemployeeInfo(eemployeeInfo);
            int effectedRows = oemployeeInfo.SetPosition(eemployeeInfo);
            if(effectedRows>0)
            {
                MessageBox.Show("Employee assigned");
            }
            else
            {
                MessageBox.Show("Employee not assigned");
            }
            



        }

        private void btnDltEmp_Click(object sender, EventArgs e)
        {
           EAdmin eAdmin = new EAdmin();
            try
            {
                eAdmin.AdNID = txtSrchNid.Text;
            }
            catch { }

            OAdmin oAdmin = new OAdmin(eAdmin);
            int effectedRows = oAdmin.DltFromEmpPosition(eAdmin);
            effectedRows = oAdmin.DltFromEmp(eAdmin);
            if (effectedRows > 0)
            {
                MessageBox.Show("Employee Deleted");
            }
            else
            {
                MessageBox.Show("Employee not Deleted");
            }
            txtSrchNid.Clear();
        }

        private void btnSearchEmp_Click(object sender, EventArgs e)
        {
            if (txtAssignNID.Text != "")
            {
                EemployeeInfo eemployeeInfo = new EemployeeInfo();
                try
                {
                    eemployeeInfo.NID = txtSrchNid.Text;
                }
                catch { }

                OemployeeInfo oemployeeInfo = new OemployeeInfo(eemployeeInfo);
                SqlDataAdapter sqlDataAdapter = oemployeeInfo.Search();
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataSearchViewEmp.DataSource = dataTable;
                txtSrchNid.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a valid NID");
            }

        }

        private void btnShowEmp_Click(object sender, EventArgs e)
        {
            EemployeeInfo eemployeeInfo = new EemployeeInfo();
            OemployeeInfo oemployeeInfo = new OemployeeInfo(eemployeeInfo);
            SqlDataAdapter sqlDataAdapter = oemployeeInfo.ShowAll();
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataShowAllEmp.DataSource = dataTable;

        }

        private void txtAssignNID_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter a employee's NID to assign";
        }

        private void txtEmpPost_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Post for the existing employee";
        }

        private void txtSrchNid_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter a NID number to search employee";
        }
    }
}
