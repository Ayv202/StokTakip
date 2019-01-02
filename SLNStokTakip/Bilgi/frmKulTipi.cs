using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SLNStokTakip.Hangar;

namespace SLNStokTakip.Bilgi
{
    public partial class frmKulTipi : Form
    {
        readonly DbStokDataContext _db = new DbStokDataContext();
        readonly Mesajlar _m = new Mesajlar();
        readonly Formlar _f = new Formlar();

        public bool Secim = false;
        int _secimId = -1;
        bool _edit = false;

        public frmKulTipi()
        {
            InitializeComponent();
        }

        private void frmKulTipi_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            int i = 0;
            Liste.Rows.Clear();
            var lst = from s in _db.bgKulTipis select s;
            
            foreach(var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = k.Id;
                Liste.Rows[i].Cells[1].Value = k.KulTipi;
                i++;
            }
            Liste.AllowUserToAddRows = false;
        }

        void YeniKaydet()
        {
            try
            {
                bgKulTipi kul = new bgKulTipi();
                kul.KulTipi = txtKulTip.Text;
                _db.bgKulTipis.InsertOnSubmit(kul);
                _db.SubmitChanges();
                _m.YeniKayit("Kayıt işlemi tamamlandı.");
                txtKulTip.Text = "";
                Listele();
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
                bgKulTipi kul = _db.bgKulTipis.First(s => s.Id == _secimId);
                kul.KulTipi = txtKulTip.Text;
                _db.SubmitChanges();
                _m.Guncelle(true);
                txtKulTip.Text = "";
                Listele();
                _edit = false;
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }

        void Sec()
        {
            try
            {
                _edit = true;
                if(Liste.CurrentRow != null)
                {
                    _secimId = int.Parse(Liste.CurrentRow.Cells[0].Value.ToString());
                    txtKulTip.Text = Liste.CurrentRow.Cells[1].Value.ToString();

                }
            }
            catch (Exception)
            {
                _edit = false;
                _secimId = -1;
            }
        }

        void Sil()
        {
            try
            {
                _db.bgKulTipis.DeleteOnSubmit(_db.bgKulTipis.First(x => x.Id == _secimId));
                _db.SubmitChanges();
                txtKulTip.Text = "";
                Listele();
                _edit = false;
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (_edit && _secimId > 0 && _m.Guncelle() == DialogResult.Yes) Guncelle();
            else YeniKaydet();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (_edit && _secimId > 0 && _m.Sil() == DialogResult.Yes) Sil();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Liste_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Sec();
        }
    }
}
