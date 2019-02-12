using DAL.Models.DomainModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.DomainModels
{
   public class Status : BaseModel<int>
    {
        public string State { get; set; }
    }
}
