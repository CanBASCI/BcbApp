using Core.Utilities.Logger.Interface;
using Core.Utilities.Results;
using Entities.Base;

namespace Business.Base.Interface
{
    public interface ILoggerService : ILogger
    {
        void Add(Logger logger);
    }
}
