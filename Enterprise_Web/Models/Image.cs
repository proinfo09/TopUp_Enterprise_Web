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
    
    public partial class Image
    {
        public int imgID { get; set; }
        public string img_Title { get; set; }
        public int consID { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    
        public virtual Contribution Contribution { get; set; }
    }
}
