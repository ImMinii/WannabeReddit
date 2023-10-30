namespace WannabeRedditShared.Domain.DTOs;

public class UserCreate
{
    public string Name { get; }
    public string PassWord { get; }

    public UserCreate(string name, string passWord)
    {
        Name = name;
        PassWord = passWord;
    }
}
