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
    public class ProductViewPageBLL
    {
        ConnectionClass obj = new ConnectionClass();

        public SqlDataReader getSingleProduct(string id)
        {
            string query = "select * from Product where product_id=" + Convert.ToInt32(id) + "";
            SqlDataReader dr = obj.FnDataReader(query);
            return dr;
        }
    }
}
