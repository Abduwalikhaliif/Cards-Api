using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Business.Entity.CardEntity
{
    public class CreateCardBE
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [StringLength(6, MinimumLength =6)]
        public string Color { get; set; }
        public string Status { get; set; }
    }
    public class CreateCardResponseBE
    {
        public int ResultCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }

}
