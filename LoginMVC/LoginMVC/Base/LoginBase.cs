using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginMVC.Base
{
    public class LoginBase
    {
        [Key]
        public int id { get; set; }
    }
}