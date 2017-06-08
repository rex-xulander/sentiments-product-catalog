using DataOperations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Product_Catalog_User_Interface
{
    public partial class CategoryAdder : Form
    {
        String category;

        private List<TextBox> formTextBoxes = new List<TextBox>();

        public CategoryAdder()
        {
            InitializeComponent();
        }

        public CategoryAdder(string categoryType)
        {
            InitializeComponent();
            category = categoryType;

            setFormHeaderTitle();
            setTextBoxLabels();

            formTextBoxes.AddRange(Controls.OfType<TextBox>().ToArray());
            loadCategoryListsFromDatabaseIntoTextboxes();
        }

            private void setFormHeaderTitle()
        {
            Text = "Adding New " + category;
        }
            private void setTextBoxLabels()
        {
            catNameLabel.Text = category + " Name";
            catAbrLabel.Text = category + " Abbreviation";
        }

        private void CategoryAdder_Load(Object sender, EventArgs e)
        {
            formTextBoxes.AddRange(Controls.OfType<TextBox>().ToArray());
            loadCategoryListsFromDatabaseIntoTextboxes();
        }

        private void loadCategoryListsFromDatabaseIntoTextboxes()
        {
            Operations ops = new Operations();

            var autoCompleteNames = new AutoCompleteStringCollection();
            var autoCompleteAbbreviations = new AutoCompleteStringCollection();

            autoCompleteNames.AddRange(ops.getNamesList(category).ToArray());
            autoCompleteAbbreviations.AddRange(ops.getAbbreviationsList(category).ToArray());

            txtCatName.AutoCompleteCustomSource = autoCompleteNames;
            txtCatAbr.AutoCompleteCustomSource = autoCompleteAbbreviations;

            foreach (var textBox in formTextBoxes)
            {
                textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            if (notAllFieldsAreCompleted())
            {
                MessageBox.Show("To save a record all fields must have information.");
                return;
            }
            else if (userInputAlreadyExists())
            {
                MessageBox.Show("There is already a category or abbreviation with that name.");
            }
            else
            {
                Operations ops = new Operations();
                string catName = txtCatName.Text;
                string catAbbreviation = txtCatAbr.Text;

                ops.addNewCategoryIntoDatabase(category, catName, catAbbreviation);

                MessageBox.Show("New " + category + " has been added to database");

                DialogResult = DialogResult.OK;
            }
        }
            private bool notAllFieldsAreCompleted()
        {
            if (formTextBoxes.Where((comboBox) => string.IsNullOrWhiteSpace(comboBox.Text)).Any())
            {
                return true;
            }
            return false;
        }
            private bool userInputAlreadyExists()
        {
            //No need to check database, because can check the auto complete string collection which is pulled from database

            foreach (TextBox textBox in formTextBoxes) {

                if (textBox.AutoCompleteCustomSource.Contains(textBox.Text))
                {
                    return true;
                }
            }

            return false;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
