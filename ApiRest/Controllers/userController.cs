using ApiRest.Models;
using ApiRest.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<UserDto> GetVillas()
        {
            return new List<UserDto> {
                new UserDto { Id = 1, Name="Pol Hernan Camino"},
                new UserDto { Id = 2, Name="Veronica Lainez Liso"}
            };
        }
    }
}
