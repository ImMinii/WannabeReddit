namespace WannabeRedditShared.Domain.Models;

public class User
{
    public string Name { get; set; }

    // TODO(rune): Hvad ellers?

    public User(string name)
    {
        Name = name;
    }
}
