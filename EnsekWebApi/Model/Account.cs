using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnsekWebApi
{
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<MeterReading> MeterReadings { get; set; }
    }
}
