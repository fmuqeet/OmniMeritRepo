using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OmniMerit.Models
{
    public class UserLogin
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string EmailID { get; set; }
        [Required(ErrorMessage = "Please provide username.", AllowEmptyStrings = false)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please provide Password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }
        public string Class { get; set; }
    }
}