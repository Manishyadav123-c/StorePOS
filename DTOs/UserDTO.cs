namespace StorePOS.API.DTOs
{
    public class UserDTO
    {
        public Guid UserGuid { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
    }
}
