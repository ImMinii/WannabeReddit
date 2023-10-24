using WannabeRedditShared.Domain.Models;
using WannabeRedditShared.Domain.DTOs;

namespace WannabeReddit.HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<User> Create(UserCreate dto);
}