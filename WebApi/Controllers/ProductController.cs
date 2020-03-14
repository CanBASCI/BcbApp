using System;
using Business.Base.Interface;
using Business.Interface;
using Entities.Dto;
using Entities.Map;
using Microsoft.AspNetCore.Mvc;
using Core.Utilities.Enums;
using Entities.Base;
using WebApi.Contants;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILoggerService loggerService;
        private readonly IProductService productService;

        public ProductController(IProductService productService, ILoggerService loggerService)
        {
            this.productService = productService;
            this.loggerService = loggerService;
        }

        [HttpGet(nameof(Messages.GetList))]
        public IActionResult GetList() {
            var result = productService.GetList();

            if (result.IsSuccess)
            {
                loggerService.Add(new LoggerMapper<Product>().Map(string.Empty, TransactionType.Select, null));
                return Ok(result.Data);
            }
            loggerService.Add(new LoggerMapper<Product>().Map(string.Empty, TransactionType.Exception, result.Message));
            return BadRequest(result.Message);
        }

        [HttpGet(nameof(Messages.GetById))]
        public IActionResult GetById(int id)
        {
            var result = productService.GetById(id);

            if (result.IsSuccess)
            {
                loggerService.Add(new LoggerMapper<Product>().Map(id.ToString(), TransactionType.Select, null));
                return Ok(result.Data);
            }
            loggerService.Add(new LoggerMapper<Product>().Map(id.ToString(), TransactionType.Exception, result.Message));
            return BadRequest(result.Message);
        }

        [HttpGet(nameof(Messages.GetListByProductName))]
        public IActionResult GetListByProductName(string productName)
        {
            var result = productService.GetListByProductName(productName);

            if (result.IsSuccess)
            {
                loggerService.Add(new LoggerMapper<Product>().Map(productName, TransactionType.Select, null));
                return Ok(result.Data);
            }
            loggerService.Add(new LoggerMapper<Product>().Map(productName, TransactionType.Exception, result.Message));

            return BadRequest(result.Message);
        }

        [HttpGet(nameof(Messages.GetListByProductType))]
        public IActionResult GetListByProductType(ProductType productType)
        {
            var result = productService.GetListByProductType(productType);

            if (result.IsSuccess)
            {
                loggerService.Add(new LoggerMapper<Product>().Map(productType.ToString(), TransactionType.Select, null));
                return Ok(result.Data);
            }
            loggerService.Add(new LoggerMapper<Product>().Map(productType.ToString(), TransactionType.Exception, result.Message));

            return BadRequest(result.Message);
        }

        [HttpGet(nameof(Messages.GetListByProductStatus))]
        public IActionResult GetListByProductStatus(char productStatus)
        {
            var result = productService.GetListByProductStatus(productStatus);

            if (result.IsSuccess)
            {
                loggerService.Add(new LoggerMapper<Product>().Map(productStatus.ToString(), TransactionType.Select, null));
                return Ok(result.Data);
            }
            loggerService.Add(new LoggerMapper<Product>().Map(productStatus.ToString(), TransactionType.Exception, result.Message));

            return BadRequest(result.Message);
        }

        [HttpPost(nameof(Messages.Add))]
        public IActionResult Add(Product product)
        {

            var result = productService.Add(product);

            if (result.IsSuccess)
            {
                loggerService.Add(new LoggerMapper<Product>().Map(product, TransactionType.Insert, null));
                return Ok(result.Message);
            }

            loggerService.Add(new LoggerMapper<Product>().Map(product, TransactionType.Exception, result.Message));

            return BadRequest(result.Message);
        }

        [HttpPost(nameof(Messages.Update))]
        public IActionResult Update(Product product)
        {
            var result = productService.Update(product);

            if (result.IsSuccess)
            {
                loggerService.Add(new LoggerMapper<Product>().Map(product, TransactionType.Update, null));
                return Ok(result.Message);
            }

            loggerService.Add(new LoggerMapper<Product>().Map(product, TransactionType.Exception, result.Message));

            return BadRequest(result.Message);
        }

        [HttpPost(nameof(Messages.Delete))]
        public IActionResult Delete(Product product)
        {
            var result = productService.Delete(product);

            if (result.IsSuccess)
            {
                loggerService.Add(new LoggerMapper<Product>().Map(product, TransactionType.Delete, null));
                return Ok(result.Message);
            }

            loggerService.Add(new LoggerMapper<Product>().Map(product, TransactionType.Exception, result.Message));

            return BadRequest(result.Message);
        }

        [HttpPost(nameof(Messages.Log))]
        public IActionResult Log(Logger log)
        {
            try
            {
                loggerService.Add(log);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}