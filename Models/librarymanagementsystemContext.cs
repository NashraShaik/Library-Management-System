using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace librarymanagementsystem.Models
{
    public class librarymanagementsystemContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public librarymanagementsystemContext() : base("name=librarymanagementsystemContext")
        {

        }

        public System.Data.Entity.DbSet<librarymanagementsystem.Models.admin> admins { get; set; }

        public System.Data.Entity.DbSet<librarymanagementsystem.Models.student> students { get; set; }

        public System.Data.Entity.DbSet<librarymanagementsystem.Models.book> books { get; set; }

        public System.Data.Entity.DbSet<librarymanagementsystem.Models.acc> accs { get; set; }

        public System.Data.Entity.DbSet<librarymanagementsystem.Models.issue> issues { get; set; }

    
    }
}
