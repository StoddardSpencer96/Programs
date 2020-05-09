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
using Colour = CurrenciesDAL.Models.Colour;

namespace CurrenciesUI
{
    public partial class ColourForm : Form
    {
        public ColourForm()
        {
            InitializeComponent();
        }

        private void ColourForm_Load(object sender, EventArgs e)
        {
            //Getting a list of Colours from DAL (ColoursManager)
            List<Colour> Colours = ColoursManager.GetColourList();

            //Put the data into the list box
            ColourListBox.DataSource = Colours;
            ColourListBox.DisplayMember = "Name";
        }

        private void ColourListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ColourListBox.SelectedIndex > -1)
            {
                //Update the textboxes with the new selected item
                Colour selectedColour = (Colour)ColourListBox.SelectedItem;

                ColourIDTextBox.Text = selectedColour.Id.ToString();
                ColourNameTextBox.Text = selectedColour.Name;
            }
        }

        private void SaveColourButton_Click(object sender, EventArgs e)
        {
            if (ColourIDTextBox.Text == string.Empty)
            {
                //Create a new colour entry
                Colour colours = new Colour();
                colours.Name = ColourNameTextBox.Text;

                //call the method in ColoursMaanger to save the data
                Colour saveColour = ColoursManager.AddColour(colours);

                //create a message to indicate it was successful
                MessageBox.Show("New colour added.");

                //refresh the list to display the new information
                List<Colour> coloursList = ColoursManager.GetColourList();
                ColourListBox.DataSource = coloursList;

                //select the new colour from the list
                SelectColourFromListBox(saveColour.Id);
            }
            else
            {
                //Update existing colour entry
                int colourId = int.Parse(ColourIDTextBox.Text);
                string colourName = ColourNameTextBox.Text;

                if (ColoursManager.UpdateColour(colourId, colourName) == 1)
                {
                    //update is successful
                    MessageBox.Show("Colour has been updated.");

                    //Get the list of types, and refresh the list box
                    //Re-select the value in the list box
                    List<Colour> colourList = ColoursManager.GetColourList();
                    ColourListBox.DataSource = colourList;
                }
                else
                {
                    MessageBox.Show("Colour has NOT been updated.");
                }
            }
        }

        private void SelectColourFromListBox(int colourId)
        {
            foreach (var item in ColourListBox.Items)
            {
                Colour colours = (Colour)item;
                if (colours.Id == colourId)
                {
                    //select the colour as it has been found
                    ColourListBox.SelectedItem = item;
                    return;
                }
            }
        }

        private void AddColourButton_Click(object sender, EventArgs e)
        {
            //set the value of id in the textbox to be an empty string
            ColourIDTextBox.Text = string.Empty;

            //clear any value in the name textbox
            ColourNameTextBox.Text = string.Empty;

            //clear any selection in the listbox
            ColourListBox.SelectedIndex = -1;

            //set focus to the name list box
            ColourListBox.Focus();
        }

        private void DeleteColourButton_Click(object sender, EventArgs e)
        {
            //get the currently selected colour id to delete
            int colourId = int.Parse(ColourIDTextBox.Text);

            //execute it using the ColoursManager
            int rowsAffected = ColoursManager.DeleteColour(colourId);

            //check for the result
            if (rowsAffected == 1)
            {
                MessageBox.Show("Colour deleted",
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
            //refresh the list box with the updated information
            ColourListBox.DataSource = ColoursManager.GetColourList();
        }
    }
}
