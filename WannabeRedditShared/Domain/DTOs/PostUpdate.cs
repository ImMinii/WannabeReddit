namespace WannabeRedditShared.Domain.DTOs;

public class PostUpdate
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    public PostUpdate(int id, string title, string body)
    {
        Id = id;
        Title = title;
        Body = body;
    }
}
