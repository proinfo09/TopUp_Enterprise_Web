using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Enterprise_Web.Models
{
    public class StudentViewModel
    {
        [Required]
        [Display(Name = "User ID")]
        public string userId { get; set; }

        [Required]
        [Display(Name = "ID")]
        public int stdID { get; set; }

        [Required]
        [Display(Name = "Fullname")]
        public string std_fullname { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string std_mail { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string std_gender { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public Nullable<System.DateTime> std_doB { get; set; }

        [Required]
        [Display(Name = "Phone numbers")]
        public string std_phone { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int facID { get; set; }
        public string RoleName { get; set; }
    }
}