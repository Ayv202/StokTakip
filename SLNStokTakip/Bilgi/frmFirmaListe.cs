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
    public partial class frmFirmaListe : Form
    {
        DbStokDataContext _db = new DbStokDataContext();
        Mesajlar _m = new Mesajlar();
        Formlar _f = new Formlar();

        public bool Secim = false;
        int _secimId = -1;

        public frmFirmaListe()
        {
            InitializeComponent();
        }
        private void frmFirmaListe_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var lst = (from c in _db.bgFirmas
                       where c.Fadi.Contains(txtFirmaBul.Text)
                       select c).ToList();

            foreach(var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = k.Fno;
                Liste.Rows[i].Cells[1].Value = k.Fadi;
                Liste.Rows[i].Cells[2].Value = k.Ftel1;
                Liste.Rows[i].Cells[3].Value = k.Ftel2;
                Liste.Rows[i].Cells[4].Value = k.bgFirmaTipi.Ftipi;
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
            if(Secim&&_secimId>0)
            {
                AnaSayfa.Aktarma = _secimId;
                Close();
            }
        }
    }
}
