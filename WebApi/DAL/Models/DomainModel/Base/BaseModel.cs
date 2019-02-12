using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DAL.Models.DomainModel.Base
{
    public abstract class BaseModel<Tkey>
    {
        public virtual Tkey Id { get; set; }
    }
}
