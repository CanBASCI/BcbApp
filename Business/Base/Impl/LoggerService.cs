using Business.Base.Interface;
using Core.Utilities.Converter;
using Core.Utilities.Stream;
using DataAccess.Interface;
using Entities.Base;
using Microsoft.Extensions.Logging;
using System;
using System.Text;

namespace Business.Base.Impl
{
    public class LoggerService : ILoggerService
    {
        private readonly ILoggerDataAccess loggerDataAccess;
        public LoggerService(ILoggerDataAccess loggerDataAccess)
        {
            this.loggerDataAccess = loggerDataAccess;
        }

        public void Add(Logger logger)
        {
            try
            {
                loggerDataAccess.Add(logger);
            }
            catch(Exception ex)
            {
                var builder = new StringBuilder();
                var exceptionMessage = builder.Append(ex.Message).Append(ex.InnerException);
                logger.Exception = exceptionMessage.ToString();
                Log(logger, ex);
                throw new Exception(logger.Exception);
            }
        }

        public void Log<TState>(TState state, Exception exception)
        {
            StreamFile.Write(StateConverter.GetLogFor(state));
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnable(LogLevel logLevel)
        {
            return true;
        }
    }
}
