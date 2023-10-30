namespace WannabeRedditShared.Domain.Models;

public class Post
{
    public User Author { get; }
    public string Title { get; }
    public string Body { get; }
    public int Id { get; set; }

    public Post(string title, string body, User author)
    {
        Title = title;
        Body = body;
        Author = author;
    }
}
