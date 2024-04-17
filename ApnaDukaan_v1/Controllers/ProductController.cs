using ApnaDukaan_v1.BLL.DTOs;
using ApnaDukaan_v1.BLL.Exceptions;
using ApnaDukaan_v1.BLL.Services;
using ApnaDukaan_v1.DAL.Entities;
using ApnaDukaan_v1.DAL.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApnaDukaan_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductController(IServiceManager serviceManager, IMapper mapper)
        {
            this.productService = serviceManager.ProductService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await this.productService.GetAll();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductRequestDTO productDTO)
        {
            try
            {

                var result = await this.productService.Add(productDTO);
                return Ok(result);
            }
            catch (BusinessException ex)
            {
                return Problem(
                     title: ex.Title,
                     detail: ex.Message,
                     statusCode: 400);
            }
        }
    }
}
