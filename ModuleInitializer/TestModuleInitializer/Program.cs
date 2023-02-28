using ServiceAccomplish;
using ServiceAccomplish2;
using ServiceInterface;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Zack.Commons;

ServiceCollection services = new ServiceCollection();
var assemblies = ReflectionHelper.GetAllReferencedAssemblies();
services.RunModuleInitializers(assemblies);
using var sp = services.BuildServiceProvider();
var items = sp.GetServices<IMyService>();
foreach (var item in items)
{
    item.SayHello();
}
