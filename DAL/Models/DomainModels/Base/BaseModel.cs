using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.DomainModels.Base
{
    public abstract class BaseModel<Tkey>
    {
        public virtual Tkey Id { get; set; }
    }
}
