using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace TodoAppMongodb;

public class TodoAppMongodbWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<TodoAppMongodbWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
