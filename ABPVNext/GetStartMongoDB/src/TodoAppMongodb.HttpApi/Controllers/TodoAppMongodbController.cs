using TodoAppMongodb.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TodoAppMongodb.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class TodoAppMongodbController : AbpControllerBase
{
    protected TodoAppMongodbController()
    {
        LocalizationResource = typeof(TodoAppMongodbResource);
    }
}
