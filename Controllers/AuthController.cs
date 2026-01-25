using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StorePOS.API.DTOs;
using StorePOS.API.Repositories;

namespace StorePOS.API.Controllers;
[ApiController]
[Route("api/auth")]
public class AuthController:ControllerBase
{
 private readonly UserRepository _repo;
 private readonly JwtService _jwt;

 public AuthController(UserRepository r,JwtService j){
  _repo=r; _jwt=j;
 }
[AllowAnonymous]
[HttpPost("login")]
public IActionResult Login(LoginDTO dto)
{
    
    var user = _repo.Login(dto.UserName);

    if (user == null)
    {
        return Unauthorized(new
        {
            success = false,
            message = "Invalid username or password"
        });
    }

    return Ok(new
    {
        success = true,
        message = "Login successful",
        token = _jwt.Generate(user.UserName, user.RoleName),
        userGuid = user.UserGuid,
        roleName = user.RoleName
    });;
}

}

