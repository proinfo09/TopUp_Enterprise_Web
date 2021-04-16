using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Enterprise_Web.Models
{
    public class UserViewModel
    {
        [Display(Name = "User ID")]
        public string userId { get; set; }

        [Display(Name = "ID")]
        public int stdID { get; set; }

        [Display(Name = "Fullname")]
        public string std_fullname { get; set; }

        [Display(Name = "Email")]
        public string std_mail { get; set; }

        [Display(Name = "Gender")]
        public string std_gender { get; set; }

        [Display(Name = "Date of Birth")]
        public Nullable<System.DateTime> std_doB { get; set; }

        [Display(Name = "Phone numbers")]
        public string std_phone { get; set; }

    }
}