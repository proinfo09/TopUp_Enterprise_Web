//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Enterprise_Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User_Marketing_Coordinator_Detail
    {
        [Required]
        [Display(Name = "User ID")]
        public string userId { get; set; }

        [Required]
        [Display(Name = "ID")]
        public int mkcID { get; set; }

        [Required]
        [Display(Name = "Fullname")]
        public string mkc_fullname { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string mkc_mail { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string mkc_gender { get; set; }

        [Required]
        [Display(Name = "Date of birth")]
        public Nullable<System.DateTime> mkc_doB { get; set; }

        [Required]
        [Display(Name = "Phone numbers")]
        public string mkc_phone { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
