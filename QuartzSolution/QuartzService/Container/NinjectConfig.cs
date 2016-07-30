using Ninject;
using Ninject.Modules;
using QuartzService.Services;

namespace QuartzService.Container
{
    class NinjectConfig : NinjectModule
    {
        private static readonly IKernel _kernel = new StandardKernel();

        public static IKernel Container { get { return _kernel; } }

        public static void Initialize()
        {
            Container.Bind<ILogService>().To<LogService>();
        }

        public override void Load()
        {
        }
    }
}
