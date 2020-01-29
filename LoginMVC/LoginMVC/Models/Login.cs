using LoginMVC.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginMVC.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("TB_M_Login")]
    public class Login : LoginBase 
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}