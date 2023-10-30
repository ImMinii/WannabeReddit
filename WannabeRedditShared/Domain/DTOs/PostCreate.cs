using WannabeRedditShared.Domain.Models;

namespace WannabeRedditShared.Domain.DTOs;

public class PostCreate
{
    public string Title { get; }
    public string Body { get; }

    public PostCreate(string title, string body)
    {
        Title = title;
        Body = body;
    }
}
