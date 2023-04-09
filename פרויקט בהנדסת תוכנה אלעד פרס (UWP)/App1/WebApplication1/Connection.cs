using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public class Connection
    {
        public SqlConnection conn;
        private SqlDataAdapter ad;
        private SqlCommand cmd;

        public Connection()
        {
            this.conn = new SqlConnection(@"Data Source = 'DESKTOP-GMDCSU5\SQLEXPRESS'; Initial Catalog = 'GameDB'; Integrated Security = SSPI");
        }
        public SqlDataReader GetDataReader(string sqlstr)
        {
            this.cmd = new SqlCommand(sqlstr, this.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public DataSet GetDataSet(string sqlstr, string Table)
        {
            this.cmd = new SqlCommand(sqlstr, this.conn);
            this.ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds, Table);
            return ds;
        }
        public void ConnectionOpen()
        {
            this.conn.Open();
        }
        public void ConnectionClose()
        {
            this.conn.Close();
        }
        public bool EecuteConnectionSql(string sql)
        {
            this.ConnectionOpen();
            cmd = new SqlCommand(sql, this.conn);
            int num = cmd.ExecuteNonQuery();
            this.ConnectionClose();
            return num > 0;
        }
        public void UpdateDataSet(DataSet ds)
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(ad);
            ad.UpdateCommand = builder.GetUpdateCommand();
            ad.InsertCommand = builder.GetInsertCommand();
            ad.DeleteCommand = builder.GetDeleteCommand();
            ad.Update(ds.Tables[0]);
        }
        public bool IsExist(string sql)
        {
            ConnectionOpen();
            SqlCommand com = new SqlCommand(sql, this.conn);
            SqlDataReader data = com.ExecuteReader();
            bool found;
            found = (bool)data.Read();
            ConnectionClose();
            return found;
        }
        public int User(string sql)
        {
            ConnectionOpen();
            SqlCommand com = new SqlCommand(sql, this.conn);
            SqlDataReader reader = com.ExecuteReader(); 
            while (reader.Read())
            {
                return reader.GetInt32(0);
            }
            ConnectionClose();
            return reader.GetInt32(0);

        }
    }
}