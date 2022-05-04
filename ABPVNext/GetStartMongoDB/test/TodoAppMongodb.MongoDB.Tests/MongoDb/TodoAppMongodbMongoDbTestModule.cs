﻿using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace TodoAppMongodb.MongoDB;

[DependsOn(
    typeof(TodoAppMongodbTestBaseModule),
    typeof(TodoAppMongodbMongoDbModule)
    )]
public class TodoAppMongodbMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var stringArray = TodoAppMongodbMongoDbFixture.ConnectionString.Split('?');
        var connectionString = stringArray[0].EnsureEndsWith('/') +
                                   "Db_" +
                               Guid.NewGuid().ToString("N") + "/?" + stringArray[1];

        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = connectionString;
        });
    }
}