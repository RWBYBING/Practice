using EFCoreRelationshipSettingPractice.EFClass;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelationshipSettingPractice.EFClassConfiguration
{
    class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        //用FluentAPI配置
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("T_Comments");
            //一对多关系配置,<Article>为实体类型，c.Article为属性
            builder.HasOne<Article>(c => c.Article).WithMany(a => a.Comments).IsRequired();
            builder.Property(c => c.Message).IsRequired().IsUnicode();
        }
    }
}
