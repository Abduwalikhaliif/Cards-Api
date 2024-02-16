using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Business.Entity.CardEntity
{
    public class SingleCardRetrievalBE
    {
        public int UserID { get; set; }
        public int CardID { get; set; }
    }
    public class SingleCardRetrievalRespondBE
    {
        public string CardID { get; set;}
        public string UserID { get; set;}
        public string Name { get; set;}
        public string Description { get; set;}
        public string color { get; set;}
        public string Status { get; set;}
        public string ReturnCode { get; set;}
        public string Descriptions { get; set;}
    }
}
