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
    public class UserPageBLL
    {
        ConnectionClass obj = new ConnectionClass();

        public DataSet getItems()
        {
            string query = "select * from Category";
            DataSet ds = obj.FnDataAdapter(query);
            return ds;
        }
    }
}
