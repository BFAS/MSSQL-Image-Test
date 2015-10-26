using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSQLImageTest
{
    public class DbConnections
    {
        public static SqlConnection GetSqlConnection()
        {
            return
                new SqlConnection(
                    @"Data Source=PACSLAP12;Initial Catalog=dbSQLFile;Integrated Security=True");
        }
    }
}
