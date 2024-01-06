using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriYapilariUygulama
{
    internal class BagliListe
    {
        // Bağlı liste sınıfı. Öğrenciler bağlı listeler ile birbirine bağlanacaktır.
        public Node head;
        public Node last;
        public BagliListe()
        {
            head = null;
            last = null;
        }

        public void Ekle(Ogrenci ogrenci)
        {
            Node ogr = new Node(ogrenci);
            if (head == null)
                head = last = ogr;

            else
            {
                last.next = ogr;
                ogr.prev = last;
                last = ogr;
                last.next = null;
            }
        }
        public bool Sil(string isim)
        {
            Node temp = head;
            Node temp2 = temp;
            if (temp.ogrenci.OgrenciIsim.ToLower() == isim)
            {
                temp = temp.next;
                temp.prev = null;
                return true;
            }
            if (temp != null)
            {
                while (temp.next != null)
                {
                    if (temp.ogrenci.OgrenciIsim.ToLower() == isim)
                    {
                        temp2.next = temp.next;
                        temp.next.prev = temp2;
                        return true;
                    }
                    temp2 = temp;
                    temp = temp.next;
                }
                temp2.next = null;
                return true;
            }
            return false;
        }
        public void Guncelle(string isim, Ogrenci yeniOgrenci)
        {
            Node yeniOgr = new Node(yeniOgrenci);
            Node temp = head;
            Node temp2 = temp;
            if (temp != null)
            {
                while (temp.next != null)
                {

                    if (temp.ogrenci.OgrenciIsim.ToLower() == isim)
                    {
                        temp2.next = yeniOgr;
                        yeniOgr.prev = temp2;
                        yeniOgr.next = temp.next;
                        temp.next.prev = yeniOgr;
                        break;
                    }
                    temp2 = temp;
                    temp = temp.next;
                }
                temp2.next = yeniOgr;
                yeniOgr.prev = temp2;
            }
        }
        public string Ara(string isim)
        {
            Node temp = head;
            while (temp != null)
            {
                if (temp.ogrenci.OgrenciIsim.ToLower() == isim)
                {
                    return temp.ogrenci.ToString();
                }
                temp = temp.next;
            }
            return "Öğrenci bulunamadı!";
        }
        public string KayitliOgrencileriGoster()
        {
            Node temp = head;
            string ogrenciler = "Öğrenci yok!";
            if (temp != null)
            {
                ogrenciler = "";
                while (temp != null)
                {

                    ogrenciler += temp.ogrenci.OgrenciIsim + "\n";
                    temp = temp.next;
                }
            }
            return ogrenciler;
        }
        public Ogrenci OgrenciyiGetir(string isim)
        {
            Node temp = head;
            if (temp != null)
            {
                while (temp != null)
                {
                    if (temp.ogrenci.OgrenciIsim == isim)
                    {
                        return temp.ogrenci;
                    }
                    temp = temp.next;
                }
            }
            return new Ogrenci("", "", "", "");
        }

    }
}
