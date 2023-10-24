namespace WannabeRedditShared.Domain.DTOs;

public class UserCreate
{
    public String Name { get; }
    public String PassWord { get; }

    public UserCreate(string name, string passWord)
    {
        Name = name;
        PassWord = passWord;
    }
}
