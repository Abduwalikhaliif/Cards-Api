using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Business.Service.DBAccess
{
    public class LogBC
    {
        public static void EntryLog(string spName, string Error)
        {
            SqlConnection cn = new SqlConnection("Server=DESKTOP-651S2E8\\SQLEXPRESS; Database=Cards; Trusted_Connection=True;");
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ErrorLogged";
                cn.Open();
                cmd.Parameters.AddWithValue("@spName", spName);
                cmd.Parameters.AddWithValue("@Error", Error);

                int i = cmd.ExecuteNonQuery();
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
            catch { }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();//connection close
                }
                cn.Dispose();
            }
        }


        public static string GetErrorMessage(Exception ex)
        {
            string msg = ex.Message.ToString();

            if (msg.ToLower().Contains("row at position"))
                msg = "An error occured while processing. Please Contact Administrator";
            else if (msg.ToLower().Contains("could not find file"))
                msg = "An error occured while processing. Please Contact Administrator";
            else if (msg.ToLower().Contains("data type"))
                msg = "An error occured while processing. Please Contact Administrator";
            else if (msg.ToLower().Contains("belong"))
                msg = "An error occured while processing. Please Contact Administrator";
            else if (msg.ToLower().Contains("primary key"))
                msg = "An error occured while processing. Please Contact Administrator";
            else if (msg.ToLower().Contains("order by"))
                msg = "An error occured while processing. Please Contact Administrator";
            else if (msg.ToLower().Contains("foreign key"))
                msg = "An error occured while processing. Please Contact Administrator";
            else if (msg.ToLower().Contains("deadlock"))
                msg = "An error occured while processing. Please Contact Administrator";
            else if (msg.Contains("invalid column name"))
                msg = "An error occured while processing. Please Contact Administrator";
            else if (msg.ToLower().Contains("parameterized query"))
                msg = "An error occured while processing. Please Contact Administrator";
            else if (msg.ToLower().Contains("invalid object"))
                msg = "An error occured while processing. Please Contact Administrator";
            else if (msg.ToLower().Contains("Object reference not set to an instance of an object"))
                msg = "An error occured while processing. Please Contact Administrator";
            else if (msg.ToLower().Contains("There was an error processing the"))
                msg = "An error occured while processing. Please Contact Administrator";
            else if (msg.ToLower().Contains("startIndex cannot be larger than length of string"))
                msg = "An error occured while processing. Please Contact Administrator";
            else if (ex.Source.ToLower() == "entityframework")
                msg = "An error occured while processing. Please Contact Administrator";
            return msg;
        }
    }
}
