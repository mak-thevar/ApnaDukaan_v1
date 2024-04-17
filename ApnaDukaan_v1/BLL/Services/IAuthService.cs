using ApnaDukaan_v1.BLL.DTOs;
using ApnaDukaan_v1.DAL.Entities;

namespace ApnaDukaan_v1.BLL.Services
{
    public interface IAuthService
    {
        Task<UserLoginResponseDTO> ValidateUser(UserLoginRequestDTO userLoginDTO);
    }
}
