using ApnaDukaan_v1.BLL.DTOs;
using ApnaDukaan_v1.DAL.Entities;
using ApnaDukaan_v1.DAL.Repositories;
using AutoMapper;

namespace ApnaDukaan_v1.BLL.Services
{
    public interface IBaseService<TRequestDTO, TResponseDTO>
    {
        Task<IEnumerable<TResponseDTO>> GetAll();
        Task<TResponseDTO> GetById(int id);
        Task<TResponseDTO> Add(TRequestDTO requestDTO);

        Task<bool> Delete(int id);

        Task<TResponseDTO> Update(TRequestDTO requestDTO);
    }

    public interface IProductService : IBaseService<ProductRequestDTO, ProductResponseDTO>
    {
    }

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
            var product = mapper.Map<Product>(requestDTO);
            var productResponse = await this.repositoryWrapper.ProductRepository.CreateAsync(product);
            await this.repositoryWrapper.SaveAsync();
            var result = mapper.Map<ProductResponseDTO>(productResponse);
            return result;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductResponseDTO>> GetAll()
        {
            var productList = await this.repositoryWrapper.ProductRepository.GetAllAsync("Category");
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
