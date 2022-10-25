﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Word_puzzle.IServices;
using Word_puzzle.ITools;
using Word_puzzle.Models;
using Word_puzzle.Services;
using Word_puzzle.Tools;

namespace Word_puzzle
{
    class Program
    {
        public static void Main()
        {
            var managerService = Setup();
            managerService.Manager();
        }

        static IGetWordsService Setup()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName)
             .AddJsonFile("appsettings.json");
            var config = builder.Build();
            var serviceProvider = new ServiceCollection()
                 //.AddLogging()
                 .AddTransient<Argument>()
                 .AddTransient<IGetWordsService, ManagerService>()
                 .AddTransient<ILoadTextGetWordsService, LoadTextGetWordsService>()
                 .AddTransient<IFilesInputOutput, FilesInputOutput>()
                 .AddTransient<IUserInputInteraction ,UserInputInteraction >()
                 .Configure<MySettings>(config.GetSection("MySettings"))
                .BuildServiceProvider();

            return serviceProvider.GetService<IGetWordsService>();
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

