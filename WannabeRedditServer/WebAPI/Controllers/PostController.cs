using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WannabeRedditServer.Application.DaoInterfaces;
using WannabeRedditServer.Application.LogicInterfaces;
using WannabeRedditShared.Domain.DTOs;
using WannabeRedditShared.Domain.Models;

namespace WannabeRedditServer.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostLogic postLogic;

    public PostController(IPostLogic postLogic)
    {
        this.postLogic = postLogic;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync([FromBody]PostCreate dto) // NOTE(rune): POST!
    {
        try
        {
            Post created = await postLogic.CreateAsync(dto);
            return Created($"posts/{created.Id}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetAsync([FromQuery] string? authorName, [FromQuery] string? tileContains, [FromQuery] string? bodyContains)
    {
        try
        {
            PostSearch parameters = new(authorName, tileContains, bodyContains);
            var posts = await postLogic.GetAsync(parameters);
            return Ok(posts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PostBasic>> GetById([FromRoute] int id)
    {
        try
        {
            PostBasic result = await postLogic.GetByIdAsync(id);
            return Ok(result);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [Authorize]
    [HttpPatch]
    public async Task<ActionResult<Post>> Update([FromBody]PostUpdate dto)
    {
        try
        {
            await postLogic.UpdateAsync(dto);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] int id)
    {
        try
        {
            await postLogic.DeleteAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}
