using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurrenciesUI
{
    public partial class CurrencyHomeForm : Form
    {
        private Dictionary<string, Form> myForms = new Dictionary<string, Form>();
        public CurrencyHomeForm()
        {
            InitializeComponent();
        }

        private void CurrencyForm_Load(object sender, EventArgs e)
        {
            myForms.Add("Type", new TypeForm());
            myForms.Add("Country", new CountryForm());
            myForms.Add("Colour", new ColourForm());
            myForms.Add("Currency", new CurrencyForm());

            foreach (KeyValuePair<string, Form> myForm in myForms)
            {
                myForm.Value.MdiParent = this;
                myForm.Value.FormBorderStyle = FormBorderStyle.None;
                myForm.Value.Dock = DockStyle.Fill;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Goodbye.");
            Application.Exit();
        }

        private void TypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Hide();

            myForms["Type"].Show();
        }

        private void CountryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Hide();

            myForms["Country"].Show();
        }

        private void ColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Hide();

            myForms["Colour"].Show();
        }

        private void CurrencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Hide();

            myForms["Currency"].Show();
        }
    }
}
