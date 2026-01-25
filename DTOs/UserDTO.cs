namespace StorePOS.API.DTOs
{
    public class UserDTO
    {
        public Guid UserGuid { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
         public Guid RoleGuid { get; set; }
        public string UserCode { get; set; } = string.Empty;
    }
    public class UserSaveDTO
    {
        public Guid? UserGuid { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public Guid RoleGuid { get; set; }
    }
    public class UserListDTO
{
    public Guid UserGuid { get; set; }
    public string UserCode { get; set; }
    public string UserName { get; set; }
    public Guid RoleGuid { get; set; }
    public string RoleName { get; set; }
    public string RoleCode { get; set; }
}

}
