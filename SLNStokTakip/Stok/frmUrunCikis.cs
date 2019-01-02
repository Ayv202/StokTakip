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

namespace SLNStokTakip.Stok
{
    public partial class frmUrunCikis : Form
    {
        DbStokDataContext _db = new DbStokDataContext();

        Formlar _f = new Formlar();
        Mesajlar _m = new Mesajlar();
        Numaralar _n = new Numaralar();

        public bool LotKontrol = false;

        public string[] MyArray { get; set; }

        public bool _edit = false;

        public frmUrunCikis()
        {
            InitializeComponent();
        }

        private void frmUrunCikis_Load(object sender, EventArgs e)
        {
            Temizle();
            Combo();
        }

        void Temizle()
        {
            foreach (Control ct in splitContainer1.Panel2.Controls)
                if (ct is TextBox || ct is ComboBox) ct.Text = "";
            Liste.Rows.Clear();
            _edit = false;
            txtCikisKodu.Text = _n.UrunCikisKodu();
            AnaSayfa.Aktarma = -1;
        }

        void Combo()
        {
            cbUrun.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection veri = new AutoCompleteStringCollection();
            var lst = _db.stStokDurums.Select(x => x.UrunKodu).Distinct();
            foreach (string urun in lst)
            {
                veri.Add(urun);
                cbUrun.Items.Add(urun);
            }
            cbUrun.AutoCompleteCustomSource = veri;

            int dgv;
            dgv = cbUrun.Items.Count;
            MyArray = new string[dgv];
            for (int p = 0; p < dgv; p++)
            {
                MyArray[p] = cbUrun.Items[p].ToString();
            }

        }

        void YeniKaydet()
        {
            Liste.AllowUserToAddRows = false;
            try
            {
                stStokDurum[] drm = new stStokDurum[Liste.RowCount];
                stUrunCiki[] uc = new stUrunCiki[Liste.RowCount];
                for (int i = 0; i < Liste.RowCount; i++)
                {
                    uc[i] = new stUrunCiki();
                    uc[i].Aciklama = Liste.Rows[i].Cells[4].Value.ToString();
                    uc[i].CikisNo = int.Parse(txtCikisKodu.Text);
                    uc[i].Adet = int.Parse(Liste.Rows[i].Cells[7].Value.ToString());
                    uc[i].Cturu = cbCturu.Text;
                    uc[i].FirmaId = txtCariAdi.Text != "" ? _db.bgFirmas.First(x => x.Fadi == txtCariAdi.Text).Fno : -1;
                    uc[i].FaturaDurum = false;
                    uc[i].saveDate = DateTime.Now;
                    uc[i].saveUser = -1;
                    uc[i].Tarih = DateTime.Parse(dtpTarih.Text);
                    uc[i].UrunId = int.Parse(Liste.Rows[i].Cells[0].Value.ToString());

                    _db.stUrunCikis.InsertOnSubmit(uc[i]);
                    _db.SubmitChanges();

                    drm[i] = new stStokDurum();
                    var srg = (from s in _db.stStokDurums
                               where s.Id == uc[i].UrunId
                               select s).ToList();
                    if (srg.Count != 0)
                    {
                        stStokDurum sd = _db.stStokDurums.First(x => x.Id == int.Parse(Liste.Rows[i].Cells[0].Value.ToString()));
                        sd.Adet -= int.Parse(Liste.Rows[i].Cells[7].Value.ToString());
                        _db.SubmitChanges();
                    }

                }
                _m.YeniKayit("Yeni kayıt oluşturulmuştur.");
                Temizle();
                Close();
                _f.UrunCikis();
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            var btngk = new Button();
            btngk.Size = new Size(25, txtCikisKodu.ClientSize.Height + 2);
            btngk.Location = new Point(txtCikisKodu.ClientSize.Width - btngk.Width, -1);
            btngk.Cursor = Cursors.Default;
            btngk.Image = SLNStokTakip.Properties.Resources.arrow_1176;
            txtCikisKodu.Controls.Add(btngk);
            SendMessage(txtCikisKodu.Handle, 0xd3, (IntPtr)2, (IntPtr)(btngk.Width << 16));
            btngk.Anchor = (AnchorStyles.Top | AnchorStyles.Right);


            var btnCari = new Button();
            btnCari.Size = new Size(25, txtCariAdi.ClientSize.Height + 2);
            btnCari.Location = new Point(txtCariAdi.ClientSize.Width - btnCari.Width, -1);
            btnCari.Cursor = Cursors.Default;
            btnCari.Image = SLNStokTakip.Properties.Resources.arrow_1176;
            txtCariAdi.Controls.Add(btnCari);
            SendMessage(txtCariAdi.Handle, 0xd3, (IntPtr)2, (IntPtr)(btnCari.Width << 16));
            btnCari.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            base.OnLoad(e);
            btngk.Click += btngk_Click;
            btnCari.Click += btnCari_Click;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        private void btngk_Click(object sender, EventArgs e)
        {
            int id = _f.UrunCikisListe(true);
            if (id > 0)
            {
                Ac(id);
            }
            AnaSayfa.Aktarma = -1;
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            int id = _f.FrmListe(true);
            if (id > 0)
            {
                CariAc(id);
            }
            AnaSayfa.Aktarma = -1;
        }

        public void CariAc(int id)
        {
            try
            {
                bgFirma frm = _db.bgFirmas.First(x => x.Fno == id);
                txtCariAdi.Text = frm.Fadi;
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }

        public void Ac(int id)
        {
            Liste.Rows.Clear();
            try
            {
                int i = 0;
                _edit = true;
                var srg = (from s in _db.stUrunCikis
                           where s.CikisNo == id
                           select s).OrderBy(x => x.stStokDurum.UrunKodu);
                foreach (var k in srg)
                {
                    Liste.Rows.Add();
                    Liste.Rows[i].Cells[1].Value = k.CikisNo;
                    Liste.Rows[i].Cells[2].Value = k.stStokDurum.UrunKodu;
                    Liste.Columns[3].Visible = false;
                    Liste.Rows[i].Cells[4].Value = k.stStokDurum.LotSeriNo;
                    Liste.Rows[i].Cells[5].Value = k.stStokDurum.Aciklama;
                    Liste.Rows[i].Cells[6].Value = k.stStokDurum.Adet;
                    Liste.Rows[i].Cells[7].Value = k.Adet;
                    i++;
                    txtCikisKodu.Text = k.CikisNo.ToString().PadLeft(7,'0');
                    txtCariAdi.Text = k.bgFirma.Fadi;
                    cbCturu.Text = k.Cturu;
                    dtpTarih.Text = k.Tarih.ToString();

                }
                
                Liste.ReadOnly = true;
                Liste.AllowUserToAddRows = false;
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
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

        private void Liste_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    int i;
                    i = Liste.CurrentRow.Index;
                    AnaSayfa.LotAktar = Liste.Rows[i].Cells[2].Value.ToString();
                    int id = _f.UrunCikisListesiLot(true);

                    if (id > 0)
                    {
                        LotKontrol = true;
                        LotAc(id);
                    }
                    AnaSayfa.Aktarma = -1;
                    AnaSayfa.LotAktar = "B";
                }
            }
            catch (Exception ex)
            {
                _m.Hata(ex);
            }
        }
        public void LotAc(int id)
        {
            try
            {
                var stok = _db.stStokDurums.First(x => x.Id == id);
                if (Liste.CurrentRow != null)
                {
                    Liste.CurrentRow.Cells[0].Value = stok.Id;
                    Liste.CurrentRow.Cells[2].Value = stok.UrunKodu;
                    Liste.CurrentRow.Cells[4].Value = stok.LotSeriNo;
                    Liste.CurrentRow.Cells[5].Value = stok.Aciklama;
                    Liste.CurrentRow.Cells[6].Value = stok.Adet;
                }
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }

        private void Liste_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txt = e.Control as TextBox;
            if (Liste.CurrentCell.ColumnIndex == 2 && txt != null)
            {
                txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txt.AutoCompleteCustomSource.AddRange(MyArray);
            }
            else if (Liste.CurrentCell.ColumnIndex != 2 && txt != null)
            {
                txt.AutoCompleteMode = AutoCompleteMode.None;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            YeniKaydet();
        }
    }
}
