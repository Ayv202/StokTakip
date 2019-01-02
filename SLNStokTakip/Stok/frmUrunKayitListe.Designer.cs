namespace SLNStokTakip.Stok
{
    partial class frmUrunKayitListe
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
            this.Liste = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCariBul = new System.Windows.Forms.TextBox();
            this.btnBul = new System.Windows.Forms.Button();
            this.btnKapat = new System.Windows.Forms.Button();
            this.GirisNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GnlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CrAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FatNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Liste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Liste
            // 
            this.Liste.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Liste.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GirisNo,
            this.GnlNo,
            this.CrAdi,
            this.Trh,
            this.FatNo});
            this.Liste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Liste.Location = new System.Drawing.Point(0, 0);
            this.Liste.MultiSelect = false;
            this.Liste.Name = "Liste";
            this.Liste.ReadOnly = true;
            this.Liste.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Liste.Size = new System.Drawing.Size(476, 421);
            this.Liste.TabIndex = 0;
            this.Liste.DoubleClick += new System.EventHandler(this.Liste_DoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Liste);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txtCariBul);
            this.splitContainer1.Panel2.Controls.Add(this.btnBul);
            this.splitContainer1.Panel2.Controls.Add(this.btnKapat);
            this.splitContainer1.Size = new System.Drawing.Size(629, 425);
            this.splitContainer1.SplitterDistance = 480;
            this.splitContainer1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cari Bul";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCariBul
            // 
            this.txtCariBul.Location = new System.Drawing.Point(3, 148);
            this.txtCariBul.Name = "txtCariBul";
            this.txtCariBul.Size = new System.Drawing.Size(135, 20);
            this.txtCariBul.TabIndex = 4;
            this.txtCariBul.TextChanged += new System.EventHandler(this.txtCariBul_TextChanged);
            // 
            // btnBul
            // 
            this.btnBul.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBul.Location = new System.Drawing.Point(0, 382);
            this.btnBul.Name = "btnBul";
            this.btnBul.Size = new System.Drawing.Size(141, 39);
            this.btnBul.TabIndex = 3;
            this.btnBul.Text = "Bul";
            this.btnBul.UseVisualStyleBackColor = true;
            this.btnBul.Click += new System.EventHandler(this.btnBul_Click);
            // 
            // btnKapat
            // 
            this.btnKapat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKapat.Location = new System.Drawing.Point(0, 0);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(141, 45);
            this.btnKapat.TabIndex = 2;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = true;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // GirisNo
            // 
            this.GirisNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.GirisNo.HeaderText = "Giriş No";
            this.GirisNo.Name = "GirisNo";
            this.GirisNo.ReadOnly = true;
            this.GirisNo.Visible = false;
            this.GirisNo.Width = 69;
            // 
            // GnlNo
            // 
            this.GnlNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.GnlNo.HeaderText = "Genel No";
            this.GnlNo.Name = "GnlNo";
            this.GnlNo.ReadOnly = true;
            this.GnlNo.Visible = false;
            this.GnlNo.Width = 77;
            // 
            // CrAdi
            // 
            this.CrAdi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CrAdi.HeaderText = "Cari Adı";
            this.CrAdi.Name = "CrAdi";
            this.CrAdi.ReadOnly = true;
            // 
            // Trh
            // 
            this.Trh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Trh.HeaderText = "Tarih";
            this.Trh.Name = "Trh";
            this.Trh.ReadOnly = true;
            this.Trh.Width = 56;
            // 
            // FatNo
            // 
            this.FatNo.HeaderText = "Fatura No";
            this.FatNo.Name = "FatNo";
            this.FatNo.ReadOnly = true;
            // 
            // frmUrunKayitListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 425);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmUrunKayitListe";
            this.Text = "Fatura Giriş Listesi(frmUrunKayitListe)";
            this.Load += new System.EventHandler(this.frmUrunKayitListe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Liste)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Liste;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCariBul;
        private System.Windows.Forms.Button btnBul;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.DataGridViewTextBoxColumn GirisNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GnlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CrAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trh;
        private System.Windows.Forms.DataGridViewTextBoxColumn FatNo;
    }
}