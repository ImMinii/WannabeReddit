namespace WannabeRedditShared.Domain.DTOs;

public class UserCreate
{
    public string Username { get;}

    public UserCreate(string username)
    {
        Username = username;
    }
}
