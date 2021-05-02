namespace lab3
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
            this.buttonEditSelected = new System.Windows.Forms.Button();
            this.addMagazine = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.addAuthorButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonEditSelected
            // 
            this.buttonEditSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEditSelected.Enabled = false;
            this.buttonEditSelected.Location = new System.Drawing.Point(35, 462);
            this.buttonEditSelected.Margin = new System.Windows.Forms.Padding(6);
            this.buttonEditSelected.Name = "buttonEditSelected";
            this.buttonEditSelected.Size = new System.Drawing.Size(200, 44);
            this.buttonEditSelected.TabIndex = 2;
            this.buttonEditSelected.Text = "Edit selected";
            this.buttonEditSelected.UseVisualStyleBackColor = true;
            this.buttonEditSelected.Click += new System.EventHandler(this.buttonEditSelected_Click);
            // 
            // addMagazine
            // 
            this.addMagazine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addMagazine.Location = new System.Drawing.Point(335, 462);
            this.addMagazine.Margin = new System.Windows.Forms.Padding(6);
            this.addMagazine.Name = "addMagazine";
            this.addMagazine.Size = new System.Drawing.Size(200, 44);
            this.addMagazine.TabIndex = 3;
            this.addMagazine.Text = "New";
            this.addMagazine.UseVisualStyleBackColor = true;
            this.addMagazine.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(35, 15);
            this.listBox1.Margin = new System.Windows.Forms.Padding(6);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(500, 354);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // addAuthorButton
            // 
            this.addAuthorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addAuthorButton.Location = new System.Drawing.Point(375, 393);
            this.addAuthorButton.Margin = new System.Windows.Forms.Padding(6);
            this.addAuthorButton.Name = "addAuthorButton";
            this.addAuthorButton.Size = new System.Drawing.Size(160, 44);
            this.addAuthorButton.TabIndex = 18;
            this.addAuthorButton.Text = "Add author";
            this.addAuthorButton.UseVisualStyleBackColor = true;
            this.addAuthorButton.Click += new System.EventHandler(this.addAuthorButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 551);
            this.Controls.Add(this.addAuthorButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.addMagazine);
            this.Controls.Add(this.buttonEditSelected);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonEditSelected;
        private System.Windows.Forms.Button addMagazine;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button addAuthorButton;
    }
}

