using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class ProductsPageBLL
    {
        ConnectionClass obj = new ConnectionClass();
        public DataSet getCategoryProducts(string id)
        {
            string query = "select * from Product where category_id=" + Convert.ToInt32(id)+"";
            DataSet ds = obj.FnDataAdapter(query);
            return ds;
        }
    }
}
