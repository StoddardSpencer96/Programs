using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CurrenciesDAL;
using Currency = CurrenciesDAL.Models.Currency;
using Colour = CurrenciesDAL.Models.Colour;
using Country = CurrenciesDAL.Models.Country;

namespace CurrenciesUI
{
    public partial class CurrencyForm : Form
    {
        public CurrencyForm()
        {
            InitializeComponent();
        }

        private void CurrencyForm_Load_1(object sender, EventArgs e)
        {
            //Getting a list of Currencies from DAL (TypesManager)
            List<Colour> Colours = ColoursManager.GetColourList();
            CurrencyColourIDComboBox.DataSource = Colours;
            CurrencyColourIDComboBox.DisplayMember = "Name";
            CurrencyColourIDComboBox.ValueMember = "Name";

            List<Country> Countries = CountryManager.GetCountryList();
            CountryCodeCurrencyComboBox.DataSource = Countries;
            CountryCodeCurrencyComboBox.DisplayMember = "Country Code";
            CountryCodeCurrencyComboBox.ValueMember = "CountryCode";

            ////Put the data into the list box
            List<Currency> Currencies = CurrenciesDAL.CurrencyManager.GetCurrencyList();
            CurrencyListBox.DataSource = Currencies;
            CurrencyListBox.DisplayMember = "Name";


        }

        private void CurrencyListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrencyListBox.SelectedIndex > -1)
            {
                //Update the textboxes with the new selected item
                Currency selectedCurrency = (Currency)CurrencyListBox.SelectedItem;

                CurrencyIDTextBox.Text = selectedCurrency.Id.ToString();
                CurrencyNameTextBox.Text = selectedCurrency.Name;
                CurrencyColourIDComboBox.SelectedValue = selectedCurrency.ColourId.ToString();
                CountryCodeCurrencyComboBox.SelectedValue = selectedCurrency.CountryCode;

            }

        }

        private void SaveCurrencyButton_Click(object sender, EventArgs e)
        {
            if (CurrencyIDTextBox.Text == string.Empty)
            {
                //Create new currency entry
                Currency c = new Currency();
                c.Id = Convert.ToInt32(CurrencyIDTextBox.Text);
                c.Name = CurrencyNameTextBox.Text;

                Currency savedCurrency = CurrenciesDAL.CurrencyManager.AddCurrency(c);
                //create successful
                MessageBox.Show("Currency Added");

                //refresh the listbox
                List<Currency> currencyList = CurrenciesDAL.CurrencyManager.GetCurrencyList();
                CurrencyListBox.DataSource = currencyList;

            }
            else
            {
                //Update existing currency entry
                int currencyId = int.Parse(CurrencyIDTextBox.Text);
                string currencyName = CurrencyNameTextBox.Text;
                int colourId = Convert.ToInt32(CurrencyColourIDComboBox.SelectedValue);
                string countryCode = CountryCodeCurrencyComboBox.SelectedValue.ToString();

                if (CurrenciesDAL.CurrencyManager.UpdateCurrency(currencyId, currencyName, colourId, countryCode) == 1)
                {
                    MessageBox.Show("Currency Updated.");

                    //refresh the currency list
                    List<Currency> currencyList = CurrenciesDAL.CurrencyManager.GetCurrencyList();
                    CurrencyListBox.DataSource = currencyList;

                    //re-select the currency
                    //Prompt user if currency was not updated

                }
                else
                {
                    MessageBox.Show("Currency NOT updated.");
                }
            }

        }

        private void DeleteCurrencyButton_Click(object sender, EventArgs e)
        {
            int currencyId = int.Parse(CurrencyIDTextBox.Text);

            int rowsAffected = CurrenciesDAL.CurrencyManager.DeleteCurrency(currencyId);

            if (rowsAffected == 1)
            {
                MessageBox.Show(
                    "Currency Deleted",
                    "Deleted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                //refresh the list box because the currency was deleted
                CurrencyListBox.DataSource = CurrenciesDAL.CurrencyManager.GetCurrencyList();
            }
            else
            {
                MessageBox.Show(
                    "Unable to delete Currency. Check log files for details",
                    "Unable to Delete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void AddCurrencyButton_Click(object sender, EventArgs e)
        {
            //set the value of id in the textbox to be empty string
            CurrencyIDTextBox.Text = string.Empty;

            //clear any value in the name textbox
            CurrencyNameTextBox.Text = string.Empty;

            //clear any selection in the listbox
            CurrencyListBox.SelectedIndex = -1;

            //set focus to the name list box
            CurrencyNameTextBox.Focus();

            //select the first item in the combobox
            CountryCodeCurrencyComboBox.SelectedIndex = 0;
        }

    }
}