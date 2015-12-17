namespace JRPG
{
    partial class Boutique
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
            this.lvInventaire = new System.Windows.Forms.ListView();
            this.lvBoutique = new System.Windows.Forms.ListView();
            this.lblInventaire = new System.Windows.Forms.Label();
            this.lblboutique = new System.Windows.Forms.Label();
            this.btnAcheter = new System.Windows.Forms.Button();
            this.btnVente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPiecesOr = new System.Windows.Forms.Label();
            this.btnVillage = new System.Windows.Forms.Button();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.SuspendLayout();
            // 
            // lvInventaire
            // 
            this.lvInventaire.Location = new System.Drawing.Point(12, 26);
            this.lvInventaire.MultiSelect = false;
            this.lvInventaire.Name = "lvInventaire";
            this.lvInventaire.Size = new System.Drawing.Size(290, 222);
            this.lvInventaire.TabIndex = 0;
            this.lvInventaire.UseCompatibleStateImageBehavior = false;
            // 
            // lvBoutique
            // 
            this.lvBoutique.Location = new System.Drawing.Point(400, 26);
            this.lvBoutique.MultiSelect = false;
            this.lvBoutique.Name = "lvBoutique";
            this.lvBoutique.Size = new System.Drawing.Size(290, 222);
            this.lvBoutique.TabIndex = 1;
            this.lvBoutique.UseCompatibleStateImageBehavior = false;
            // 
            // lblInventaire
            // 
            this.lblInventaire.AutoSize = true;
            this.lblInventaire.Location = new System.Drawing.Point(18, 10);
            this.lblInventaire.Name = "lblInventaire";
            this.lblInventaire.Size = new System.Drawing.Size(54, 13);
            this.lblInventaire.TabIndex = 2;
            this.lblInventaire.Text = "Inventaire";
            // 
            // lblboutique
            // 
            this.lblboutique.AutoSize = true;
            this.lblboutique.Location = new System.Drawing.Point(406, 10);
            this.lblboutique.Name = "lblboutique";
            this.lblboutique.Size = new System.Drawing.Size(49, 13);
            this.lblboutique.TabIndex = 3;
            this.lblboutique.Text = "Boutique";
            // 
            // btnAcheter
            // 
            this.btnAcheter.Location = new System.Drawing.Point(310, 104);
            this.btnAcheter.Name = "btnAcheter";
            this.btnAcheter.Size = new System.Drawing.Size(84, 23);
            this.btnAcheter.TabIndex = 4;
            this.btnAcheter.Text = "<< Acheter <<";
            this.btnAcheter.UseVisualStyleBackColor = true;
            this.btnAcheter.Click += new System.EventHandler(this.btnAcheter_Click);
            // 
            // btnVente
            // 
            this.btnVente.Location = new System.Drawing.Point(310, 133);
            this.btnVente.Name = "btnVente";
            this.btnVente.Size = new System.Drawing.Size(84, 23);
            this.btnVente.TabIndex = 5;
            this.btnVente.Text = ">> Vendre >>";
            this.btnVente.UseVisualStyleBackColor = true;
            this.btnVente.Click += new System.EventHandler(this.btnVente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Pièces d\'or: ";
            // 
            // txtPiecesOr
            // 
            this.txtPiecesOr.AutoSize = true;
            this.txtPiecesOr.Location = new System.Drawing.Point(80, 251);
            this.txtPiecesOr.Name = "txtPiecesOr";
            this.txtPiecesOr.Size = new System.Drawing.Size(61, 13);
            this.txtPiecesOr.TabIndex = 7;
            this.txtPiecesOr.Text = "txtPiecesOr";
            // 
            // btnVillage
            // 
            this.btnVillage.Location = new System.Drawing.Point(591, 258);
            this.btnVillage.Name = "btnVillage";
            this.btnVillage.Size = new System.Drawing.Size(99, 23);
            this.btnVillage.TabIndex = 8;
            this.btnVillage.Text = "Retour au village";
            this.btnVillage.UseVisualStyleBackColor = true;
            this.btnVillage.Click += new System.EventHandler(this.btnVillage_Click);
            // 
            // Boutique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 293);
            this.Controls.Add(this.btnVillage);
            this.Controls.Add(this.txtPiecesOr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVente);
            this.Controls.Add(this.btnAcheter);
            this.Controls.Add(this.lblboutique);
            this.Controls.Add(this.lblInventaire);
            this.Controls.Add(this.lvBoutique);
            this.Controls.Add(this.lvInventaire);
            this.Name = "Boutique";
            this.Text = "Boutique";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvInventaire;
        private System.Windows.Forms.ListView lvBoutique;
        private System.Windows.Forms.Label lblInventaire;
        private System.Windows.Forms.Label lblboutique;
        private System.Windows.Forms.Button btnAcheter;
        private System.Windows.Forms.Button btnVente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtPiecesOr;
        private System.Windows.Forms.Button btnVillage;
    }
}