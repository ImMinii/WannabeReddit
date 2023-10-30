using System.ComponentModel.DataAnnotations;
using WannabeRedditServer.Application.DaoInterfaces;
using WannabeRedditServer.Application.LogicInterfaces;
using WannabeRedditShared.Domain.Models;

namespace WannabeRedditServer.Application.Logic;

public class AuthLogic : IAuthLogic
{
    private readonly IUserDao userDao;

    public AuthLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = await userDao.GetByUsernameAsync(username);
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.PassWord.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return existingUser;
    }

    public async Task<User> RegisterUser(string username, string password)
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(password))
        {
            throw new ValidationException("Password cannot be null");
        }

        if (password.Length < 8)
        {
            throw new ValidationException("Password must be 8 or more characters.");
        }

        User? existingUser = await userDao.GetByUsernameAsync(username);
        if (existingUser != null)
        {
            throw new ValidationException("Username already taken");
        }

        User registeredUser = await userDao.CreateAsync(new User(username, password));
        return registeredUser;
    }

    public Task<User> GetUser(string username, string password)
    {
        throw new NotImplementedException();
    }
}
