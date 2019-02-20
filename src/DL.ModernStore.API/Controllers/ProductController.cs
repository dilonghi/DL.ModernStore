using DL.ModernStore.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DL.ModernStore.API.Controllers
{
    //[Route("api")]
    public class ProductController : Controller
    {
        private readonly ICustomerRepository _productRepository;

        public ProductController(ICustomerRepository productRepository)
        {
            _productRepository = productRepository;
        }


        [HttpGet]
        [Route("v1/products")]
        public IActionResult Get()
        {
            return Ok(_productRepository.Get());
        }

        [HttpGet]
        [Route("v2/products/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok($"Produto { id }!");
        }

        [HttpGet]
        [Route("v1/products/{number}")]
        public IActionResult Get(string number)
        {
            return Ok($"Produto { number }!");
        }

        [HttpPost]
        [Route("v1/products/insert")]
        public IActionResult Post()
        {
            return Ok("inserindo um produto!");
        }

        [HttpPost]
        [Route("v1/products/update/{id}")]
        public IActionResult Put(Guid id)
        {
            return Ok("inserindo um produto!");
        }

        [HttpPost]
        [Route("v1/products/delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok("inserindo um produto!");
        }
    }
}
