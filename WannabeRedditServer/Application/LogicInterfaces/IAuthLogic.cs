using WannabeRedditShared.Domain.Models;

namespace WannabeRedditServer.Application.LogicInterfaces;

public interface IAuthLogic
{
    Task<User> GetUser(string username, string password);
    Task<User> ValidateUser(string username, string password);
    Task<User> RegisterUser(string username, string password);
}
