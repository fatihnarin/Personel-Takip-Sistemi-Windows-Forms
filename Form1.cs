using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonelTakipSistemi.Models;

namespace PersonelTakipSistemi
{

    public partial class Form1 : Form
    {
        PDKSDbEntities db = new PDKSDbEntities();
       
        public Form1()
        {                        
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var result = (from ob1 in db.PersonelOzlukBilgileri
                          join ob2 in db.Departmanlar
                          on ob1.DepartmanId equals ob2.Id
                          join ob3 in db.PersonelEgitim
                          on ob1.Id equals ob3.PersonelId
                          select new
                          {
                              ob1.Id,
                              ob1.TcKimlik,
                              ob1.Ad,
                              ob1.Soyad,
                              ob1.Unvan,
                              ob1.KurumSicilNo,
                              ob1.CepTelefonu,
                              ob1.Eposta,
                              ob1.MedeniDurum,
                              ob1.Askerlik,
                              ob1.Ehliyet,
                              ob1.EngellilikDurumu,
                              ob2.DepartmanAdi,
                              ob1.DepartmanId,
                              ob1.DogumTarihi,
                              ob1.İseGirisTarihi,
                              ob1.AktifPasif,
                              ob1.CikisTarihi,
                              ob1.EsiTc,
                              ob1.EsiAdiSoyadi,
                              ob1.EsiTelefon,
                              ob1.EsiIsDurumu,                                                            
                              ob1.EvAdresi,                                              
                              ob3.EgitimBilgisi
                          }).ToList();

            tab1dataGridView1.DataSource = result;

        }

        private void tab1BtnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (tab1TextBoxTc.Text.Length == 11 && tab1TextBoxAd.Text.Length >= 2 && tab1TextBoxSoyad.Text.Length >= 2 &&
                tab1TextBoxUnvan.Text.Length >= 2 && tab1TextBoxSicilNo.Text.Length == 7 && tab1TextBoxCepTel.Text.Length == 11 &&
                tab1TextBoxEPosta.Text.Length >= 8 && tab1ComboboxMedeniDurum.Text != "" && tab1richTextBoxEvAdresi.Text.Length >= 20 &&
                tab1CombobaxAskerlik.Text != "" && tab1TextBoxEhliyet.Text != "" && tab1ComboboxEngelDurum.Text != "" &&
                tab1ComboboxDepartman.Text != "" && tab1dateTimePickerDogum.Value.Date != null && tab1dateTimePickerİsGiris.Value.Date != null &&
                tab1ComboboxDurum.Text != "")
                {
                    var durum = db.PersonelOzlukBilgileri.FirstOrDefault(x => x.TcKimlik == tab1TextBoxTc.Text);
                    if (durum == null)
                    {
                        Classes.PersonelOzluk.Ekle(tab1TextBoxTc.Text, tab1TextBoxAd.Text, tab1TextBoxSoyad.Text,
                   tab1TextBoxUnvan.Text, tab1TextBoxSicilNo.Text, tab1TextBoxCepTel.Text, tab1TextBoxEPosta.Text,
                   tab1ComboboxMedeniDurum.Text, tab1richTextBoxEvAdresi.Text,
                   tab1CombobaxAskerlik.Text, tab1TextBoxEhliyet.Text, tab1ComboboxEngelDurum.Text,
                   tab1ComboboxDepartman.Text, tab1dateTimePickerDogum.Value.Date, tab1dateTimePickerİsGiris.Value.Date,
                   tab1ComboboxDurum.Text, tab1dateTimePickerİsCikisTarihi.Value.Date, tab1TextBoxEsTc.Text,
                   tab1TextBoxEsAdSoyad.Text, tab1TextBoxEsTel.Text, tab1ComboboxEsDurum.Text, db);

                        tab1dataGridView1.DataSource = db.PersonelOzlukBilgileri.ToList();
                        MessageBox.Show(tab1TextBoxTc.Text, "TC kimlik numaralı personel kaydı veri tabanına kaydedildi");
                    }
                    else
                    {
                        MessageBox.Show(tab1TextBoxTc.Text, "TC kimlik numaralı personel kaydı zaten var");

                    }
                }
                else
                {
                    MessageBox.Show("Tüm alanların doldurunuz!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Veritabanıyla bağlantı kurulamadı!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
           
        }

        private void tab1ComboboxDepartman_MouseClick(object sender, MouseEventArgs e)
        {
            ((ComboBox)sender).Items.Clear();
            var oku = db.Departmanlar.ToList();
            foreach (var item in oku)
            {
                string a = item.DepartmanAdi;
                ((ComboBox)sender).Items.Add(a);
            }
        }

        private void tab1BtnTemizle_Click(object sender, EventArgs e)
        {
            Classes.PersonelOzluk.Temizle(tab1TextBoxTc, tab1TextBoxAd,tab1TextBoxSoyad,
                tab1TextBoxUnvan, tab1TextBoxSicilNo,tab1TextBoxCepTel, tab1TextBoxEPosta,tab1ComboboxMedeniDurum,
                tab1richTextBoxEvAdresi,tab1CombobaxAskerlik,tab1TextBoxEhliyet,tab1ComboboxEngelDurum,
                tab1ComboboxDepartman,tab1dateTimePickerDogum,tab1dateTimePickerİsGiris,
                tab1ComboboxDurum,tab1dateTimePickerİsCikisTarihi,tab1TextBoxEsTc,tab1TextBoxEsAdSoyad,
                tab1TextBoxEsTel,tab1ComboboxEsDurum);
        }

        private void tab1BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (tab1TextBoxTc.Text.Length == 11 && tab1TextBoxAd.Text.Length >= 2 && tab1TextBoxSoyad.Text.Length >= 2 &&
                tab1TextBoxUnvan.Text.Length >= 2 && tab1TextBoxSicilNo.Text.Length == 7 && tab1TextBoxCepTel.Text.Length == 11 &&
                tab1TextBoxEPosta.Text.Length >= 8 && tab1ComboboxMedeniDurum.Text != "" && tab1richTextBoxEvAdresi.Text.Length >= 20 &&
                tab1CombobaxAskerlik.Text != "" && tab1TextBoxEhliyet.Text != "" && tab1ComboboxEngelDurum.Text != "" &&
                tab1ComboboxDepartman.Text != "" && tab1dateTimePickerDogum.Value.Date != null && tab1dateTimePickerİsGiris.Value.Date != null &&
                tab1ComboboxDurum.Text != "")
                {
                    var durum = db.PersonelOzlukBilgileri.FirstOrDefault(x => x.TcKimlik == tab1TextBoxTc.Text);
                    if (durum != null)
                    {
                        Classes.PersonelOzluk.Guncelle(tab1TextBoxTc, tab1TextBoxAd, tab1TextBoxSoyad,
                tab1TextBoxUnvan, tab1TextBoxSicilNo, tab1TextBoxCepTel, tab1TextBoxEPosta, tab1ComboboxMedeniDurum,
                tab1richTextBoxEvAdresi, tab1CombobaxAskerlik, tab1TextBoxEhliyet, tab1ComboboxEngelDurum,
                tab1ComboboxDepartman, tab1dateTimePickerDogum, tab1dateTimePickerİsGiris,
                tab1ComboboxDurum, tab1dateTimePickerİsCikisTarihi, tab1TextBoxEsTc, tab1TextBoxEsAdSoyad,
                tab1TextBoxEsTel, tab1ComboboxEsDurum, durum,db);

                        tab1dataGridView1.DataSource = db.PersonelOzlukBilgileri.ToList();
                        MessageBox.Show(tab1TextBoxTc.Text, "TC kimlik numaralı personel kaydı Güncellendi");
                    }
                    else
                    {
                        MessageBox.Show(tab1TextBoxTc.Text, "TC kimlik numaralı personel kaydı yok!! Güncelleme Yapılamaz");
                        
                    }
                }
                else
                {
                    MessageBox.Show("Tüm alanların doldurunuz!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Veritabanıyla bağlantı kurulamadı!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void tab1BtnSec_Click(object sender, EventArgs e)
        {
            try
            {
                if (tab1dataGridView1.TabIndex > -1)
                {

                    Classes.PersonelOzluk.Sec(tab1TextBoxTc, tab1TextBoxAd, tab1TextBoxSoyad,
                tab1TextBoxUnvan, tab1TextBoxSicilNo, tab1TextBoxCepTel, tab1TextBoxEPosta, tab1ComboboxMedeniDurum,
                tab1richTextBoxEvAdresi, tab1CombobaxAskerlik, tab1TextBoxEhliyet, tab1ComboboxEngelDurum,
                tab1ComboboxDepartman, tab1dateTimePickerDogum, tab1dateTimePickerİsGiris,
                tab1ComboboxDurum, tab1dateTimePickerİsCikisTarihi, tab1TextBoxEsTc, tab1TextBoxEsAdSoyad,
                tab1TextBoxEsTel, tab1ComboboxEsDurum, tab1dataGridView1);

                   
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Bir hata ile karşılaşıldı!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }









        //***************LINQ İŞLEMLERİ****************
        private void tab1dataGridView1Linq_TextChanged(object sender, EventArgs e)
        {
            tab1dataGridView1.DataSource = db.PersonelOzlukBilgileri.Where(p => p.TcKimlik.Contains(tab1TextBoxLinqTc.Text) && p.Ad.Contains(tab1TextBoxLinqAd.Text) && p.Soyad.Contains(tab1TextBoxLinqSoyad.Text)).ToList();
        }

        private void tab1BtnSil_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Kayıtı Silmek İstediğinizden eminmisiniz", "Dikkat Kayıt Silinecek", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    var durum = db.PersonelOzlukBilgileri.FirstOrDefault(x => x.TcKimlik == tab1TextBoxTc.Text);
                    if (durum == null)
                    {
                        MessageBox.Show(tab1TextBoxTc.Text+"Tc kimlik numaralı personal bulunmamaktadır.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                    
                    else
                    {

                        db.PersonelOzlukBilgileri.Remove(durum);
                        db.SaveChanges();
                        MessageBox.Show(tab1TextBoxTc.Text + "Tc kimlik numaralı personel kaydı silindi.");
                        tab1dataGridView1.DataSource = db.PersonelOzlukBilgileri.ToList();
                    }
                }


            }
            catch (Exception)
            {

                MessageBox.Show("Veritabanıyla bağlantı kurulamadı!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
       
    }
}
