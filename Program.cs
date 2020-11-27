using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BackgroundTask.Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
        .ConfigureServices(services =>
            {
            //在program这里就可以直接启动，Ihostserver的设计不能手动启停，只能直接启动
            //下面的2种方式都是可以的
            services.AddHostedService<DerivedBackgroundPrinter>();
            services.AddHostedService<BackgroundPrinter>();
        }
        );

    }
}
