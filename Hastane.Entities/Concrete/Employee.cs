using Hastane.Core.Entities.Abstract;
using Hastane.Core.Enums;
using Hastane.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Entities.Concrete
{
    public class Employee : IUser, IEmployee, IBaseEntity
    {
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? IdentityNumber { get; set; }
        public decimal? Salary { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public Roles Roles { get; set; }
    }
}
