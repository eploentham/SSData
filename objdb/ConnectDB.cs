using SSData.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSData.objdb
{
    public class ConnectDB
    {
        public SqlConnection connMainHIS, connSSData;
        InitConfig initC;
        public int _rowsAffected = 0;

        public ConnectDB(InitConfig initc)
        {
            initC = initc;
            connMainHIS = new SqlConnection();
            connSSData = new SqlConnection();
            connMainHIS.ConnectionString = "Server=" + initC.hostDBMainHIS + ";Database=" + initC.nameDBMainHIS + ";Uid=" + initC.userDBMainHIS + ";Pwd=" + initC.passDBMainHIS + ";";
            connSSData.ConnectionString = "Server=" + initC.hostDBSSData + ";Database=" + initC.nameDBSSData + ";Uid=" + initC.userDBSSData + ";Pwd=" + initC.passDBSSData + ";";
        }
        public DataTable selectData(SqlConnection con, String sql)
        {
            DataTable toReturn = new DataTable();
            
            SqlCommand comMainhis = new SqlCommand();
            comMainhis.CommandText = sql;
            comMainhis.CommandType = CommandType.Text;
            //comMainhis.Connection = connMainHIS;
            SqlDataAdapter adapMainhis = new SqlDataAdapter(comMainhis);
            try
            {
                con.Open();
                adapMainhis.Fill(toReturn);
                //return toReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                con.Close();
                comMainhis.Dispose();
                adapMainhis.Dispose();
            }            
            return toReturn;
        }
        public String ExecuteNonQuery(SqlConnection con, String sql)
        {
            String toReturn = "";

            SqlCommand comMainhis = new SqlCommand();
            comMainhis.CommandText = sql;
            comMainhis.CommandType = CommandType.Text;
            //comMainhis.Connection = connMainHIS5;
            try
            {
                con.Open();
                _rowsAffected = comMainhis.ExecuteNonQuery();
                toReturn = _rowsAffected.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery::Error occured.", ex);
                toReturn = ex.Message;
            }
            finally
            {
                //_mainConnection.Close();
                con.Close();
                comMainhis.Dispose();
            }
            
            return toReturn;
        }
    }
}
