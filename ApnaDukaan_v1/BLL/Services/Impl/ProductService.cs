using ApnaDukaan_v1.BLL.DTOs;
using ApnaDukaan_v1.BLL.Exceptions;
using ApnaDukaan_v1.DAL.Entities;
using ApnaDukaan_v1.DAL.Repositories.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApnaDukaan_v1.BLL.Services.Impl
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public ProductService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        public async Task<ProductResponseDTO> Add(ProductRequestDTO requestDTO)
        {
            try
            {
                var product = mapper.Map<Product>(requestDTO);
                var productResponse = await repositoryWrapper.ProductRepository.CreateAsync(product);
                await repositoryWrapper.SaveAsync();
                var result = mapper.Map<ProductResponseDTO>(productResponse);
                return result;
            }
            catch (DbUpdateException ex)
            {
                if(ExceptionHelper.IsForeignKeyConstraintViolation(ex))
                {
                    throw new BusinessException("Foreign key error", "A foreign key constraint violation occurred.");
                }
                throw;
            }
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductResponseDTO>> GetAll()
        {
            var productList = await repositoryWrapper.ProductRepository.GetAllAsync("Category");
            var productResponseDTO = mapper.Map<IEnumerable<ProductResponseDTO>>(productList);
            return productResponseDTO;
        }

        public Task<ProductResponseDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponseDTO> Update(ProductRequestDTO requestDTO)
        {
            throw new NotImplementedException();
        }
    }
}
