using WannabeRedditShared.Domain.DTOs;
using WannabeRedditShared.Domain.Models;

namespace WannabeRedditServer.Application.LogicInterfaces;

public interface IUserLogic
{
    public Task<UserCreateResult> CreateAsync(UserCreate dto);
    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto userParametersDto);
}
