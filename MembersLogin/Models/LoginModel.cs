using System;
using System.ComponentModel.DataAnnotations;

namespace MembersLogin.Models
{
    public class LoginModel
    {
        [Display(Name = "Username")]
        [Required]
        public String Username { set;get;}

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public String Password { set; get; }

    }
}