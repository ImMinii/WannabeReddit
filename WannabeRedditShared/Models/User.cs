namespace WannabeRedditShared.Domain.Models;

public class User
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string PassWord { get; set; }

    // TODO(rune): Hvad ellers?

    public User(string name, string passWord, int id)
    {
        Name = name;
        PassWord = passWord;
        Id = id;
    }
}
