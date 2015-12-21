namespace JRPG
{
    partial class Chapel
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
            this.cboMembreMort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRes = new System.Windows.Forms.Button();
            this.lblPrixRes = new System.Windows.Forms.Label();
            this.txtPrix = new System.Windows.Forms.Label();
            this.lblPieces = new System.Windows.Forms.Label();
            this.btnRetour = new System.Windows.Forms.Button();
            this.txtPiecesOr = new System.Windows.Forms.Label();
            this.lblPiecesOr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboMembreMort
            // 
            this.cboMembreMort.FormattingEnabled = true;
            this.cboMembreMort.Location = new System.Drawing.Point(160, 6);
            this.cboMembreMort.Name = "cboMembreMort";
            this.cboMembreMort.Size = new System.Drawing.Size(121, 21);
            this.cboMembreMort.TabIndex = 0;
            this.cboMembreMort.SelectedIndexChanged += new System.EventHandler(this.cboMembreMort_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Membres du groupe décédés";
            // 
            // btnRes
            // 
            this.btnRes.Location = new System.Drawing.Point(301, 4);
            this.btnRes.Name = "btnRes";
            this.btnRes.Size = new System.Drawing.Size(75, 23);
            this.btnRes.TabIndex = 2;
            this.btnRes.Text = "Ressuciter";
            this.btnRes.UseVisualStyleBackColor = true;
            this.btnRes.Click += new System.EventHandler(this.btnRes_Click);
            // 
            // lblPrixRes
            // 
            this.lblPrixRes.AutoSize = true;
            this.lblPrixRes.Location = new System.Drawing.Point(382, 9);
            this.lblPrixRes.Name = "lblPrixRes";
            this.lblPrixRes.Size = new System.Drawing.Size(112, 13);
            this.lblPrixRes.TabIndex = 3;
            this.lblPrixRes.Text = "Prix pour résurrection: ";
            // 
            // txtPrix
            // 
            this.txtPrix.AutoSize = true;
            this.txtPrix.Location = new System.Drawing.Point(491, 9);
            this.txtPrix.Name = "txtPrix";
            this.txtPrix.Size = new System.Drawing.Size(35, 13);
            this.txtPrix.TabIndex = 4;
            this.txtPrix.Text = "txtPrix";
            // 
            // lblPieces
            // 
            this.lblPieces.AutoSize = true;
            this.lblPieces.Location = new System.Drawing.Point(532, 9);
            this.lblPieces.Name = "lblPieces";
            this.lblPieces.Size = new System.Drawing.Size(38, 13);
            this.lblPieces.TabIndex = 5;
            this.lblPieces.Text = "pièces";
            // 
            // btnRetour
            // 
            this.btnRetour.Location = new System.Drawing.Point(439, 31);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(111, 23);
            this.btnRetour.TabIndex = 6;
            this.btnRetour.Text = "Retour au village";
            this.btnRetour.UseVisualStyleBackColor = true;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // txtPiecesOr
            // 
            this.txtPiecesOr.AutoSize = true;
            this.txtPiecesOr.Location = new System.Drawing.Point(77, 36);
            this.txtPiecesOr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtPiecesOr.Name = "txtPiecesOr";
            this.txtPiecesOr.Size = new System.Drawing.Size(61, 13);
            this.txtPiecesOr.TabIndex = 44;
            this.txtPiecesOr.Text = "txtPiecesOr";
            // 
            // lblPiecesOr
            // 
            this.lblPiecesOr.AutoSize = true;
            this.lblPiecesOr.Location = new System.Drawing.Point(11, 36);
            this.lblPiecesOr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPiecesOr.Name = "lblPiecesOr";
            this.lblPiecesOr.Size = new System.Drawing.Size(62, 13);
            this.lblPiecesOr.TabIndex = 43;
            this.lblPiecesOr.Text = "Pièces d\'or:";
            // 
            // Chapel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 66);
            this.Controls.Add(this.txtPiecesOr);
            this.Controls.Add(this.lblPiecesOr);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.lblPieces);
            this.Controls.Add(this.txtPrix);
            this.Controls.Add(this.lblPrixRes);
            this.Controls.Add(this.btnRes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboMembreMort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Chapel";
            this.Text = "Chapelle";
            this.Load += new System.EventHandler(this.Chapel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboMembreMort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRes;
        private System.Windows.Forms.Label lblPrixRes;
        private System.Windows.Forms.Label txtPrix;
        private System.Windows.Forms.Label lblPieces;
        private System.Windows.Forms.Button btnRetour;
        private System.Windows.Forms.Label txtPiecesOr;
        private System.Windows.Forms.Label lblPiecesOr;
    }
}