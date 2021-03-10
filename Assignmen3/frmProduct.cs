using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryAssignment3;

namespace Assignmen3
{
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        ProductDB db = new ProductDB();

        public void LoadProduct()
        {
            List<Product> listProduct = db.GetProductList();
            dgvProductList.DataSource = listProduct;
        }
        private void frmProduct_Load(object sender, EventArgs e)
        {
            LoadProduct();
        }
        private String valid(string id, string name, string price, string quantity)
        {
            string error = "";
            if ("".Equals(id) || "".Equals(name) || "".Equals(price) || "".Equals(quantity))
            {
                error = "Cannot empty";
            }
            else
            {
                try
                {
                    int.Parse(id);
                }
                catch (Exception)
                {
                    error += "id: Input number!\n";
                }
                try
                {
                    float.Parse(price);
                }
                catch (Exception)
                {
                    error += "price: Input number!\n";
                }
                try
                {
                    int.Parse(quantity);
                }
                catch (Exception)
                {
                    error += "quantity: Input number!";
                }
            }
            return error;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String id = txtProductID.Text;
            String name = txtProductName.Text;
            String price = txtUnitPrice.Text;
            String quantity = txtQuantity.Text;
            string error = valid(id, name, price, quantity);
            if (error.Equals(""))
            {
                Product p = new Product(int.Parse(id), name, float.Parse(price), int.Parse(quantity));
                bool check = db.AddNewProduct(p);
                if (check)
                {
                    LoadProduct();
                    MessageBox.Show("Add success!");
                }
                else
                {
                    MessageBox.Show("Id is exist");
                }
            }
            else
            {
                MessageBox.Show(error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtProductID.Text;
            if ("".Equals(id))
            {
                MessageBox.Show("Input id to remove!");
            }
            else
            {
                Product p = db.FindProduct(int.Parse(id));
                if (p != null)
                {
                    if (db.RemoveProduct(p))
                    {
                        LoadProduct();
                        MessageBox.Show("Remove success!");
                        txtProductID.Clear();
                        txtProductName.Clear();
                        txtUnitPrice.Clear();
                        txtQuantity.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Not found!");
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String id = txtProductID.Text;
            String name = txtProductName.Text;
            String price = txtUnitPrice.Text;
            String quantity = txtQuantity.Text;
            string error = valid(id, name, price, quantity);
            if (error.Equals(""))
            {
                Product p = new Product(int.Parse(id), name, float.Parse(price), int.Parse(quantity));
                bool check = db.UpdateProduct(p);
                if(check)
                {
                    LoadProduct();
                    MessageBox.Show("Update success!");
                }
                else
                {
                    MessageBox.Show("ID isn't exist!");
                }
            }
            else
            {
                MessageBox.Show(error);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string id = txtProductID.Text;
            if ("".Equals(id))
            {
                MessageBox.Show("Input id to find!");
            }
            else
            {
                Product p = db.FindProduct(int.Parse(id));
                if (p != null)
                {
                    frmPopup pop = new frmPopup(p);
                    pop.Show();
                }
                else
                {
                    MessageBox.Show("ID can not found!");
                }
            }
        }
    }
}
