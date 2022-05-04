using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace Acme.IssueManagement.Blazor.WebAssembly;

[DependsOn(
    typeof(IssueManagementBlazorModule),
    typeof(IssueManagementHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class IssueManagementBlazorWebAssemblyModule : AbpModule
{

}
