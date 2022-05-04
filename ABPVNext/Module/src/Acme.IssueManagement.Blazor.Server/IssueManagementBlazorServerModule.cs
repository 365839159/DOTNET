using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace Acme.IssueManagement.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(IssueManagementBlazorModule)
    )]
public class IssueManagementBlazorServerModule : AbpModule
{

}
