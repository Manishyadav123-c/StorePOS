using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            _repo.Save(dto);
            return Ok("User Saved Successfully");
        }
    }
}
