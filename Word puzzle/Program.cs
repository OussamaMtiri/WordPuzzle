using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System.IO;
using WordPuzzle.IServices;
using WordPuzzle.ITools;
using WordPuzzle.Models;
using WordPuzzle.Services;
using WordPuzzle.Tools;

namespace WordPuzzle
{
    class Program
    {
        public static void Main()
        {
            var managerService = Setup();
            managerService.GetWords();
        }

        static IManagerService Setup()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName)
             .AddJsonFile("appsettings.json");
            var config = builder.Build();
            var serviceProvider = new ServiceCollection()           
                 .AddTransient<Argument>()
                 .AddTransient<IManagerService, ManagerService>()
                 .AddTransient<ILoadTextGetWordsService, LoadTextGetWordsService>()
                 .AddTransient<IFilesInputOutput, FilesInputOutput>()
                 .AddTransient<IUserInputInteraction, UserInputServices>()
                 .AddTransient<ExceptionHandling>()

                 .Configure<MySettings>(config.GetSection("MySettings"))
            .BuildServiceProvider();

            return serviceProvider.GetService<IManagerService>();
        }
    }
}



























//    static void Main(string[] args)
//    {
//        //var builder = new ConfigurationBuilder();
//        //BuildConfig(builder);


//        var host = Host.CreateDefaultBuilder()
//            .ConfigureServices((context, services) =>
//            {
//                //services.AddTransient<IInputOutputService, InputOutputService>();
//            })

//          .Build();

//        var svc = ActivatorUtilities.CreateInstance<InputOutputService>(host.Services);
//        svc.ArgumentsInput();
//    }

//    static void BuildConfig(IConfigurationBuilder builder)
//    {
//        //builder.SetBasePath(Directory.GetCurrentDirectory())
//        //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//        //    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
//        //    .AddEnvironmentVariables();
//    }
//}

