using CurrenciesDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Type = CurrenciesDAL.Models.Type;
using Currency = CurrenciesDAL.Models.Currency;
using Country = CurrenciesDAL.Models.Country;

namespace CurrenciesUI
{
    public partial class TypeForm : Form
    {
        public TypeForm()
        {
            InitializeComponent();
        }

        private void TypeForm_Load(object sender, EventArgs e)
        {

            //Getting a list of Types from DAL (TypesManager)
            List<Type> Types = TypesManager.GetTypeList();
            //List<Country> Countries = CountryManager.GetCountryList();
            //List<Currency> Currencies = CurrenciesDAL.CurrencyManager.GetCurrencyList();

            ////Put the data into the list box
            TypeListBox.DataSource = Types;
            TypeListBox.DisplayMember = "Name";


        }

        private void TypeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TypeListBox.SelectedIndex > -1)
            {
                //Update textboxes with the new selected item
                Type selectedType = (Type)TypeListBox.SelectedItem;
                //Country selectedType = (Country)TypeListBox.SelectedItem;
                //Currency selectedType = (Currency)TypeListBox.SelectedItem;

                TypeIDTextBox.Text = selectedType.Id.ToString();
                NameTextBox.Text = selectedType.Name;

            }
        }

        private void SaveTypeButton_Click(object sender, EventArgs e)
        {
            if (TypeIDTextBox.Text == string.Empty)
            {
                Type t = new Type();
                t.Name = NameTextBox.Text;

                Type savedType = TypesManager.AddType(t);

                MessageBox.Show("A new Type has been added.");

                //refresh the value in the list
                List<Type> typeList = TypesManager.GetTypeList();
                TypeListBox.DataSource = typeList;

                //re-select the chosen type
                SelectTypeFromListBox(savedType.Id);

            }
            else
            {
                //Update existing type entry
                int typeId = int.Parse(TypeIDTextBox.Text);
                string typeName = NameTextBox.Text;


                if (TypesManager.UpdateType(typeId, typeName) == 1)
                {
                    //update is successful
                    MessageBox.Show("Type has been updated.");

                    //Get the list of types, and refresh the list box
                    //Re-select the value in the list box
                    List<Type> typeList = TypesManager.GetTypeList();
                    TypeListBox.DataSource = typeList;
                }
                else
                {
                    MessageBox.Show("Type has NOT been updated.");
                }
            }
        }

        private void SelectTypeFromListBox(int typeId)
        {
            foreach (var item in TypeListBox.Items)
            {
                Type types = (Type)item;
                if (types.Id == typeId)
                {
                    TypeListBox.SelectedItem = item;
                    return;
                }
            }
        }

        private void DeleteTypeButton_Click(object sender, EventArgs e)
        {
            int typeId = int.Parse(TypeIDTextBox.Text); //parse from int to string
            int rowsAffected = TypesManager.DeleteType(typeId); //check for # rows affected
            if (rowsAffected == 1)
            {
                MessageBox.Show(
                    "Type deleted.", 
                    "Deleted", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    "Unable to delete type.",
                    "Unable to delete.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }
            //refresh the list with the updated information
            TypeListBox.DataSource = TypesManager.GetTypeList();
        }

        private void AddButtonType_Click(object sender, EventArgs e)
        {
            //set the value of id in the textbox to be an empty string
            TypeIDTextBox.Text = string.Empty;

            //clear any value in the name textbox
            NameTextBox.Text = string.Empty;

            //clear any selection in the listbox
            TypeListBox.SelectedIndex = -1;

            //set focus to the name list box
            NameTextBox.Focus();
        }
    }
}
