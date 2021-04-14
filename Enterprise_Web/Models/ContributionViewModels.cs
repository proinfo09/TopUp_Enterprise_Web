using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Enterprise_Web.Models
{
    public class ContributionViewModels
    {
        public int consID { get; set; }

        [Required]
        [Display(Name = "Contributions Name")]
        public string cons_Name { get; set; }

      
        [Display(Name = "Contributions Comment")]
        public string cons_comment { get; set; }
        public Nullable<System.DateTime> cons_submit { get; set; }

        
        [Display(Name = "Contributions Status")]
        public string cons_status { get; set; }

        
        [Display(Name = "StudentID")]
        public int stdID { get; set; }

        [Required]
        [Display(Name = "FileID")]
        public int fileID { get; set; }

        [Required]
        [Display(Name = "File Title")]
        public string file_Title { get; set; }

    }
}