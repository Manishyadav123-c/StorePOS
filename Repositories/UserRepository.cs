using Dapper;
using Microsoft.Data.SqlClient;
using StorePOS.API.DTOs;
using StorePOS.API.Helpers;
using System.Data;

namespace StorePOS.API.Repositories
{
   public class UserRepository
{
    private readonly DbHelper _db;

    public UserRepository(DbHelper db)
    {
        _db = db;
    }

        // 🔐 LOGIN
        public UserDTO Login(string userName)
        {
            using SqlConnection con = _db.GetConnection();
            con.Open();

            return con.QueryFirstOrDefault<UserDTO>(
                "sp_User_Login",
                new { UserName = userName },
                commandType: CommandType.StoredProcedure
            );
        }


        // 📋 USER LIST
        public List<UserListDTO> List()
        {
            using var con = _db.GetConnection();
            con.Open();  // OPEN CONNECTION

            return con.Query<UserListDTO>(
                "sp_User_List",
                commandType: CommandType.StoredProcedure
            ).ToList();
        }

        // 💾 ADD / UPDATE USER
        public void Save(UserSaveDTO dto)
        {
            using var con = _db.GetConnection();
            con.Open();  // OPEN CONNECTION

            con.Execute(
                "sp_User_Save",
                dto,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
