using DAL.Models.DomainModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.DomainModels
{
   public class Message : BaseModel<int>
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
