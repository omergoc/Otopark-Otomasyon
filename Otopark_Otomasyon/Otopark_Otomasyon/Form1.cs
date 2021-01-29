using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Otopark_Otomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Veritabanı bag = new Veritabanı();
        MySqlCommand kmt = new MySqlCommand();
        DataTable tablo = new DataTable();
        DataTable tablo2 = new DataTable();
        DataTable tablo3 = new DataTable();
        DataTable tablo4 = new DataTable();
        Arabalar araba = new Arabalar();
        Musteriler musteri = new Musteriler();
        Abonelikler abone = new Abonelikler();
        Hizmetler hizmet = new Hizmetler();
        private void Form1_Load(object sender, EventArgs e)
        {
            Metotlarım();
        }

        private void Metotlarım()
        {
            araclar();
            musteriler();
            aboneler();
            hizmet_araba_liste();
            hizmet_musteri_liste();
            hizmet_abone_liste();
            hizmetler();
        }
        private void aracekle_Click_1(object sender, EventArgs e)
        {
            if(arac_plaka.Text=="" || arac_renk.Text=="" || arac_model.Text == "" || arac_yıl.Text =="")
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz.");
            }
            else
            {
                string plaka = arac_plaka.Text;
                string renk = arac_renk.Text;
                string model = arac_model.Text;
                int yıl = Convert.ToInt32(arac_yıl.Text);

                araba.araba_ekle(plaka, renk, model, yıl);
                Metotlarım();
                temizle();
                MessageBox.Show("Araç Eklendi İşlem Başarılı");
            }
        }

        private void aracguncelle_Click(object sender, EventArgs e)
        {
            if(arac_id.Text=="")
            {
                MessageBox.Show("Lütfen Araç Seçiniz !!!");
            }
            else
            {
                int id = Convert.ToInt32(arac_id.Text);
                string plaka = arac_plaka.Text;
                string renk = arac_renk.Text;
                string model = arac_model.Text;
                int yıl = Convert.ToInt32(arac_yıl.Text);
                araba.araba_guncelle(plaka, renk, model, yıl, id);
                Metotlarım();
                temizle();
                MessageBox.Show("Araç Güncellendi İşlem Başarılı");
            }
        }
        private void araclar()
        {
            tablo.Clear();
            MySqlDataAdapter adtr = new MySqlDataAdapter("Select * from araclar", bag.baglan());
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns[0].Visible = true;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void aractemızle_Click(object sender, EventArgs e)
        {
            temizle();
            MessageBox.Show("Araç Alanları Temizlendi İşlem Başarılı");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            arac_id.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            arac_plaka.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            arac_renk.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            arac_model.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            arac_yıl.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
        }

        private void aracsıl_Click(object sender, EventArgs e)
        {

            if(arac_id.Text=="")
            {
                MessageBox.Show("Lütfen Araç Seçiniz !!!");
            }
            else
            {
                int id = Convert.ToInt32(arac_id.Text);
                araba.arac_sil(id);
                Metotlarım();
                temizle();
                MessageBox.Show("Araç Silindi İşlem Başarılı");
            }
        }
        private void musteriler()
        {
            tablo2.Clear();
            MySqlDataAdapter adtr = new MySqlDataAdapter("Select * from musteriler", bag.baglan());
            adtr.Fill(tablo2);
            dataGridView2.DataSource = tablo2;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.Columns[0].Visible = true;
            dataGridView2.MultiSelect = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void musteri_temizle_Click(object sender, EventArgs e)
        {
            temizle();
            MessageBox.Show("Musteri Alanları Temizlendi İşlem Başarılı");
        }

        private void musteri_ekle_Click(object sender, EventArgs e)
        {
            if(musteri_adsoyad.Text == "" || musteri_telefon.Text == "" || musteri_adres.Text=="")
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz.");
            }
            else
            {
                string adsoyad = musteri_adsoyad.Text;
                string telefon = musteri_telefon.Text;
                string adres = musteri_adres.Text;
                musteri.musteri_ekle(adsoyad, telefon, adres);
                Metotlarım();
                temizle();
                MessageBox.Show("Musteri Eklendi İşlem Başarılı");
            }
        }

        private void musteri_guncelle_Click(object sender, EventArgs e)
        {
            if(musteri_id.Text=="")
            {
                MessageBox.Show("Lütfen Müşteri Seçiniz !!!");
            }
            else
            {
                int id = Convert.ToInt32(musteri_id.Text);
                string adsoyad = musteri_adsoyad.Text;
                string telefon = musteri_telefon.Text;
                string adres = musteri_adres.Text;
                musteri.musteri_guncelle(adsoyad, telefon, adres, id);
                Metotlarım();
                temizle();
                MessageBox.Show("Musteri Guncellendi İşlem Başarılı");
            }
        }

        private void musteri_sil_Click(object sender, EventArgs e)
        {
            if (musteri_id.Text == "")
            {
                MessageBox.Show("Lütfen Muşteri Seçiniz !!!");
            }
            else
            {
                int id = Convert.ToInt32(musteri_id.Text);
                musteri.musteri_sil(id);
                Metotlarım();
                temizle();
                MessageBox.Show("Musteri Silindi İşlem Başarılı");
            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            musteri_id.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            musteri_adsoyad.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
            musteri_telefon.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
            musteri_adres.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
        }
        private void aboneler()
        {
            tablo3.Clear();
            MySqlDataAdapter adtr = new MySqlDataAdapter("Select * from aboneler", bag.baglan());
            adtr.Fill(tablo3);
            dataGridView4.DataSource = tablo3;
            dataGridView4.RowHeadersVisible = false;
            dataGridView4.Columns[0].Visible = true;
            dataGridView4.MultiSelect = false;
            dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView4.SelectedCells[0].RowIndex;
            abone_id.Text = dataGridView4.Rows[secilen].Cells[0].Value.ToString();
            abonelik_tip.Text = dataGridView4.Rows[secilen].Cells[1].Value.ToString();
            abonelik_sure.Text = dataGridView4.Rows[secilen].Cells[2].Value.ToString();
            abone_baslangic.Text = dataGridView4.Rows[secilen].Cells[3].Value.ToString();
            abone_bitis.Text = dataGridView4.Rows[secilen].Cells[4].Value.ToString();
            abone_ucret.Text = dataGridView4.Rows[secilen].Cells[5].Value.ToString();
        }

        private void abone_ekle_Click(object sender, EventArgs e)
        {
            if(abonelik_tip.Text == "" || abonelik_sure.Text == "" || abone_baslangic.Text== "" || abone_bitis.Text == "" || abone_ucret.Text== "")
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz.");
            }
            else
            {
                string abonetip = abonelik_tip.Text;
                string abonesure = abonelik_sure.Text;
                string abonebas = abone_baslangic.Value.ToString();
                string abonebitis = abone_bitis.Value.ToString();
                int aboneucret = Convert.ToInt32(abone_ucret.Text);
                abone.abone_ekle(abonetip, abonesure, abonebas, abonebitis, aboneucret);
                Metotlarım();
                temizle();
                MessageBox.Show("Abonelik Eklendi İşlem Başarılı");
            }
        }

        private void abone_temizle_Click(object sender, EventArgs e)
        {
            temizle();
            MessageBox.Show("Abonelik Alanları Temizlendi İşlem Başarılı");
        }

        private void abone_guncelle_Click(object sender, EventArgs e)
        {
            if(abone_id.Text=="")
            {
                MessageBox.Show("Lütfen Abonelik Seçiniz !!!");
            }
            else
            {
                string abonetip = abonelik_tip.Text;
                string abonesure = abonelik_sure.Text;
                string abonebas = abone_baslangic.Value.ToString();
                string abonebitis = abone_bitis.Value.ToString();
                int aboneucret = Convert.ToInt32(abone_ucret.Text);
                int aboneid = Convert.ToInt32(abone_id.Text);
                abone.abone_guncelle(abonetip, abonesure, abonebas, abonebitis, aboneucret, aboneid);
                Metotlarım();
                temizle();
                MessageBox.Show("Abonelik Güncellendi İşlem Başarılı");
            }
        }

        private void abone_sil_Click(object sender, EventArgs e)
        {
            if (abone_id.Text == "")
            {
                MessageBox.Show("Lütfen Abonelik Seçiniz !!!");
            }
            else
            {
                int aboneid = Convert.ToInt32(abone_id.Text);
                abone.abone_sil(aboneid);
                Metotlarım();
                temizle();
                MessageBox.Show("Abonelik Silindi İşlem Başarılı");
            }

        }
        void hizmet_araba_liste()
        {
                string sorgu = "Select * from araclar";
                MySqlCommand komut = new MySqlCommand(sorgu, bag.baglan());
                MySqlDataReader liste = komut.ExecuteReader();
                while (liste.Read())
                {
                    string arac_plaka = liste.GetString("arac_plaka");
                    hizmet_arac.Items.Add(arac_plaka);
                }

        }
        void hizmet_musteri_liste()
        {
            string sorgu = "Select * from musteriler";
            MySqlCommand komut = new MySqlCommand(sorgu, bag.baglan());
            MySqlDataReader liste = komut.ExecuteReader();
            while (liste.Read())
            {
                string musteri = liste.GetString("musteri_ad_soyad");
                hizmet_musteri.Items.Add(musteri);
            }

        }
        void hizmet_abone_liste()
        {
            string sorgu = "Select * from aboneler";
            MySqlCommand komut = new MySqlCommand(sorgu, bag.baglan());
            MySqlDataReader liste = komut.ExecuteReader();
            while (liste.Read())
            {
                string abone = liste.GetString("abone_tip");
                hizmet_abone.Items.Add(abone);
            }

        }
        private void hizmetler()
        {
            tablo4.Clear();
            MySqlDataAdapter adtr = new MySqlDataAdapter("Select * from hizmetler", bag.baglan());
            adtr.Fill(tablo4);
            dataGridView3.DataSource = tablo4;
            dataGridView3.RowHeadersVisible = false;
            dataGridView3.Columns[0].Visible = true;
            dataGridView3.MultiSelect = false;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void hizmet_temizle_Click(object sender, EventArgs e)
        {
            temizle();
            MessageBox.Show("Hizmet Alanları Başarılı İle Temizlendi");
        }

        private void hizmet_ekle_Click(object sender, EventArgs e)
        {
            if(hizmet_musteri.Text=="" || hizmet_arac.Text == "" || hizmet_giris.Text== "" || hizmet_ucret.Text == "" || hizmet_abone.Text == "")
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz !!!");
            }
            else
            {
                string hizmetmusteri = hizmet_musteri.Text;
                string hizmetarac = hizmet_arac.Text;
                string hizmetbaslangic = hizmet_giris.Text;
                string hizmetbitis = hizmet_bitis.Text;
                int hizmetucret = Convert.ToInt32(hizmet_ucret.Text);
                string hizmetabonelik = hizmet_abone.Text;
                hizmet.hizmet_ekle(hizmetmusteri, hizmetarac, hizmetbaslangic, hizmetbitis, hizmetucret, hizmetabonelik);
                Metotlarım();
                temizle();
                MessageBox.Show("Hizmet Eklendi İşlem Başarılı");
            }

        }

        private void hizmet_guncelle_Click(object sender, EventArgs e)
        {
            if(hizmet_id.Text=="")
            {
                MessageBox.Show("Lütfen Hizmet Seçiniz !!!");
            }
            else
            {
                string hizmetmusteri = hizmet_musteri.Text;
                string hizmetarac = hizmet_arac.Text;
                string hizmetbaslangic = hizmet_giris.Text;
                string hizmetbitis = hizmet_bitis.Text;
                int hizmetucret = Convert.ToInt32(hizmet_ucret.Text);
                string hizmetabonelik = hizmet_abone.Text;
                int hizmetid = Convert.ToInt32(hizmet_id.Text);

                hizmet.hizmet_guncelle(hizmetmusteri, hizmetarac, hizmetbaslangic, hizmetbitis, hizmetucret, hizmetabonelik, hizmetid);
                Metotlarım();
                temizle();
                MessageBox.Show("Hizmet Güncellendi İşlem Başarılı");
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView3.SelectedCells[0].RowIndex;
            hizmet_id.Text = dataGridView3.Rows[secilen].Cells[0].Value.ToString();
            hizmet_musteri.Text = dataGridView3.Rows[secilen].Cells[1].Value.ToString();
            hizmet_arac.Text = dataGridView3.Rows[secilen].Cells[2].Value.ToString();
            hizmet_giris.Text = dataGridView3.Rows[secilen].Cells[3].Value.ToString();
            hizmet_bitis.Text = dataGridView3.Rows[secilen].Cells[4].Value.ToString();
            hizmet_ucret.Text = dataGridView3.Rows[secilen].Cells[5].Value.ToString();
            hizmet_abone.Text = dataGridView3.Rows[secilen].Cells[6].Value.ToString();
        }

        private void hizmet_sil_Click(object sender, EventArgs e)
        {
            if (hizmet_id.Text == "")
            {
                MessageBox.Show("Lütfen Hizmet Seçiniz !!!");
            }
            else
            {
                int hizmetid = Convert.ToInt32(hizmet_id.Text);
                hizmet.hizmet_sil(hizmetid);
                Metotlarım();
                temizle();
            }
        }
        private void temizle()
        {
            arac_id.Text = "";
            arac_plaka.Text = "";
            arac_model.Text = "";
            arac_renk.Text = "";
            arac_yıl.Text = "";
            musteri_id.Text = "";
            musteri_adsoyad.Text = "";
            musteri_telefon.Text = "";
            musteri_adres.Text = "";
            abone_id.Text = "";
            abonelik_tip.Text = "";
            abonelik_sure.Text = "";
            abone_baslangic.Text = "";
            abone_bitis.Text = "";
            abone_ucret.Text = "";
            hizmet_musteri.Text = "";
            hizmet_arac.Text = "";
            hizmet_giris.Text = "";
            hizmet_bitis.Text = "";
            hizmet_ucret.Text = "";
            hizmet_abone.Text = "";
        }
    }
}
