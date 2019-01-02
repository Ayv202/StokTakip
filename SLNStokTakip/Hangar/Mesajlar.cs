using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLNStokTakip.Hangar
{
    class Mesajlar
    {
        public void YeniKayit(string mesaj)
        {
            MessageBox.Show(mesaj, "Yeni Kayıt Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public DialogResult Guncelle()
        {
            return MessageBox.Show("Seçili olan kayıt güncellenecektir.\n Güncelleme işlemini onaylıyormusunuz?", "Güncelleme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public DialogResult Kayit()
        {
            return MessageBox.Show("Aynı kaydı tekrardan kaydetmek istediğinize emin misiniz?", "Kayıt Uyarısı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public DialogResult Sil()
        {
            return MessageBox.Show("Tüm kayıt kalıcı olarak silinecektir.\n Silme işlemini onaylıyormusunuz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public void Guncelle(bool guncelleme)
        {
            MessageBox.Show("Kayıt Güncellenmiştir.", "Kayıt Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Kayit(bool kayit)
        {
            MessageBox.Show("Aynı kayıt tekrardan kaydedilmiştir.", "Kayıt Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Hata(Exception hata)
        {
            MessageBox.Show(hata.Message, "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public DialogResult Bitti()
        {
            return MessageBox.Show("Ekrandaki kayıt rafa geri alınacaktır.\n Kaydı geri almayı onaylıyormusun?\n Not: Bu işlem geri alınamaz!!", "İşlem Bitirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public DialogResult Yazdir()
        {
            return MessageBox.Show(@"Kaydı yazdırmak istiyormusunuz?", @"Yazdırma İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

    }
}
