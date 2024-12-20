using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling_System.Classes
{
    internal class DBConnection
    {
        public static MySqlConnection conn { get; set; }

        //Connect to Database
        public static void ConnectToDb()
        {
            conn = null;
            string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            
            try
            {
                conn = new MySqlConnection(constr);
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Disconnect from Database
        public static void DisConnFromDb()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                }
                conn = null;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
