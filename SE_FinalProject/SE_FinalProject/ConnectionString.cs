using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_FinalProject
{
    public class ConnectionString
    {
        static SqlConnection conn = new SqlConnection();
        public static void Connect()
        {
            string sql = "Data Source=(local)\\SQLEXPRESS;Database=MobilePhone;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn = new SqlConnection(sql);
            conn.Open();
        }

        public static void ActionQuery(string sql)
        {
            Connect();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

        public static DataTable SelectQuery(string sql)
        {
            Connect();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            if (adapter.Fill(dt) > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
    }
}
