using WannabeRedditShared.Domain.Models;

namespace WannabeRedditShared.Domain.DTOs;

public class PostUpdate
{
    public int Id { get; }
    public string? Title { get; }
    public string? Body { get; }

    public PostUpdate(int id, string? title, string? body)
    {
        Id = id;
        Title = title;
        Body = body;
    }
}
