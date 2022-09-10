
namespace EEF2019
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.associationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stageInscriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.associationToolStripMenuItem,
            this.stageInscriptionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1041, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // associationToolStripMenuItem
            // 
            this.associationToolStripMenuItem.Name = "associationToolStripMenuItem";
            this.associationToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.associationToolStripMenuItem.Text = "Association";
            this.associationToolStripMenuItem.Click += new System.EventHandler(this.associationToolStripMenuItem_Click);
            // 
            // stageInscriptionToolStripMenuItem
            // 
            this.stageInscriptionToolStripMenuItem.Name = "stageInscriptionToolStripMenuItem";
            this.stageInscriptionToolStripMenuItem.Size = new System.Drawing.Size(136, 24);
            this.stageInscriptionToolStripMenuItem.Text = "Stage_Inscription";
            this.stageInscriptionToolStripMenuItem.Click += new System.EventHandler(this.stageInscriptionToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 524);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem associationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stageInscriptionToolStripMenuItem;
    }
}

