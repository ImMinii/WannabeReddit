namespace WannabeRedditShared.Domain.DTOs;

public class UserSearchParam
{
    public string? UsernameContains { get;  }

    public UserSearchParam(string? usernameContains)
    {
        UsernameContains = usernameContains;
    }
}