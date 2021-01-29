using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Otopark_Otomasyon
{
    class Abonelikler
    {
        Veritabanı bag = new Veritabanı();
        MySqlCommand kmt = new MySqlCommand();

        public void abone_ekle(string abonetip,string abonesure,string abonebas,string abonebitis,int aboneucret)
        {
            kmt.Connection = bag.baglan();

            kmt.CommandText = ((((("INSERT INTO aboneler(abone_tip,abone_sure,abone_bas_tarihi,abone_bitis_tarih,abonelik_ucret) VALUES ('" + abonetip + "','") + abonesure + "','") + abonebas + "','") + abonebitis + "','") + aboneucret + "')");
            kmt.ExecuteNonQuery();
        }
        public void abone_guncelle(string abonetip, string abonesure, string abonebas, string abonebitis, int aboneucret,int id)
        {
            kmt.Connection = bag.baglan();
            kmt.CommandText = "UPDATE aboneler SET abone_tip='" + abonetip + "' , abone_sure='" + abonesure + "',abone_bas_tarihi='" + abonebas + "' , abone_bitis_tarih='" + abonebitis + "' , abonelik_ucret='" + aboneucret + "' where abone_id='" + id + "'";
            kmt.ExecuteNonQuery();
            kmt.Dispose();
        }
        public void abone_sil(int id)
        {
            kmt.Connection = bag.baglan();
            kmt.CommandText = "DELETE FROM aboneler WHERE abone_id = '" + id + "'";
            kmt.ExecuteNonQuery();
        }
    }
}
