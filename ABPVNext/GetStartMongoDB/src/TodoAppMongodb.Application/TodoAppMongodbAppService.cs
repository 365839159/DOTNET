using System;
using System.Collections.Generic;
using System.Text;
using TodoAppMongodb.Localization;
using Volo.Abp.Application.Services;

namespace TodoAppMongodb;

/* Inherit your application services from this class.
 */
public abstract class TodoAppMongodbAppService : ApplicationService
{
    protected TodoAppMongodbAppService()
    {
        LocalizationResource = typeof(TodoAppMongodbResource);
    }
}
