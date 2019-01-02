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
using SLNStokTakip.Bilgi;

namespace SLNStokTakip.Stok
{
    public partial class frmUrunKayitListe : Form
    {
        DbStokDataContext _db = new DbStokDataContext();

        Formlar _f = new Formlar();
        Mesajlar _m = new Mesajlar();
        public bool Secim = false;
        int _secimId = -1;

        public frmUrunKayitListe()
        {
            InitializeComponent();
        }

        private void frmUrunKayitListe_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var lst = (from s in _db.stUrunKayitUsts
                       where s.bgFirma.Fadi.Contains(txtCariBul.Text)
                       select new
                       {
                           gk = s.GirisKod,
                           gn = s.GenelNo,
                           fa = s.bgFirma.Fadi,
                           gt = s.GirisTarih,
                           fn=s.FaturaNo
                       }).OrderByDescending(x => x.gt).ThenBy(y => y.fa);

            foreach(var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = k.gk;
                Liste.Rows[i].Cells[1].Value = k.gn;
                Liste.Rows[i].Cells[2].Value = k.fa;
                DateTime a =DateTime.Parse(k.gt.ToString());
                string aa = a.ToShortDateString();
                Liste.Rows[i].Cells[3].Value = aa;
                Liste.Rows[i].Cells[4].Value = k.fn;

                i++;
            }
            Liste.AllowUserToAddRows = false;
        }
        void Sec()
        {
            try
            {
                if (Liste.CurrentRow != null) _secimId = int.Parse(Liste.CurrentRow.Cells[0].Value.ToString());//Giris No yu _secimId ye atadık.
            }
            catch (Exception)
            {
                _secimId = -1;
            }
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            Sec();
            if(Secim && _secimId>0)
            {
                AnaSayfa.Aktarma = _secimId;
                Close();
            }
        }

        private void txtCariBul_TextChanged(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
