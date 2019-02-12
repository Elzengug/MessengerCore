using DAL.Models.DomainModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.DomainModels.Authorization
{
    public class User : BaseModel<int>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
