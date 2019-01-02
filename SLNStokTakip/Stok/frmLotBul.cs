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
    public partial class frmLotBul : Form
    {
        DbStokDataContext _db = new DbStokDataContext();

        public bool Secim = false;
        public string Lott;
        int _secimId = -1;

        public frmLotBul()
        {
            InitializeComponent();
        }

        Stok.frmUrunCikis ucikis=Application.OpenForms["frmUrunCikis"] as frmUrunCikis;

        private void frmLotBul_Load(object sender, EventArgs e)
        {
            switch (Lott)
            {
                case "UrunCikis":
                    txtUrunKodu.Text = AnaSayfa.LotAktar;
                    break;
            }
        }

        private void txtUrunKodu_TextChanged(object sender, EventArgs e)
        {
            int i = 0;
            var lst = from s in _db.stStokDurums
                      where s.UrunKodu == txtUrunKodu.Text
                      where s.Adet != 0
                      select new
                      {
                          id = s.Id,
                          ukod = s.UrunKodu,
                          lot = s.LotSeriNo,
                          acik = s.Aciklama,
                          adt = s.Adet
                      };
            foreach(var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = k.id;
                Liste.Rows[i].Cells[1].Value = k.ukod;
                Liste.Rows[i].Cells[2].Value = k.lot;
                Liste.Rows[i].Cells[3].Value = k.acik;
                Liste.Rows[i].Cells[4].Value = k.adt;
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

        void Tmm()
        {
            Sec();
            if(Secim && _secimId>0)
            {
                AnaSayfa.Aktarma = _secimId;
                Close();
            }
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            Tmm();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //Tmm();
            Liste_DoubleClick(sender,e);
        }
    }
}
