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
    public partial class frmUrunGiris : Form
    {
        DbStokDataContext _db = new DbStokDataContext();

        Mesajlar _m = new Mesajlar();
        Numaralar _n = new Numaralar();
        Formlar _f = new Formlar();

        bool _edit = false;

        public frmUrunGiris()
        {
            InitializeComponent();
        }

        private void frmUrunGiris_Load(object sender, EventArgs e)
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
            txtUrnNo.Text = _n.UrnNo();
        }

        void Combo()
        {
            cbUKat.Items.Clear();
            cbUKat.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection veri = new AutoCompleteStringCollection();

            var ct = _db.bgKategoris.Select(x => x.KategoriAdi).Distinct();
            foreach (string ukat in ct)
            {
                veri.Add(ukat);
                cbUKat.Items.Add(ukat);
            }
            cbUKat.AutoCompleteCustomSource = veri;
        }

        void YeniKaydet()
        {
            try
            {
                if (txtUrnKodu.Text != "" && txtUrnNo.Text != "" && txtUrnAciklama.Text != "" && cbUKat.Text != "")
                {
                    bgUrunGiri ug = new bgUrunGiri()
                    {
                        UrunNo = int.Parse(txtUrnNo.Text),
                        UrunKodu = txtUrnKodu.Text,
                        UrunAciklama = txtUrnAciklama.Text,
                        KategoriId = _db.bgKategoris.First(x=>x.KategoriAdi==cbUKat.Text).Id,
                        
                        
                        saveDate = DateTime.Now,
                        saveUser = -1 // Burada ki bilgi giriş sayfası yapıldığında eklenecektir.
                    };

                    _db.bgUrunGiris.InsertOnSubmit(ug);
                    _db.SubmitChanges();
                    _m.YeniKayit("Kayıt başarıyla oluşturuldu.");
                    Temizle();
                    Close();//formu kapat.
                    _f.UrnGir();//Yeniden aç.
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
                bgUrunGiri ug = _db.bgUrunGiris.First(x => x.UrunNo == int.Parse(txtUrnNo.Text));
                ug.UrunNo = int.Parse(txtUrnNo.Text);
                ug.UrunKodu = txtUrnKodu.Text;
                ug.KategoriId = _db.bgKategoris.First(x => x.KategoriAdi == cbUKat.Text).Id;
                ug.UrunAciklama = txtUrnAciklama.Text;                
                ug.updateDate = DateTime.Now;
                ug.updateUser = -1;//Kullanıcı giriş ekranı yapıldığında burası düzenlenecektir. Hata almamak için -1 değerine set edilmiştir.
                _db.SubmitChanges();
                _m.Guncelle(true);
                Temizle();
                Close();//güncelleme işlemi bittiğinde form kapatılsın.
                _f.UrnGir();//formu otomatik yeniden açması için yazdım.asl
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
                _db.bgUrunGiris.DeleteOnSubmit(_db.bgUrunGiris.First(x => x.UrunNo == int.Parse(txtUrnNo.Text)));
                _db.SubmitChanges();
                Temizle();
                Close();//Silme işlemi başarılı olduktan sonra formu kapatıyoruz.
                //tekrar otomatik açmak için ise aşağıdaki kodu kullana biliriz.
                _f.UrnGir();
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            var btnurn = new Button();
            btnurn.Size = new Size(25, txtUrnNo.ClientSize.Height + 2);
            btnurn.Location = new Point(txtUrnNo.ClientSize.Width - btnurn.Width, -1);
            btnurn.Cursor = Cursors.Default;
            btnurn.Image = SLNStokTakip.Properties.Resources.arrow_1176;
            txtUrnNo.Controls.Add(btnurn);

            SendMessage(txtUrnNo.Handle, 0xd3, (IntPtr)2, (IntPtr)(btnurn.Width << 16));
            btnurn.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            base.OnLoad(e);
            btnurn.Click += btnurn_Click;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private void btnurn_Click(object sender, EventArgs e)
        {
            int id = _f.UrnListe(true);
            if (id > 0)
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
                bgUrunGiri ug = _db.bgUrunGiris.First(z => z.UrunNo == id);//bu yüzden fno ile id eşitliğini kontrol ediyoruz. 
                
                txtUrnNo.Text = ug.UrunNo.ToString().PadLeft(7, '0');
                txtUrnAciklama.Text = ug.UrunAciklama;
                txtUrnKodu.Text = ug.UrunKodu;                
                cbUKat.Text = ug.bgKategori.KategoriAdi;
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (_edit && int.Parse(txtUrnNo.Text) > 0 && _m.Guncelle() == DialogResult.Yes) Guncelle();
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
            if (_edit && int.Parse(txtUrnNo.Text) > 0 && _m.Sil() == DialogResult.Yes) Sil();
            else return;
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

        private void cbUKat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string a= cbUKat.Text.PadRight(4, '-').Substring(0, 4);
            //txtUrnKodu.Text = a.PadRight(5, '-');

            txtUrnKodu.Text= cbUKat.Text.PadRight(4, '*').Substring(0, 4)+"-";
        }
    }
}
