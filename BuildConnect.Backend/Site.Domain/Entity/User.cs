using Site.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Domain.Entity
{
    public class User: BaseModel
    {
        public string FullName {  get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string ProfileImage { get; set; }
        public string PasswordHash { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }

    public class UserDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string ProfileImage { get; set; }
        public Guid RoleId { get; set; }
    }
}
