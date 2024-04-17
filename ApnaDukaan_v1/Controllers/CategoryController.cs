using ApnaDukaan_v1.DAL.Entities;
using ApnaDukaan_v1.DAL.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApnaDukaan_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;

        public CategoryController(IRepositoryWrapper repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.repository.CategoryRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Category category)
        {
            var result = await this.repository.CategoryRepository.CreateAsync(category);
            return Ok(result);
        }
    }
}
