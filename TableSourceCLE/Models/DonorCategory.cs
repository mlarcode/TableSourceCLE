using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TableSourceCLE.Models
{
    public class DonorCategory
    {
        [Key]
        public int donorCategoryID { get; set; }
        public string donorCategoryName { get; set; }

        //navigation properties
        public virtual ICollection<DonorOrganization> DonorOrganizations { get; set; }
    }
}