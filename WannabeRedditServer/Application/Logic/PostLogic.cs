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

    public async Task UpdateAsync(PostUpdate dto)
    {
        Post? existing = await PostDao.GetByIdAsync(dto.Id);
        if (existing == null)
        {
            throw new Exception($"Post with ID {dto.Id} not found!");
        }

        User userToUse = existing.Author;
        string titleToUse = dto.Title ?? existing.Title;
        string bodyToUse = dto.Body ?? existing.Body;

        Post updated = new(titleToUse, bodyToUse, userToUse)
        {
            Id = existing.Id
        };
        ValidatePost(updated);
        await PostDao.UpdateAsync(updated);
    }

    public async Task DeleteAsync(int id)
    {
        await PostDao.DeleteAsync(id);
    }

    public async Task<PostBasic> GetByIdAsync(int id)
    {
        Post? post = await PostDao.GetByIdAsync(id);
        if (post == null)
        {
            throw new Exception($"Post with id {id} not found");
        }

        return new PostBasic(post.Title, post.Body, post.Author, post.Id);
    }
    
    private void ValidatePost(Post post)
    {
        if (string.IsNullOrEmpty(post.Title)) throw new Exception("Title cannot be empty");
    }
}
