namespace AuthenticationAndAuthorizationPOC.BLL.DTOs
{
    public class LoginResponseDTO
    {
        public string Username { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public string LoginToken { get; set; }

    }
}
