namespace ELO_Rating
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
            this.AddGameButton = new System.Windows.Forms.Button();
            this.GenListButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddGameButton
            // 
            this.AddGameButton.Location = new System.Drawing.Point(12, 70);
            this.AddGameButton.Name = "AddGameButton";
            this.AddGameButton.Size = new System.Drawing.Size(106, 82);
            this.AddGameButton.TabIndex = 0;
            this.AddGameButton.Text = "Add game";
            this.AddGameButton.UseVisualStyleBackColor = true;
            this.AddGameButton.Click += new System.EventHandler(this.AddGameButton_Click);
            // 
            // GenListButton
            // 
            this.GenListButton.Location = new System.Drawing.Point(163, 70);
            this.GenListButton.Name = "GenListButton";
            this.GenListButton.Size = new System.Drawing.Size(106, 82);
            this.GenListButton.TabIndex = 1;
            this.GenListButton.Text = "Generate ranked list";
            this.GenListButton.UseVisualStyleBackColor = true;
            this.GenListButton.Click += new System.EventHandler(this.GenListButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.GenListButton);
            this.Controls.Add(this.AddGameButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddGameButton;
        private System.Windows.Forms.Button GenListButton;
    }
}

