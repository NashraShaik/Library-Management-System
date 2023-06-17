using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace librarymanagementsystem.Models
{
    public class acc
    {
        [Key]
        public int accno { get; set; }
        public int bookid { get; set; }
        public book book { get; set; }
    }
}