using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Otopark_Otomasyon
{
    class Musteriler
    {
        Veritabanı bag = new Veritabanı();
        MySqlCommand kmt = new MySqlCommand();

        public void musteri_ekle(string adsoyad,string telefon,string adres)
        {
            kmt.Connection = bag.baglan();

            kmt.CommandText = ((((("INSERT INTO musteriler(musteri_ad_soyad,musteri_tel_no,musteri_adres) VALUES ('" + adsoyad + "','") + telefon + "','") + adres + "')"))); 
            kmt.ExecuteNonQuery();
        }
        public void musteri_guncelle(string adsoyad,string telefon,string adres,int id )
        {
            kmt.Connection = bag.baglan();
            kmt.CommandText = "UPDATE musteriler SET musteri_ad_soyad='" + adsoyad + "' , musteri_tel_no='" + telefon + "',musteri_adres='" + adres + "' where musteri_id='" + id + "'";
            kmt.ExecuteNonQuery();
            kmt.Dispose();
        }
        public void musteri_sil(int id)
        {
            kmt.Connection = bag.baglan();
            kmt.CommandText = "DELETE FROM musteriler WHERE musteri_id = '" + id + "'";
            kmt.ExecuteNonQuery();
        }

    }
}
