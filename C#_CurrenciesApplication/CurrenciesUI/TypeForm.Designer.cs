namespace CurrenciesUI
{
    partial class TypeForm
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
            this.TypeListBox = new System.Windows.Forms.ListBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.TypeIDTextBox = new System.Windows.Forms.TextBox();
            this.TypeIDLabel = new System.Windows.Forms.Label();
            this.SaveTypeButton = new System.Windows.Forms.Button();
            this.DeleteTypeButton = new System.Windows.Forms.Button();
            this.AddButtonType = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TypeListBox
            // 
            this.TypeListBox.FormattingEnabled = true;
            this.TypeListBox.Location = new System.Drawing.Point(12, 12);
            this.TypeListBox.Name = "TypeListBox";
            this.TypeListBox.Size = new System.Drawing.Size(191, 407);
            this.TypeListBox.TabIndex = 0;
            this.TypeListBox.SelectedIndexChanged += new System.EventHandler(this.TypeListBox_SelectedIndexChanged);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(296, 89);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.NameTextBox.TabIndex = 1;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(249, 92);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(41, 13);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "Name: ";
            // 
            // TypeIDTextBox
            // 
            this.TypeIDTextBox.Enabled = false;
            this.TypeIDTextBox.Location = new System.Drawing.Point(296, 57);
            this.TypeIDTextBox.Name = "TypeIDTextBox";
            this.TypeIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.TypeIDTextBox.TabIndex = 3;
            //this.TypeIDTextBox.TextChanged += new System.EventHandler(this.TypeIDTextBox_TextChanged);
            // 
            // TypeIDLabel
            // 
            this.TypeIDLabel.AutoSize = true;
            this.TypeIDLabel.Location = new System.Drawing.Point(249, 60);
            this.TypeIDLabel.Name = "TypeIDLabel";
            this.TypeIDLabel.Size = new System.Drawing.Size(24, 13);
            this.TypeIDLabel.TabIndex = 4;
            this.TypeIDLabel.Text = "ID: ";
            // 
            // SaveTypeButton
            // 
            this.SaveTypeButton.Location = new System.Drawing.Point(348, 137);
            this.SaveTypeButton.Name = "SaveTypeButton";
            this.SaveTypeButton.Size = new System.Drawing.Size(75, 23);
            this.SaveTypeButton.TabIndex = 5;
            this.SaveTypeButton.Text = "Save";
            this.SaveTypeButton.UseVisualStyleBackColor = true;
            this.SaveTypeButton.Click += new System.EventHandler(this.SaveTypeButton_Click);
            // 
            // DeleteTypeButton
            // 
            this.DeleteTypeButton.Location = new System.Drawing.Point(471, 137);
            this.DeleteTypeButton.Name = "DeleteTypeButton";
            this.DeleteTypeButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteTypeButton.TabIndex = 6;
            this.DeleteTypeButton.Text = "Delete";
            this.DeleteTypeButton.UseVisualStyleBackColor = true;
            this.DeleteTypeButton.Click += new System.EventHandler(this.DeleteTypeButton_Click);
            // 
            // AddButtonType
            // 
            this.AddButtonType.Location = new System.Drawing.Point(222, 137);
            this.AddButtonType.Name = "AddButtonType";
            this.AddButtonType.Size = new System.Drawing.Size(75, 23);
            this.AddButtonType.TabIndex = 7;
            this.AddButtonType.Text = "Add";
            this.AddButtonType.UseVisualStyleBackColor = true;
            this.AddButtonType.Click += new System.EventHandler(this.AddButtonType_Click);
            // 
            // TypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddButtonType);
            this.Controls.Add(this.DeleteTypeButton);
            this.Controls.Add(this.SaveTypeButton);
            this.Controls.Add(this.TypeIDLabel);
            this.Controls.Add(this.TypeIDTextBox);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.TypeListBox);
            this.Name = "TypeForm";
            this.Text = "TypeForm";
            this.Load += new System.EventHandler(this.TypeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox TypeListBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox TypeIDTextBox;
        private System.Windows.Forms.Label TypeIDLabel;
        private System.Windows.Forms.Button SaveTypeButton;
        private System.Windows.Forms.Button DeleteTypeButton;
        private System.Windows.Forms.Button AddButtonType;
    }
}