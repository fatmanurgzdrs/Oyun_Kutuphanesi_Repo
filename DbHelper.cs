using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oyunKutuphanesi047
{
    public static class DbHelper
    {
        private static string connectionString = "Data Source=MELODY\\SQLEXPRESS;Initial Catalog=oyunKutuphanesi047;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public static SqlConnection Baglanti()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
