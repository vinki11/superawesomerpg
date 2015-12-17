namespace JRPG
{
    partial class MenuPrincipal
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
            this.pboxTitre = new System.Windows.Forms.PictureBox();
            this.btnChargerPartie = new System.Windows.Forms.Button();
            this.btnNouvellePartie = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pboxTitre)).BeginInit();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.SuspendLayout();
            // 
            // pboxTitre
            // 
            this.pboxTitre.Image = global::JRPG.Properties.Resources.PixelTitle;
            this.pboxTitre.Location = new System.Drawing.Point(9, 12);
            this.pboxTitre.Name = "pboxTitre";
            this.pboxTitre.Size = new System.Drawing.Size(459, 285);
            this.pboxTitre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxTitre.TabIndex = 0;
            this.pboxTitre.TabStop = false;
            // 
            // btnChargerPartie
            // 
            this.btnChargerPartie.Location = new System.Drawing.Point(189, 322);
            this.btnChargerPartie.Name = "btnChargerPartie";
            this.btnChargerPartie.Size = new System.Drawing.Size(116, 27);
            this.btnChargerPartie.TabIndex = 1;
            this.btnChargerPartie.Text = "Charger partie";
            this.btnChargerPartie.UseVisualStyleBackColor = true;
            this.btnChargerPartie.Click += new System.EventHandler(this.btnChargerPartie_Click);
            // 
            // btnNouvellePartie
            // 
            this.btnNouvellePartie.Location = new System.Drawing.Point(316, 322);
            this.btnNouvellePartie.Name = "btnNouvellePartie";
            this.btnNouvellePartie.Size = new System.Drawing.Size(116, 27);
            this.btnNouvellePartie.TabIndex = 2;
            this.btnNouvellePartie.Text = "Nouvelle partie";
            this.btnNouvellePartie.UseVisualStyleBackColor = true;
            this.btnNouvellePartie.Click += new System.EventHandler(this.btnNouvellePartie_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 373);
            this.Controls.Add(this.btnNouvellePartie);
            this.Controls.Add(this.btnChargerPartie);
            this.Controls.Add(this.pboxTitre);
            this.Name = "MenuPrincipal";
            this.Text = "Menu Principal";
            ((System.ComponentModel.ISupportInitialize)(this.pboxTitre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pboxTitre;
        private System.Windows.Forms.Button btnChargerPartie;
        private System.Windows.Forms.Button btnNouvellePartie;
    }
}