using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Utilities.Tools;
/// <summary>
/// Get config, instantiate objects accordingly and start running.
/// </summary>

namespace Utilities.Configs
{



    /// <summary>
    /// Get the needed Configuration
    /// </summary>
    /// <see cref="https://docs.microsoft.com/en-us/dotnet/core/extensions/options#bind-hierarchical-configuration"/>
    public static class Configuaration
    {
        private static readonly IConfigurationRoot _configRoot;
        static Configuaration()
        {
            string? baseDir = AppDomain.CurrentDomain.BaseDirectory;
            Trace.Assert(baseDir != null);
            if (baseDir == null)
            {
                throw new InvalidOperationException(
                    $"the baseDir is null at {ToolFunctions.FILE()}:{ToolFunctions.LINE()}");
            }

            var physicalFileProvider = new PhysicalFileProvider(baseDir);
            var configBuilder = new ConfigurationBuilder();
            configBuilder.Sources.Clear();

            _configRoot = configBuilder
                .AddJsonFile(physicalFileProvider, "appsettings.json", false, true)
                .Build();
        }



        public static T Get<T>(string nameoftype) where T : class, new()
        {
            return _configRoot.GetSection(nameoftype).Get<T>();

        }





    }

}
