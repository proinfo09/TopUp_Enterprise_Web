using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Enterprise_Web.Dtos
{
    public class ContributionDto
    {
        public int consID { get; set; }

        [Required]
        
        public string cons_Name { get; set; }
      
        public string cons_comment { get; set; }
        public Nullable<System.DateTime> cons_submit { get; set; }
        
        public string cons_status { get; set; }

        public int stdID { get; set; }

        [Required]

        public int fileID { get; set; }

        [Required]
        
        public string file_Title { get; set; }

        public static readonly string Available = "Available";
    }
}