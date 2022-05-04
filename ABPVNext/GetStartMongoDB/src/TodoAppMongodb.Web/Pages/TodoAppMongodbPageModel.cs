using TodoAppMongodb.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace TodoAppMongodb.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class TodoAppMongodbPageModel : AbpPageModel
{
    protected TodoAppMongodbPageModel()
    {
        LocalizationResourceType = typeof(TodoAppMongodbResource);
    }
}
