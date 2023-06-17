using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace librarymanagementsystem.Models
{
    public class admin
    {
        [Key]
        public String adminid { get; set; }
        public String adminpassword { get; set; }
    }
}