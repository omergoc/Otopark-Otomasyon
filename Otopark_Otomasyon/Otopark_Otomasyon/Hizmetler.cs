using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Otopark_Otomasyon
{
    class Hizmetler
    {
        Veritabanı bag = new Veritabanı();
        MySqlCommand kmt = new MySqlCommand();

        public void hizmet_ekle(string musteri,string arac,string baslangic,string bitis,int ucret,string abonelik)
        {
            kmt.Connection = bag.baglan();

            kmt.CommandText = ((((("INSERT INTO hizmetler(hizmet_musteri,hizmet_arac,hizmet_baslangic,hizmet_bitis,hizmet_ucret,hizmet_abonelik) VALUES ('" + musteri + "','") + arac + "','") + baslangic + "','") + bitis + "','") + ucret + "','") + abonelik + "')";
            kmt.ExecuteNonQuery();
        }
        public void hizmet_guncelle(string musteri, string arac, string baslangic, string bitis, int ucret, string abonelik,int id)
        {
            kmt.Connection = bag.baglan();
            kmt.CommandText = "UPDATE hizmetler SET hizmet_musteri='" + musteri + "' , hizmet_arac='" + arac + "', hizmet_baslangic='" + baslangic + "' , hizmet_bitis='" + bitis + "' , hizmet_ucret='" + ucret + "' , hizmet_abonelik='" + abonelik + "' where hizmet_id='" + id + "'";
            kmt.ExecuteNonQuery();
            kmt.Dispose();
        }
        public void hizmet_sil(int id)
        {
            kmt.Connection = bag.baglan();
            kmt.CommandText = "DELETE FROM hizmetler WHERE hizmet_id = '" + id + "'";
            kmt.ExecuteNonQuery();
        }
    }
}
