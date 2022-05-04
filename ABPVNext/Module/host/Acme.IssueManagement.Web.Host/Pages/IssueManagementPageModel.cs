using Acme.IssueManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.IssueManagement.Pages;

public abstract class IssueManagementPageModel : AbpPageModel
{
    protected IssueManagementPageModel()
    {
        LocalizationResourceType = typeof(IssueManagementResource);
    }
}
