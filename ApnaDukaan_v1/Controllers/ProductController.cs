using ApnaDukaan_v1.BLL.DTOs;
using ApnaDukaan_v1.BLL.Services;
using ApnaDukaan_v1.DAL.Entities;
using ApnaDukaan_v1.DAL.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApnaDukaan_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService  productService;
        private readonly IMapper mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService= productService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var products = await this.productService.GetAll();

            var result = mapper.Map<IEnumerable<ProductResponseDTO>>(products);


            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductRequestDTO productDTO)
        {
            try
            {
              
                var result = await this.productService.Add(productDTO);
                return Ok(result);
            }
            catch (DbUpdateException dbex)
            {
                ModelState.AddModelError("error", $"Category with id {productDTO.CategoryId} not found.");
                return BadRequest(ModelState);
                
                //ModelState.AddModelError("Error", $"Category with id {productDTO.CategoryId} not found.");
                //return BadRequest(ModelState);


                //return Problem(title: "Error", detail: $"Category with id {productDTO.CategoryId} not found.", statusCode: 400);
            }
        }
    }
}
