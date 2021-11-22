using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AIS
{
    public class DBConnector
    {
        public void Connect()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\corse\\Database1.mdf;Integrated Security=True");
            sqlConnection.Open();
            var command = new SqlCommand("INSERT INTO Clients(Name) VALUES('Sam');", sqlConnection) ;
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
