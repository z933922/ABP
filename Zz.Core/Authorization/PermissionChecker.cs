using Abp.Authorization;
using Zz.Authorization.Roles;
using Zz.MultiTenancy;
using Zz.Users;

namespace Zz.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
