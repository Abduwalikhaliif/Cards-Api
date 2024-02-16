using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Business.Entity.CardEntity
{
    public class CardDeletionBE
    {
        public int UserID { get; set; }
        public int CardID { get; set; }
    }
    public class CardDeletionBEResponsedBE
    {
        public int ResultCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
