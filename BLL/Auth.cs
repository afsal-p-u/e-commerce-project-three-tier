using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class Auth
    {
        ConnectionClass obj = new ConnectionClass();

        public int registerAcoount(string name, string address, string email, int phone, string username, string password)
        {
            string query = "select Max(reg_id) from Main";
            string i = obj.FnExecuteScalar(query);
            int reg_id = 0;
            int k = 0;

            if (i == "")
            {
                reg_id = 1;
            } else
            {
                reg_id = Convert.ToInt32(i) + 1;
            }

            string query2 = "insert into Main values('" + reg_id + "', '" + username + "', " + password + ", 'user', 'active')";
            int j  = obj.FnExecuteNonQuery(query);

            if (j != 0)
            {
                string query3 = "insert into UserTable values('" + reg_id + "', '" + name + "', '" + address + "', '"+email+"', "+phone+")";
                k = obj.FnExecuteNonQuery(query3);
            } 

            return k;
        }

        public string FnLoginAccount(string username, string password)
        {
            string query = "select Count(id) from Main where username='" + username + "' and password='" + password + "'";
            string s = obj.FnExecuteScalar(query).ToString();
            return s;
        }

        public SqlDataReader FnUserType(string username, string password)
        {
            string query = "select reg_id, id, type from Main where username='" + username + "' and password='" + password + "'";
            SqlDataReader dr = obj.FnDataReader(query);
            return dr;
        }
    }
}
