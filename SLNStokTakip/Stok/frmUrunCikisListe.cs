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

namespace SLNStokTakip.Stok
{
    public partial class frmUrunCikisListe : Form
    {
        DbStokDataContext _db = new DbStokDataContext();

        public bool Secim = false;
        int _secimId = -1;
        public frmUrunCikisListe()
        {
            InitializeComponent();
        }

        private void frmUrunCikisListe_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;

            var srg = (from s in _db.stUrunCikis
                       where s.bgFirma.Fadi.Contains(txtCariBul.Text)
                       select new
                       {
                           ckod = s.CikisNo,
                           fad=s.bgFirma.Fadi,
                           ct=s.Cturu,
                           trh=s.Tarih,
                           drm=s.FaturaDurum
                       }).Distinct().OrderByDescending(x=>x.trh);
            foreach(var k in srg)
            {
                Liste.Rows.Add();                
                Liste.Rows[i].Cells[0].Value = k.ckod;
                Liste.Rows[i].Cells[1].Value = k.fad;
                Liste.Rows[i].Cells[2].Value = k.ct;
                Liste.Rows[i].Cells[3].Value = k.trh;
                Liste.Rows[i].Cells[4].Value = k.drm;
                i++;
            }
            Liste.AllowUserToAddRows = false;
        }

        void Sec()
        {
            try
            {
                if (Liste.CurrentRow != null) _secimId = int.Parse(Liste.CurrentRow.Cells[0].Value.ToString());
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
    }
}
