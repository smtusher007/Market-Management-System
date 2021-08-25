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
    public partial class Admin_Stores : Form
    {
        public Admin_Stores()
        {
            InitializeComponent();
        }

        private void linkBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Home2().Show();
            this.Hide();
        }

        private void btnAddStore_Click(object sender, EventArgs e)
        {
            if(txtStoreName.Text !="" & txtStoreId.Text !="" & txtSType.Text !="")
            {
                EStore eStore = new EStore();
                eStore.SID = txtStoreId.Text;
                eStore.SName = txtStoreName.Text;
                eStore.SNo = txtSNo.Text;
                eStore.SType = txtSType.Text;

                OStore oStore = new OStore(eStore);
                int effectedRows = oStore.AddStore(eStore);
                MessageBox.Show("Store Added");

                txtStoreId.Clear();
                txtStoreName.Clear();
                txtSNo.Clear();
                txtSType.Clear();
                
            }
            else
            {
                MessageBox.Show("No feild shouldn't empty");
            }
        }

        private void btnDeleteAdStores_Click(object sender, EventArgs e)
        {
            if(txtDltStoreId.Text !="")
            {
                EStore eStore = new EStore();
                eStore.SID = txtDltStoreId.Text;

                OStore oStore = new OStore(eStore);
                int effectedRows = oStore.DeleteStore(eStore);
                if (effectedRows > 0)
                {
                    MessageBox.Show("Store Deleted");
                }
                else { MessageBox.Show("Store not Deleted"); }

                txtDltStoreId.Clear();
            }
            else
            {
                MessageBox.Show("Please Enter a Store ID");
            }
        }



        private void btnShowStores_Click(object sender, EventArgs e)
        {
            EStore eStore = new EStore();
            OStore oStore = new OStore(eStore);
            SqlDataAdapter sqlDataAdapter = oStore.ShowAllStore();
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataShowAdStore.DataSource = dataTable;
        }

        private void btnSearchStores_Click(object sender, EventArgs e)
        {
            if (txtDltStoreId.Text != "")
            {
                EStore eStore = new EStore();
                eStore.SID = txtDltStoreId.Text;
                OStore oStore = new OStore(eStore);
                SqlDataAdapter sqlDataAdapter = oStore.SrchStore();
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataSearchAdStore.DataSource = dataTable;

            }
            else
            {
                MessageBox.Show("Please Enter a Store ID");
            }
            txtDltStoreId.Clear();
        }

        private void txtStoreName_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter Valid Store Name";
        }

        private void txtStoreId_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter Valid Store ID";
        }

        private void txtSNo_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter a serial number to locate the store";
        }

        private void txtSType_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter the store type";
        }

        private void txtDltStoreId_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter store ID to search or delete a store";
        }

        private void btnShowStores_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Show All the Stores";
        }
    }
}
