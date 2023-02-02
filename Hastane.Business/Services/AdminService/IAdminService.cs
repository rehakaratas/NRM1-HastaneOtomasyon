using Hastane.Business.Models.DTOs;
using Hastane.Business.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Business.Services.AdminService
{
    public interface IAdminService
    {
        Task AddManager(AddManagerDTO addManagerDTO);
        Task<List<ListOfManagersVM>> ListOfManager();
        Task<UpdateManagerDTO> GetManager(Guid id);
        Task UpdateManager(UpdateManagerDTO updateManagerDTO);
    }
}
