using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party.Business
{
    public class DataAccessClass
    {

        string baglanti;
        SqlConnection con;


        public DataAccessClass()
        {
            baglanti = "Data Source = DESKTOP - TNFNUSJ; Initial Catalog = ForumParty; Integrated Security = True";
            con = new SqlConnection(baglanti);
        }

        public void ConnectionOpen()
        {
            try
            {
                con = new SqlConnection(baglanti);
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
            }
            catch(Exception e)
            {
                e.Message.ToString();
            }
        }

        public void ConnectionClose()
        {
            try
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Dispose();
                    con.Close();
                }
            }catch(Exception e)
            {
                e.Message.ToString();
            }
        }

        public SqlDataAdapter DataAdapter(String sorgu)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu, con);
            return adapter;
        }
        public SqlCommand DataCommand(String sorgu)
        {
            SqlCommand command = new SqlCommand(sorgu, con);
            command.CommandTimeout = 3600;
            return command;
        }

    }
}
