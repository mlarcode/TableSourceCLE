using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TableSourceCLE.Models
{
    public class DonorOrganization
    {
        [Key]
        public int donorID { get; set; }
        public string donorName { get; set; }
        public string donorAddress { get; set; }
        public string donorCity { get; set; }
        public string donorState { get; set; }
        public int donorZip { get; set; }
        public string donorPhone { get; set; }
        public string donorEmail { get; set; }
        public string donorTaxID { get; set; }
        public int donorCategoryID { get; set; }

        //public virtual ICollection<Donation> Donations { get; set; }
        public virtual DonorCategory DonorCategory { get; set; }
    }
}