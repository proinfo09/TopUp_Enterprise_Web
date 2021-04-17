using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enterprise_Web.Dtos
{
    public class StudentDto
    {
        public string userId { get; set; }
        public int stdID { get; set; }
        public string std_fullname { get; set; }
        public string std_mail { get; set; }
        public string std_gender { get; set; }
        public string std_phone { get; set; }
    }
}