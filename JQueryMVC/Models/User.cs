using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JQueryMVC.Models
{
    public partial class User
    {
        public int UserID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public DateTime DoB { get; set; }
        public bool IsActive { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Rating { get; set; }
    }
}