using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Otopark_Otomasyon
{
    class Veritabanı
    {
        public MySqlConnection baglan()
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=otopark;Uid=root;Pwd=;");

            baglanti.Open();
            MySqlConnection.ClearPool(baglanti);
            MySqlConnection.ClearAllPools();
            return (baglanti);

        }
    }
}
