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

namespace SLNStokTakip.Fatura
{
    public partial class frmCikisBul : Form
    {
        DbStokDataContext _db = new DbStokDataContext();
        Formlar _f = new Formlar();

        public bool Secim = false;
        int _secimId = -1;

        public frmCikisBul()
        {
            InitializeComponent();
        }

        private void frmCikisBul_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var lst = (from s in _db.stUrunCikis
                       where s.FaturaDurum == false
                       select new {
                           cn=s.CikisNo,
                           fa=s.bgFirma.Fadi,
                           ct=s.Cturu,
                           trh=s.Tarih,
                           fd=s.FaturaDurum
                       }).ToList().Distinct();
            foreach(var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = k.cn;
                Liste.Rows[i].Cells[1].Value = k.fa;
                Liste.Rows[i].Cells[2].Value = k.ct;
                Liste.Rows[i].Cells[3].Value = k.trh;
                Liste.Rows[i].Cells[4].Value = k.fd;
                i++;
            }
            Liste.AllowUserToAddRows = false;
        }

        void Sec()
        {
            try
            {
                _secimId = int.Parse(Liste.CurrentRow.Cells[0].Value.ToString());
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
            Secim = true;
            if(Secim && _secimId>0)
            {
                AnaSayfa.Aktarma = _secimId;
                Close();
                _f.FaturaCikis();
            }
        }
    }
}
