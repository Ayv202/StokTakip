using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLNStokTakip
{
    public partial class AnaSayfa : Form
    {
        Hangar.Formlar _f = new Hangar.Formlar();
        Hangar.Mesajlar _m = new Hangar.Mesajlar();

        public static int Aktarma = -1;
        public static int ListeAktarma = -1;

        public static string LotAktar = "B";

        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            gb1.Text = "Stok Takibi Menüsü";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            pnl1.Visible = true;
            pnl2.Visible = false;
            pnl3.Visible = false;
            pnl4.Visible = false;
            gb1.ForeColor = Color.DarkGreen;
            gb1.Text = "Stok Takibi Menüsü";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            pnl1.Visible = false;
            pnl2.Visible = true;
            pnl3.Visible = false;
            pnl4.Visible = false;
            gb1.ForeColor = Color.DarkRed;
            gb1.Text = "Bilgi Giriş Menüsü";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            pnl1.Visible = false;
            pnl2.Visible = false;
            pnl3.Visible = true;
            pnl4.Visible = false;
            gb1.ForeColor = Color.DarkBlue;
            gb1.Text = "Fatura Menüsü";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            pnl1.Visible = false;
            pnl2.Visible = false;
            pnl3.Visible = false;
            pnl4.Visible = true;
            gb1.ForeColor = Color.DarkCyan;
            gb1.Text = "Raporlar Menüsü";
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Program Kapatılsınmı?", "Programdan Çıkış Yapıyorsunuz!!!", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes) Application.Exit();
            else return;
            
        }

        private void btnKulGir_Click(object sender, EventArgs e)
        {
            _f.KulGiris();
        }

        private void btnKulList_Click(object sender, EventArgs e)
        {
            _f.KulListe();
        }

        private void btnKulTipi_Click(object sender, EventArgs e)
        {
            _f.KulTipi();
        }

        private void btnFirmaGirisi_Click(object sender, EventArgs e)
        {
            _f.FrmGir();
        }

        private void btnFirmaListesi_Click(object sender, EventArgs e)
        {
            _f.FrmListe();
        }

        private void btnUrunGiris_Click(object sender, EventArgs e)
        {
            _f.UrnGir();
        }

        private void btnUrunListe_Click(object sender, EventArgs e)
        {
            _f.UrnListe();
        }

        private void btnUrunKayit_Click(object sender, EventArgs e)
        {
            _f.UrunKayit();
        }

        private void btnUrunKayitListe_Click(object sender, EventArgs e)
        {
            _f.UrunKayitListe();
        }

        private void btnStokDurum_Click(object sender, EventArgs e)
        {
            _f.stokDurum();
        }

        private void btnUrunCikis_Click(object sender, EventArgs e)
        {
            _f.UrunCikis();
        }

        private void btnUrunCikisListe_Click(object sender, EventArgs e)
        {
            _f.UrunCikisListe();
        }

        private void btnGb_Click(object sender, EventArgs e)
        {
            if (gb1.Visible)
            {
                gb1.Visible = false; 
            }
            else
            {
                gb1.Visible = true;
            }
        }

        private void btnFaturaKes_Click(object sender, EventArgs e)
        {
            _f.UrunCikisBul();
        }

        private void btnFaturaKesListe_Click(object sender, EventArgs e)
        {
            _f.FaturaKesListe();
        }
    }
}
