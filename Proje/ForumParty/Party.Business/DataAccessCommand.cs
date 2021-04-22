using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Party.Business
{
    public class DataAccessCommand
    {
        public DataTable GetDataTable(string sorgu)
        {
            DataAccessClass baglanti = new DataAccessClass();
            DataTable dt = new DataTable();
            SqlDataAdapter da = baglanti.DataAdapter(sorgu);
            da.Fill(dt);
            baglanti.ConnectionClose();
            return dt;
        }

        public DataTable GetDataList(string sorgu)
        {
            DataAccessClass baglanti = new DataAccessClass();
            DataTable dt = new DataTable();
            SqlDataAdapter da = baglanti.DataAdapter(sorgu);
            da.Fill(dt);
            return dt;

        }
        public SqlDataReader GetDataReader(string sorgu)
        {
            DataAccessClass baglanti = new DataAccessClass();
            baglanti.ConnectionOpen();
            SqlCommand com = new SqlCommand(sorgu);
            SqlDataReader dr = com.ExecuteReader();
            return dr;
            baglanti.ConnectionClose();

        }
    }
}
