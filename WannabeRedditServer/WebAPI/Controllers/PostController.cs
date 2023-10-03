using Microsoft.AspNetCore.Mvc;
using WannabeRedditShared.Domain.DTOs;
using WannabeRedditShared.Domain.Models;

namespace WannabeRedditServer.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController
{
    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync(PostCreate dto) // NOTE(rune): POST!
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public async Task<ActionResult<Post>> GetAsync() // TODO(rune): Query parametre?
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public async Task<ActionResult<Post>> Update(PostUpdate dto)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] int id)
    {
        throw new NotImplementedException();
    }
}
