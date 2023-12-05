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
    public class AdminProductsPageBLL
    {
        ConnectionClass obj = new ConnectionClass();

        public DataSet getAllProducts()
        {
            string query = "select * from Product";
            DataSet ds = obj.FnDataAdapter(query);
            return ds;
        }
        public int deleteProduct(int id)
        {
            string query = "delete from Product where product_id=" + id+"";
            int i = obj.FnExecuteNonQuery(query);
            return i;
        }

        public int updateProduct(int id, string name)
        {
            string query = "update Product set name='"+name+"' where product_id=" + id + "";
            int i = obj.FnExecuteNonQuery(query);
            return i;
        }
        
        public int FnAddProduct(int id, string name, string description, string image, int price, string status)
        {
            string query = "insert into Product values("+id+", '"+name+ "', '" + description + "', '" + image + "', " + price + ", '" + status + "')";
            int i = obj.FnExecuteNonQuery(query);
            return i;
        }
    }
}
