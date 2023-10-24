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

    public async Task<User> CreateAsync(UserCreate dto)
    {
        User? existing = await UserDao.GetByUsernameAsync(dto.Name);
        if (existing != null)
        {
            throw new Exception("Username already taken");
        }

        ValidateData(dto);

        User toCreate = new User(dto.Name, dto.PassWord);

        User created = await UserDao.CreateAsync(toCreate);
        return created;

    }

    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto userParametersDto)
    {
        return UserDao.GetAsync(userParametersDto);
    }
    
    private void ValidateData(UserCreate dto)
    {
        //Todo hvad skal validates? Password længde måske?
    }
}