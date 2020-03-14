using Core.DataAccess.Base;
using DataAccess.EntityFramework.Context;
using DataAccess.Interface;
using Entities.Dto;

namespace DataAccess.EntityFramework.Base
{
    public class EntityFrameworkProductDataAccess : BaseRepository<Product, DataBaseContext>, IProductDataAccess
    {

    }
}
