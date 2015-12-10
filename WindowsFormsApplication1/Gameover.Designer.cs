namespace JRPG
{
    partial class Gameover
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
            this.lblGameOver = new System.Windows.Forms.Label();
            this.lblGameOver2 = new System.Windows.Forms.Label();
            this.btnMenuPrincipal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOver.Location = new System.Drawing.Point(50, 35);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(343, 39);
            this.lblGameOver.TabIndex = 0;
            this.lblGameOver.Text = "Votre groupe est mort";
            // 
            // lblGameOver2
            // 
            this.lblGameOver2.AutoSize = true;
            this.lblGameOver2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOver2.Location = new System.Drawing.Point(12, 88);
            this.lblGameOver2.Name = "lblGameOver2";
            this.lblGameOver2.Size = new System.Drawing.Size(407, 31);
            this.lblGameOver2.TabIndex = 1;
            this.lblGameOver2.Text = "Meilleur chance la prochaine fois";
            // 
            // btnMenuPrincipal
            // 
            this.btnMenuPrincipal.Location = new System.Drawing.Point(129, 129);
            this.btnMenuPrincipal.Name = "btnMenuPrincipal";
            this.btnMenuPrincipal.Size = new System.Drawing.Size(149, 23);
            this.btnMenuPrincipal.TabIndex = 2;
            this.btnMenuPrincipal.Text = "Retour au menu principal";
            this.btnMenuPrincipal.UseVisualStyleBackColor = true;
            this.btnMenuPrincipal.Click += new System.EventHandler(this.btnMenuPrincipal_Click);
            // 
            // Gameover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 164);
            this.Controls.Add(this.btnMenuPrincipal);
            this.Controls.Add(this.lblGameOver2);
            this.Controls.Add(this.lblGameOver);
            this.Name = "Gameover";
            this.Text = "Gameover";
            this.Load += new System.EventHandler(this.Gameover_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGameOver;
        private System.Windows.Forms.Label lblGameOver2;
        private System.Windows.Forms.Button btnMenuPrincipal;
    }
}