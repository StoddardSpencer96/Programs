namespace CurrenciesUI
{
    partial class CountryForm
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
            this.CountryListBox = new System.Windows.Forms.ListBox();
            this.CountryCodeTextBox = new System.Windows.Forms.TextBox();
            this.CountryNameTextBox = new System.Windows.Forms.TextBox();
            this.CountryCodeLabel = new System.Windows.Forms.Label();
            this.CountryNameLabel = new System.Windows.Forms.Label();
            this.AddCountryButton = new System.Windows.Forms.Button();
            this.SaveCountryButton = new System.Windows.Forms.Button();
            this.DeleteCountryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CountryListBox
            // 
            this.CountryListBox.FormattingEnabled = true;
            this.CountryListBox.Location = new System.Drawing.Point(27, 37);
            this.CountryListBox.Name = "CountryListBox";
            this.CountryListBox.Size = new System.Drawing.Size(154, 316);
            this.CountryListBox.TabIndex = 0;
            this.CountryListBox.SelectedIndexChanged += new System.EventHandler(this.CountryListBox_SelectedIndexChanged);
            // 
            // CountryCodeTextBox
            // 
            this.CountryCodeTextBox.Location = new System.Drawing.Point(310, 98);
            this.CountryCodeTextBox.Name = "CountryCodeTextBox";
            this.CountryCodeTextBox.Size = new System.Drawing.Size(100, 20);
            this.CountryCodeTextBox.TabIndex = 1;
            // 
            // CountryNameTextBox
            // 
            this.CountryNameTextBox.Location = new System.Drawing.Point(310, 174);
            this.CountryNameTextBox.Name = "CountryNameTextBox";
            this.CountryNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.CountryNameTextBox.TabIndex = 2;
            // 
            // CountryCodeLabel
            // 
            this.CountryCodeLabel.AutoSize = true;
            this.CountryCodeLabel.Location = new System.Drawing.Point(214, 104);
            this.CountryCodeLabel.Name = "CountryCodeLabel";
            this.CountryCodeLabel.Size = new System.Drawing.Size(74, 13);
            this.CountryCodeLabel.TabIndex = 3;
            this.CountryCodeLabel.Text = "Country Code:";
            // 
            // CountryNameLabel
            // 
            this.CountryNameLabel.AutoSize = true;
            this.CountryNameLabel.Location = new System.Drawing.Point(217, 180);
            this.CountryNameLabel.Name = "CountryNameLabel";
            this.CountryNameLabel.Size = new System.Drawing.Size(41, 13);
            this.CountryNameLabel.TabIndex = 4;
            this.CountryNameLabel.Text = "Name: ";
            // 
            // AddCountryButton
            // 
            this.AddCountryButton.Location = new System.Drawing.Point(220, 235);
            this.AddCountryButton.Name = "AddCountryButton";
            this.AddCountryButton.Size = new System.Drawing.Size(75, 23);
            this.AddCountryButton.TabIndex = 5;
            this.AddCountryButton.Text = "Add";
            this.AddCountryButton.UseVisualStyleBackColor = true;
            this.AddCountryButton.Click += new System.EventHandler(this.AddCountryButton_Click);
            // 
            // SaveCountryButton
            // 
            this.SaveCountryButton.Location = new System.Drawing.Point(335, 235);
            this.SaveCountryButton.Name = "SaveCountryButton";
            this.SaveCountryButton.Size = new System.Drawing.Size(75, 23);
            this.SaveCountryButton.TabIndex = 6;
            this.SaveCountryButton.Text = "Save";
            this.SaveCountryButton.UseVisualStyleBackColor = true;
            this.SaveCountryButton.Click += new System.EventHandler(this.SaveCountryButton_Click);
            // 
            // DeleteCountryButton
            // 
            this.DeleteCountryButton.Location = new System.Drawing.Point(460, 235);
            this.DeleteCountryButton.Name = "DeleteCountryButton";
            this.DeleteCountryButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteCountryButton.TabIndex = 7;
            this.DeleteCountryButton.Text = "Delete";
            this.DeleteCountryButton.UseVisualStyleBackColor = true;
            this.DeleteCountryButton.Click += new System.EventHandler(this.DeleteCountryButton_Click);
            // 
            // CountryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeleteCountryButton);
            this.Controls.Add(this.SaveCountryButton);
            this.Controls.Add(this.AddCountryButton);
            this.Controls.Add(this.CountryNameLabel);
            this.Controls.Add(this.CountryCodeLabel);
            this.Controls.Add(this.CountryNameTextBox);
            this.Controls.Add(this.CountryCodeTextBox);
            this.Controls.Add(this.CountryListBox);
            this.Name = "CountryForm";
            this.Text = "CountryForm";
            this.Load += new System.EventHandler(this.CountryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox CountryListBox;
        private System.Windows.Forms.TextBox CountryCodeTextBox;
        private System.Windows.Forms.TextBox CountryNameTextBox;
        private System.Windows.Forms.Label CountryCodeLabel;
        private System.Windows.Forms.Label CountryNameLabel;
        private System.Windows.Forms.Button AddCountryButton;
        private System.Windows.Forms.Button SaveCountryButton;
        private System.Windows.Forms.Button DeleteCountryButton;
    }
}