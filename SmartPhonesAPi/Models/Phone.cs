using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPhonesAPi.Models
{
    // smartphones class
    public class Phone
    {
        [Key] // unique key field
        public int Id { get; set; }
        // model field
        public string Model { get; set; }
        // specs field
        public string Specs { get; set; }
        // price of phone
        public double Price { get; set; }
    }
}
