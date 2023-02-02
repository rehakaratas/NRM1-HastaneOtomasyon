using Hastane.Core.DataAccess.Abstract;
using Hastane.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.DataAccess.Abstract
{
    public interface IAdminRepo : IBaseRepo<Admin>
    {
        Task<Admin> GetByEmail(string email, string password);
    }
}
