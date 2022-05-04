using Acme.IssueManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.IssueManagement.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class IssueManagementPageModel : AbpPageModel
{
    protected IssueManagementPageModel()
    {
        LocalizationResourceType = typeof(IssueManagementResource);
        ObjectMapperContext = typeof(IssueManagementWebModule);
    }
}
