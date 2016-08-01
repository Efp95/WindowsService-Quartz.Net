﻿using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;

namespace QuartzService.Container
{
    class NinjectConfig : NinjectModule
    {
        private static readonly IKernel _kernel = new StandardKernel();

        public static IKernel Container { get { return _kernel; } }

        public static void Initialize()
        {
            _kernel.Bind(k =>
            {
                foreach (var assembly in LoadDirectoryAssemblies())
                {
                    k.From(assembly)
                      .Select(type => !type.IsAbstract)
                      .BindAllInterfaces();
                }
            });
        }

        public override void Load()
        {
        }

        private static IEnumerable<Assembly> LoadDirectoryAssemblies()
        {
            const string searchCriteria = "*.dll";
            //string pluginsFolder = ConfigurationManager.AppSettings[nameof(pluginsFolder)];
            string pluginsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins");

            if (!Directory.Exists(pluginsPath))
                yield break;

            foreach (var dllPath in Directory.GetFiles(pluginsPath, searchCriteria, SearchOption.TopDirectoryOnly))
            {
                if (!dllPath.EndsWith("Quartz.dll"))
                {
                    yield return Assembly.LoadFile(dllPath);
                }
            }

        }
    }
}
