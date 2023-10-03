using WannabeRedditShared.Domain.Models;

namespace WannabeRedditServer.FileData;

public class DataContainer
{
    public ICollection<User> Users { get; set; }
    public ICollection<Post> Posts { get; set; }
}