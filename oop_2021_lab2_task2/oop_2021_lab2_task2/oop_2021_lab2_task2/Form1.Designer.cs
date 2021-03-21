namespace oop_2021_lab2_task2
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
            this.InvisibleModeButton = new System.Windows.Forms.Button();
            this.GreetingButton = new System.Windows.Forms.Button();
            this.ChangeColorButton = new System.Windows.Forms.Button();
            this.MagicButton = new System.Windows.Forms.Button();
            this.GreetingCheckBox = new System.Windows.Forms.CheckBox();
            this.CahangeColorCheckBox = new System.Windows.Forms.CheckBox();
            this.InvisibleModeCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // InvisibleModeButton
            // 
            this.InvisibleModeButton.Location = new System.Drawing.Point(73, 71);
            this.InvisibleModeButton.Name = "InvisibleModeButton";
            this.InvisibleModeButton.Size = new System.Drawing.Size(233, 63);
            this.InvisibleModeButton.TabIndex = 0;
            this.InvisibleModeButton.Text = "Invisible mode";
            this.InvisibleModeButton.UseVisualStyleBackColor = true;
            this.InvisibleModeButton.Click += new System.EventHandler(this.InvisibleModeButton_Click);
            // 
            // GreetingButton
            // 
            this.GreetingButton.Location = new System.Drawing.Point(737, 71);
            this.GreetingButton.Name = "GreetingButton";
            this.GreetingButton.Size = new System.Drawing.Size(233, 63);
            this.GreetingButton.TabIndex = 1;
            this.GreetingButton.Text = "Grreting";
            this.GreetingButton.UseVisualStyleBackColor = true;
            this.GreetingButton.Click += new System.EventHandler(this.GreetingButton_Click);
            // 
            // ChangeColorButton
            // 
            this.ChangeColorButton.Location = new System.Drawing.Point(417, 71);
            this.ChangeColorButton.Name = "ChangeColorButton";
            this.ChangeColorButton.Size = new System.Drawing.Size(233, 63);
            this.ChangeColorButton.TabIndex = 2;
            this.ChangeColorButton.Text = "Change color";
            this.ChangeColorButton.UseVisualStyleBackColor = true;
            this.ChangeColorButton.Click += new System.EventHandler(this.ChangeColorButton_Click);
            // 
            // MagicButton
            // 
            this.MagicButton.Location = new System.Drawing.Point(290, 175);
            this.MagicButton.Name = "MagicButton";
            this.MagicButton.Size = new System.Drawing.Size(475, 63);
            this.MagicButton.TabIndex = 3;
            this.MagicButton.Text = "Magic";
            this.MagicButton.UseVisualStyleBackColor = true;
            this.MagicButton.Click += new System.EventHandler(this.MagicButton_Click);
            // 
            // GreetingCheckBox
            // 
            this.GreetingCheckBox.AutoSize = true;
            this.GreetingCheckBox.Location = new System.Drawing.Point(133, 366);
            this.GreetingCheckBox.Name = "GreetingCheckBox";
            this.GreetingCheckBox.Size = new System.Drawing.Size(126, 29);
            this.GreetingCheckBox.TabIndex = 4;
            this.GreetingCheckBox.Text = "Greeting";
            this.GreetingCheckBox.UseVisualStyleBackColor = true;
            this.GreetingCheckBox.CheckedChanged += new System.EventHandler(this.GreetingCheckBox_CheckedChanged);
            // 
            // CahangeColorCheckBox
            // 
            this.CahangeColorCheckBox.AutoSize = true;
            this.CahangeColorCheckBox.Location = new System.Drawing.Point(133, 331);
            this.CahangeColorCheckBox.Name = "CahangeColorCheckBox";
            this.CahangeColorCheckBox.Size = new System.Drawing.Size(172, 29);
            this.CahangeColorCheckBox.TabIndex = 5;
            this.CahangeColorCheckBox.Text = "Change color";
            this.CahangeColorCheckBox.UseVisualStyleBackColor = true;
            this.CahangeColorCheckBox.CheckedChanged += new System.EventHandler(this.CahangeColorCheckBox_CheckedChanged);
            // 
            // InvisibleModeCheckBox
            // 
            this.InvisibleModeCheckBox.AutoSize = true;
            this.InvisibleModeCheckBox.Location = new System.Drawing.Point(133, 296);
            this.InvisibleModeCheckBox.Name = "InvisibleModeCheckBox";
            this.InvisibleModeCheckBox.Size = new System.Drawing.Size(181, 29);
            this.InvisibleModeCheckBox.TabIndex = 6;
            this.InvisibleModeCheckBox.Text = "Invisible mode";
            this.InvisibleModeCheckBox.UseVisualStyleBackColor = true;
            this.InvisibleModeCheckBox.CheckedChanged += new System.EventHandler(this.InvisibleModeCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 681);
            this.Controls.Add(this.InvisibleModeCheckBox);
            this.Controls.Add(this.CahangeColorCheckBox);
            this.Controls.Add(this.GreetingCheckBox);
            this.Controls.Add(this.MagicButton);
            this.Controls.Add(this.ChangeColorButton);
            this.Controls.Add(this.GreetingButton);
            this.Controls.Add(this.InvisibleModeButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button InvisibleModeButton;
        private System.Windows.Forms.Button GreetingButton;
        private System.Windows.Forms.Button ChangeColorButton;
        private System.Windows.Forms.Button MagicButton;
        private System.Windows.Forms.CheckBox GreetingCheckBox;
        private System.Windows.Forms.CheckBox CahangeColorCheckBox;
        private System.Windows.Forms.CheckBox InvisibleModeCheckBox;
    }
}

