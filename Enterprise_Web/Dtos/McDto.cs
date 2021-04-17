using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enterprise_Web.Dtos
{
    public class McDto
    {
        public string userId { get; set; }
        public int mkcID { get; set; }
        public string mkc_fullname { get; set; }
        public string mkc_mail { get; set; }
        public string mkc_gender { get; set; }
        public string mkc_doB { get; set; }
        public string mkc_phone { get; set; }
    }
}