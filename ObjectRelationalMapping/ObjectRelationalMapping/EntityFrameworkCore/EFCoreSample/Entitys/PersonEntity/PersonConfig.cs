using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreSample.Entitys.PersonEntity
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable(nameof(Person));

            #region 实体配置

            // //表映射
            // builder.ToTable(nameof(Person))
            //     //排除字段映射
            //     .Ignore(p => p.Age)
            //     //设置主键
            //     .HasKey(p => p.PersonId);
            // //索引
            // builder.HasIndex(p => p.PersonId)
            //     //唯一索引
            //     .IsUnique();
            // //复合索引
            // builder.HasIndex(p => new {p.PersonId, p.Age})
            //     //聚集索引
            //     .IsClustered();
            // //视图映射
            // builder.ToView(nameof(Person));

            #endregion

            #region 属性配置

            // builder.Property(s => s.Name)
            //     //配置列名
            //     .HasColumnName($"{nameof(Person.Name)}s")
            //     //配置列数据类型
            //     .HasColumnType("nvarchar(20)")
            //     //配置长度
            //     .HasMaxLength(50)
            //     //必学的
            //     .IsRequired(true)
            //     //unicode 字符
            //     .IsUnicode(true)
            //     //默认值
            //     .HasDefaultValue("zxc")
            //     //生成列的值
            //     .ValueGeneratedOnAdd();

            #endregion
            
        }
    }
}