using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SLNStokTakip.Hangar;

namespace SLNStokTakip.Stok
{
    public partial class frmStokDurum : Form
    {
        DbStokDataContext _db = new DbStokDataContext();

        public frmStokDurum()
        {
            InitializeComponent();
        }

        private void frmStokDurum_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var lst = from s in _db.stStokDurums
                      where s.Adet != 0
                      where SqlMethods.Like(s.UrunKodu, "%" + txtUrunKodu.Text + "%")
                      select s;

            foreach(var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = k.Id;
                Liste.Rows[i].Cells[1].Value = k.UrunKodu;
                Liste.Rows[i].Cells[2].Value = k.LotSeriNo;
                Liste.Rows[i].Cells[3].Value = k.Adet;
                Liste.Rows[i].Cells[4].Value = k.Aciklama;
                i++;
            }
            Liste.AllowUserToAddRows = false;
            Topla();
        }
        void Topla()
        {
            int a = 0;
            for(int ii=0;ii<Liste.Rows.Count;ii++)
            {
                a += Convert.ToInt32(Liste.Rows[ii].Cells[3].Value);
                //txtToplam.Text = Convert.ToString(a);
            }
            txtToplam.Text = a.ToString();
            
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
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

        private void txtUrunKodu_TextChanged(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
