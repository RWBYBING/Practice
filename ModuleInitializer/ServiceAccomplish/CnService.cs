using ServiceInterface;

namespace ServiceAccomplish
{
    public class CnService : IMyService
    {
        public void SayHello()
        {
            Console.WriteLine("你好");
        }
    }
}