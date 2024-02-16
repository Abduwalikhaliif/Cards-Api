using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Business.Entity.UserEntity
{
    public class LoginUserBE
    {
        
        [EmailAddress] 
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class LoginUserResponseBE
    {
        public int ResultCode { get; set; }

        public bool Success { get; set; }
        public string Message { get; set; }
        public string Role { get; set; }
        public string UserID { get; set; }
        public string Token { get; set; }

    }
}
