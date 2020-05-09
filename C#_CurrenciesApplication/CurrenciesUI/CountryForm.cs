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
using Country = CurrenciesDAL.Models.Country;

namespace CurrenciesUI
{
    public partial class CountryForm : Form
    {
        public CountryForm()
        {
            InitializeComponent();
        }

        private void CountryForm_Load(object sender, EventArgs e)
        {
            //Get the list of Countries from DAL (CountryManager)
            List<Country> Countries = CountryManager.GetCountryList();

            //Put the data into the list box
            CountryListBox.DataSource = Countries;
            CountryListBox.DisplayMember = "Name";

        }

        private void CountryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CountryListBox.SelectedIndex > -1)
            {
                Country selectedCountry = (Country)CountryListBox.SelectedItem;

                CountryCodeTextBox.Text = selectedCountry.CountryCode;
                CountryNameTextBox.Text = selectedCountry.Name;

            }
        }

        private void SelectCountryFromListBox(string countryCode)
        {
            foreach (var item in CountryListBox.Items)
            {
                Country countries = (Country)item;
                if (countries.CountryCode == countryCode)
                {
                    CountryListBox.SelectedItem = item;
                    return;
                }


            }
        }

        private void AddCountryButton_Click(object sender, EventArgs e)
        {
            //make the country code empty
            CountryCodeTextBox.Text = string.Empty;

            //clear any value in the name textbox
            CountryNameTextBox.Text = string.Empty;

            //clear the selection in the listbox
            CountryListBox.SelectedIndex = -1;

            CountryNameTextBox.Focus();
        }

        private void SaveCountryButton_Click(object sender, EventArgs e)
        {
            if (CountryCodeTextBox.Text != string.Empty)
            {
                //Create a new country entry
                Country country = new Country();
                country.Name = CountryNameTextBox.Text;

                //call the method in ColoursMaanger to save the data
                Country saveCountry = CountryManager.AddCountry(country);

                //create a message to indicate it was successful
                MessageBox.Show("A new country has been added.");

                //refresh the list to display the new information
                List<Country> countriesList = CountryManager.GetCountryList();
                CountryListBox.DataSource = countriesList;

                //select the new colour from the list
                SelectCountryFromListBox(saveCountry.CountryCode);
            }
            else
            {
                //Save changes to an existing item
                //get the selected country code and the name from the text boxes
                string countryCode = CountryCodeTextBox.Text;
                string countryName = CountryNameTextBox.Text;

                //execute the update from ColoursManager
                //then check the result
                //Converted the 1 from an int to a string
                int num = 1;
                string stringNum = num.ToString();

                if (CountryManager.UpdateCountry(countryCode, countryName) == stringNum)
                {
                    //create a message to indicate update was successful
                    MessageBox.Show("Country has been Updated");

                    //refresh the list to show the updated values
                    List<Country> countryList = CountryManager.GetCountryList();
                    CountryListBox.DataSource = countryList;
                }
                else
                {
                    //create a message to indicate update was NOT successful
                    MessageBox.Show("Country NOT updated.");
                }
            }
        }

        private void DeleteCountryButton_Click(object sender, EventArgs e)
        {
            string countryCode = CountryCodeTextBox.Text;
            int rowsAffected = Convert.ToInt32(CountryManager.DeleteCountry(countryCode));

            if (rowsAffected == 1)
            {
                MessageBox.Show(
                    "Country deleted.",
                    "Deleted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                   "Unable to delete country.",
                   "Unable to delete.",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);

                //refresh the list with the updated information
                CountryListBox.DataSource = CountryManager.GetCountryList();
            }
        }
    }
}
