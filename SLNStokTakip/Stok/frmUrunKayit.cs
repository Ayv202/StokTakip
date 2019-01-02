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
using SLNStokTakip.Bilgi;

namespace SLNStokTakip.Stok
{
    public partial class frmUrunKayit : Form
    {
        DbStokDataContext _db = new DbStokDataContext();
        Formlar _f = new Formlar();
        Numaralar _n = new Numaralar();
        Mesajlar _m = new Mesajlar();


        bool _edit = false;
        public string[] MyArray { get; set; } 

        public frmUrunKayit()
        {
            InitializeComponent();
        }

        private void frmUrunKayit_Load(object sender, EventArgs e)
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
            txtGirisKodu.Text = _n.GirisKod();
            AnaSayfa.Aktarma = -1;
            Genel();//lblGenelNo.Text = _n.Genel();
        }
        void Combo()
        {
            cbUrun.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection veri = new AutoCompleteStringCollection();
            var lst = _db.bgUrunGiris.Select(x => x.UrunKodu).Distinct();
            foreach(string urun in lst)
            {
                veri.Add(urun);
                cbUrun.Items.Add(urun);
            }
            cbUrun.AutoCompleteCustomSource = veri;

            int dgv;
            dgv = cbUrun.Items.Count;
            MyArray = new string[dgv];
            for(int p=0;p<dgv;p++)
            {
                MyArray[p] = cbUrun.Items[p].ToString();
            }

        }
        
        void YeniKaydet()
        {            
            
            Liste.AllowUserToAddRows = false;
            Genel();
            try
            {
                stUrunKayitUst ust = new stUrunKayitUst()
                {
                    Aciklama = txtAciklama.Text,
                    GenelNo = int.Parse(lblGenelNo.Text),
                    GirisKod = int.Parse(txtGirisKodu.Text),
                    FirmaId = txtCariAdi.Text != "" ? _db.bgFirmas.First(x => x.Fadi == txtCariAdi.Text).Fno : -1,
                    GirisTarih = DateTime.Parse(dtpTarih.Text),
                    FaturaNo=txtFaturaNo.Text,
                    saveDate = DateTime.Now,
                    saveUser = -1
                };

                //var a = _db.bgFirmas.First(x => x.Fadi == txtCariAdi.Text).Fno;
                //ust.FirmaId = a;
                _db.stUrunKayitUsts.InsertOnSubmit(ust);
                _db.SubmitChanges();

                stUrunKayitAlt[] alt = new stUrunKayitAlt[Liste.RowCount];
                stStokDurum[] drm = new stStokDurum[Liste.RowCount];
                for(int i=0;i<Liste.RowCount;i++)
                {
                    alt[i] = new stUrunKayitAlt
                    {
                        GenelNo = int.Parse(lblGenelNo.Text),
                        GirisKod= int.Parse(txtGirisKodu.Text),
                        UrunKodu = Liste.Rows[i].Cells["UrunKodu"].Value.ToString(),
                        Aciklama = Liste.Rows[i].Cells[1].Value.ToString(),
                        LotSeriNo = Liste.Rows[i].Cells[2].Value.ToString(),

                        Nott = Liste.Rows[i].Cells[3].Value != null ? Liste.Rows[i].Cells[3].Value.ToString() : "",


                        //Nott = Liste.Rows[i].Cells[3].Value.ToString(),
                        Adet =int.Parse(Liste.Rows[i].Cells[4].Value.ToString()),
                        Bfiyat=decimal.Parse(Liste.Rows[i].Cells[5].Value.ToString())
                    };
                    _db.stUrunKayitAlts.InsertOnSubmit(alt[i]);
                    _db.SubmitChanges();

                    drm[i] = new stStokDurum();
                    var srg = (from s in _db.stStokDurums
                               where s.UrunKodu == Liste.Rows[i].Cells[0].Value.ToString()
                               where s.LotSeriNo == Liste.Rows[i].Cells[2].Value.ToString()
                               select s).ToList();
                    if(srg.Count==0)
                    {
                        drm[i].UrunKodu = Liste.Rows[i].Cells[0].Value.ToString();
                        drm[i].LotSeriNo = Liste.Rows[i].Cells[2].Value.ToString();
                        drm[i].Adet = int.Parse(Liste.Rows[i].Cells[4].Value.ToString());
                        drm[i].Aciklama= Liste.Rows[i].Cells[1].Value.ToString();
                        _db.stStokDurums.InsertOnSubmit(drm[i]);
                        _db.SubmitChanges();
                    }
                    else
                    {
                        stStokDurum sd = _db.stStokDurums.First(x => x.UrunKodu == Liste.Rows[i].Cells[0].Value.ToString() && x.LotSeriNo == Liste.Rows[i].Cells[2].Value.ToString());
                        sd.Adet += int.Parse(Liste.Rows[i].Cells[4].Value.ToString());
                        _db.SubmitChanges();
                    }
                }
                bgSira sr = _db.bgSiras.First(x => x.Sadi == "GenelNo");
                sr.Sno = int.Parse(lblGenelNo.Text);
                _db.SubmitChanges();

                _m.YeniKayit("Yeni kayır oluşturulmuştur.");
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }

        public int Genel()
        {            
            try
            {
                var numara = (from s in _db.bgSiras
                              where s.Sadi == "GenelNo"
                              orderby s.Id descending
                              select s).First().Sno;
                numara++;
                int num = int.Parse(numara.ToString());
                lblGenelNo.Text = num.ToString();
                return num;                
            }
            catch (Exception)
            {
                lblGenelNo.Text = "1";
                return 1;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            var btngk = new Button();
            btngk.Size = new Size(25, txtGirisKodu.ClientSize.Height + 2);
            btngk.Location = new Point(txtGirisKodu.ClientSize.Width - btngk.Width, -1);
            btngk.Cursor = Cursors.Default;
            btngk.Image = SLNStokTakip.Properties.Resources.arrow_1176;
            txtGirisKodu.Controls.Add(btngk);
            SendMessage(txtGirisKodu.Handle, 0xd3, (IntPtr)2, (IntPtr)(btngk.Width << 16));
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
            btnCari.Click+= btnCari_Click;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private void btngk_Click(object sender,EventArgs e)
        {
            int id = _f.UrunKayitListe(true);
            if(id>0)
            {
                Ac(id);
            }
            AnaSayfa.Aktarma = -1;
        }

        private void btnCari_Click(object sender,EventArgs e)
        {
            int id = _f.FrmListe(true);
            if(id>0)
            {
                CariAc(id);
            }
            AnaSayfa.Aktarma = -1;
        }

        public void Ac(int id)
        {
            try
            {
                Liste.Rows.Clear();
                int i = 0;
                _edit = true;

                stUrunKayitUst ust = _db.stUrunKayitUsts.First(z => z.GirisKod == id);
                lblGenelNo.Text = ust.GenelNo.ToString();
                txtAciklama.Text = ust.Aciklama;
                txtCariAdi.Text = ust.bgFirma.Fadi;
                txtGirisKodu.Text = ust.GirisKod.ToString().PadLeft(7, '0');
                dtpTarih.Text = ust.GirisTarih.ToString();

                var srg = from s in _db.stUrunKayitAlts
                          where s.GenelNo == ust.GenelNo
                          select s;
                foreach (stUrunKayitAlt k in srg)
                {
                    Liste.Rows.Add();
                    Liste.Rows[i].Cells[0].Value = k.UrunKodu;
                    Liste.Rows[i].Cells[1].Value = k.Aciklama;
                    Liste.Rows[i].Cells[2].Value = k.LotSeriNo;
                    Liste.Rows[i].Cells[3].Value = k.Nott;
                    Liste.Rows[i].Cells[4].Value = k.Adet;
                    Liste.Rows[i].Cells[5].Value = k.Bfiyat;
                    i++;
                }
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
            Liste.ReadOnly = true;

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

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            YeniKaydet();
        }

        private void Liste_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                foreach (DataGridViewCell cell in Liste.SelectedCells)
                {
                    if (cell.Value != null)
                    {
                        try
                        {
                            var lst = (from s in _db.bgUrunGiris
                                       where s.UrunKodu == Liste.CurrentRow.Cells[0].Value.ToString()
                                       select s).First();
                            string ack = lst.UrunAciklama;

                            if (Liste.CurrentRow != null) Liste.CurrentRow.Cells[1].Value = ack;
                        }
                        catch (Exception ex)
                        {
                            _m.Hata(ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ürün kodu boş olmamalı.!!!");
                    }
                }
            }
        }

        private void Liste_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txt = e.Control as TextBox;
            if(Liste.CurrentCell.ColumnIndex==0 && txt !=null)
            {
                txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txt.AutoCompleteCustomSource.AddRange(MyArray);
            }
            else if(Liste.CurrentCell.ColumnIndex !=0 && txt!=null)
            {
                txt.AutoCompleteMode = AutoCompleteMode.None;
            }
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
    }
}
