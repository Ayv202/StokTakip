using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SLNStokTakip.Hangar;

namespace SLNStokTakip.Fatura
{
    public partial class frmFaturaKes : Form
    {
        DbStokDataContext _db = new DbStokDataContext();
        Formlar _f = new Formlar();
        Mesajlar _m = new Mesajlar();
        Numaralar _n = new Numaralar();

        int cksNo = -1;
        int fkayNo = -1;

        public bool _edit = false;

        public frmFaturaKes()
        {
            InitializeComponent();
        }

        private void frmFaturaKes_Load(object sender, EventArgs e)
        {
            if (AnaSayfa.Aktarma>0 )
            {
                ListeleIlk();
            }
            else if(AnaSayfa.ListeAktarma>0)
            {
                ListeleIki();
            }
            
            SaatBul();
            Temizle();
        }
        void Temizle()
        {
            //foreach (Control ct in splitContainer1.Panel2.Controls)
            //    if (ct is TextBox || ct is ComboBox) ct.Text = "";
            ////Liste.Rows.Clear();
            //_edit = false;
            txtEvrakNo.Text = _n.FaturaKayıtNo();
            //AnaSayfa.Aktarma = -1;
        }
        void ListeleIlk()
        {
            cksNo = AnaSayfa.Aktarma;
            Liste.Rows.Clear();
            int i = 0;
            var srg = (from s in _db.stUrunCikis
                       where s.CikisNo == cksNo
                       select s);
            foreach (var k in srg)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = -1;
                Liste.Columns[1].Visible = true;
                Liste.Columns[2].Visible = false;
                Liste.Rows[i].Cells[1].Value = k.CikisNo;
                Liste.Rows[i].Cells[3].Value = k.stStokDurum.UrunKodu;
                Liste.Rows[i].Cells[4].Value = k.stStokDurum.LotSeriNo;
                Liste.Rows[i].Cells[5].Value = k.stStokDurum.Aciklama;
                Liste.Rows[i].Cells[6].Value = k.Adet;
                txtCariAdi.Text = k.bgFirma.Fadi;
                txtVd.Text = k.bgFirma.Fvd;
                txtTcv.Text = k.bgFirma.Fvno;
                txtAdres.Text = k.bgFirma.Fadres;
                i++;
            }
            Liste.AllowUserToAddRows = false;
            AnaSayfa.Aktarma = -1;
        }
        void ListeleIki()
        {
            fkayNo = AnaSayfa.ListeAktarma;
            Liste.Rows.Clear();
            int i = 0;
            var srg = (from s in _db.vwFaturaKes
                       where s.FKayitNo == fkayNo
                       select s);
            foreach (var k in srg)
            {

                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = -1;
                Liste.Columns[1].Visible = false;
                Liste.Rows[i].Cells[1].Value = k.CikisNo;
                Liste.Columns[2].Visible = true;
                Liste.Rows[i].Cells[2].Value = k.FKayitNo;
                Liste.Rows[i].Cells[3].Value = k.UrunKodu;
                Liste.Rows[i].Cells[4].Value = k.LotSeriNo;
                Liste.Rows[i].Cells[5].Value = k.Aciklama;
                Liste.Rows[i].Cells[6].Value = k.Cadet;
                Liste.Rows[i].Cells[7].Value = k.BFiyat;
                Liste.Rows[i].Cells[8].Value = k.Tutar;
                txtCariAdi.Text = k.Fadi;
                txtVd.Text = k.Fvd;
                txtTcv.Text = k.Fvno;
                txtAdres.Text = k.Fadres;
                dtpTarih.Text = k.Tarih.ToString();
                txtSaat.Text = k.Saat;
                txtAraT.Text = k.Atoplam.ToString();
                txtKdv.Text = k.KdvToplam.ToString();
                txtToplamT.Text = k.Ttutar.ToString();
                txtEvrakNo.Text = k.FKayitNo.ToString().PadLeft(7, '0');
                i++;
            }
            Liste.AllowUserToAddRows = false;
            AnaSayfa.ListeAktarma = -1;
        }

        //void ListeleIki()
        //{
            
        //    Liste.Rows.Clear();
        //    int i = 0;
        //    var srg = (from s in _db.ftFaturaKesUsts
        //               where s.FKayitNo == AnaSayfa.ListeAktarma
        //               select s);
        //    foreach (var k in srg)
        //    {
        //        stUrunKayitUst ust = new stUrunKayitUst();
        //        stStokDurum durum = new stStokDurum();
        //        ftFaturaKesAlt alt = new ftFaturaKesAlt();

        //        Liste.Rows.Add();
        //        Liste.Rows[i].Cells[0].Value = -1;
        //        Liste.Columns[1].Visible = false;
        //        Liste.Columns[2].Visible = true;
        //        Liste.Rows[i].Cells[2].Value = k.FKayitNo;
        //        Liste.Rows[i].Cells[3].Value = durum.UrunKodu;
        //        Liste.Rows[i].Cells[4].Value = durum.LotSeriNo;
        //        Liste.Rows[i].Cells[5].Value = ust.Aciklama;
        //        Liste.Rows[i].Cells[6].Value = alt.Cadet;
        //        Liste.Rows[i].Cells[7].Value = alt.BFiyat;
        //        Liste.Rows[i].Cells[8].Value = k.Ttutar;
        //        txtCariAdi.Text = k.bgFirma.Fadi;
        //        txtVd.Text = k.bgFirma.Fvd;
        //        txtTcv.Text = k.bgFirma.Fvno;
        //        txtAdres.Text = k.bgFirma.Fadres;
        //        dtpTarih.Text = k.Tarih.ToString();
        //        txtSaat.Text = k.Saat;
        //        txtAraT.Text = k.Atoplam.ToString();
        //        txtKdv.Text = k.KdvToplam.ToString();
        //        txtToplamT.Text = k.Ttutar.ToString();
        //        txtEvrakNo.Text = k.FKayitNo.ToString().PadLeft(7, '0');
        //        i++;
        //    }
        //    Liste.AllowUserToAddRows = false;
        //} 

        void YeniKaydet()
        {
            try
            {
                ftFaturaKesUst ust = new ftFaturaKesUst();
                ust.FKayitNo = int.Parse(txtEvrakNo.Text);
                ust.CariId = _db.bgFirmas.First(x => x.Fadi == txtCariAdi.Text).Fno;
                ust.Tarih = DateTime.Parse(dtpTarih.Text);
                ust.Saat = txtSaat.Text;
                ust.Yazi = txtYazi.Text;
                ust.Atoplam = decimal.Parse(txtAraT.Text);
                ust.KdvToplam = decimal.Parse(txtKdv.Text);
                ust.Ttutar = decimal.Parse(txtToplamT.Text);
                ust.CikisNo = cksNo;
                _db.ftFaturaKesUsts.InsertOnSubmit(ust);
                _db.SubmitChanges();

                ftFaturaKesAlt[] alt = new ftFaturaKesAlt[Liste.RowCount];
                for (int i = 0; i < Liste.RowCount; i++)
                {
                    alt[i] = new ftFaturaKesAlt();
                    alt[i].BFiyat = decimal.Parse(Liste.Rows[i].Cells[7].Value.ToString());
                    alt[i].Cadet = int.Parse(Liste.Rows[i].Cells[6].Value.ToString());
                    alt[i].Tutar = int.Parse(Liste.Rows[i].Cells[8].Value.ToString());
                    alt[i].FKayitNo = int.Parse(txtEvrakNo.Text);
                    alt[i].UrunId = _db.stStokDurums.First(x => x.UrunKodu == Liste.Rows[i].Cells[3].Value.ToString() && x.LotSeriNo == Liste.Rows[i].Cells[4].Value.ToString()).Id;

                    _db.ftFaturaKesAlts.InsertOnSubmit(alt[i]);
                    _db.SubmitChanges();

                    var aa = alt[i].UrunId.Value;
                    var bb = int.Parse(Liste.Rows[i].Cells[1].Value.ToString());
                    var gncl = (from s in _db.stUrunCikis where s.UrunId == alt[i].UrunId where s.CikisNo == int.Parse(Liste.Rows[i].Cells[1].Value.ToString()) select s).ToList();

                    if (gncl.Count!=0)
                    {
                        var srg = _db.stUrunCikis.First(x => x.UrunId == aa && x.CikisNo == bb);
                        srg.FaturaDurum = true;
                        _db.SubmitChanges();
                    }
                }
                _m.YeniKayit("Kayıt Oluşturuldu.");
                Temizle();
            }
            catch (Exception e)
            {

                _m.Hata(e);
            }
        }

        void Sil()
        {
            for (int i = 0; i < Liste.RowCount; i++)
            {
                int bb = int.Parse(Liste.Rows[i].Cells[1].Value.ToString());

                var urnId =  _db.stStokDurums.First(x => x.UrunKodu == Liste.Rows[i].Cells[3].Value.ToString() && x.LotSeriNo == Liste.Rows[i].Cells[4].Value.ToString()).Id;

                //var srg = _db.stUrunCikis.First(x => x.UrunId == urnId && x.CikisNo == bb);
                //srg.FaturaDurum = false;

                _db.stUrunCikis.First(x => x.UrunId == urnId && x.CikisNo == bb).FaturaDurum = false;
                _db.SubmitChanges();
            }
            _db.ftFaturaKesUsts.DeleteOnSubmit(_db.ftFaturaKesUsts.First(x => x.FKayitNo == fkayNo));

            var alt = (from c in _db.ftFaturaKesAlts where c.FKayitNo == fkayNo select c).ToList();

            _db.ftFaturaKesAlts.DeleteAllOnSubmit(alt);
            _db.SubmitChanges();

            MessageBox.Show("Silme İşlemi başaralı");
            Close();
            _f.FaturaCikis();
        }

        protected override void OnLoad(EventArgs e)
        {
            var btngk = new Button();
            btngk.Size = new Size(25, txtEvrakNo.ClientSize.Height + 2);
            btngk.Location = new Point(txtEvrakNo.ClientSize.Width - btngk.Width, -1);
            btngk.Cursor = Cursors.Default;
            btngk.Image = SLNStokTakip.Properties.Resources.arrow_1176;
            txtEvrakNo.Controls.Add(btngk);
            SendMessage(txtEvrakNo.Handle, 0xd3, (IntPtr)2, (IntPtr)(btngk.Width << 16));
            btngk.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            base.OnLoad(e);
            btngk.Click += btngk_Click;
           
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private void btngk_Click(object sender, EventArgs e)
        {
            int id = _f.FaturaKesListe(true);
            if (id > 0)
            {
                Ac(id);
            }
            AnaSayfa.Aktarma = -1;
        }

        void Ac(int id)
        {

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            YeniKaydet();
        }

        private void Liste_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==8)
            {
                decimal a, b,t;
                a = decimal.Parse(Liste.CurrentRow.Cells[6].Value.ToString());
                b= decimal.Parse(Liste.CurrentRow.Cells[7].Value.ToString());
                t = a * b;
                Liste.CurrentRow.Cells[8].Value = t;

                Toplam();
            }
        }

        void Toplam()
        {
            decimal b=0,c=0,t=0;
            try
            {
                for(int i=0;i<Liste.Rows.Count;i++)
                {
                    b = b + Convert.ToDecimal(Liste.Rows[i].Cells[7].Value);
                    c = (b * 18) / 100;
                    t = b + c;
                }
                txtAraT.Text = b.ToString();
                txtKdv.Text = c.ToString();
                txtToplamT.Text = t.ToString();
                
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }

        private void btnCollaps_Click(object sender, EventArgs e)
        {
            switch (splitContainer1.Panel2Collapsed)
            {
                case true:
                    splitContainer1.Panel2Collapsed = false;
                    btnCollaps.Text = "GİZLE";
                    break;
                case false:
                    splitContainer1.Panel2Collapsed = true;
                    btnCollaps.Text = "GÖSTER";
                    break;
            }
        }

        public static string YaziyaCevir(decimal tutar)
        {
            bool tutarNegatifMi = false;

            if (tutar<0)
            {
                tutarNegatifMi = true;
                tutar = tutar * (-1);
            }

            string sTutar = tutar.ToString("F2").Replace('.', ','); //Replace  ('.', ',') ondalık ayracının nokta olma durumu için.
            string lira = sTutar.Substring(0, sTutar.IndexOf(',')); // Tutarın tam kısmı
            string kurus = sTutar.Substring(sTutar.IndexOf(',') + 1, 2);
            string yazi = "";

            string[] birler = { "", " BİR", " İKİ", " ÜÇ", " DÖRT", " BEŞ", " ALTI", " YEDİ", " SEKİZ", " DOKUZ" };
            string[] onlar = { "", " ON", " YİRMİ", " OTUZ", " KIRK", " ELLİ", " ALTMIŞ", " YETMİŞ", " SEKSEN", " DOKSAN" };
            string[] binler = { " KATRİLYON", " TRİLYON", " MİLYAR", " MİLYON", " BİN", "" };

            int grupSayisi = 6; //sayidaki 3'lü grup sayısı katrilyon için 6.(1.234,00 daki grup sayısı 2 dir.)
            lira = lira.PadLeft(grupSayisi * 3, '0'); // sayının sonuna 0 eklenrek grup sayısını 3 basamaklı yapıyor.

            string grupDegeri;
            for (int i = 0; i < grupSayisi*3; i+=3)
            {
                grupDegeri = "";
                if (lira.Substring(i, 1) != "0") 
                    grupDegeri += birler[Convert.ToInt32(lira.Substring(i, 1))]+ "YÜZ";
                if (grupDegeri=="BİRYÜZ")
                    grupDegeri = " YÜZ";
                    grupDegeri += onlar[Convert.ToInt32(lira.Substring(i + 1, 1))];  //+ "ONLAR";
                    grupDegeri += birler[Convert.ToInt32(lira.Substring(i + 2, 1))];  //+ "BİRLER";
                if (grupDegeri!="")
                    grupDegeri += binler[i / 3];
                if (grupDegeri=="BİRBİN")
                    grupDegeri = " BİN";
                    yazi += grupDegeri;
            }
            if (yazi!="")
                yazi += " TL";
            int yaziUzunlugu = yazi.Length;
            if (kurus.Substring(0,1)!="0")
                yazi += onlar[Convert.ToInt32(kurus.Substring(0, 1))];
            if (kurus.Substring(1,1)!="0")
                yazi += birler[Convert.ToInt32(kurus.Substring(1, 1))];
            if(yazi.Length>yaziUzunlugu)
            {
                yazi += " Kr.";
            }
            else
            {
                yazi += " SIFIR Kr.";
            }
            if (tutarNegatifMi)
            {
                return "Eksi" + yazi;
            }
            return yazi;
        }

        private void txtToplamT_TextChanged(object sender, EventArgs e)
        {
            txtYazi.Text = YaziyaCevir(Convert.ToDecimal(txtToplamT.Text));
        }

        void SaatBul()
        {
            if (!chbManuel.Checked)
            {
                DateTime zmn = DateTime.Now;
                txtSaat.Text = zmn.ToShortTimeString();
            }
            else
            {
                txtSaat.Text = "00:00";
            }
        }

        private void chbManuel_CheckedChanged(object sender, EventArgs e)
        {
            SaatBul();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Sil();
        }
    }
}
