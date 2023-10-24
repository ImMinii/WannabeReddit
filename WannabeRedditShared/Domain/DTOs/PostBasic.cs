using WannabeRedditShared.Domain.Models;

namespace WannabeRedditShared.Domain.DTOs;

public class PostBasic
{
    public User Author { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public int Id { get; set; }

    public PostBasic(string title, string body, User author, int id)
    {
        Title = title;
        Body = body;
        Author = author;
        Id = id;
    }
}