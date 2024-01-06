using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriYapilariUygulama
{
    internal class Ogrenci
    {
        //Öğrenci sınıfımız. GUI'den elde edilen bilgiler burada değer kazanacaktır.
        
        public string OgrenciIsim { get; set; }
        public string OgrenciSoyisim { get; set; }
        public string OgrenciNo { get; set; }
        public string OgrenciBolum { get; set; }

        public Ogrenci(string _ogrenciIsim, string _ogrenciSoyisim, string _ogrenciNo, string _ogrenciBolum)
        {
            OgrenciIsim = _ogrenciIsim;
            OgrenciSoyisim = _ogrenciSoyisim;
            OgrenciNo = _ogrenciNo;
            OgrenciBolum = _ogrenciBolum;
        }

        public override string ToString()
        {
            return $"Isim: {OgrenciIsim}\nSoyisim: {OgrenciSoyisim}\nOgrenci No: {OgrenciNo}\nOgrenci Bolum: {OgrenciBolum}";
        }
    }
}
