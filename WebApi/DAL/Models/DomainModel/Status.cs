using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DAL.Models.DomainModel.Base;

namespace WebApi.DAL.Models.DomainModel
{
    public class Status : BaseModel<int>
    {
        public string State { get; set; }
    }
}
