using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Voluntario.IoCManager.Tests
{
    public abstract class BaseTestClass
    {
        protected IConfiguration Config { get; }

        public BaseTestClass()
        {
            var configurationBuilder = new ConfigurationBuilder();
            string path = "";
            path = Path.Combine(Directory.GetCurrentDirectory(), "appSettings.json");
            Console.WriteLine("===================================" + File.Exists(path).ToString());
            if (File.Exists(path))
            {
                Console.WriteLine("************************** PATH: " + path + "******************************************************");
                configurationBuilder.AddJsonFile(path, false);
                var root = configurationBuilder.Build();
                Config = root;
            }
            else
            {
                Console.WriteLine(path + " NOOOOOOOOT EXXXISTS");
                throw new FileNotFoundException(path);
            }
        }
    }
}
