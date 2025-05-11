using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using To_Do_App.Models;
using Microsoft.VisualBasic;
namespace To_Do_App.Utils;


public class TokenUtil
{
    public static string GenerateJwtToken(User user, IConfiguration config){
      var claims=new[]
      {
         new Claim(JwtRegisteredClaimNames.Sub, config["Jwt:Subject"]),
         
      } 
    }
}
