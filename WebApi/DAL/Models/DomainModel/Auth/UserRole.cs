using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DAL.Models.DomainModel.Auth
{
    public class UserRole
    {
        public int UserId { get; set; }
        public User User { get; set;}

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
