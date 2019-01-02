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
    public partial class frmFirmaGiris : Form
    {
        DbStokDataContext _db = new DbStokDataContext();

        Mesajlar _m = new Mesajlar();
        Numaralar _n = new Numaralar();
        Formlar _f = new Formlar();

        bool _edit = false;


        public frmFirmaGiris()
        {
            InitializeComponent();
        }

        private void btnCollaps_Click(object sender, EventArgs e)
        {
            //if(splitContainer1.Panel2Collapsed)
            //{
            //    splitContainer1.Panel2Collapsed = false;
            //    btnCollaps.Text = "GİZLE";
            //}
            ////else if(splitContainer1.Panel2Collapsed==false)
            ////{
            ////    splitContainer1.Panel2Collapsed = true;
            ////    btnCollaps.Text = "GÖSTER";
            ////}
            //else if (!splitContainer1.Panel2Collapsed)
            //{
            //    splitContainer1.Panel2Collapsed = true;
            //    btnCollaps.Text = "GÖSTER";
            //}

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

        private void frmFirmaGiris_Load(object sender, EventArgs e)
        {
            Temizle();
            Combo();            
        }

        void Temizle()
        {
            foreach (Control ct in splitContainer1.Panel1.Controls)
            {
                if (ct is TextBox || ct is ComboBox)
                {
                    ct.Text = "";
                }
            }
            _edit = false;
            AnaSayfa.Aktarma = -1;
            txtFno.Text = _n.FirNo();
        }

        void Combo()
        {
            cbCtipi.Items.Clear();
            cbCtipi.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection veri = new AutoCompleteStringCollection();

            var ct = _db.bgFirmaTipis.Select(x => x.Ftipi).Distinct();
            foreach (string ftip in ct)
            {
                veri.Add(ftip);
                cbCtipi.Items.Add(ftip);
            }
            cbCtipi.AutoCompleteCustomSource = veri;
        }

        void YeniKaydet()
        {
            try
            {
                if (txtAdi.Text != "" && txtVd.Text != "" && txtTcVno.Text != "" && cbCtipi.Text!="")
                {
                    bgFirma fm = new bgFirma()
                    {
                        Fno=int.Parse(txtFno.Text),
                        Fadi = txtAdi.Text,
                        Fadres = txtAdres.Text,
                        Ffaks = txtFaks.Text,
                        Ftel1 = txtTel1.Text,
                        Ftel2 = txtTel2.Text,
                        Femail = txtEposta.Text,
                        Fvd = txtVd.Text,
                        Fvno = txtTcVno.Text,
                        Fyetkili = txtYetkili.Text,
                        Fweb = txtWeb.Text,
                        Ftipi= _db.bgFirmaTipis.First(x => x.Ftipi == cbCtipi.Text).Id,
                        Fdepartman = cbDep.Text,
                        saveDate = DateTime.Now,
                        saveUser = -1 // Burada ki bilgi giriş sayfası yapıldığında eklenecektir.
                    };
                    
                    _db.bgFirmas.InsertOnSubmit(fm);
                    _db.SubmitChanges();
                    _m.YeniKayit("Kayıt başarıyla oluşturuldu.");
                    Temizle();
                    Close();//formu kapat.
                    _f.FrmGir();//Yeniden aç.
                }
                else
                {
                    MessageBox.Show("Eksik alanları doldurun!!!");
                }
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }

        }

        void Guncelle()
        {
            DbStokDataContext _db = new DbStokDataContext();
            try
            {
                bgFirma fr = _db.bgFirmas.First(x => x.Fno == int.Parse(txtFno.Text));
                fr.Ftel1 = txtTel1.Text;
                fr.Ftel2 = txtTel2.Text;
                fr.Ftipi = _db.bgFirmaTipis.First(x => x.Ftipi == cbCtipi.Text).Id;
                fr.Fadi = txtAdi.Text;
                fr.Fadres = txtAdres.Text;
                fr.Fdepartman = cbDep.Text;
                fr.Femail = txtEposta.Text;
                fr.Ffaks = txtFaks.Text;
                fr.Fvd = txtVd.Text;
                fr.Fvno = txtTcVno.Text;
                fr.Fweb = txtWeb.Text;
                fr.Fyetkili = txtYetkili.Text;
                fr.updateDate = DateTime.Now;
                fr.updateUser = -1;//Kullanıcı giriş ekranı yapıldığında burası düzenlenecektir. Hata almamak için -1 değerine set edilmiştir.
                _db.SubmitChanges();
                _m.Guncelle(true);
                Temizle();
                Close();//güncelleme işlemi bittiğinde form kapatılsın.
                _f.FrmGir();//formu otomatik yeniden açması için yazdım.asl
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }

        void Sil()
        {
            try
            {
                _db.bgFirmas.DeleteOnSubmit(_db.bgFirmas.First(x => x.Fno == int.Parse(txtFno.Text)));
                _db.SubmitChanges();
                Temizle();
                Close();//Silme işlemi başarılı olduktan sonra formu kapatıyoruz.
                //tekrar otomatik açmak için ise aşağıdaki kodu kullana biliriz.
                _f.FrmGir();
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            var btnfno = new Button();
            btnfno.Size = new Size(25, txtFno.ClientSize.Height + 2);
            btnfno.Location = new Point(txtFno.ClientSize.Width - btnfno.Width, -1);
            btnfno.Cursor = Cursors.Default;
            btnfno.Image = SLNStokTakip.Properties.Resources.arrow_1176;
            txtFno.Controls.Add(btnfno);

            SendMessage(txtFno.Handle, 0xd3, (IntPtr)2, (IntPtr)(btnfno.Width << 16));
            btnfno.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            base.OnLoad(e);
            btnfno.Click += btnfno_Click;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);


        private void btnfno_Click(object sender,EventArgs e)
        {
            int id = _f.FrmListe(true);
            if (id>0)
            {
                Ac(id);
            }
            AnaSayfa.Aktarma = -1;
        }

        void Ac(int id)//id olarak gelen parametre değerini Firma tablosunda Fno alanından aldık.
        {
            try
            {
                _edit = true;
                bgFirma fm = _db.bgFirmas.First(z => z.Fno == id);//bu yüzden fno ile id eşitliğini kontrol ediyoruz. 
                txtAdi.Text = fm.Fadi;
                txtAdres.Text = fm.Fadres;
                txtEposta.Text = fm.Femail;
                txtFaks.Text = fm.Ffaks;
                txtFno.Text = fm.Fno.ToString().PadLeft(7, '0');
                txtTcVno.Text = fm.Fvno;
                txtTel1.Text = fm.Ftel1;
                txtTel2.Text = fm.Ftel2;
                txtVd.Text = fm.Fvd;
                txtWeb.Text = fm.Fweb;
                txtYetkili.Text = fm.Fyetkili;
                cbCtipi.Text = fm.bgFirmaTipi.Ftipi;
                cbDep.Text = fm.Fdepartman;
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (_edit && int.Parse(txtFno.Text) > 0 && _m.Guncelle() == DialogResult.Yes) Guncelle();
            else if (_edit == false)
                YeniKaydet();
            else
                return;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (_edit && int.Parse(txtFno.Text) > 0 && _m.Sil() == DialogResult.Yes) Sil();
            else return;
        }
    }
}
