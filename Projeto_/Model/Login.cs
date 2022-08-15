using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Login
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}