using Hastane.DataAccess.Abstract;
using Hastane.DataAccess.EntityFramework.Context;
using Hastane.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.DataAccess.EntityFramework.Concrete
{
    public class EmployeeRepo : BaseRepo<Employee>, IEmployeeRepo
    {
        public EmployeeRepo(HastaneDbContext hastaneDbContext) : base(hastaneDbContext)
        {
        }
    }
}
