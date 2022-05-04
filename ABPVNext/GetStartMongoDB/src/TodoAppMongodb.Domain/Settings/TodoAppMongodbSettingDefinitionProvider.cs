using Volo.Abp.Settings;

namespace TodoAppMongodb.Settings;

public class TodoAppMongodbSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(TodoAppMongodbSettings.MySetting1));
    }
}
