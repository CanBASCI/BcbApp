using Business.Contants;
using Business.Interface;
using Core.Utilities.Enums;
using Core.Utilities.Results;
using Core.Utilities.Results.Impl;
using Core.Utilities.Results.Interface;
using DataAccess.Interface;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Impl
{
    public class ProductService : IProductService
    {
        private readonly IProductDataAccess productDataAccess;

        public ProductService(IProductDataAccess productDataAccess)
        {
            this.productDataAccess = productDataAccess;
        }

        public IDataResult<Product> GetById(int Id)
        {
            try
            {
                return new SuccessDataResult<Product>(productDataAccess.Get(p => p.Id == Id));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Product>(null, ex.Message);
            }
        }

        public IDataResult<List<Product>> GetList()
        {
            try
            {
                return new SuccessDataResult<List<Product>>(productDataAccess.GetList().ToList());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Product>>(null, ex.Message);
            }
        }

        public IDataResult<List<Product>> GetListByProductName(string productName)
        {
            try
            {
                return new SuccessDataResult<List<Product>>(productDataAccess.GetList(p => p.ProductName == productName)
                    .ToList());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Product>>(null, ex.Message);
            }
        }

        public IDataResult<List<Product>> GetListByProductStatus(char productStatus)
        {
            try
            {
                return new SuccessDataResult<List<Product>>(productDataAccess.GetList(p => p.Status == productStatus).ToList());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Product>>(null, ex.Message);
            }
        }

        public IDataResult<List<Product>> GetListByProductType(ProductType productType)
        {
            try
            {
                return new SuccessDataResult<List<Product>>(productDataAccess.GetList(p => p.ProductType == productType).ToList());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Product>>(null, ex.Message);
            }
        }

        public IResult Add(Product product)
        {
            try
            {
                productDataAccess.Add(product);
            }
            catch (Exception ex)
            {
                var builder = new StringBuilder();
                return new ErrorResult(false, builder.Append(ex.Message).Append(ex.InnerException.Message).ToString());
            }
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            try
            {
                productDataAccess.Delete(product);
            }
            catch (Exception ex)
            {
                var builder = new StringBuilder();
                return new ErrorResult(false, builder.Append(ex.Message).Append(ex.InnerException.Message).ToString());
            }
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IResult Update(Product product)
        {
            try
            {
                productDataAccess.Updated(product);
            }
            catch (Exception ex)
            {
                var builder = new StringBuilder();
                return new ErrorResult(false, builder.Append(ex.Message).Append(ex.InnerException.Message).ToString());
            }
            return new SuccessResult(Messages.ProductAdded);
        }
    }
}
