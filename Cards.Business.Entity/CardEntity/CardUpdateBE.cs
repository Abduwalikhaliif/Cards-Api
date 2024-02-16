using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Business.Entity.CardEntity
{
    public class CardUpdateBE
    {
        public int UserID { get; set; }
        public int CardID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Status { get; set; }
    }
    public class CardUpdateResponsedBE
    {
        public int ResultCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
