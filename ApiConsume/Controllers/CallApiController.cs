using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ApiConsume.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace ApiConsume.Controllers
{
    public class CallApiController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            if ((username != "Secret") || (password != "Secret"))
                return View((object)"Wrong Username or Password");

            var tokenString = GenerateJSONToken();

            List<Reservation> reservationList = new List<Reservation>();
            using (var httpClient = new HttpClient())
            {
                // Aqui eu passo o token
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenString);

                using (var response = await httpClient.GetAsync("http://localhost:8888/api/Reservation")) // change API URL to yours 
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<List<Reservation>>(apiResponse);
                }
                return View("Reservation", reservationList);
            }
        }

        private string GenerateJSONToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MynameisJamesBond007"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "https://www.infnet.edu.br",
                audience: "https://www.infnet.edu.br",
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials
                
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
