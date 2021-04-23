using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EnsekWebApi
{
    public class MeterReading
    {
        
        public DateTime MeterReadingDate { get; set; }
        public int MeterReadingValue { get; set; }

        public Account Account { get; set; }
        
        [ForeignKey("Account")]
        public int AccountId { get; set; }
    }
}
