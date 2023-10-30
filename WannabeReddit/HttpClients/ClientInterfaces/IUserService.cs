using WannabeRedditShared.Domain.Models;
using WannabeRedditShared.Domain.DTOs;

namespace WannabeReddit.HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<UserCreateResult> Create(UserCreate dto);
}
