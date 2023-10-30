using WannabeRedditShared.Domain.Models;

namespace WannabeRedditShared.Domain.DTOs;

public class PostCreate
{
    public string Title { get; set; }
    public string Body { get; set; }

    public PostCreate(string title, string body)
    {
        Title = title;
        Body = body;
    }
}
