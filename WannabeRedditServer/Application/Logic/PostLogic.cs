using WannabeRedditServer.Application.DaoInterfaces;
using WannabeRedditServer.Application.LogicInterfaces;
using WannabeRedditShared.Domain.DTOs;
using WannabeRedditShared.Domain.Models;

namespace WannabeRedditServer.Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao PostDao;
    private readonly IUserDao UserDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        PostDao = postDao;
        UserDao = userDao;
    }


    public async Task<Post> CreateAsync(PostCreate dto)
    {
        User? user = await UserDao.GetByIdAsync(dto.Author.Id);
        if ( user == null)
        {
            throw new Exception($"Author with id {dto.Author.Id} was not found");
        }

        Post post = new Post(dto.Title, dto.Body, user);

        ValidatePost(post);
        Post created = await PostDao.CreateAsync(post);
        return created;
    }
    

    public Task<IEnumerable<Post>> GetAsync(PostSearch dto)
    {
        return PostDao.GetAsync(dto);
    }

    public Task UpdateAsync(PostUpdate dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PostBasic> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
    
    private void ValidatePost(Post post)
    {
        throw new NotImplementedException();
    }
}