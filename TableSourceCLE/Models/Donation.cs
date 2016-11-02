using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TableSourceCLE.Models
{
    public class Donation
    {
        [Key]
        public int donationID { get; set; }
        [Required]
        public string type { get; set; }
        [DataType(DataType.Date)]
        public DateTime pickUpDate { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public string pickupTime { get; set; }
        [Required]
        public double weight { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }


    }
}