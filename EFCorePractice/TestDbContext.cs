using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePractice
{
    public class TestDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        //配置连接字符串
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
