using ServiceInterface;

namespace ServiceAccomplish2
{
    public class EnService : IMyService
    {
        public void SayHello()
        {
            Console.WriteLine("Hello");
        }
    }
}