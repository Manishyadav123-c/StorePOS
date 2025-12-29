using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class JwtService
{
 private readonly IConfiguration _config;
 public JwtService(IConfiguration config){_config=config;}

 public string Generate(string user,string role){
  var key=new SymmetricSecurityKey(
   Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
  var creds=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

  var token=new JwtSecurityToken(
   claims:new[]{
     new Claim(ClaimTypes.Name,user),
     new Claim(ClaimTypes.Role,role)
   },
   expires:DateTime.Now.AddHours(8),
   signingCredentials:creds);

  return new JwtSecurityTokenHandler().WriteToken(token);
 }
}
