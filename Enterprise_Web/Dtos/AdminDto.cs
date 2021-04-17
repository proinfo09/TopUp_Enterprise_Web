using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enterprise_Web.Dtos
{
    public class AdminDto
    {
        public string userId { get; set; }
        public int admID { get; set; }
        public string admin_fullname { get; set; }
        public string admin_mail { get; set; }
        public string admin_gender { get; set; }
        public string admin_doB { get; set; }
        public string admin_phone { get; set; }

    }
}