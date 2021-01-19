using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductStore.Domain.Interfaces;
using ProductStore.Domain.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductStore.Api.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(ILogger<ProductsController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _unitOfWork.ProductRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Product> Get(int id) => await _unitOfWork.ProductRepository.Get(id);

        [HttpPost]
        public IActionResult Post(Product newProduct)
        {
            _unitOfWork.ProductRepository.Add(newProduct);
            _unitOfWork.Commit();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Product product)
        {
            _unitOfWork.ProductRepository.Update(product);
            _unitOfWork.Commit();
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _unitOfWork.ProductRepository.Delete(id);
            _unitOfWork.Commit();
            return Ok();
        }
    }
}
