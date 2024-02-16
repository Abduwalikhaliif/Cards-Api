using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Business.Entity.CardEntity
{
    public class SearchCardBE
    {
        public int UserID { get; set; }
        public int ROLE { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Status { get; set; }

        public string DateofCreation { get; set; }
        public string OrderBy { get; set; }
    }
    public class SearchCardRespondBE
    {
        public string CardId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Status { get; set; }

        public string DateofCreation { get; set; }
    }
}
