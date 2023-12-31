﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ConnectionClass
    {
        SqlConnection con;
        SqlCommand cmd;

        public ConnectionClass()
        {
            con = new SqlConnection(@"server=AFSAL\SQLEXPRESS;database=ECommerceProject;Integrated Security=true");
        }

        public void ConnectionControl()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public int FnExecuteNonQuery(string sqlQuery)
        {
            ConnectionControl();
            cmd = new SqlCommand(sqlQuery, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i;
        }

        public string FnExecuteScalar(string sqlQuery)
        {
            ConnectionControl();
            cmd = new SqlCommand(sqlQuery, con);
            con.Open();
            string i = cmd.ExecuteScalar().ToString();
            con.Close();

            return i;
        }

        public SqlDataReader FnDataReader(string sqlQuery)
        {
            ConnectionControl();
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            return dr;
        }

        public DataSet FnDataAdapter(string sqlQuery)
        {
            ConnectionControl();
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }
    }
}
