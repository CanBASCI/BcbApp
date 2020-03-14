using Core.Entities;
using Core.Utilities.Enums;
using System;

namespace Entities.Base
{
    public class Logger : IEntity
    {
        public Logger()
        {
            Date = DateTime.Now;
        }

        public int Id { get; set; }
        //JSON
        public string Object { get; set; }
        public TransactionType TransactionType { get; set; }

        public string Exception { get; set; }
        public DateTime Date { get; private set; }
    }
}
