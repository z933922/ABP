using Abp.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zz
{
    public class MySettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
                  {
                    new SettingDefinition(
                        name: "SmtpServerAddress",
                        defaultValue: "127.0.0.1",
                        displayName:null,
                        group:null,
                        description:null,
                        scopes:SettingScopes.Application,
                        isVisibleToClients:false,
                        isInherited:true,
                        customData:null
                        ),

                    new SettingDefinition(
                        "PassiveUsersCanNotLogin",
                        "true",
                        scopes: SettingScopes.Application | SettingScopes.Tenant
                        ),

                    new SettingDefinition(
                        "SiteColorPreference",
                        "red",
                        scopes: SettingScopes.User,
                        isVisibleToClients: true
                        )

                };
        }
    }
}
