using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriYapilariUygulama
{
    public partial class Form1 : Form
    {
        private static BagliListe listem = new BagliListe();
        //Tüm öğrencilerin kaydedildiği liste.
        public Form1()
        {

            InitializeComponent();
        }
        public static void ogrenciEkle()
        {
            listem.Ekle(new Ogrenci("Ali", "Kaya", "2233567561", "Tıp"));
            listem.Ekle(new Ogrenci("Lionel", "Messi", "1923456213", "Antrenörlük"));
            listem.Ekle(new Ogrenci("Kemal", "Merzifonluoğlu", "2356040349", "Din Kültürü Öğretmenliği"));
            listem.Ekle(new Ogrenci("Hazal", "Cemaydın", "1808075670", "Veterinerlik"));
            listem.Ekle(new Ogrenci("Halime", "Ferah", "1564457610", "Makine Mühendisliği"));
            listem.Ekle(new Ogrenci("Ayşe", "Kazma", "1727375430", "Diş Hekimliği"));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ogrenciEkle();
            panel_arananIsimPaneli.Visible = false;
            panel_yeniKayitPaneli.Visible = false;
        }

        private void button_cikis_Click(object sender, EventArgs e)
        {//Ekran kapatma butonu.
            this.Close();
        }

        private void button_ekle_Click(object sender, EventArgs e)
        {//Öğrenci ekleme butonu.

            string isim = textBox_isim.Text;
            string soyisim = textBox_soyisim.Text;
            string ogrNo = textBox_ogrenciNo.Text;
            string bolum = textBox_bolum.Text;
            Ogrenci ogr = new Ogrenci(isim, soyisim, ogrNo, bolum);
            listem.Ekle(ogr);
            MessageBox.Show("Ogrenci basariyla kaydedildi.", caption: "Kayıt etme", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);

            textBox_isim.Text = string.Empty;
            textBox_soyisim.Text = string.Empty;
            textBox_ogrenciNo.Text = string.Empty;
            textBox_bolum.Text = string.Empty;

        }

        private void button_ara_Click(object sender, EventArgs e)
        {
            panel_arananIsimPaneli.Visible = true;
        }

        private void button_ogrAra_Click(object sender, EventArgs e)
        {
            //Ara butonuna tıklandıktan sonraki aranan öğrencinin ismini elde edip aramaya başladığımız kısım.
            //

            string aranan_isim = textBox_arananIsim.Text;
            groupBox_bilgiler.Text = "\n" + listem.Ara(aranan_isim.ToLower());
            textBox_arananIsim.Text = string.Empty;
            panel_arananIsimPaneli.Visible = false;
        }

        private void button_kayitli_ogr_goster_Click(object sender, EventArgs e)
        {
            groupBox_bilgiler.Text = "\nKayıtlı öğrenci isimleri:\n" + listem.KayitliOgrencileriGoster();
        }

        private void button_guncelle_Click(object sender, EventArgs e)
        {
            //Kayıt güncellemeyi hazırlar.
            panel_arananIsimPaneli.Visible = true;
            panel_yeniKayitPaneli.Visible = true;
            button_ogrAra.Visible = false;
        }

        private void button_KayitGuncelle_Click(object sender, EventArgs e)
        {
            //Kayıt güncelleme kısmından sonra kullanıcı değerlerini elde edip bilgileri güncellediğimiz kısım.

            Ogrenci eskiOgrenciBilgileri = listem.OgrenciyiGetir(textBox_yeniIsim.Text);
            string aranan_isim = textBox_arananIsim.Text;


            string yeni_isim = textBox_yeniIsim.Text == "" ? eskiOgrenciBilgileri.OgrenciIsim : textBox_yeniIsim.Text;
            string yeni_soyisim = textBox_yeniSoyisim.Text == "" ? eskiOgrenciBilgileri.OgrenciSoyisim : textBox_yeniSoyisim.Text;
            string yeni_numara = textBox_yeniNo.Text == "" ? eskiOgrenciBilgileri.OgrenciNo : textBox_yeniNo.Text;
            string yeni_bolum = textBox_yeniBolum.Text == "" ? eskiOgrenciBilgileri.OgrenciBolum : textBox_yeniBolum.Text;
            Ogrenci guncellenecek_ogr = new Ogrenci(yeni_isim, yeni_soyisim, yeni_numara, yeni_bolum);
            listem.Guncelle(aranan_isim.ToLower(), guncellenecek_ogr);
            MessageBox.Show($"{aranan_isim} eski adlı, {yeni_isim} yeni adlı öğrencinin bilgileri değiştirildi.");

            //Gereksiz araçlarımızı görünmez kılıyor ve bazılarının metin kısmını boş bırakıyoruz.
            foreach (Control item in panel_arananIsimPaneli.Controls)
            {
                if (item is TextBox)
                    item.Text = string.Empty;
            }
            foreach (Control item in panel_yeniKayitPaneli.Controls)
            {
                if (item is TextBox)
                    item.Text = string.Empty;

            }
            panel_arananIsimPaneli.Visible = false;
            panel_yeniKayitPaneli.Visible = false;
            button_ogrAra.Visible = true;
        }

        private void button_sil_Click(object sender, EventArgs e)
        {
            //Ara butonunu gizleyip sil butonunu görünür kıldık.
            button_ikinciSil.Visible = true;
            button_ogrAra.Visible = false;
            
            
            panel_arananIsimPaneli.Visible = true;
            panel_yeniKayitPaneli.Visible = false;
            
        }

        private void button_ikinciSil_Click(object sender, EventArgs e)
        {
           bool kontrol= listem.Sil(textBox_arananIsim.Text.ToLower());
            if (kontrol)
            {
                MessageBox.Show(text: "Öğrenci kaydı silindi.",caption:"Silme İşlemi",buttons:MessageBoxButtons.OK,icon:MessageBoxIcon.Information);
            }
            else
                MessageBox.Show(text:"Öğrenci kaydı bulunamadı!",caption:"Silme işlemi",buttons:MessageBoxButtons.OK,icon:MessageBoxIcon.Error);
        }
    }
}
