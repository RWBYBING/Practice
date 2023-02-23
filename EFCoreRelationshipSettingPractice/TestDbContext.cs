using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFCoreRelationshipSettingPractice.EFClassConfiguration;
using EFCoreRelationshipSettingPractice.EFClass;

namespace EFCoreRelationshipSettingPractice
{
    class TestDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connStr = "Server = DESKTOP-P1LT7DC\\SQLEXPRESS;DataBase = EFCorePracticeDemo;Trusted_Connection = True;TrustServerCertificate = True";
            optionsBuilder.UseSqlServer(connStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
