using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enterprise_Web.Dtos
{
    public class MmDto
    {
        public string userId { get; set; }
        public int mkmID { get; set; }
        public string mkm_fullname { get; set; }
        public string mkm_mail { get; set; }
        public string mkm_gender { get; set; }
        public string mkm_doB { get; set; }
        public string mkm_phone { get; set; }
    }
}