namespace JRPG
{
    partial class Maison
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
            this.btnRetourVillage = new System.Windows.Forms.Button();
            this.btnSauvegarder = new System.Windows.Forms.Button();
            this.btnCharger = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRetourVillage
            // 
            this.btnRetourVillage.Location = new System.Drawing.Point(127, 55);
            this.btnRetourVillage.Name = "btnRetourVillage";
            this.btnRetourVillage.Size = new System.Drawing.Size(115, 23);
            this.btnRetourVillage.TabIndex = 0;
            this.btnRetourVillage.Text = "Retourner au village";
            this.btnRetourVillage.UseVisualStyleBackColor = true;
            this.btnRetourVillage.Click += new System.EventHandler(this.btnRetourVillage_Click);
            // 
            // btnSauvegarder
            // 
            this.btnSauvegarder.Location = new System.Drawing.Point(116, 12);
            this.btnSauvegarder.Name = "btnSauvegarder";
            this.btnSauvegarder.Size = new System.Drawing.Size(126, 23);
            this.btnSauvegarder.TabIndex = 1;
            this.btnSauvegarder.Text = "Sauvegarder une partie";
            this.btnSauvegarder.UseVisualStyleBackColor = true;
            this.btnSauvegarder.Click += new System.EventHandler(this.btnSauvegarder_Click);
            // 
            // btnCharger
            // 
            this.btnCharger.Location = new System.Drawing.Point(12, 12);
            this.btnCharger.Name = "btnCharger";
            this.btnCharger.Size = new System.Drawing.Size(98, 23);
            this.btnCharger.TabIndex = 2;
            this.btnCharger.Text = "Charger la partie";
            this.btnCharger.UseVisualStyleBackColor = true;
            this.btnCharger.Click += new System.EventHandler(this.btnCharger_Click);
            // 
            // Maison
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 93);
            this.Controls.Add(this.btnCharger);
            this.Controls.Add(this.btnSauvegarder);
            this.Controls.Add(this.btnRetourVillage);
            this.Name = "Maison";
            this.Text = "Maison";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRetourVillage;
        private System.Windows.Forms.Button btnSauvegarder;
        private System.Windows.Forms.Button btnCharger;
    }
}