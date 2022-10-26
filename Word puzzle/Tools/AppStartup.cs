using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using WordPuzzle.IServices;
using WordPuzzle.ITools;
using WordPuzzle.Models;
using WordPuzzle.Services;
using WordPuzzle.Tools;
using WordPuzzle;

namespace Word_puzzle.Tools
{
    public class AppStartup
    {
        public static IManagerService Setup()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName)
             .AddJsonFile("appsettings.json");

            var config = builder.Build();

            var serviceProvider = new ServiceCollection()
                 .AddTransient<Argument>() //TODO Add??
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
