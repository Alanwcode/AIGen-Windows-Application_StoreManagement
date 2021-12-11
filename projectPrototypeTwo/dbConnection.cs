using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace projectPrototypeTwo
{
    class dbConnection
    {
        string connectionString = "Data Source=DESKTOP-9PI6981;Integrated Security=True";
           // "Server=tcp:server-nibm-rar.database.windows.net,1433;Initial Catalog=dbMegaTech;Persist Security Info=False;User ID=ramesh_rukshan;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private SqlDataReader dr;

        public void setConnection()
        {
            con = new SqlConnection(connectionString);
        }
        public void openConnection()
        {
            con.Open();
        }
        public void closeConnection()
        {
            con.Close();
        }
        
    }
}
