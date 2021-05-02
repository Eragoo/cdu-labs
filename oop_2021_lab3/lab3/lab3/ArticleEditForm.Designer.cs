namespace lab3
{
    partial class ArticleEditForm
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
            this.name = new System.Windows.Forms.TextBox();
            this.royalti = new System.Windows.Forms.TextBox();
            this.pageCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.authorComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonEditSelected = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(197, 36);
            this.name.Margin = new System.Windows.Forms.Padding(6);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(196, 31);
            this.name.TabIndex = 2;
            // 
            // royalti
            // 
            this.royalti.Location = new System.Drawing.Point(197, 118);
            this.royalti.Margin = new System.Windows.Forms.Padding(6);
            this.royalti.Name = "royalti";
            this.royalti.Size = new System.Drawing.Size(196, 31);
            this.royalti.TabIndex = 3;
            this.royalti.Validating += new System.ComponentModel.CancelEventHandler(this.royalti_Validating);
            // 
            // pageCount
            // 
            this.pageCount.Location = new System.Drawing.Point(197, 208);
            this.pageCount.Margin = new System.Windows.Forms.Padding(6);
            this.pageCount.Name = "pageCount";
            this.pageCount.Size = new System.Drawing.Size(196, 31);
            this.pageCount.TabIndex = 4;
            this.pageCount.Validating += new System.ComponentModel.CancelEventHandler(this.pageCount_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 124);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Royalti";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 214);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Page count";
            // 
            // authorComboBox
            // 
            this.authorComboBox.FormattingEnabled = true;
            this.authorComboBox.Location = new System.Drawing.Point(197, 294);
            this.authorComboBox.Name = "authorComboBox";
            this.authorComboBox.Size = new System.Drawing.Size(196, 33);
            this.authorComboBox.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 297);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Author";
            // 
            // buttonEditSelected
            // 
            this.buttonEditSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEditSelected.Location = new System.Drawing.Point(45, 446);
            this.buttonEditSelected.Margin = new System.Windows.Forms.Padding(6);
            this.buttonEditSelected.Name = "buttonEditSelected";
            this.buttonEditSelected.Size = new System.Drawing.Size(160, 44);
            this.buttonEditSelected.TabIndex = 14;
            this.buttonEditSelected.Text = "Save";
            this.buttonEditSelected.UseVisualStyleBackColor = true;
            this.buttonEditSelected.Click += new System.EventHandler(this.buttonEditSelected_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(233, 446);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 44);
            this.button1.TabIndex = 15;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ArticleEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 541);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonEditSelected);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.authorComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pageCount);
            this.Controls.Add(this.royalti);
            this.Controls.Add(this.name);
            this.Name = "ArticleEditForm";
            this.Text = "ArticleEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox royalti;
        private System.Windows.Forms.TextBox pageCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox authorComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonEditSelected;
        private System.Windows.Forms.Button button1;
    }
}