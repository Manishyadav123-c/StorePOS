public class RoleDTO{
 public Guid RoleGuid{get;set;}
 public string RoleName{get;set;} = string.Empty;
 public string RoleCode{get;set;} = string.Empty;
}
public class RoleSaveDTO
{
    public Guid? RoleGuid { get; set; }
    public string RoleName { get; set; }
}
