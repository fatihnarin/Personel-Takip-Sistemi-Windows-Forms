using PersonelTakipSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelTakipSistemi.Classes
{
    class PersonelOzluk
    {
        
        public static void Ekle(string Tc, string Ad, string Soyad, string unvan, string kurumsicilno,
           string ceptel, string eposta, string medenihal, string evadresi, string askerlik,
           string ehliyet, string engeldurum, string departman, DateTime dogum, DateTime isgiristarihi,
           string aktifpasif, DateTime cikistarih, string esitc, string esiadsoyad,
           string esitel, string esiisdurum, PDKSDbEntities db)
        {
            bool mdnhal;
            if (medenihal=="Evli")
                mdnhal = true;
            else
                mdnhal = false;
            var durum = db.Departmanlar.FirstOrDefault(x => x.DepartmanAdi == departman);

            bool drm;
            if (aktifpasif=="Aktif")
                drm = true;
            else
                drm = false;
            bool esdurum;
            if (esiisdurum=="Çalışıyor")
                esdurum = true;
            else
                esdurum = false;

            bool engldurum;
            if (engeldurum=="Var")
                engldurum = true;
            else           
                engldurum = false;


            PersonelOzlukBilgileri personelOzlukBilgileri = new PersonelOzlukBilgileri();

            personelOzlukBilgileri.TcKimlik = Tc;
            personelOzlukBilgileri.Ad = Ad;
            personelOzlukBilgileri.Soyad = Soyad;
            personelOzlukBilgileri.Unvan = unvan;
            personelOzlukBilgileri.KurumSicilNo = kurumsicilno;
            personelOzlukBilgileri.CepTelefonu = ceptel;
            personelOzlukBilgileri.Eposta = eposta;          
            personelOzlukBilgileri.MedeniDurum = mdnhal;
            personelOzlukBilgileri.EvAdresi = evadresi;
            personelOzlukBilgileri.Askerlik = askerlik;
            personelOzlukBilgileri.Ehliyet = ehliyet;
            personelOzlukBilgileri.DepartmanId = durum.Id;
            personelOzlukBilgileri.DogumTarihi = dogum;
            personelOzlukBilgileri.İseGirisTarihi = isgiristarihi;
            personelOzlukBilgileri.AktifPasif = drm;
            personelOzlukBilgileri.CikisTarihi = cikistarih;
            personelOzlukBilgileri.EsiTc = esitc;
            personelOzlukBilgileri.EsiAdiSoyadi = esiadsoyad;
            personelOzlukBilgileri.EsiIsDurumu = esdurum;
            personelOzlukBilgileri.EsiTelefon = esitel;
            personelOzlukBilgileri.EngellilikDurumu = engldurum;

            db.PersonelOzlukBilgileri.Add(personelOzlukBilgileri);
            db.SaveChanges();
        }
        public static void Temizle(TextBox tab1TextBoxTc, TextBox tab1TextBoxAd, TextBox tab1TextBoxSoyad, TextBox tab1TextBoxUnvan, TextBox tab1TextBoxSicilNo, TextBox tab1TextBoxCepTel, TextBox tab1TextBoxEPosta, ComboBox tab1ComboboxMedeniDurum, RichTextBox tab1richTextBoxEvAdresi, ComboBox tab1CombobaxAskerlik, TextBox tab1TextBoxEhliyet, ComboBox tab1ComboboxEngelDurum, ComboBox tab1ComboboxDepartman, DateTimePicker tab1dateTimePickerDogum, DateTimePicker tab1dateTimePickerİsGiris, ComboBox tab1ComboboxDurum, DateTimePicker tab1dateTimePickerİsCikisTarihi, TextBox tab1TextBoxEsTc, TextBox tab1TextBoxEsAdSoyad, TextBox tab1TextBoxEsTel, ComboBox tab1ComboboxEsDurum)
        {
            tab1TextBoxTc.Text = "";
            tab1TextBoxAd.Text = "";
            tab1TextBoxSoyad.Text = "";
            tab1TextBoxUnvan.Text = "";
            tab1TextBoxSoyad.Text = "";
            tab1TextBoxCepTel.Text = "";
            tab1TextBoxEPosta.Text = "";
            tab1ComboboxMedeniDurum.Text = "";
            tab1richTextBoxEvAdresi.Text = "";
            tab1CombobaxAskerlik.Text = "";
            tab1TextBoxEhliyet.Text = "";
            tab1ComboboxEngelDurum.Text = "";
            tab1ComboboxDepartman.Text = "";
            tab1dateTimePickerDogum.Value = DateTime.Today;
            tab1dateTimePickerİsGiris.Value = DateTime.Today;
            tab1ComboboxDurum.Text = "";
            tab1dateTimePickerİsCikisTarihi.Value = DateTime.Today;
            tab1TextBoxEsTc.Text = "";
            tab1TextBoxEsAdSoyad.Text = "";
            tab1TextBoxEsTel.Text = "";
            tab1ComboboxEsDurum.Text = "";
            tab1TextBoxSicilNo.Text = "";
        }

        public static void Guncelle(TextBox tab1TextBoxTc, TextBox tab1TextBoxAd,
            TextBox tab1TextBoxSoyad, TextBox tab1TextBoxUnvan, TextBox tab1TextBoxSicilNo, 
            TextBox tab1TextBoxCepTel, TextBox tab1TextBoxEPosta, ComboBox tab1ComboboxMedeniDurum,
            RichTextBox tab1richTextBoxEvAdresi, ComboBox tab1CombobaxAskerlik, TextBox tab1TextBoxEhliyet, 
            ComboBox tab1ComboboxEngelDurum, ComboBox tab1ComboboxDepartman, DateTimePicker tab1dateTimePickerDogum, 
            DateTimePicker tab1dateTimePickerİsGiris, ComboBox tab1ComboboxDurum, DateTimePicker tab1dateTimePickerİsCikisTarihi, 
            TextBox tab1TextBoxEsTc, TextBox tab1TextBoxEsAdSoyad, TextBox tab1TextBoxEsTel, 
            ComboBox tab1ComboboxEsDurum, PersonelOzlukBilgileri durum, PDKSDbEntities db)
        {
            durum.TcKimlik = tab1TextBoxTc.Text;
            durum.Ad = tab1TextBoxAd.Text;
            durum.Soyad = tab1TextBoxSoyad.Text;
            durum.Unvan = tab1TextBoxUnvan.Text;
            durum.KurumSicilNo = tab1TextBoxSicilNo.Text;
            durum.CepTelefonu = tab1TextBoxCepTel.Text;
            durum.Eposta = tab1TextBoxEPosta.Text;
            bool meddurum = false;
            if (tab1ComboboxMedeniDurum.Text == "Evli")
                meddurum = true;
            durum.MedeniDurum = meddurum;
            bool engdurum = false;
            if (tab1ComboboxEngelDurum.Text == "Var")
                engdurum = true;
            durum.EngellilikDurumu = engdurum;
            var durum1 = db.Departmanlar.FirstOrDefault(x => x.DepartmanAdi == tab1ComboboxDepartman.Text);
            durum.DepartmanId = durum1.Id;
            durum.DogumTarihi = tab1dateTimePickerDogum.Value.Date;
            durum.İseGirisTarihi = tab1dateTimePickerİsGiris.Value.Date;
            bool akpas = false;
            if (tab1ComboboxDurum.Text == "Aktif")
                akpas = true;
            durum.AktifPasif = akpas;
            durum.CikisTarihi = tab1dateTimePickerİsCikisTarihi.Value.Date;
            durum.EsiTc = tab1TextBoxEsTc.Text;
            durum.EsiAdiSoyadi = tab1TextBoxEsAdSoyad.Text;
            bool esdurum = false;
            if (tab1ComboboxEsDurum.Text == "Çalışıyor")
                esdurum = true;
            durum.EsiIsDurumu = esdurum;
            durum.EsiTelefon = tab1TextBoxEsTel.Text;
            durum.EvAdresi = tab1richTextBoxEvAdresi.Text;
            durum.Ehliyet = tab1TextBoxEhliyet.Text;
            durum.Askerlik = tab1CombobaxAskerlik.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleşme gercekleşti.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Sec(TextBox tab1TextBoxTc, TextBox tab1TextBoxAd, TextBox tab1TextBoxSoyad, TextBox tab1TextBoxUnvan, TextBox tab1TextBoxSicilNo, TextBox tab1TextBoxCepTel, TextBox tab1TextBoxEPosta, ComboBox tab1ComboboxMedeniDurum, RichTextBox tab1richTextBoxEvAdresi, ComboBox tab1CombobaxAskerlik, TextBox tab1TextBoxEhliyet, ComboBox tab1ComboboxEngelDurum, ComboBox tab1ComboboxDepartman, DateTimePicker tab1dateTimePickerDogum, DateTimePicker tab1dateTimePickerİsGiris, ComboBox tab1ComboboxDurum, DateTimePicker tab1dateTimePickerİsCikisTarihi, TextBox tab1TextBoxEsTc, TextBox tab1TextBoxEsAdSoyad, TextBox tab1TextBoxEsTel, ComboBox tab1ComboboxEsDurum, DataGridView tab1dataGridView1)
        {
            tab1TextBoxTc.Text=tab1dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tab1TextBoxAd.Text= tab1dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tab1TextBoxSoyad.Text= tab1dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tab1TextBoxUnvan.Text= tab1dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tab1TextBoxSicilNo.Text= tab1dataGridView1.CurrentRow.Cells[5].Value.ToString();
            tab1TextBoxCepTel.Text= tab1dataGridView1.CurrentRow.Cells[6].Value.ToString();
            tab1TextBoxEPosta.Text= tab1dataGridView1.CurrentRow.Cells[7].Value.ToString();
            tab1ComboboxMedeniDurum.Text= tab1dataGridView1.CurrentRow.Cells[8].Value.ToString();
            tab1richTextBoxEvAdresi.Text= tab1dataGridView1.CurrentRow.Cells[9].Value.ToString();
            tab1CombobaxAskerlik.Text= tab1dataGridView1.CurrentRow.Cells[10].Value.ToString();
            tab1TextBoxEhliyet.Text= tab1dataGridView1.CurrentRow.Cells[11].Value.ToString();
            tab1ComboboxEngelDurum.Text= tab1dataGridView1.CurrentRow.Cells[12].Value.ToString();
            tab1ComboboxDepartman.Text= tab1dataGridView1.CurrentRow.Cells[13].Value.ToString();
            tab1dateTimePickerDogum.Text= tab1dataGridView1.CurrentRow.Cells[14].Value.ToString();
            tab1dateTimePickerİsGiris.Text= tab1dataGridView1.CurrentRow.Cells[15].Value.ToString();
            tab1ComboboxDurum.Text= tab1dataGridView1.CurrentRow.Cells[16].Value.ToString();
           //tab1dateTimePickerİsCikisTarihi.Text= tab1dataGridView1.CurrentRow.Cells[17].Value.ToString();
           // tab1TextBoxEsTc.Text= tab1dataGridView1.CurrentRow.Cells[18].Value.ToString();
           // tab1TextBoxEsAdSoyad.Text= tab1dataGridView1.CurrentRow.Cells[19].Value.ToString();
           // tab1TextBoxEsTel.Text= tab1dataGridView1.CurrentRow.Cells[20].Value.ToString();
           // tab1ComboboxEsDurum.Text= tab1dataGridView1.CurrentRow.Cells[21].Value.ToString();


        }

    
    }
}
