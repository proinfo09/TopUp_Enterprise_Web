using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enterprise_Web.Dtos
{
    public class GuestDto
    {
        public string userId { get; set; }
        public int gstID { get; set; }
        public string gst_fullname { get; set; }
        public string gst_mail { get; set; }
        public string gst_gender { get; set; }
        public string gst_doB { get; set; }
        public string gst_phone { get; set; }
    }
}