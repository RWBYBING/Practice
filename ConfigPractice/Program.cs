using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


/* 手动读取配置 */
ConfigurationBuilder configBuilder = new ConfigurationBuilder();
//添加待解析的配置文件
configBuilder.AddJsonFile("config.json", optional: false, reloadOnChange: false);
//IConfigurationRoot对象可以读取配置项
IConfigurationRoot config = configBuilder.Build();
string name = config["name"];
Console.WriteLine($"name={name}");
string proxyAddress = config.GetSection("proxy:address").Value;
Console.WriteLine($"Address:{proxyAddress}");


Console.WriteLine("____________________________________________");

/* 选项方式读取配置 */

//注入服务
ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
IConfigurationRoot configuration = configurationBuilder.Build();
ServiceCollection services = new ServiceCollection();
//注册与选项相关的服务
services.AddOptions().Configure<DbSettings>(e => configuration.GetSection("DB").Bind(e))
    .Configure<SmtpSettings>(e => configuration.GetSection("Smtp").Bind(e));
//注册瞬态服务
services.AddTransient<Demo>();
using(var sp = services.BuildServiceProvider())
{
    while (true)
    {
        using(var scope = sp.CreateScope())
        {
            var spScope = scope.ServiceProvider;
            var demo = spScope.GetRequiredService<Demo>();
            demo.Test();
        }
        Console.ReadKey();
    }
}


//定义两个模型类
public class DbSettings
{
    public string DbType { get; set; }
    public string ConnectionString { get; set; }
}
public class SmtpSettings
{
    public string Server { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}

//用于测试读取配置的Demo类
class Demo
{
    private readonly IOptionsSnapshot<DbSettings> _optionsSnapshot;
    private readonly IOptionsSnapshot<SmtpSettings> _smtpSettingsSnapshot;
    //通过构造方法注入两个服务，通过IOptionSnapshot<T>的Value属性获取DbSettings,SmtpSettings等具体配置对象的值
    public Demo(IOptionsSnapshot<DbSettings> optionsSnapshot, IOptionsSnapshot<SmtpSettings> smtpSettingsSnapshot)
    {
        _optionsSnapshot = optionsSnapshot;
        _smtpSettingsSnapshot = smtpSettingsSnapshot;
    }

    public void Test()
    {
        var db = _optionsSnapshot.Value;
        Console.WriteLine($"数据库:{db.DbType},{db.ConnectionString}");
        var smtp = _smtpSettingsSnapshot.Value;
        Console.WriteLine($"Smtp:{smtp.Server},{smtp.UserName},{smtp.Password}");
    }
}



