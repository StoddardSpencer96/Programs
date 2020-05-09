namespace CurrenciesUI
{
    partial class ColourForm
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
            this.ColourListBox = new System.Windows.Forms.ListBox();
            this.ColourIDTextBox = new System.Windows.Forms.TextBox();
            this.ColourNameTextBox = new System.Windows.Forms.TextBox();
            this.ColourIDLabel = new System.Windows.Forms.Label();
            this.ColourNameLabel = new System.Windows.Forms.Label();
            this.AddColourButton = new System.Windows.Forms.Button();
            this.SaveColourButton = new System.Windows.Forms.Button();
            this.DeleteColourButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ColourListBox
            // 
            this.ColourListBox.FormattingEnabled = true;
            this.ColourListBox.Location = new System.Drawing.Point(31, 38);
            this.ColourListBox.Name = "ColourListBox";
            this.ColourListBox.Size = new System.Drawing.Size(154, 368);
            this.ColourListBox.TabIndex = 0;
            this.ColourListBox.SelectedIndexChanged += new System.EventHandler(this.ColourListBox_SelectedIndexChanged);
            // 
            // ColourIDTextBox
            // 
            this.ColourIDTextBox.Enabled = false;
            this.ColourIDTextBox.Location = new System.Drawing.Point(285, 101);
            this.ColourIDTextBox.Name = "ColourIDTextBox";
            this.ColourIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.ColourIDTextBox.TabIndex = 1;
            // 
            // ColourNameTextBox
            // 
            this.ColourNameTextBox.Location = new System.Drawing.Point(285, 173);
            this.ColourNameTextBox.Name = "ColourNameTextBox";
            this.ColourNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.ColourNameTextBox.TabIndex = 2;
            // 
            // ColourIDLabel
            // 
            this.ColourIDLabel.AutoSize = true;
            this.ColourIDLabel.Location = new System.Drawing.Point(215, 107);
            this.ColourIDLabel.Name = "ColourIDLabel";
            this.ColourIDLabel.Size = new System.Drawing.Size(22, 13);
            this.ColourIDLabel.TabIndex = 3;
            this.ColourIDLabel.Text = "Id: ";
            // 
            // ColourNameLabel
            // 
            this.ColourNameLabel.AutoSize = true;
            this.ColourNameLabel.Location = new System.Drawing.Point(215, 176);
            this.ColourNameLabel.Name = "ColourNameLabel";
            this.ColourNameLabel.Size = new System.Drawing.Size(41, 13);
            this.ColourNameLabel.TabIndex = 4;
            this.ColourNameLabel.Text = "Name: ";
            // 
            // AddColourButton
            // 
            this.AddColourButton.Location = new System.Drawing.Point(218, 235);
            this.AddColourButton.Name = "AddColourButton";
            this.AddColourButton.Size = new System.Drawing.Size(75, 23);
            this.AddColourButton.TabIndex = 5;
            this.AddColourButton.Text = "Add";
            this.AddColourButton.UseVisualStyleBackColor = true;
            this.AddColourButton.Click += new System.EventHandler(this.AddColourButton_Click);
            // 
            // SaveColourButton
            // 
            this.SaveColourButton.Location = new System.Drawing.Point(354, 235);
            this.SaveColourButton.Name = "SaveColourButton";
            this.SaveColourButton.Size = new System.Drawing.Size(75, 23);
            this.SaveColourButton.TabIndex = 6;
            this.SaveColourButton.Text = "Save";
            this.SaveColourButton.UseVisualStyleBackColor = true;
            this.SaveColourButton.Click += new System.EventHandler(this.SaveColourButton_Click);
            // 
            // DeleteColourButton
            // 
            this.DeleteColourButton.Location = new System.Drawing.Point(500, 235);
            this.DeleteColourButton.Name = "DeleteColourButton";
            this.DeleteColourButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteColourButton.TabIndex = 7;
            this.DeleteColourButton.Text = "Delete";
            this.DeleteColourButton.UseVisualStyleBackColor = true;
            this.DeleteColourButton.Click += new System.EventHandler(this.DeleteColourButton_Click);
            // 
            // ColourForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeleteColourButton);
            this.Controls.Add(this.SaveColourButton);
            this.Controls.Add(this.AddColourButton);
            this.Controls.Add(this.ColourNameLabel);
            this.Controls.Add(this.ColourIDLabel);
            this.Controls.Add(this.ColourNameTextBox);
            this.Controls.Add(this.ColourIDTextBox);
            this.Controls.Add(this.ColourListBox);
            this.Name = "ColourForm";
            this.Text = "ColourForm";
            this.Load += new System.EventHandler(this.ColourForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ColourListBox;
        private System.Windows.Forms.TextBox ColourIDTextBox;
        private System.Windows.Forms.TextBox ColourNameTextBox;
        private System.Windows.Forms.Label ColourIDLabel;
        private System.Windows.Forms.Label ColourNameLabel;
        private System.Windows.Forms.Button AddColourButton;
        private System.Windows.Forms.Button SaveColourButton;
        private System.Windows.Forms.Button DeleteColourButton;
    }
}