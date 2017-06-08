using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_Catalog_User_Interface
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'master_SheetsDataSet.ProductCatalog' table. You can move, or remove it, as needed.
            this.productCatalogTableAdapter1.Fill(this.master_SheetsDataSet.ProductCatalog);
        }


        //Edit Existing Model Number
        private void productCatalogBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            editCurrentRow();
        }
            private void editCurrentRow()
        {
            DataRow currentSelectedRow = ((DataRowView)productCatalogBindingSource1.Current).Row;
            WindowsApplication_cs.ModelNumberForm f = new WindowsApplication_cs.ModelNumberForm(false, ref currentSelectedRow);

            try
            {
                if(f.ShowDialog() == DialogResult.OK)
                {
                    refreshDataTable();
                }
            }
            finally
            {
                f.Dispose();
                productCatalogDataGridView.Refresh();
            }
        }

        //Add New Model Number
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            addNewModelNumber();
        }
        private void addNewModelNumber()
        {
            WindowsApplication_cs.ModelNumberForm f = new WindowsApplication_cs.ModelNumberForm(true);

            try
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    refreshDataTable();
                }
            }
            finally
            {
                f.Dispose();
                productCatalogDataGridView.Refresh();
            }
        }
            private void refreshDataTable()
        {
            this.productCatalogTableAdapter1.Fill(this.master_SheetsDataSet.ProductCatalog);
        }
        
        
        //Category Adder Form Calls
        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addNewCategory("Product");
        }
        private void patternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addNewCategory("Pattern");
        }
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addNewCategory("Color");
        }
        private void brandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addNewCategory("Brand");
        }
        private void sizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addNewCategory("Size");
        }

        private void addNewCategory(string category)
        {
            CategoryAdder f = new CategoryAdder(category);

            try
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    refreshDataTable();
                }
            }
            finally
            {
                f.Dispose();
                productCatalogDataGridView.Refresh();
            }
        }
    }
}
