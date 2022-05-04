using Volo.Abp.Bundling;

namespace Acme.IssueManagement.Blazor.Host;

public class IssueManagementBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
