using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCoreRelationshipSettingPractice.EFClass;

namespace EFCoreRelationshipSettingPractice.EFClassConfiguration
{
    class ArticleConfig : IEntityTypeConfiguration<Article>
    {
        //用FluentAPI配置
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("T_Articles");
            builder.Property(a => a.Title).IsRequired().IsUnicode().HasMaxLength(255);
            builder.Property(a => a.Content).IsRequired().IsUnicode();
        }
    }
}
