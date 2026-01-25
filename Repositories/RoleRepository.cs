using Dapper;
using StorePOS.API.DTOs;
using StorePOS.API.Helpers;
using System.Data;
using Microsoft.Data.SqlClient;

public class RoleRepository
{
    private readonly DbHelper _db;

    public RoleRepository(DbHelper db)
    {
        _db = db;
    }

    public List<RoleDTO> List()
    {
        using SqlConnection con = _db.GetConnection();
        con.Open(); // ✅ REQUIRED

        return con.Query<RoleDTO>(
            "sp_Role_List",
            commandType: CommandType.StoredProcedure
        ).ToList();
    }

  public string Save(RoleSaveDTO dto)
{
    using var con = _db.GetConnection();
    con.Open();

    var param = new DynamicParameters();
    param.Add("@RoleGuid", dto.RoleGuid);
    param.Add("@RoleName", dto.RoleName);
    param.Add("@RoleCode", dbType: DbType.String, size: 20, direction: ParameterDirection.Output);

    con.Execute("sp_Role_Save", param, commandType: CommandType.StoredProcedure);

    return param.Get<string>("@RoleCode");
}


}
