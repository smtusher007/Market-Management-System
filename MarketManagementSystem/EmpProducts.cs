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
    public partial class EmpProducts : Form
    {
        public object EProduct { get; private set; }

        public EmpProducts()
        {
            InitializeComponent();
        }

        private void linkEmpPro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Home1().Show();
            this.Hide();
        }

        private void btnAddEmpProduct_Click(object sender, EventArgs e)
        {
            if (txtEmpProductId.Text != "" & txtEmpProductName.Text != "" & txtEmpProductType.Text != "" & txtEmpQuantity.Text != "")
            {
                EProduct eProduct = new EProduct();
                eProduct.PID = txtEmpProductId.Text;
                eProduct.PName = txtEmpProductName.Text;
                eProduct.PType = txtEmpProductType.Text;
                eProduct.PQuantity = txtEmpQuantity.Text;
                txtEmpProductId.Clear();
                txtEmpProductName.Clear();
                txtEmpProductType.Clear();
                txtEmpQuantity.Clear();

                OProduct oProduct = new OProduct(eProduct);
                int effectedRows = oProduct.AddProducts(eProduct);
                effectedRows = oProduct.CopyPID(eProduct);
                MessageBox.Show("Product has been added");
            }
            else
            {
                MessageBox.Show("Please fill up every feild");
            }
        }

        private void btnEmpSrchPro_Click(object sender, EventArgs e)
        {
            if(txtDeleteEmpProduct.Text !="")
            {
                EProduct eProduct = new EProduct();
                eProduct.PID = txtDeleteEmpProduct.Text;

                OProduct oProduct = new OProduct(eProduct);
                SqlDataAdapter sqlDataAdapter = oProduct.SrchProduct();
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataSrchResult.DataSource = dataTable;
            }
            else { MessageBox.Show("Please Enter a Product ID"); }
            txtDeleteEmpProduct.Clear();
        }

        private void btnUpdateEmpProduct_Click(object sender, EventArgs e)
        {
            if(txtDeleteEmpProduct.Text !="")
            {
                EProduct eProduct = new EProduct();
                eProduct.PID = txtDeleteEmpProduct.Text;
                eProduct.PQuantity = txtProductUpdate.Text;
                txtDeleteEmpProduct.Clear();
                txtProductUpdate.Clear();

                OProduct oProduct = new OProduct(eProduct);
                int effectedRows = oProduct.UpdateProduct(eProduct);
                
                if(effectedRows>0)
                {
                    MessageBox.Show("Product updated");

                }
                else
                {
                    MessageBox.Show("Error to Update Product");
                }
                
            }
            else
            {
                MessageBox.Show("Please Enter a Product ID");
            }
            txtDeleteEmpProduct.Clear();
        }

        private void btnShowEmpPro_Click(object sender, EventArgs e)
        {
            EProduct eProduct = new EProduct();
            OProduct oProduct = new OProduct(eProduct);
            SqlDataAdapter sqlDataAdapter = oProduct.ShowAllProduct();
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataShowEmpProduct.DataSource = dataTable;
        }

        private void txtEmpProductId_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter the ID of the Product";
        }

        private void txtEmpProductName_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter the Name of the Product";
        }

        private void txtEmpProductType_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Type of the product";
        }

        private void txtEmpQuantity_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter the product quantity by counting";
        }

        private void txtDeleteEmpProduct_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Search or delete product";
        }

        private void txtProductUpdate_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Update the Quantity of the product by your calculation";
        }
    }
}
