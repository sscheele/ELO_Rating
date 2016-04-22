namespace ELO_Rating
{
    partial class AddGameForm
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
            this.whiteNameBox = new System.Windows.Forms.TextBox();
            this.blackNameBox = new System.Windows.Forms.TextBox();
            this.winnerBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // whiteNameBox
            // 
            this.whiteNameBox.Location = new System.Drawing.Point(12, 32);
            this.whiteNameBox.Name = "whiteNameBox";
            this.whiteNameBox.ShortcutsEnabled = false;
            this.whiteNameBox.Size = new System.Drawing.Size(100, 20);
            this.whiteNameBox.TabIndex = 0;
            this.whiteNameBox.Text = "White Name";
            // 
            // blackNameBox
            // 
            this.blackNameBox.Location = new System.Drawing.Point(12, 105);
            this.blackNameBox.Name = "blackNameBox";
            this.blackNameBox.ShortcutsEnabled = false;
            this.blackNameBox.Size = new System.Drawing.Size(100, 20);
            this.blackNameBox.TabIndex = 1;
            this.blackNameBox.Text = "Black Name";
            // 
            // winnerBox
            // 
            this.winnerBox.FormattingEnabled = true;
            this.winnerBox.Items.AddRange(new object[] {
            "White",
            "Black",
            "Draw"});
            this.winnerBox.Location = new System.Drawing.Point(138, 65);
            this.winnerBox.Name = "winnerBox";
            this.winnerBox.Size = new System.Drawing.Size(121, 21);
            this.winnerBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Winner";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(167, 105);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(92, 40);
            this.submitButton.TabIndex = 4;
            this.submitButton.Text = "Add Game";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // AddGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 164);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.winnerBox);
            this.Controls.Add(this.blackNameBox);
            this.Controls.Add(this.whiteNameBox);
            this.Name = "AddGameForm";
            this.Text = "AddGameForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox whiteNameBox;
        private System.Windows.Forms.TextBox blackNameBox;
        private System.Windows.Forms.ComboBox winnerBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button submitButton;
    }
}