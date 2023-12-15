using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class AdminCategoryPageBBL
    {
        ConnectionClass obj = new ConnectionClass();

        public int FnAddCategory(string name, string description, string image, string status)
        {
            string query = "insert into Category values('" + name + "', '" + description + "', '" + image + "', '" + status + "')";
            int i = obj.FnExecuteNonQuery(query);
            return i;
        }

        public DataSet FnGetAllCategories()
        {
            string query = "select * from Category";
            DataSet ds = obj.FnDataAdapter(query);
            return ds;
        }

        public DataSet FnGetCategories()
        {
            string query = "select id, name from Category";
            DataSet ds = obj.FnDataAdapter(query);
            return ds;
        }
    }
}
