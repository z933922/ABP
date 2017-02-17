using System.Threading.Tasks;
using Abp.Application.Services;
using Zz.Roles.Dto;

namespace Zz.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
