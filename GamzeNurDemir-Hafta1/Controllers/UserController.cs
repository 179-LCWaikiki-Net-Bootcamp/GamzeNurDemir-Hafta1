using GamzeNurDemir_Hafta1.Entities;
using GamzeNurDemir_Hafta1.Models;
using GamzeNurDemir_Hafta1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamzeNurDemir_Hafta1.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UserCreate(UserCreateRequestModel request)
        {
            try
            {
                var user = new User()
                {
                    Name = request.Name,
                    LastName = request.LastName,
                    Status = request.Status,
                    IsDeleted = false,
                    CreatedAt = System.DateTime.Now,
                    UpdatedAt = System.DateTime.Now,
                };

                var result = _userService.Create(user);
                if (result)
                {
                    var response = new UserResponseModel()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        LastName = user.LastName,
                        Status = user.Status,
                        CreatedAt = user.CreatedAt,
                        UpdatedAt = user.UpdatedAt,
                    };
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpDelete("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UserUpdate(UserUpdateRequestModel request)
        {
            try
            {
                var user = _userService.GetUser(request.Id);

                user.Name = request.Name;
                user.LastName = request.LastName;
                user.Status = request.Status;
                user.IsDeleted = request.IsDeleted;

                var result = _userService.Update(user);
                if (result)
                {
                    var response = new User()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        LastName = user.LastName,
                        Status = user.Status,
                        IsDeleted = false,
                        CreatedAt = user.CreatedAt,
                        UpdatedAt = System.DateTime.Now
                    };
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet("get/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UserGet(int userId)
        {
            try
            {
                var user = _userService.GetUser(userId);
                var response = new UserResponseModel()
                {
                    Id = user.Id,
                    Name = user.Name,
                    LastName = user.LastName,
                    Status = user.Status,
                    CreatedAt = user.CreatedAt,
                    UpdatedAt = user.UpdatedAt,
                };
                if (response == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                return Ok(response);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UserDelete(int id)
        {
            try
            {
                var user = _userService.GetUser(id);
                if (user == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                var deletedUser = _userService.Delete(id);
                if (deletedUser)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status400BadRequest);

            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
