using WannabeRedditShared.Domain.Models;

namespace WannabeRedditShared.Domain.DTOs;

public class PostCreate
{
    public User Author { get; } // TODO(rune): Måske burde Author være implicit, alt efter om man er logget ind.
    public string Title { get; }
    public string Body { get; }

    public PostCreate(User author, string title, string body)
    {
        Author = author;
        Title = title;
        Body = body;
    }
}
