using System;

namespace QuartzService.Services
{
    interface ILogService
    {
        void Debug(string message);
        void Error(string message, Exception ex);
    }
}
