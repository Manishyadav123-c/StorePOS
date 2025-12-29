namespace StorePOS.API.DTOs
{
    public class UserSaveDTO
    {
        public Guid? UserGuid { get; set; }   // NULL → Insert
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Guid RoleGuid { get; set; }
    }
}
