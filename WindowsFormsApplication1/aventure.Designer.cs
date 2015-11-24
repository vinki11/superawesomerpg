namespace JRPG
{
    partial class Aventure
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
            this.lblChoisirAventure = new System.Windows.Forms.Label();
            this.cboChoisirAventure = new System.Windows.Forms.ComboBox();
            this.rtbInformationsAventure = new System.Windows.Forms.RichTextBox();
            this.btnRetourVillage = new System.Windows.Forms.Button();
            this.btnAventure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblChoisirAventure
            // 
            this.lblChoisirAventure.AutoSize = true;
            this.lblChoisirAventure.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChoisirAventure.Location = new System.Drawing.Point(41, 57);
            this.lblChoisirAventure.Name = "lblChoisirAventure";
            this.lblChoisirAventure.Size = new System.Drawing.Size(149, 16);
            this.lblChoisirAventure.TabIndex = 0;
            this.lblChoisirAventure.Text = "Choisir une aventure";
            // 
            // cboChoisirAventure
            // 
            this.cboChoisirAventure.FormattingEnabled = true;
            this.cboChoisirAventure.Location = new System.Drawing.Point(43, 82);
            this.cboChoisirAventure.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboChoisirAventure.Name = "cboChoisirAventure";
            this.cboChoisirAventure.Size = new System.Drawing.Size(236, 24);
            this.cboChoisirAventure.TabIndex = 1;
            // 
            // rtbInformationsAventure
            // 
            this.rtbInformationsAventure.Location = new System.Drawing.Point(43, 133);
            this.rtbInformationsAventure.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbInformationsAventure.Name = "rtbInformationsAventure";
            this.rtbInformationsAventure.Size = new System.Drawing.Size(401, 242);
            this.rtbInformationsAventure.TabIndex = 2;
            this.rtbInformationsAventure.Text = "";
            // 
            // btnRetourVillage
            // 
            this.btnRetourVillage.Location = new System.Drawing.Point(187, 414);
            this.btnRetourVillage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRetourVillage.Name = "btnRetourVillage";
            this.btnRetourVillage.Size = new System.Drawing.Size(123, 31);
            this.btnRetourVillage.TabIndex = 5;
            this.btnRetourVillage.Text = "Retour au village";
            this.btnRetourVillage.UseVisualStyleBackColor = true;
            // 
            // btnAventure
            // 
            this.btnAventure.Location = new System.Drawing.Point(325, 414);
            this.btnAventure.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAventure.Name = "btnAventure";
            this.btnAventure.Size = new System.Drawing.Size(123, 31);
            this.btnAventure.TabIndex = 6;
            this.btnAventure.Text = "À l\'aventure!";
            this.btnAventure.UseVisualStyleBackColor = true;
            // 
            // Aventure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 473);
            this.Controls.Add(this.btnAventure);
            this.Controls.Add(this.btnRetourVillage);
            this.Controls.Add(this.rtbInformationsAventure);
            this.Controls.Add(this.cboChoisirAventure);
            this.Controls.Add(this.lblChoisirAventure);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Aventure";
            this.Text = "JRPG";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChoisirAventure;
        private System.Windows.Forms.ComboBox cboChoisirAventure;
        private System.Windows.Forms.RichTextBox rtbInformationsAventure;
        private System.Windows.Forms.Button btnRetourVillage;
        private System.Windows.Forms.Button btnAventure;
    }
}