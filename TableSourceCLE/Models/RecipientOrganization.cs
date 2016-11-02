using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TableSourceCLE.Models
{
    public class RecipientOrganization
    {
        [Key]
        public int recipientID { get; set; }
        public string recipientName { get; set; }
        public string recipientAddress { get; set; }
        public string recipientCity { get; set; }
        public string recipientState { get; set; }
        public int recipientZip { get; set; }
        public string recipientPhone { get; set; }
        public string recipientEmail { get; set; }
        public string recipientTaxID { get; set; }
        public int recipientCategoryID { get; set; }

        //navigation properties
        public virtual RecipientCategory RecipientCategory { get; set; }
    }
}