using Newtonsoft.Json;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("Ocelot.json", false, true);
// Add services to the container.
builder.Services.AddOcelot();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    SortedDictionary<string, object> sort = new SortedDictionary<string, object>();
    if (context.Request.Method.ToLower() == "get")
    {
        var ss = context.Request.Query;
        foreach (var item in ss)
        {
            sort.Add(item.Key, item.Value);
        }
    }
    else if (context.Request.Method.ToLower() == "post")
    {
        if (context.Request.ContentType.ToLower() == "application/json")
        {
            //操作Request.Body之前加上EnableBuffering即可
            context.Request.EnableBuffering();
            StreamReader stream = new StreamReader(context.Request.Body);
            string body = await stream.ReadToEndAsync();
            context.Request.Body.Seek(0, SeekOrigin.Begin);
            var ss = JsonConvert.DeserializeObject<Dictionary<string, object>>(body);
            foreach (var item in ss)
            {
                sort.Add(item.Key, item.Value);
            }
        }
        else
        {
            var ss = context.Request.Form;
            foreach (var item in ss)
            {
                sort.Add(item.Key, item.Value);
            }
        }
    }
    foreach (var item in sort)
    {
        global::System.Console.WriteLine($"{item.Key}:{item.Value}");
    }

    // Call the next delegate/middleware in the pipeline.
    await next(context);
});

app.UseOcelot();
app.Run();
