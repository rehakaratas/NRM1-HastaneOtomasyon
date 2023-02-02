using Hastane.DataAccess.Abstract;
using Hastane.DataAccess.EntityFramework.Context;
using Hastane.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.DataAccess.EntityFramework.Concrete
{
    public class AdminRepo : BaseRepo<Admin>, IAdminRepo
    {
        public AdminRepo(HastaneDbContext hastaneDbContext) : base(hastaneDbContext)
        {

        }

        public async Task<Admin> GetByEmail(string email , string password)
        {
            var admin = await _table.Where(x => x.EmailAddress == email && x.Password == password).FirstOrDefaultAsync();
            return admin;
        }
    }
}
