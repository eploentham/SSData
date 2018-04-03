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
        public SqlConnection connMainHISNoClose, connSSDataNoClose;
        SqlCommand comMainhisNoClose;
        InitConfig initC;
        public int _rowsAffected = 0;

        public ConnectDB(InitConfig initc)
        {
            initC = initc;
            connMainHIS = new SqlConnection();
            connSSData = new SqlConnection();
            connMainHISNoClose = new SqlConnection();
            connSSDataNoClose = new SqlConnection();
            comMainhisNoClose = new SqlCommand();

            connMainHIS.ConnectionString = "Server=" + initC.hostDBMainHIS + ";Database=" + initC.nameDBMainHIS + ";Uid=" + initC.userDBMainHIS + ";Pwd=" + initC.passDBMainHIS + ";";
            connSSData.ConnectionString = "Server=" + initC.hostDBSSData + ";Database=" + initC.nameDBSSData + ";Uid=" + initC.userDBSSData + ";Pwd=" + initC.passDBSSData + ";";

            connMainHISNoClose.ConnectionString = "Server=" + initC.hostDBMainHIS + ";Database=" + initC.nameDBMainHIS + ";Uid=" + initC.userDBMainHIS + ";Pwd=" + initC.passDBMainHIS + ";";
            connSSDataNoClose.ConnectionString = "Server=" + initC.hostDBSSData + ";Database=" + initC.nameDBSSData + ";Uid=" + initC.userDBSSData + ";Pwd=" + initC.passDBSSData + ";";
        }
        public DataTable selectData(SqlConnection con, String sql)
        {
            DataTable toReturn = new DataTable();

            SqlCommand comMainhis = new SqlCommand();
            comMainhis.CommandText = sql;
            comMainhis.CommandType = CommandType.Text;
            comMainhis.Connection = con;
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
        public DataTable selectDataNoClose(SqlConnection con, String sql)
        {
            DataTable toReturn = new DataTable();

            //SqlCommand comMainhis = new SqlCommand();
            comMainhisNoClose.CommandText = sql;
            comMainhisNoClose.CommandType = CommandType.Text;
            comMainhisNoClose.Connection = con;
            SqlDataAdapter adapMainhis = new SqlDataAdapter(comMainhisNoClose);
            try
            {
                //con.Open();
                adapMainhis.Fill(toReturn);
                //return toReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                //con.Close();
                //comMainhis.Dispose();
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
            comMainhis.Connection = con;
            try
            {
                con.Open();
                //_rowsAffected = comMainhis.ExecuteNonQuery();
                _rowsAffected = (int)comMainhis.ExecuteScalar();
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
        public String ExecuteNonQueryNoClose(SqlConnection con, String sql)
        {
            String toReturn = "";
            comMainhisNoClose.CommandText = sql+ "; SELECT SCOPE_IDENTITY();";
            comMainhisNoClose.CommandType = CommandType.Text;
            comMainhisNoClose.Connection = con;
            try
            {
                //connMainHIS.Open();
                //_rowsAffected = comMainhisNoClose.ExecuteNonQuery();
                var aaa = comMainhisNoClose.ExecuteScalar();
                toReturn = aaa.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery::Error occured.", ex);
                toReturn = ex.Message;
            }
            finally
            {
                //_mainConnection.Close();
                //comMainhis.Dispose();
            }
            return toReturn;
        }
        public String ExecuteNonQueryNoCloseMainHIS(SqlConnection con, String sql)
        {
            String toReturn = "";
            comMainhisNoClose.CommandText = sql;
            comMainhisNoClose.CommandType = CommandType.Text;
            comMainhisNoClose.Connection = con;
            try
            {
                //connMainHIS.Open();
                _rowsAffected = comMainhisNoClose.ExecuteNonQuery();
                //var aaa = comMainhisNoClose.ExecuteNonQuery();
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
                //comMainhis.Dispose();
            }

            return toReturn;
        }
        public String OpenConnectionMainHIS()
        {
            String toReturn = "";
            try
            {
                connMainHISNoClose.Open();
                //_rowsAffected = comMainhis.ExecuteNonQuery();
                //toReturn = _rowsAffected.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery::Error occured.", ex);
                toReturn = ex.Message;
            }
            finally
            {
                //_mainConnection.Close();
                //comMainhis.Dispose();
            }
            
            return toReturn;
        }
        public void CloseConnectionMainHIS()
        {
            connMainHISNoClose.Close();
        }
        public String OpenConnectionSSData()
        {
            String toReturn = "";
            try
            {
                connSSDataNoClose.Open();
                //_rowsAffected = comMainhis.ExecuteNonQuery();
                //toReturn = _rowsAffected.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery::Error occured.", ex);
                toReturn = ex.Message;
            }
            finally
            {
                //_mainConnection.Close();
                //comMainhis.Dispose();
            }

            return toReturn;
        }
        public void CloseConnectionSSData()
        {
            connSSDataNoClose.Close();
        }
    }
}
