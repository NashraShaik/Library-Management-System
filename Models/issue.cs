using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace librarymanagementsystem.Models
{
    public class issue
    {
        [Key]
        public int bookissueid { get; set; }
        public String adminid { get; set; }
        public admin admin { get; set; }
        public String studentid { get; set; }
        public student student { get; set; }

        public int accno { get; set; }
        public acc acc { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime bookissuedate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime bookduedate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime bookreturndate { get; set; }
        public int fine { get; set; }
        
    }
}