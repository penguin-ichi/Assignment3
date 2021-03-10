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
    public partial class frmPopup : Form
    {
        public frmPopup(Product p)
        {
            InitializeComponent();
            LoadData(p);
        }

        private void LoadData(Product p)
        {
            lbProductID.Text = p.ProductID.ToString();
            lbProductName.Text = p.ProductName.ToString();
            lbUnitPrice.Text = p.UnitPrice.ToString();
            lbQuantity.Text = p.Quantity.ToString();
        }
    }
}
