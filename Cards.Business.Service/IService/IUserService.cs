using Cards.Business.Entity.CardEntity;
using Cards.Business.Entity.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Business.Service.IService
{
    public interface IUserService
    {
        LoginUserResponseBE Userlogin(LoginUserBE _LoginUserBE);
       
    }
}
