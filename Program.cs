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
            //��program����Ϳ���ֱ��������Ihostserver����Ʋ����ֶ���ͣ��ֻ��ֱ������
            //�����2�ַ�ʽ���ǿ��Ե�
            services.AddHostedService<DerivedBackgroundPrinter>();
            services.AddHostedService<BackgroundPrinter>();
        }
        );

    }
}
