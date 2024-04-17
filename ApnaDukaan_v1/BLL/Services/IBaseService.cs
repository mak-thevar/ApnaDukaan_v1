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
}
