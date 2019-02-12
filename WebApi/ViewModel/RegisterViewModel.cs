using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ViewModel
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
         
        public string Password { get; set; }

        public string PasswordConfirm { get; set; }
    }
}
