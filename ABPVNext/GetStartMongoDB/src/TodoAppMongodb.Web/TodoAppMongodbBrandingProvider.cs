using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace TodoAppMongodb.Web;

[Dependency(ReplaceServices = true)]
public class TodoAppMongodbBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "TodoAppMongodb";
}
