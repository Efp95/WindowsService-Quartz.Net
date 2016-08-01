using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
                // Will be removed when moving Jobs to another assembly
                k.From(Assembly.GetExecutingAssembly())
                       .Select(type => !type.IsAbstract)
                       .BindAllInterfaces();

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
            string pluginsFolder = ConfigurationManager.AppSettings[nameof(pluginsFolder)];
            string pluginsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pluginsFolder);

            if (!Directory.Exists(pluginsPath))
                yield break;

            foreach (var dll in Directory.GetFiles(pluginsPath, searchCriteria, SearchOption.TopDirectoryOnly))
            {
                yield return Assembly.LoadFile(dll);
            }

        }
    }
}
