using WannabeRedditServer.Application.DaoInterfaces;
using WannabeRedditShared;
using WannabeRedditShared.Domain.DTOs;
using WannabeRedditShared.Domain.Models;

namespace WannabeRedditServer.FileData.DAOs;

public class PostFileDao : IPostDao
{
    private readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Post> CreateAsync(Post post)
    {
        int id = 1;
        if (context.Posts.Any())
        {
            id = context.Posts.Max(t => t.Id);
            id++;
        }

        post.Id = id;

        context.Posts.Add(post);
        context.SaveChanges();

        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetAsync(PostSearch searchParameters)
    {
        var results = context.Posts.Where(post =>
        {
            bool ret = true;

            if (searchParameters.titleContains != null)
            {
                ret &= post.Title.ContainsIgnoreCase(searchParameters.titleContains);
            }

            if (searchParameters.authorName != null)
            {
                ret &= post.Author.Name.ContainsIgnoreCase(searchParameters.authorName);
            }

            if (searchParameters.bodyContains != null)
            {
                ret &= post.Body.ContainsIgnoreCase(searchParameters.bodyContains);
            }

            return ret;
        });

        return Task.FromResult(results);
    }

    public Task<Post?> GetByIdAsync(int id)
    {
        Post? post = context.Posts.FirstOrDefault(post => post.Id == id);
        return Task.FromResult(post);
    }

    public Task UpdateAsync(Post toUpdate)
    {
        Post? existing = context.Posts.FirstOrDefault(post => post.Id == toUpdate.Id);
        if (existing == null)
        {
            throw new Exception($"Tried to update Post with id {toUpdate.Id}, but it does not exist.");
        }

        context.Posts.Remove(existing);
        context.Posts.Add(toUpdate);

        context.SaveChanges();

        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        Post? existing = context.Posts.FirstOrDefault(post => post.Id == id);
        if (existing == null)
        {
            throw new Exception($"cannot delete post with id {id}, because it does not exist.");
        }

        context.Posts.Remove(existing);
        context.SaveChanges();
        return Task.CompletedTask;
    }
}
