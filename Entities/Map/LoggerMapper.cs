using Core.Utilities.Enums;
using Entities.Base;
using Newtonsoft.Json;

namespace Entities.Map
{
    public class LoggerMapper<T>
    {
        public Logger Map(T entity, TransactionType transactionType, string message)
        {
            var jsonObject = JsonConvert.SerializeObject(entity);
            var logger = new Logger
            {
                TransactionType = transactionType,
                Object = jsonObject,
                Exception = message
            };
            return logger;
        }

        public Logger Map(string value, TransactionType transactionType, string message)
        {
            var logger = new Logger
            {
                TransactionType = transactionType,
                Object = value,
                Exception = message
            };

            return logger;
        }
    }
}
