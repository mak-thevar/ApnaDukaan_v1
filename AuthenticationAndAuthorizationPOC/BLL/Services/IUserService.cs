using AuthenticationAndAuthorizationPOC.BLL.DTOs;

namespace AuthenticationAndAuthorizationPOC.BLL.Services
{
    public interface IUserService
    {
        Task<LoginResponseDTO?> IsValidUser(LoginRequestDTO loginRequestDTO);
    }

    public class UserService : IUserService
    {
        const string CUST_USERNAME = "CUSTOMER";
        const string USERNAME = "ADMIN";
        const string PASSWORD = "mypassw@rd";

        public Task<LoginResponseDTO?> IsValidUser(LoginRequestDTO loginRequestDTO)
        {
            //use the repository to validate the username and password from the database.

            
            if((loginRequestDTO.Username ==  USERNAME || loginRequestDTO.Username == CUST_USERNAME) && loginRequestDTO.Password == PASSWORD)
            {
                

                return Task.FromResult<LoginResponseDTO?>(new LoginResponseDTO
                {
                    RoleId = 1,
                    RoleName = loginRequestDTO.Username == CUST_USERNAME ? "Customer" : "Admin",
                    Username = USERNAME,
                    UserId = 101
                });
            }

            return Task.FromResult<LoginResponseDTO?>(null);

        }
    }
}
