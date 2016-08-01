using System;

namespace QuartzService.Services
{
    public interface ILogService
    {
        void Debug(string message);
        void Error(string message, Exception ex);
    }
}
