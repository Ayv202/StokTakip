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

namespace SLNStokTakip.Bilgi
{
    public partial class frmKulGiris : Form
    {
         DbStokDataContext _db = new DbStokDataContext();
         DbStokDataContext _gb = new DbStokDataContext();

        readonly Formlar _f = new Formlar();
        readonly Mesajlar _m = new Mesajlar();
        readonly Numaralar _n = new Numaralar();

        public bool _edit = false;
        
        

        public frmKulGiris()
        {
            InitializeComponent();
        }

        private void frmKulGiris_Load(object sender, EventArgs e)
        {            
            Combo();
            Temizle();
            cbKtipi.SelectedIndex = 0;
        }

        void Combo()
        {
            cbKtipi.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection veri = new AutoCompleteStringCollection();
            var dg = _db.bgKulTipis.Select(x => x.KulTipi).Distinct();
            foreach(string tip in dg)
            {
                veri.Add(tip);
                cbKtipi.Items.Add(tip);
            }
            cbKtipi.AutoCompleteCustomSource = veri;
            
        }

        void Temizle()
        {
            foreach (Control ct in splitContainer1.Panel1.Controls)
                if (ct is TextBox || ct is ComboBox) ct.Text = "";
            txtGenelNo.Text=_n.KulGenel();
            _edit = false;
        }

        private void YeniKaydet()
        {
            try
            {
                Hangar.bgKullanicilar kul = new Hangar.bgKullanicilar
                {
                    Adres = txtAdres.Text,
                    Kadi = txtAdi.Text,
                    Ksoyadi = txtSoyadi.Text,
                    Email = txtEmail.Text,
                    Tel = txtTelefon.Text,
                    Sifre = txtSifre.Text,
                    Gsm = txtGsm.Text,
                    Ktipi = _db.bgKulTipis.First(x=>x.KulTipi==cbKtipi.Text).Id,
                    GenelNo = txtGenelNo.Text
                };
                _db.bgKullanicilars.InsertOnSubmit(kul);
                _db.SubmitChanges();
                _m.YeniKayit("Yeni kayıt oluşturuldu");
                Temizle();
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }

        void Guncelle()
        {
            try
            {
                bgKullanicilar kul = _gb.bgKullanicilars.First(x => x.GenelNo == txtGenelNo.Text);
                kul.Gsm = txtGsm.Text;
                kul.Adres = txtAdres.Text;
                kul.Email = txtEmail.Text;
                kul.GenelNo = txtGenelNo.Text;
                kul.Kadi = txtAdi.Text;
                kul.Ksoyadi = txtSoyadi.Text;
                kul.Sifre = txtSifre.Text;               

                kul.Ktipi = _gb.bgKulTipis.First(x => x.KulTipi == cbKtipi.Text).Id;
                kul.Tel = txtTelefon.Text;

                _gb.SubmitChanges();
                _m.Guncelle(true);
                Temizle();
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }

        void Sil()
        {
            DbStokDataContext _db = new DbStokDataContext();
            try
            {
                _db.bgKullanicilars.DeleteOnSubmit(_db.bgKullanicilars.First(s => s.GenelNo == txtGenelNo.Text));
                _db.SubmitChanges();
                Temizle();
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (_edit && int.Parse(txtGenelNo.Text) > 0 && _m.Guncelle() == DialogResult.Yes) Guncelle();
            else if (_edit == false) YeniKaydet();
            else return;

            //if (_edit && int.Parse(txtGenelNo.Text) > 0 && _m.Guncelle() == DialogResult.Yes)
            //{Guncelle();}
            //else if (_edit == true && int.Parse(txtGenelNo.Text) > 0)
            //{return;}
            //else
            //{YeniKaydet();}
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();            
        }

        public void Ac(int id)
        {
            DbStokDataContext _db = new DbStokDataContext();
            try
            {
                _edit = true;

                Hangar.bgKullanicilar kul = _db.bgKullanicilars.First(x => x.Id == id);
                txtAdi.Text = kul.Kadi;
                txtAdres.Text = kul.Adres;
                txtEmail.Text = kul.Email;
                txtGenelNo.Text = kul.GenelNo;
                txtGsm.Text = kul.Gsm;
                txtSifre.Text = kul.Sifre;
                txtSoyadi.Text = kul.Ksoyadi;
                txtTelefon.Text = kul.Tel;
                //cbKtipi.Text = _db.bgKulTipis.First(y => y.Id == id).KulTipi;

                cbKtipi.Text = kul.bgKulTipi.KulTipi;
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            var btngno = new Button();
            btngno.Size = new Size(25, txtGenelNo.ClientSize.Height + 2);
            btngno.Location = new Point(txtGenelNo.ClientSize.Width - btngno.Width, -1);
            btngno.Cursor = Cursors.Default;
            btngno.Image = SLNStokTakip.Properties.Resources.arrow_1176;
            txtGenelNo.Controls.Add(btngno);

            //SendMessage(txtGenelNo.Handle, 0xd3, (IntPtr)(btngno.Width << 16));
            btngno.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            base.OnLoad(e);
            btngno.Click += btngno_Click;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private void btngno_Click(object sender,EventArgs e)
        {
            int id = _f.KulListe(true);
            if(id>0)
            {
                Ac(id);
            }
            AnaSayfa.Aktarma = -1;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (_edit && txtGenelNo.Text != "" && _m.Sil() == DialogResult.Yes) Sil();
        }
    }
}
