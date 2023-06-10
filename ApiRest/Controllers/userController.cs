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
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<UserDto>> GetVillas()
        {
            //? If we couldn't take the users data we will return error "Not Found" error 404.
            if (UserStore.userList == null) return NotFound();
            //? If we could get a list of valid users, we will return the full list of users.
            return Ok(UserStore.userList);
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
            var user = UserStore.userList.FirstOrDefault(u => u.Id == id);
            if(user == null) return NotFound();

            //? Finally if the request is succesful you can return the user object.
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<UserDto> CrearUser([FromBody] UserDto user)
        {
            if(!ModelState.IsValid) return BadRequest();
            if(UserStore.userList.FirstOrDefault(u => u.Name.ToLower() == user.Name.ToLower()) != null)
            {
                ModelState.AddModelError("NombreExiste", "Un usuario con ese nombre ya existe!");
                return BadRequest();
            }
            if(user == null) return BadRequest();
            if(user.Id >0)
            {
                return StatusCode(500);
            }
            user.Id=UserStore.userList.OrderByDescending(u => u.Id).FirstOrDefault().Id +1;
            UserStore.userList.Add(user);
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
            var user = UserStore.userList.FirstOrDefault(u => u.Id == id);
            if(user == null) return BadRequest();

            //? Finally if the request is succesful you can return the user object.
            UserStore.userList.Remove(user);
            return NoContent();
        }

        [HttpPut("id:int")]
        public IActionResult UpdateUser(int id, [FromBody] UserDto user)
        {
            if(user == null || id != user.Id) return BadRequest();
            var oldUser = UserStore.userList.FirstOrDefault(u => u.Id == id);
            oldUser.Name = user.Name;
            oldUser.Age = user.Age;
            oldUser.Money = user.Money;

            return NoContent();
        }

        [HttpPatch("id:int")]
        public IActionResult UpdatePartialUser(int id, JsonPatchDocument<UserDto> patchDto)
        {
            if (patchDto == null || id == 0) return BadRequest();
            var oldUser = UserStore.userList.FirstOrDefault(u => u.Id == id);

            patchDto.ApplyTo(oldUser, ModelState);

            if(!ModelState.IsValid) return BadRequest(ModelState);
            

            return NoContent();
        }
    }
}
}
