using WannabeRedditShared.Domain.DTOs;
using WannabeRedditShared.Domain.Models;

namespace WannabeRedditServer.Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(int authorId, PostCreate dto);
    Task<IEnumerable<Post>> GetAsync(PostSearchParam dto);
    Task UpdateAsync(PostUpdate dto);
    Task DeleteAsync(int id);
    Task<PostBasic> GetByIdAsync(int id);
}
