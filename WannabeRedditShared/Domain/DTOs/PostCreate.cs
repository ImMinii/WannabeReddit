using WannabeRedditShared.Domain.Models;

namespace WannabeRedditShared.Domain.DTOs;

public class PostCreate
{
    public User Author { get; set; } // TODO(rune): Måske burde Author være implicit, alt efter om man er logget ind.
    public string Title { get; set; }
    public string Body { get; set; }

    public PostCreate(User author, string title, string body)
    {
        Author = author;
        Title = title;
        Body = body;
    }
}
