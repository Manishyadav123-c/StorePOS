using Dapper;
using StorePOS.API.Helpers;

public class RoleRepository{
 private readonly DbHelper _db;
 public RoleRepository(DbHelper db){_db=db;}

 public List<RoleDTO> List(){
  using var con=_db.GetConnection();
  return con.Query<RoleDTO>("sp_Role_List",
   commandType:System.Data.CommandType.StoredProcedure).ToList();
 }

 public void Save(RoleDTO dto){
  using var con=_db.GetConnection();
  con.Execute("sp_Role_Save",dto,
   commandType:System.Data.CommandType.StoredProcedure);
 }
}
