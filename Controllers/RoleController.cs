using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StorePOS.API.DTOs;
using StorePOS.API.Repositories;

namespace StorePOS.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/roles")]
    public class RoleController : ControllerBase
    {
        private readonly RoleRepository _repo;

        public RoleController(RoleRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_repo.List());
        }

        [HttpPost]
        public IActionResult Save(RoleDTO dto)
        {
            _repo.Save(dto);
            return Ok("Role Saved Successfully");
        }
    }
}
