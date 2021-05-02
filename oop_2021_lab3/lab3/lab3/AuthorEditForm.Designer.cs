namespace lab3
{
    partial class AuthorEditForm
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
            this.nameInput = new System.Windows.Forms.TextBox();
            this.surnameInput = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.birthDate = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(280, 35);
            this.nameInput.Margin = new System.Windows.Forms.Padding(6);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(196, 31);
            this.nameInput.TabIndex = 3;
            // 
            // surnameInput
            // 
            this.surnameInput.Location = new System.Drawing.Point(280, 91);
            this.surnameInput.Margin = new System.Windows.Forms.Padding(6);
            this.surnameInput.Name = "surnameInput";
            this.surnameInput.Size = new System.Drawing.Size(196, 31);
            this.surnameInput.TabIndex = 4;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(73, 41);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(68, 25);
            this.nameLabel.TabIndex = 7;
            this.nameLabel.Text = "Name";
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Location = new System.Drawing.Point(73, 94);
            this.surnameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(98, 25);
            this.surnameLabel.TabIndex = 8;
            this.surnameLabel.Text = "Surname";
            // 
            // birthDate
            // 
            this.birthDate.AutoSize = true;
            this.birthDate.Location = new System.Drawing.Point(73, 163);
            this.birthDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.birthDate.Name = "birthDate";
            this.birthDate.Size = new System.Drawing.Size(104, 25);
            this.birthDate.TabIndex = 9;
            this.birthDate.Text = "Birth date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(276, 157);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 31);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // save
            // 
            this.save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.save.Location = new System.Drawing.Point(78, 302);
            this.save.Margin = new System.Windows.Forms.Padding(6);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(160, 44);
            this.save.TabIndex = 15;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancel.Location = new System.Drawing.Point(316, 302);
            this.cancel.Margin = new System.Windows.Forms.Padding(6);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(160, 44);
            this.cancel.TabIndex = 16;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // AuthorEditFormcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 463);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.save);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.birthDate);
            this.Controls.Add(this.surnameLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.surnameInput);
            this.Controls.Add(this.nameInput);
            this.Name = "AuthorEditFormcs";
            this.Text = "AuthorEditFormcs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.TextBox surnameInput;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.Label birthDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
    }
}