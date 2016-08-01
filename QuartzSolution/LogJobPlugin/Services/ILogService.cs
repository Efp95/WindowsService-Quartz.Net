using System;

namespace LogJobPlugin.Services
{
    public interface ILogService
    {
        void Debug(string message);
        void Error(string message, Exception ex);
    }
}
