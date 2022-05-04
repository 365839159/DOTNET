using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Acme.IssueManagement;

[Dependency(ReplaceServices = true)]
public class IssueManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "IssueManagement";
}
