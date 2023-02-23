using EFCorePractice;

namespace EFCore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //using释放资源
            using TestDbContext db = new TestDbContext();
            var b1 = new Book
            {
                AuthorName = "A",
                Title = "B",
                Price = 20.0,
                PubTime = DateTime.Now,
            };
            //加入逻辑数据库
            db.Books.Add(b1);
            //用异步方法同步到实际数据库
            await db.SaveChangesAsync();
        }
    }
}