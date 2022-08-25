using LuckyDraw.Interfaces;
using LuckyDraw.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDraw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenAdminController : ControllerBase
    {
        public ICustomer _customerSvc;
        public IConfiguration _configuration;
        public TokenAdminController(ICustomer customerSvc, IConfiguration configuration)
        {
            _customerSvc = customerSvc;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ViewLogin viewLogin)
        {
            if (viewLogin != null && !string.IsNullOrEmpty(viewLogin.Email) && !string.IsNullOrEmpty(viewLogin.PassWord))
            {
                var customer = _customerSvc.LoginAdmin(viewLogin);

                if (customer != null)
                {
                    if (customer != null)
                    {
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),

                            new Claim("Id", customer.CustomerID.ToString()),
                            new Claim("FullName", customer.CustomerName),
                            new Claim("Email", customer.CustomerPhone)
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
                            claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                        ViewToken viewToken = new ViewToken()
                        {
                            Token = new JwtSecurityTokenHandler().WriteToken(token),
                            Customer = customer
                        };
                        return Ok(viewToken);
                    }
                    else
                    {
                        return BadRequest("Invalid credentials");
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

