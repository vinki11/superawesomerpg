﻿namespace JRPG
{
    partial class FenetreAventure
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
            this.txtInformationsAventure = new System.Windows.Forms.RichTextBox();
            this.btnRetourVillage = new System.Windows.Forms.Button();
            this.btnAventure = new System.Windows.Forms.Button();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.SuspendLayout();
            // 
            // lblChoisirAventure
            // 
            this.lblChoisirAventure.AutoSize = true;
            this.lblChoisirAventure.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChoisirAventure.Location = new System.Drawing.Point(31, 46);
            this.lblChoisirAventure.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChoisirAventure.Name = "lblChoisirAventure";
            this.lblChoisirAventure.Size = new System.Drawing.Size(149, 16);
            this.lblChoisirAventure.TabIndex = 0;
            this.lblChoisirAventure.Text = "Choisir une aventure";
            // 
            // cboChoisirAventure
            // 
            this.cboChoisirAventure.FormattingEnabled = true;
            this.cboChoisirAventure.Location = new System.Drawing.Point(32, 67);
            this.cboChoisirAventure.Margin = new System.Windows.Forms.Padding(2);
            this.cboChoisirAventure.Name = "cboChoisirAventure";
            this.cboChoisirAventure.Size = new System.Drawing.Size(178, 21);
            this.cboChoisirAventure.TabIndex = 1;
            this.cboChoisirAventure.SelectedIndexChanged += new System.EventHandler(this.cboChoisirAventure_SelectedIndexChanged);
            // 
            // txtInformationsAventure
            // 
            this.txtInformationsAventure.Location = new System.Drawing.Point(32, 108);
            this.txtInformationsAventure.Margin = new System.Windows.Forms.Padding(2);
            this.txtInformationsAventure.Name = "txtInformationsAventure";
            this.txtInformationsAventure.Size = new System.Drawing.Size(302, 197);
            this.txtInformationsAventure.TabIndex = 2;
            this.txtInformationsAventure.Text = "";
            // 
            // btnRetourVillage
            // 
            this.btnRetourVillage.Location = new System.Drawing.Point(118, 336);
            this.btnRetourVillage.Margin = new System.Windows.Forms.Padding(2);
            this.btnRetourVillage.Name = "btnRetourVillage";
            this.btnRetourVillage.Size = new System.Drawing.Size(114, 25);
            this.btnRetourVillage.TabIndex = 5;
            this.btnRetourVillage.Text = "Retour au village";
            this.btnRetourVillage.UseVisualStyleBackColor = true;
            this.btnRetourVillage.Click += new System.EventHandler(this.btnRetourVillage_Click);
            // 
            // btnAventure
            // 
            this.btnAventure.Location = new System.Drawing.Point(244, 336);
            this.btnAventure.Margin = new System.Windows.Forms.Padding(2);
            this.btnAventure.Name = "btnAventure";
            this.btnAventure.Size = new System.Drawing.Size(92, 25);
            this.btnAventure.TabIndex = 6;
            this.btnAventure.Text = "À l\'aventure!";
            this.btnAventure.UseVisualStyleBackColor = true;
            this.btnAventure.Click += new System.EventHandler(this.btnAventure_Click);
            // 
            // FenetreAventure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 384);
            this.Controls.Add(this.btnAventure);
            this.Controls.Add(this.btnRetourVillage);
            this.Controls.Add(this.txtInformationsAventure);
            this.Controls.Add(this.cboChoisirAventure);
            this.Controls.Add(this.lblChoisirAventure);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FenetreAventure";
            this.Text = "JRPG";
            this.Load += new System.EventHandler(this.Aventure_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChoisirAventure;
        private System.Windows.Forms.ComboBox cboChoisirAventure;
        private System.Windows.Forms.RichTextBox txtInformationsAventure;
        private System.Windows.Forms.Button btnRetourVillage;
        private System.Windows.Forms.Button btnAventure;
    }
}