using Cards.Business.Entity.UserEntity;
using Cards.Business.Service.IService;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards.Business.Service.DBAccess;

namespace Cards.Business.Service.Service
{
    public class UserService : IUserService
    {
        public string Conns = "Server=DESKTOP-651S2E8\\SQLEXPRESS; Database=Cards; Trusted_Connection=True;";
        public LoginUserResponseBE Userlogin(LoginUserBE _LoginUserBE)
        {
            LoginUserResponseBE obj = new LoginUserResponseBE();
            try
            {
                //string strPassword = TawakalOrg.BusinessCore.Encrypt.Hash.GenerateHashSHA1(_LoginUserBE.Password);
                SqlConnection sql = new SqlConnection(Conns);
                SqlCommand cmd = new SqlCommand("SP_UserLogin", sql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", _LoginUserBE.Email);
                cmd.Parameters.AddWithValue("@Password", _LoginUserBE.Password);

                sql.Open();
                using (System.Data.IDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        obj.ResultCode = (int)reader["RESULT"];
                        obj.Message = reader["DESCRIPTION"].ToString();
                        obj.Role = reader["ROLE"].ToString();
                        obj.UserID = reader["USERID"].ToString();
                        //obj.Token = GeneratetokenString(_LoginUserBE, obj.Role);
                        if (obj.ResultCode == 0)
                        {
                            obj.Success = true;
                        }
                        else
                        {
                            obj.Success = false;
                        }
                    }
                }

            }
            catch (Exception e)
            {
                LogBC.EntryLog("SP_UserLogin", e.Message);
                return null;
            }
            return obj;
        }
    }
}
