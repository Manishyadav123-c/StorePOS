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

 [HttpPost("login")]
 public IActionResult Login(LoginDTO dto){
  var user=_repo.Login(dto.UserName);
  if(user==null) return Unauthorized();
  return Ok(new{token=_jwt.Generate(user.UserName,user.RoleName),
                user.UserGuid});
 }
}

