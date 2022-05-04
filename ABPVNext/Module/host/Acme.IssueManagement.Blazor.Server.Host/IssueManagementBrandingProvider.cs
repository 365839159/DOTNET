using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Acme.IssueManagement.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class IssueManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "IssueManagement";
}
