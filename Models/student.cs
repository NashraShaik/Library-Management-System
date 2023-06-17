using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace librarymanagementsystem.Models
{
    public class student
    {
        [Key]
        public String studentid { get; set; }
        public String studentname { get; set; }
        public String studentpassword { get; set; }
        public String studentphno { get; set; }
        public String studentemail { get; set; }
    }
}