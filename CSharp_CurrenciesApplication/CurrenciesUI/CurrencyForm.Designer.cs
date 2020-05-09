namespace CurrenciesUI
{
    partial class CurrencyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CurrencyListBox = new System.Windows.Forms.ListBox();
            this.CurrencyIDTextBox = new System.Windows.Forms.TextBox();
            this.CurrencyIDLabel = new System.Windows.Forms.Label();
            this.CurrencyNameTextBox = new System.Windows.Forms.TextBox();
            this.CurrencyNameLabel = new System.Windows.Forms.Label();
            this.CurrencyColourIDComboBox = new System.Windows.Forms.ComboBox();
            this.CurrencyColourIDLabel = new System.Windows.Forms.Label();
            this.CountryCodeCurrencyComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddCurrencyButton = new System.Windows.Forms.Button();
            this.SaveCurrencyButton = new System.Windows.Forms.Button();
            this.DeleteCurrencyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CurrencyListBox
            // 
            this.CurrencyListBox.FormattingEnabled = true;
            this.CurrencyListBox.Location = new System.Drawing.Point(25, 50);
            this.CurrencyListBox.Name = "CurrencyListBox";
            this.CurrencyListBox.Size = new System.Drawing.Size(149, 264);
            this.CurrencyListBox.TabIndex = 0;
            this.CurrencyListBox.SelectedIndexChanged += new System.EventHandler(this.CurrencyListBox_SelectedIndexChanged);
            // 
            // CurrencyIDTextBox
            // 
            this.CurrencyIDTextBox.Enabled = false;
            this.CurrencyIDTextBox.Location = new System.Drawing.Point(315, 62);
            this.CurrencyIDTextBox.Name = "CurrencyIDTextBox";
            this.CurrencyIDTextBox.Size = new System.Drawing.Size(118, 20);
            this.CurrencyIDTextBox.TabIndex = 1;
            // 
            // CurrencyIDLabel
            // 
            this.CurrencyIDLabel.AutoSize = true;
            this.CurrencyIDLabel.Location = new System.Drawing.Point(214, 65);
            this.CurrencyIDLabel.Name = "CurrencyIDLabel";
            this.CurrencyIDLabel.Size = new System.Drawing.Size(22, 13);
            this.CurrencyIDLabel.TabIndex = 2;
            this.CurrencyIDLabel.Text = "Id: ";
            // 
            // CurrencyNameTextBox
            // 
            this.CurrencyNameTextBox.Location = new System.Drawing.Point(315, 131);
            this.CurrencyNameTextBox.Name = "CurrencyNameTextBox";
            this.CurrencyNameTextBox.Size = new System.Drawing.Size(121, 20);
            this.CurrencyNameTextBox.TabIndex = 3;
            // 
            // CurrencyNameLabel
            // 
            this.CurrencyNameLabel.AutoSize = true;
            this.CurrencyNameLabel.Location = new System.Drawing.Point(214, 134);
            this.CurrencyNameLabel.Name = "CurrencyNameLabel";
            this.CurrencyNameLabel.Size = new System.Drawing.Size(41, 13);
            this.CurrencyNameLabel.TabIndex = 4;
            this.CurrencyNameLabel.Text = "Name: ";
            // 
            // CurrencyColourIDComboBox
            // 
            this.CurrencyColourIDComboBox.FormattingEnabled = true;
            this.CurrencyColourIDComboBox.Location = new System.Drawing.Point(315, 208);
            this.CurrencyColourIDComboBox.Name = "CurrencyColourIDComboBox";
            this.CurrencyColourIDComboBox.Size = new System.Drawing.Size(121, 21);
            this.CurrencyColourIDComboBox.TabIndex = 5;
            // 
            // CurrencyColourIDLabel
            // 
            this.CurrencyColourIDLabel.AutoSize = true;
            this.CurrencyColourIDLabel.Location = new System.Drawing.Point(214, 211);
            this.CurrencyColourIDLabel.Name = "CurrencyColourIDLabel";
            this.CurrencyColourIDLabel.Size = new System.Drawing.Size(57, 13);
            this.CurrencyColourIDLabel.TabIndex = 6;
            this.CurrencyColourIDLabel.Text = "Colour ID: ";
            // 
            // CountryCodeCurrencyComboBox
            // 
            this.CountryCodeCurrencyComboBox.FormattingEnabled = true;
            this.CountryCodeCurrencyComboBox.Location = new System.Drawing.Point(315, 283);
            this.CountryCodeCurrencyComboBox.Name = "CountryCodeCurrencyComboBox";
            this.CountryCodeCurrencyComboBox.Size = new System.Drawing.Size(121, 21);
            this.CountryCodeCurrencyComboBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Country Code: ";
            // 
            // AddCurrencyButton
            // 
            this.AddCurrencyButton.Location = new System.Drawing.Point(196, 345);
            this.AddCurrencyButton.Name = "AddCurrencyButton";
            this.AddCurrencyButton.Size = new System.Drawing.Size(75, 23);
            this.AddCurrencyButton.TabIndex = 9;
            this.AddCurrencyButton.Text = "Add";
            this.AddCurrencyButton.UseVisualStyleBackColor = true;
            this.AddCurrencyButton.Click += new System.EventHandler(this.AddCurrencyButton_Click);
            // 
            // SaveCurrencyButton
            // 
            this.SaveCurrencyButton.Location = new System.Drawing.Point(358, 344);
            this.SaveCurrencyButton.Name = "SaveCurrencyButton";
            this.SaveCurrencyButton.Size = new System.Drawing.Size(75, 23);
            this.SaveCurrencyButton.TabIndex = 10;
            this.SaveCurrencyButton.Text = "Save";
            this.SaveCurrencyButton.UseVisualStyleBackColor = true;
            this.SaveCurrencyButton.Click += new System.EventHandler(this.SaveCurrencyButton_Click);
            // 
            // DeleteCurrencyButton
            // 
            this.DeleteCurrencyButton.Location = new System.Drawing.Point(513, 344);
            this.DeleteCurrencyButton.Name = "DeleteCurrencyButton";
            this.DeleteCurrencyButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteCurrencyButton.TabIndex = 11;
            this.DeleteCurrencyButton.Text = "Delete";
            this.DeleteCurrencyButton.UseVisualStyleBackColor = true;
            this.DeleteCurrencyButton.Click += new System.EventHandler(this.DeleteCurrencyButton_Click);
            // 
            // CurrencyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeleteCurrencyButton);
            this.Controls.Add(this.SaveCurrencyButton);
            this.Controls.Add(this.AddCurrencyButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CountryCodeCurrencyComboBox);
            this.Controls.Add(this.CurrencyColourIDLabel);
            this.Controls.Add(this.CurrencyColourIDComboBox);
            this.Controls.Add(this.CurrencyNameLabel);
            this.Controls.Add(this.CurrencyNameTextBox);
            this.Controls.Add(this.CurrencyIDLabel);
            this.Controls.Add(this.CurrencyIDTextBox);
            this.Controls.Add(this.CurrencyListBox);
            this.Name = "CurrencyForm";
            this.Text = "CurrencyForm";
            this.Load += new System.EventHandler(this.CurrencyForm_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox CurrencyListBox;
        private System.Windows.Forms.TextBox CurrencyIDTextBox;
        private System.Windows.Forms.Label CurrencyIDLabel;
        private System.Windows.Forms.TextBox CurrencyNameTextBox;
        private System.Windows.Forms.Label CurrencyNameLabel;
        private System.Windows.Forms.ComboBox CurrencyColourIDComboBox;
        private System.Windows.Forms.Label CurrencyColourIDLabel;
        private System.Windows.Forms.ComboBox CountryCodeCurrencyComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddCurrencyButton;
        private System.Windows.Forms.Button SaveCurrencyButton;
        private System.Windows.Forms.Button DeleteCurrencyButton;
    }
}