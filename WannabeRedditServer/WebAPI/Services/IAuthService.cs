using WannabeRedditShared.Domain.Models;

namespace WannabeRedditServer.WebAPI.Properties;

public interface IAuthService
{
    Task<User> GetUser(string username, string password);
}