using Core.Utilities.Enums;
using Core.Utilities.Results;
using Core.Utilities.Results.Interface;
using Entities.Dto;
using System.Collections.Generic;

namespace Business.Interface
{
    public interface IProductService
    {
        IDataResult<Product> GetById(int Id);
        IDataResult<List<Product>> GetList();
        IDataResult<List<Product>> GetListByProductName(string productName);
        IDataResult<List<Product>> GetListByProductType(ProductType productType);
        IDataResult<List<Product>> GetListByProductStatus(char productStatus);
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
    }
}
