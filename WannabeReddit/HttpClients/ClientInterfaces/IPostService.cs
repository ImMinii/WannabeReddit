﻿using WannabeRedditShared.Domain.DTOs;
using WannabeRedditShared.Domain.Models;

namespace WannabeReddit.HttpClients.ClientInterfaces;

public interface IPostService
{
    Task<IEnumerable<Post>> GetPostsAsync(PostSearchParam postSearchParam);
    Task<Post> GetPostAsync(int id);
    Task CreateAsync(PostCreate dto);
}
