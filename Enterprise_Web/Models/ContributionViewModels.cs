using System;
using System.Collections.Generic;


namespace Enterprise_Web.Models
{
    public class ContributionViewModels
    {
        public int consID { get; set; }
        public string cons_Name { get; set; }
        public string cons_comment { get; set; }
        public Nullable<System.DateTime> cons_submit { get; set; }
        public string cons_status { get; set; }
        public int imgID { get; set; }
        public int stdID { get; set; }
        public int fileID { get; set; }

        public virtual File File { get; set; }
        public string file_Title { get; set; }
        public virtual Image Image { get; set; }
        public string img_Title { get; set; }
        public virtual User_Student_Detail User_Student_Detail { get; set; }
    }
}