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
    
    public partial class User_Marketing_Manager_Detail
    {
        public string userId { get; set; }
        public int mkmID { get; set; }
        public string mkm_fullname { get; set; }
        public string mkm_mail { get; set; }
        public string mkm_gender { get; set; }
        public Nullable<System.DateTime> mkm_doB { get; set; }
        public string mkm_phone { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}