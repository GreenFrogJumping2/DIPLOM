using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace DIPLOM
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public class DBController
        {
            public static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\'|DataDirectory|Database1.mdf\';Integrated Security=True";
            public static SqlConnection conn = new SqlConnection(connectionString);

            public static DataTable SelectQuery(string SQL)
            {
                conn.Close();
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(SQL, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                conn.Close();
                return dt;
            }

            public static SqlDataReader ReaderQuery(string SQL)
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }

            public static void Query(string SQL)
            {
                conn.Close();
                conn.Open();
                SqlCommand command = new SqlCommand(SQL, conn);
                SqlDataReader reader = command.ExecuteReader();
                conn.Close();
            }

            public static string ConvertToNumeric(string str)
            {
                return str.Replace(',', '.');
            }
        }
    }
}
