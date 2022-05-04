using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace TodoAppMongodb.MongoDB;

[ConnectionStringName("Default")]
public class TodoAppMongodbMongoDbContext : AbpMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        //builder.Entity<YourEntity>(b =>
        //{
        //    //...
        //});
        modelBuilder.Entity<TodoItem>(b =>
        {
            b.CollectionName = "TodoItems";
        });
    }
    public IMongoCollection<TodoItem> TodoItems => Collection<TodoItem>();
}
