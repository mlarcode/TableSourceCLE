using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TableSourceCLE.Models
{
    public class RecipientCategory
    {
        [Key]
        public int recipientCategoryID { get; set; }
        public string recipientCategoryName { get; set; }

        //navigation properties
        public virtual ICollection<RecipientOrganization> RecipientOrganizations { get; set; }
    }
}