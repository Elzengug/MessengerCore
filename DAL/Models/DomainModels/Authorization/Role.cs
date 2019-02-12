using DAL.Models.DomainModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.DomainModels.Authorization
{
     public class Role : BaseModel<int>
    {
        public string Name { get; set; }
    }
}
