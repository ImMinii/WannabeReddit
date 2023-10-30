using WannabeRedditShared.Domain.DTOs;
using WannabeRedditShared.Domain.Models;

namespace WannabeRedditServer.Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<IEnumerable<Post>> GetAsync(PostSearchParam searchParamParameters);
    Task UpdateAsync(Post toUpdate);
    Task<Post?> GetByIdAsync(int id);
    Task DeleteAsync(int id);
}
