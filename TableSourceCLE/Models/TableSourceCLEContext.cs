using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TableSourceCLE.Models
{
    public class TableSourceCLEContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TableSourceCLEContext() : base("name=TableSourceCLEContext")
        {
        }

        public System.Data.Entity.DbSet<TableSourceCLE.Models.Donation> Donations { get; set; }

        public System.Data.Entity.DbSet<TableSourceCLE.Models.DonorCategory> DonorCategories { get; set; }

        public System.Data.Entity.DbSet<TableSourceCLE.Models.DonorOrganization> DonorOrganizations { get; set; }

        public System.Data.Entity.DbSet<TableSourceCLE.Models.RecipientOrganization> RecipientOrganizations { get; set; }

        public System.Data.Entity.DbSet<TableSourceCLE.Models.RecipientCategory> RecipientCategories { get; set; }
    }
}
