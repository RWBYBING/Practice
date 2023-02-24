using EFCoreRelationshipSettingPractice.EFClass;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipSettingPractice
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //数据插入
/*            Article a1 = new Article();
            a1.Title = "A";
            a1.Content = "AAAAAA";
            Comment c1 = new Comment() { Message = "123" };
            Comment c2 = new Comment() { Message = c1.Message };
            Comment c3 = new Comment() { Message = "牛牛" };
            a1.Comments.Add(c1);
            a1.Comments.Add(c2);
            a1.Comments.Add(c3);
            using TestDbContext dbContext = new TestDbContext();
            dbContext.Articles.Add(a1);
            await dbContext.SaveChangesAsync();*/

            //获取数据
            using TestDbContext testDbContext = new TestDbContext();
            Article a = testDbContext.Articles.Include(a => a.Comments).Single(a => a.Id == 1);
            Console.WriteLine(a.Title);
            foreach (Comment c in a.Comments)
            {
                Console.WriteLine(c.Id + ":" + c.Message);
            }
        }
    }
}
