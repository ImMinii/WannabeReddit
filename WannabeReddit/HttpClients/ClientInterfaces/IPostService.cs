using WannabeRedditShared.Domain.DTOs;
using WannabeRedditShared.Domain.Models;

namespace WannabeReddit.HttpClients.ClientInterfaces;

public interface IPostService
{
    public Task<IEnumerable<Post>> GetPostsAsync(PostSearch postSearch);
}
