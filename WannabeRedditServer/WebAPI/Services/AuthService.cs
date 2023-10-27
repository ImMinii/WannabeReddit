using System.ComponentModel.DataAnnotations;
using WannabeRedditShared.Domain.Models;

namespace WannabeRedditServer.WebAPI.Properties;

public class AuthService : IAuthService
{
    private readonly IList<User> users = new List<User>()
    {

    };

    public Task<User> ValidateUser(string username, int id, string password)
    {
        User? existingUser = users.FirstOrDefault(u =>
            u.Name.Equals(username));
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.PassWord.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return Task.FromResult(existingUser);
    }

    public Task RegisterUser(User user)
    {
        if (string.IsNullOrEmpty((user.Name)))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.PassWord))
        {
            throw new ValidationException("Password cannot be null");
        }
        users.Add(user);

        return Task.CompletedTask;
    }
        
    public Task<User> GetUser(string username, string password)
    {
        throw new NotImplementedException();
    }
}