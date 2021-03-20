namespace lab1OOP
{
    partial class Form1
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
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.LockButton = new System.Windows.Forms.Button();
            this.UnlockButton = new System.Windows.Forms.Button();
            this.ShowAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(349, 271);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(418, 31);
            this.maskedTextBox1.TabIndex = 1;
            // 
            // LockButton
            // 
            this.LockButton.Location = new System.Drawing.Point(349, 413);
            this.LockButton.Name = "LockButton";
            this.LockButton.Size = new System.Drawing.Size(197, 76);
            this.LockButton.TabIndex = 2;
            this.LockButton.Text = "lock";
            this.LockButton.UseVisualStyleBackColor = true;
            this.LockButton.Click += new System.EventHandler(this.LockButton_Click);
            // 
            // UnlockButton
            // 
            this.UnlockButton.Location = new System.Drawing.Point(570, 413);
            this.UnlockButton.Name = "UnlockButton";
            this.UnlockButton.Size = new System.Drawing.Size(197, 76);
            this.UnlockButton.TabIndex = 3;
            this.UnlockButton.Text = "unlock";
            this.UnlockButton.UseVisualStyleBackColor = true;
            this.UnlockButton.Click += new System.EventHandler(this.UnlockButton_Click);
            // 
            // ShowAll
            // 
            this.ShowAll.Location = new System.Drawing.Point(26, 23);
            this.ShowAll.Name = "ShowAll";
            this.ShowAll.Size = new System.Drawing.Size(197, 76);
            this.ShowAll.TabIndex = 4;
            this.ShowAll.Text = "Show all";
            this.ShowAll.UseVisualStyleBackColor = true;
            this.ShowAll.Click += new System.EventHandler(this.ShowAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 807);
            this.Controls.Add(this.ShowAll);
            this.Controls.Add(this.UnlockButton);
            this.Controls.Add(this.LockButton);
            this.Controls.Add(this.maskedTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Click += new System.EventHandler(this.Form1_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button LockButton;
        private System.Windows.Forms.Button UnlockButton;
        private System.Windows.Forms.Button ShowAll;
    }
}

