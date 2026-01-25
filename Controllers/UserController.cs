using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StorePOS.API.DTOs;
using StorePOS.API.Repositories;

namespace StorePOS.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _repo;

        public UserController(UserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_repo.List());
        }

        [HttpPost]
public IActionResult Save(UserSaveDTO dto)
{
    try
    {
        _repo.Save(dto);
        return Ok(new { success = true, message = "User saved successfully" });
    }
    catch (SqlException ex)
    {
        return BadRequest(new { success = false, message = ex.Message });
    }
}

    }
}
