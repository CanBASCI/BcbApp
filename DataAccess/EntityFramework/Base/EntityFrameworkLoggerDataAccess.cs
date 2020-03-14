using Core.DataAccess.Base;
using DataAccess.EntityFramework.Context;
using DataAccess.Interface;
using Entities.Base;

namespace DataAccess.EntityFramework.Base
{
    public class EntityFrameworkLoggerDataAccess : BaseRepository<Logger, DataBaseContext>, ILoggerDataAccess
    {

    }
}
