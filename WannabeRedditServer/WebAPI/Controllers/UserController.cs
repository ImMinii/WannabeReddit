using Microsoft.AspNetCore.Mvc;
using WannabeRedditServer.Application.LogicInterfaces;
using WannabeRedditShared.Domain.DTOs;
using WannabeRedditShared.Domain.Models;

namespace WannabeRedditServer.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserLogic userLogic;

    public UserController(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }


    [HttpPost]
    public async Task<ActionResult<UserCreateResult>> CreateAsync(UserCreate dto)
    {
        try
        {
            UserCreateResult result = await userLogic.CreateAsync(dto);
            if (result.HasValidationError) {
                return BadRequest(result);
            } else {
                return Created($"/user/{result.User!.Id}", result);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAsync([FromQuery] string? userNameContains)
    {
        try
        {
            UserSearchParam parameters = new(userNameContains);
            IEnumerable<User> users = await userLogic.GetAsync(parameters);
            return Ok(users);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}
