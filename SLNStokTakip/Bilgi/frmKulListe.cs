using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLNStokTakip.Bilgi
{
    public partial class frmKulListe : Form
    {
        readonly Hangar.DbStokDataContext _db = new Hangar.DbStokDataContext();

        readonly Hangar.Formlar _f = new Hangar.Formlar();

        public bool Secim = false;
        int _secimId = -1;
        
        public frmKulListe()
        {
            InitializeComponent();
        }

        private void frmKulListe_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            //Hangar.DbStokDataContext _db = new Hangar.DbStokDataContext();
            Liste.Rows.Clear();

            int i = 0;

            var lst = (from s in _db.bgKullanicilars where s.Kadi.Contains(txtAdi.Text)
                       //where s.Kadi==txtAdi.Text
                       select s).ToList();
            foreach(var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = k.Kadi;
                Liste.Rows[i].Cells[1].Value = k.Ksoyadi;
                Liste.Rows[i].Cells[2].Value = k.Tel;
                Liste.Rows[i].Cells[3].Value = k.Gsm;
                Liste.Rows[i].Cells[4].Value = _db.bgKulTipis.First(x => x.Id == k.Ktipi).KulTipi;
                Liste.Rows[i].Cells[5].Value = k.Id;
                i++;
            }
            Liste.AllowUserToAddRows = false;

        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtAdi_TextChanged(object sender, EventArgs e)
        {
            Listele();
        }

        void Sec()
        {
            try
            {
                if (Liste.CurrentRow != null) _secimId = int.Parse(Liste.CurrentRow.Cells[5].Value.ToString());
            }
            catch (Exception)
            {
                _secimId = -1;
            }
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
