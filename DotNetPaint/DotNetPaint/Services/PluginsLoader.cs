using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DotNetPaint.Common;
using System.Linq;

namespace DotNetPaint.Services
{
    public static class PluginsLoader
    {
        private const string PluginsDirectory = "Plugins";

        public static IEnumerable<IPlugin> Load()
         {
             if (!Directory.Exists(PluginsDirectory))
                return new List<IPlugin>();

             return Directory.EnumerateFiles(PluginsDirectory).Where(fileName => fileName.EndsWith(".dll"))
                 .Select(fileName => Assembly.LoadFile(Path.GetFullPath(fileName)))
                 .Select(assembly => assembly.GetTypes().Where(type => type.GetInterfaces().Any(i => i == typeof(IPlugin))))
                 .SelectMany(pluginsTypes => pluginsTypes.Select(type => Activator.CreateInstance(type) as IPlugin).ToList());
         }
    }
}