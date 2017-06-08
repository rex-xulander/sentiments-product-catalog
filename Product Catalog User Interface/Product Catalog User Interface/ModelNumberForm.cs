using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using DataOperations;

namespace WindowsApplication_cs
{
    public partial class ModelNumberForm : Form
    {
        private bool addingNewModelNumber;
        private DataRow ModelNumberRow;
        private List<TextBox> formTextBoxes = new List<TextBox>();
        private List<ComboBox> formComboBoxes = new List<ComboBox>();
   
        public ModelNumberForm(bool AddMode, ref DataRow currentRow)
        {
            InitializeComponent();
            addingNewModelNumber = AddMode;
            ModelNumberRow = currentRow;
        }
        public ModelNumberForm(bool AddMode)
        {
            InitializeComponent();
            addingNewModelNumber = AddMode;
        }
        public ModelNumberForm()
        {
            InitializeComponent();
        }

        private void ModelNumberForm_Load(object sender, EventArgs e)
        {
            formTextBoxes.AddRange(Controls.OfType<TextBox>().ToArray());
            formComboBoxes.AddRange(Controls.OfType<ComboBox>().ToArray());

            setFormHeaderTitle();
            loadCategoryListsFromDatabaseIntoComboBoxes();
            if(!addingNewModelNumber)
            {
                loadEditRowInfoIntoFields();
            }
        }
            private void setFormHeaderTitle()
        {
            if (addingNewModelNumber)
            {
                Text = "Adding New Model Number";
            }
            else
            {
                Text = "Editing Current Model Number";
            }
        }
            private void loadCategoryListsFromDatabaseIntoComboBoxes()
        {
            foreach (var comboBox in formComboBoxes)
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }

            Operations ops = new Operations();

            cboProductName.Items.AddRange(ops.getProductNameList().ToArray());
            cboColorName.Items.AddRange(ops.getColorNameList().ToArray());
            cboPatternName.Items.AddRange(ops.getPatternNameList().ToArray());
            cboSize.Items.AddRange(ops.getSizeNameList().ToArray());
            cboBrandName.Items.AddRange(ops.getBrandNameList().ToArray());
            
        }
            private void loadEditRowInfoIntoFields()
        {
            cboProductName.Text = ModelNumberRow.Field<string>("ProductName");
            cboPatternName.Text = ModelNumberRow.Field<string>("Pattern");
            cboColorName.Text = ModelNumberRow.Field<string>("Color");
            cboSize.Text = ModelNumberRow.Field<string>("Size");
            cboBrandName.Text = ModelNumberRow.Field<string>("Brand");
        }

        //User Button Actions
        private void cmdAccept_Click(object sender, EventArgs e)
        {
            if (formComboBoxes.Where((comboBox) => string.IsNullOrWhiteSpace(comboBox.Text)).Any())
            {
                MessageBox.Show("To save a record all fields must have information.");
                return;
            }
            else
            {
                if (!addingNewModelNumber)
                {
                    Operations ops = new Operations();
                    ops.tryToEditCurrentModelNumber(
                        Convert.ToInt32(ModelNumberRow.Field<double>("SKU")),
                        cboProductName.Text,
                        cboPatternName.Text,
                        cboColorName.Text,
                        cboSize.Text,
                        cboBrandName.Text);

                }
                else //if Adding New Model Number 
                {
                    MessageBox.Show("In Form calling Operation to Try to Add new Model Number");
                    Operations ops = new Operations();
                    int countOfExistingProducts = ops.tryToAddNewModelNumberToDatabase(
                        cboProductName.Text, 
                        cboPatternName.Text, 
                        cboColorName.Text, 
                        cboSize.Text, 
                        cboBrandName.Text);

                    MessageBox.Show("Number of Existing Model Numbers: " + countOfExistingProducts);
                }

                DialogResult = DialogResult.OK;
            }

        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (ModelNumberRow != null)
            {
                ModelNumberRow.RejectChanges();
            }
            DialogResult = DialogResult.Cancel;
        }

    }
}
