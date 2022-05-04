using Acme.IssueManagement.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Acme.IssueManagement.Blazor.Server.Host;

public abstract class IssueManagementComponentBase : AbpComponentBase
{
    protected IssueManagementComponentBase()
    {
        LocalizationResource = typeof(IssueManagementResource);
    }
}
