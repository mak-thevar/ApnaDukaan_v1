namespace ApnaDukaan_v1.BLL.DTOs
{
    public class UserLoginResponseDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; } = null!;

        public string JwtToken { get; set; }
    }
}
