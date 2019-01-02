namespace SLNStokTakip.Bilgi
{
    partial class frmUrunGiris
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
            this.btnSil = new System.Windows.Forms.Button();
            this.btnKapat = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUKat = new System.Windows.Forms.ComboBox();
            this.txtUrnNo = new System.Windows.Forms.TextBox();
            this.txtUrnAciklama = new System.Windows.Forms.TextBox();
            this.txtUrnKodu = new System.Windows.Forms.TextBox();
            this.btnCollaps = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnKaydet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(25, 213);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 23);
            this.btnSil.TabIndex = 2;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnKapat
            // 
            this.btnKapat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKapat.Location = new System.Drawing.Point(0, 0);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(137, 45);
            this.btnKapat.TabIndex = 0;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = true;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.SkyBlue;
            this.label12.Location = new System.Drawing.Point(10, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 21);
            this.label12.TabIndex = 3;
            this.label12.Text = "Kategori :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SkyBlue;
            this.label2.Location = new System.Drawing.Point(10, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 36);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ürün Açıklama :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.SkyBlue;
            this.label13.Location = new System.Drawing.Point(10, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 21);
            this.label13.TabIndex = 3;
            this.label13.Text = "Ürün No :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SkyBlue;
            this.label1.Location = new System.Drawing.Point(10, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ürün Kodu :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbUKat
            // 
            this.cbUKat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbUKat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUKat.FormattingEnabled = true;
            this.cbUKat.Location = new System.Drawing.Point(104, 51);
            this.cbUKat.Name = "cbUKat";
            this.cbUKat.Size = new System.Drawing.Size(144, 21);
            this.cbUKat.TabIndex = 2;
            this.cbUKat.SelectedIndexChanged += new System.EventHandler(this.cbUKat_SelectedIndexChanged);
            // 
            // txtUrnNo
            // 
            this.txtUrnNo.Location = new System.Drawing.Point(104, 25);
            this.txtUrnNo.Name = "txtUrnNo";
            this.txtUrnNo.Size = new System.Drawing.Size(301, 20);
            this.txtUrnNo.TabIndex = 1;
            // 
            // txtUrnAciklama
            // 
            this.txtUrnAciklama.Location = new System.Drawing.Point(104, 119);
            this.txtUrnAciklama.Multiline = true;
            this.txtUrnAciklama.Name = "txtUrnAciklama";
            this.txtUrnAciklama.Size = new System.Drawing.Size(301, 48);
            this.txtUrnAciklama.TabIndex = 1;
            // 
            // txtUrnKodu
            // 
            this.txtUrnKodu.Location = new System.Drawing.Point(104, 93);
            this.txtUrnKodu.Name = "txtUrnKodu";
            this.txtUrnKodu.Size = new System.Drawing.Size(301, 20);
            this.txtUrnKodu.TabIndex = 1;
            // 
            // btnCollaps
            // 
            this.btnCollaps.BackColor = System.Drawing.Color.Red;
            this.btnCollaps.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCollaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCollaps.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCollaps.Location = new System.Drawing.Point(628, 0);
            this.btnCollaps.Name = "btnCollaps";
            this.btnCollaps.Size = new System.Drawing.Size(23, 446);
            this.btnCollaps.TabIndex = 0;
            this.btnCollaps.Text = "GİZLE";
            this.btnCollaps.UseVisualStyleBackColor = false;
            this.btnCollaps.Click += new System.EventHandler(this.btnCollaps_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label13);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.cbUKat);
            this.splitContainer1.Panel1.Controls.Add(this.txtUrnNo);
            this.splitContainer1.Panel1.Controls.Add(this.txtUrnAciklama);
            this.splitContainer1.Panel1.Controls.Add(this.txtUrnKodu);
            this.splitContainer1.Panel1.Controls.Add(this.btnCollaps);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.splitContainer1.Panel2.Controls.Add(this.btnSil);
            this.splitContainer1.Panel2.Controls.Add(this.btnKaydet);
            this.splitContainer1.Panel2.Controls.Add(this.btnKapat);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 655;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnKaydet.Location = new System.Drawing.Point(0, 407);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(137, 39);
            this.btnKaydet.TabIndex = 1;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // frmUrunGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmUrunGiris";
            this.Text = "frmUrunGiris";
            this.Load += new System.EventHandler(this.frmUrunGiris_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbUKat;
        private System.Windows.Forms.TextBox txtUrnNo;
        private System.Windows.Forms.TextBox txtUrnAciklama;
        private System.Windows.Forms.TextBox txtUrnKodu;
        private System.Windows.Forms.Button btnCollaps;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnKaydet;
    }
}