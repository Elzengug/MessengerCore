using DAL.Models.DomainModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.DomainModels
{
   public class Client : BaseModel<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
