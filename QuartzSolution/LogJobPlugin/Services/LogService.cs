using Common.Logging;
using System;
using System.Diagnostics;

namespace LogJobPlugin.Services
{
    public class LogService : ILogService
    {
        private readonly ILog _log = LogManager.GetLogger<LogService>();

        public void Debug(string message)
        {
            try
            {
                var callingTypeName = GetCallingType().Name;
                _log.Debug($"[From {callingTypeName}] => {message}");
            }
            catch (Exception ex)
            {
                Error(message, ex);
            }
        }

        public void Error(string message, Exception ex)
        {
            var callingTypeName = GetCallingType().Name;
            _log.Error(message, ex);
        }

        private Type GetCallingType()
        {
            // Retrieve 2nd position from the calling stack
            const int frameStack = 2;

            var callingMethod = new StackTrace().GetFrame(frameStack).GetMethod();
            return callingMethod.ReflectedType;
        }
    }
}
