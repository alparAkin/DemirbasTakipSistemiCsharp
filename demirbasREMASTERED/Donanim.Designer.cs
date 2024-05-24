namespace demirbasREMASTERED
{
    partial class Donanim
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.genelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donanımToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_kasaBilgileri = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.genelToolStripMenuItem,
            this.donanımToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // genelToolStripMenuItem
            // 
            this.genelToolStripMenuItem.Name = "genelToolStripMenuItem";
            this.genelToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.genelToolStripMenuItem.Text = "Genel";
            // 
            // donanımToolStripMenuItem
            // 
            this.donanımToolStripMenuItem.Name = "donanımToolStripMenuItem";
            this.donanımToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.donanımToolStripMenuItem.Text = "Donanım";
            // 
            // button_kasaBilgileri
            // 
            this.button_kasaBilgileri.Location = new System.Drawing.Point(613, 346);
            this.button_kasaBilgileri.Name = "button_kasaBilgileri";
            this.button_kasaBilgileri.Size = new System.Drawing.Size(107, 37);
            this.button_kasaBilgileri.TabIndex = 2;
            this.button_kasaBilgileri.Text = "KASA BİLGİLERİ";
            this.button_kasaBilgileri.UseVisualStyleBackColor = true;
            this.button_kasaBilgileri.Click += new System.EventHandler(this.button_kasaBilgileri_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(78, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(642, 224);
            this.dataGridView1.TabIndex = 0;
            // 
            // Donanim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_kasaBilgileri);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Donanim";
            this.Text = "Donanim";
            this.Load += new System.EventHandler(this.Donanim_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem genelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donanımToolStripMenuItem;
        private System.Windows.Forms.Button button_kasaBilgileri;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}