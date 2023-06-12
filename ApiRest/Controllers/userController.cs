using ApiRest.Data;
using ApiRest.Models;
using ApiRest.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly ILogger<userController> _logger;
        private readonly AplicationDbContext _db;
        public userController(ILogger<userController> logger, AplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            _logger.LogInformation("Obtener todos los usuarios.");
            //? If we couldn't take the users data we will return error "Not Found" error 404.
            if (UserStore.userList == null) return NotFound();
            //? If we could get a list of valid users, we will return the full list of users.
            return Ok(_db.Users.ToList()); //? _db.Users.ToList() == SELECT * FROM Users
        }

        [HttpGet("id:int", Name ="GetUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<UserDto> GetUser(int id)
        {
            //? If ID i less equal or less than 0, respond with the error "Bad Request" error 400.
            if (id <= 0) return BadRequest();

            //? If the ID provided is not found, respond with the error "Not Found" error 404.
            // var user = UserStore.userList.FirstOrDefault(u => u.Id == id);
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            if(user == null) return NotFound();

            //? Finally if the request is succesful you can return the user object.
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<User> CrearUser([FromBody] User user)
        {
            if(!ModelState.IsValid) return BadRequest();
            if(_db.Users.FirstOrDefault(u => u.name.ToLower() == user.name.ToLower() && u.surnames.ToLower() == user.surnames.ToLower()) != null)
            {
                ModelState.AddModelError("NombreExiste", "Un usuario con ese nombre ya existe!");
                return BadRequest(ModelState);
            }
            if(user == null) return BadRequest(user);
            if(user.Id >0)
            {
                return StatusCode(500);
            }

            User modelo = new()
            {
                name = user.name,
                surnames = user.surnames,
                username = user.username,
                password = user.password,
                age = user.age,
                email = user.email,
                imageUrl = user.imageUrl,
            };

            _db.Users.Add(modelo);
            _db.SaveChanges();

            return CreatedAtRoute("GetUser", new {id=user.Id}, user);
        }

        [HttpDelete("is:int")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(int id)
        {
            //? If ID i less equal or less than 0, respond with the error "Bad Request" error 400.
            if (id <= 0) return BadRequest();

            //? If the ID provided is not found, respond with the error "Not Found" error 404.
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            if(user == null) return BadRequest();

            //? Finally if the request is succesful you can return the user object.
            _db.Users.Remove(user);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPut("id:int")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            if(user == null || id != user.Id) return BadRequest();

            _db.Users.Update(user);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpPatch("id:int")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdatePartialUser(int id, JsonPatchDocument<User> patchDto)
        {
            if (patchDto == null || id == 0) return BadRequest();
            var user = _db.Users.FirstOrDefault(u => u.Id == id);

            if (user == null) return BadRequest();

            patchDto.ApplyTo(user, ModelState);

            if(!ModelState.IsValid) return BadRequest(ModelState);

            _db.SaveChanges();
            return NoContent();
        }
    }
}

