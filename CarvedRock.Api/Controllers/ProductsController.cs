using System.Collections.Generic;
using CarvedRock.Api.ApiModels;
using CarvedRock.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;

namespace CarvedRock.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductLogic _productLogic;

        public ProductsController(IProductLogic productLogic)
        {
            _productLogic = productLogic;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts(string category = "all")
        {
            //Log.Information("Starting controller action GetProdicts for {category}", category);
            Log.ForContext("Category", category)
                .Information("Starting controller action GetProdicts");

            return _productLogic.GetProductsForCategory(category);
        }
    }
}