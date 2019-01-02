using SLNStokTakip.Bilgi;
using System.Windows.Forms;
using SLNStokTakip.Stok;
using SLNStokTakip.Fatura;

namespace SLNStokTakip.Hangar
{
    class Formlar
    {
        #region Kullanıcı İşlemleri

        public void KulGiris()
        {
            frmKulGiris kg = new frmKulGiris();
            kg.MdiParent = Application.OpenForms["AnaSayfa"] as AnaSayfa;
            kg.WindowState = FormWindowState.Maximized;
            kg.Show();
        }
        public int KulListe(bool secim = false)
        {
            frmKulListe kl = new frmKulListe();
            if (secim)
            {
                kl.Secim = true;
                kl.ShowDialog();
            }
            else
            {
                kl.MdiParent = Form.ActiveForm;
                kl.Show();
            }
            return AnaSayfa.Aktarma;
        }
        public void KulTipi()
        {
            frmKulTipi kul = new frmKulTipi();
            kul.ShowDialog();
        }

        #endregion

        #region Firma İşlemleri
        public void FrmGir()
        {
            frmFirmaGiris frm = new frmFirmaGiris();
            frm.MdiParent = Form.ActiveForm; //Application.OpenForms["AnaSayfa"] as AnaSayfa;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();

        }
        public int FrmListe(bool secim = false)
        {
            frmFirmaListe fl = new frmFirmaListe();
            if (secim)//Eğer true ise ifadesidir.
            {
                fl.Secim = true;
                fl.ShowDialog();
            }
            else
            {
                fl.MdiParent = Form.ActiveForm;
                fl.Show();
            }
            return AnaSayfa.Aktarma;
        }
        #endregion

        #region Ürün Giriş İşlemleri
        public void UrnGir()
        {
            frmUrunGiris urn = new frmUrunGiris();
            urn.MdiParent = Form.ActiveForm; //Application.OpenForms["AnaSayfa"] as AnaSayfa;
            urn.WindowState = FormWindowState.Maximized;
            urn.Show();

        }
        public int UrnListe(bool secim = false)
        {
            frmUrunListe ul = new frmUrunListe();
            if (secim)//Eğer true ise ifadesidir.
            {
                ul.Secim = true;
                ul.ShowDialog();
            }
            else
            {
                ul.MdiParent = Form.ActiveForm;
                ul.Show();
            }
            return AnaSayfa.Aktarma;
        }
        #endregion

        #region Ürün Kayıt İşlemleri

        public void UrunKayit()
        {
            frmUrunKayit urn = new frmUrunKayit();
            urn.MdiParent = Form.ActiveForm; //Application.OpenForms["AnaSayfa"] as AnaSayfa;
            urn.WindowState = FormWindowState.Maximized;
            urn.Show();

        }
        public int UrunKayitListe(bool secim = false)
        {
            frmUrunKayitListe ul = new frmUrunKayitListe();
            if (secim)//Eğer true ise ifadesidir.
            {
                ul.Secim = true;
                ul.ShowDialog();
            }
            else
            {
                ul.MdiParent = Form.ActiveForm;
                ul.Show();
            }
            return AnaSayfa.Aktarma;
        }

        #endregion

        #region STOK DURUM
        public void stokDurum()
        {
            frmStokDurum stk = new frmStokDurum();
            stk.MdiParent = Form.ActiveForm; //Application.OpenForms["AnaSayfa"] as AnaSayfa;
            stk.WindowState = FormWindowState.Maximized;
            stk.Show();
        }
        #endregion

        #region Ürün Çıkış İşlemleri
        public void UrunCikis()
        {
            frmUrunCikis urn = new frmUrunCikis();
            urn.MdiParent = Form.ActiveForm; //Application.OpenForms["AnaSayfa"] as AnaSayfa;
            urn.WindowState = FormWindowState.Maximized;
            urn.Show();

        }
        public int UrunCikisListe(bool secim = false)
        {
            frmUrunCikisListe ucl = new frmUrunCikisListe();
            if (secim)//Eğer true ise ifadesidir.
            {
                ucl.Secim = true;
                ucl.ShowDialog();
            }
            else
            {
                ucl.MdiParent = Form.ActiveForm;
                ucl.Show();
            }
            return AnaSayfa.Aktarma;
        }

        public int UrunCikisListesiLot(bool secim=false)
        {
            frmLotBul flt = new frmLotBul();
            if(secim)
            {
                flt.Secim = true;
                flt.Lott = "UrunCikis";
                flt.ShowDialog();
            }
            else
            {
                flt.MdiParent = Form.ActiveForm;
                flt.Show();
            }
            return AnaSayfa.Aktarma;
        }
        #endregion

        #region FATURA İŞLEMLERİ
        public void FaturaCikis()
        {
            frmFaturaKes kes = new frmFaturaKes();
            kes.MdiParent = Form.ActiveForm; //Application.OpenForms["AnaSayfa"] as AnaSayfa;
            kes.WindowState = FormWindowState.Maximized;
            kes.Show();

        }
        public int FaturaKesListe(bool secim = false)
        {
            frmFaturaKesListe fkl = new frmFaturaKesListe();
            if (secim)//Eğer true ise ifadesidir.
            {
                fkl.Secim = true;
                fkl.ShowDialog();
            }
            else
            {
                fkl.MdiParent = Form.ActiveForm;
                fkl.Show();
            }
            return AnaSayfa.Aktarma;
        }

        public int UrunCikisBul(bool secim = false)
        {
            frmCikisBul fcb = new frmCikisBul();
            if (secim)
            {
                fcb.Secim = true;               
                fcb.ShowDialog();
            }
            else
            {
                fcb.MdiParent = Form.ActiveForm;
                fcb.Show();
            }
            return AnaSayfa.Aktarma;
        }
        #endregion
    }
}
