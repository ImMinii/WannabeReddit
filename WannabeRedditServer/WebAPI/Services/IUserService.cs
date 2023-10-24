namespace WannabeRedditServer.WebAPI.Properties;

public interface IUserService
{
    GetUser Task<User>(string username, string password);
    
    
}