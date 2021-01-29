using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Otopark_Otomasyon
{
    class Arabalar
    {

        Veritabanı bag = new Veritabanı();
        MySqlCommand kmt = new MySqlCommand();
        public void araba_ekle(string plaka, string renk, string model, int yıl)
        {
            kmt.Connection = bag.baglan();

            kmt.CommandText = ((((("INSERT INTO araclar(arac_plaka,arac_renk,arac_model,arac_yil) VALUES ('" + plaka + "','") + renk + "','") + model + "','") + yıl + "')"));
            kmt.ExecuteNonQuery();
        }
        public void araba_guncelle(string plaka, string renk, string model, int yıl,int id)
        {
            kmt.Connection = bag.baglan();
            kmt.CommandText = "UPDATE araclar SET arac_plaka='" + plaka + "' , arac_renk='" + renk + "',arac_model='" + model  + "' where arac_id='" + id + "'";
            kmt.ExecuteNonQuery();
            kmt.Dispose();
        }
        public void arac_sil(int id)
        {
            kmt.Connection = bag.baglan();
            kmt.CommandText = "DELETE FROM araclar WHERE arac_id = '" + id + "'";
            kmt.ExecuteNonQuery();
        }
    }
}