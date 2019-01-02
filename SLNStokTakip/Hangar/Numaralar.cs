using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLNStokTakip.Hangar
{    
    class Numaralar
    {
        readonly DbStokDataContext _db = new DbStokDataContext();

        public string KulGenel()
        {
            try
            {
                var numara =(from s in _db.bgKullanicilars orderby s.Id descending select s).First().GenelNo;
                int a = int.Parse(numara);
                a++;
                string num = a.ToString().PadLeft(7, '0');
                return num;
            }
            catch (Exception)
            {
                return "0000001";
            }
        }

        public string FirNo()
        {
            try
            {
                var numara = (from s in _db.bgFirmas orderby s.Id descending select s).First().Fno;

                numara++;
                string num = numara.ToString().PadLeft(7, '0');
                return num;

            }
            catch (Exception)
            {
                return ("0000001");
            }
        }

        public string UrnNo()
        {
            try
            {
                var numara = (from s in _db.bgUrunGiris orderby s.Id descending select s).First().UrunNo;

                numara++;
                string num = numara.ToString().PadLeft(7, '0');
                return num;

            }
            catch (Exception)
            {
                return ("0000001");
            }
        }

        public string Genel()
        {
            try
            {
                var numara = (from s in _db.bgSiras
                              where s.Sadi == "GenelNo"
                              orderby s.Id descending
                              select s).First().Sno;
                numara++;
                string num = numara.ToString();
                return num;
            }
            catch (Exception)
            {
                return "1";
            }
        }

        public string GirisKod()
        {
            try
            {
                var numara = (from s in _db.stUrunKayitUsts orderby s.Id descending select s).First().GirisKod;

                numara++;
                string num = numara.ToString().PadLeft(7, '0');
                return num;

            }
            catch (Exception)
            {
                return ("0000001");
            }
        }

        public string UrunCikisKodu()
        {
            try
            {
                var numara = (from s in _db.stUrunCikis orderby s.Id descending select s).First().CikisNo;

                numara++;
                string num = numara.ToString().PadLeft(7, '0');
                return num;

            }
            catch (Exception)
            {
                return ("0000001");
            }
        }

        public string FaturaKayıtNo()
        {
            try
            {
                var numara = (from s in _db.ftFaturaKesUsts orderby s.Id descending select s).First().FKayitNo;

                numara++;
                string num = numara.ToString().PadLeft(7, '0');
                return num;

            }
            catch (Exception)
            {
                return ("0000001");
            }
        }
    }
}
