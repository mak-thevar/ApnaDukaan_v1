using ApnaDukaan_v1.BLL.DTOs;
using ApnaDukaan_v1.BLL.Exceptions;
using ApnaDukaan_v1.DAL.Entities;
using ApnaDukaan_v1.DAL.Repositories.Interface;
using AuthenticationAndAuthorizationPOC.BLL;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ApnaDukaan_v1.BLL.Services.Impl
{
    public class AuthService : IAuthService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IConfiguration configuration;

        public AuthService(IRepositoryWrapper repositoryWrapper, IConfiguration configuration)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.configuration = configuration;
        }
        public async Task<UserLoginResponseDTO> ValidateUser(UserLoginRequestDTO userLoginDTO)
        {
            var userInfo = (await this.repositoryWrapper.UserRepository.GetByCondition(x=>x.Username == userLoginDTO.Username)).FirstOrDefault();
            if (userInfo is null)
            {
                throw new LoginException("Invalid user", "Invalid username or password");
            }

            var passwordVerificationResult = new PasswordHasher<object>().VerifyHashedPassword(null, userInfo.PasswordHash, userLoginDTO.Password);

            if(passwordVerificationResult == PasswordVerificationResult.Success)
            {
                var userLoginResponse = new UserLoginResponseDTO
                {
                    Email = userInfo.Email,
                    FullName = $"{userInfo.FirstName} {userInfo.LastName}",
                    JwtToken = JWTHelper.GenerateToken(configuration, new Dictionary<string, string>
                    {
                        { ClaimTypes.Email, userInfo.Email },
                        { ClaimTypes.NameIdentifier, userInfo.Username },
                        { ClaimTypes.DateOfBirth, Convert.ToString(userInfo?.Dob) ?? "" },
                    })
                };
                return userLoginResponse;
            }

            throw new LoginException("Invalid user", "Invalid username or password");

        }
    }
}
