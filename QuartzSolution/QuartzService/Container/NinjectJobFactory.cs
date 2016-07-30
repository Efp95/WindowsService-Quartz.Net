using Common.Logging;
using Ninject;
using Ninject.Syntax;
using Quartz;
using Quartz.Spi;
using System;

namespace QuartzService.Container
{
    class NinjectJobFactory : IJobFactory
    {
        readonly IResolutionRoot _resolutionRoot;
        readonly ILog _log = LogManager.GetLogger<NinjectJobFactory>();

        public NinjectJobFactory(IResolutionRoot resolutionRoot)
        {
            _resolutionRoot = resolutionRoot;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            try
            {
                return _resolutionRoot.Get(bundle.JobDetail.JobType) as IJob;
            }
            catch (Exception ex)
            {
                _log.Error($"Problem while instantiating job '{bundle.JobDetail.Key}' from the NinjectJobFactory.", ex);
                throw;
            }
        }

        public void ReturnJob(IJob job)
        {
            _resolutionRoot.Release(job);
        }
    }
}
