using WannabeRedditShared.Domain.Models;

namespace WannabeRedditServer.WebAPI.Properties;

public interface IAuthService
{
    Task<User> GetUser(string username, string password);
    Task<User> ValidateUser(object username, object password);
}