using WannabeRedditServer.Application.DaoInterfaces;
using WannabeRedditServer.Application.LogicInterfaces;
using WannabeRedditShared.Domain.DTOs;
using WannabeRedditShared.Domain.Models;

namespace WannabeRedditServer.Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao UserDao;

    public UserLogic(IUserDao userDao)
    {
        UserDao = userDao;
    }

    public async Task<UserCreateResult> CreateAsync(UserCreate dto)
    {
        string validationError = await ValidateData(dto);
        if (validationError != "") {
            return new UserCreateResult(null, validationError);
        }

        User toCreate = new User(dto.Name, dto.PassWord);
        User created = await UserDao.CreateAsync(toCreate);


        return new UserCreateResult(created, validationError);

    }

    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto userParametersDto)
    {
        return UserDao.GetAsync(userParametersDto);
    }

    private async Task<string> ValidateData(UserCreate dto)
    {
        User? existing = await UserDao.GetByUsernameAsync(dto.Name);
        if (existing != null)
        {
            return "Username already taken";
        }

        if (dto.PassWord.Length < 8)
        {
            return "Password must be 8 or more characters.";
        }

        return "";
    }
}
