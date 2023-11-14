using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WannabeRedditServer.Application.DaoInterfaces;
using WannabeRedditServer.Efc;
using WannabeRedditShared;
using WannabeRedditShared.Domain.DTOs;
using WannabeRedditShared.Domain.Models;

namespace WannabeRedditServer.FileData.DAOs;

public class PostEfcDao : IPostDao {
    private readonly WannabeRedditContext context;

    public PostEfcDao(WannabeRedditContext context) {
        this.context = context;
    }

    public async Task<Post> CreateAsync(Post post) {
        // TODO(rune): TEMP LØSNING. Spørg Troels.
        // Hvis ikke vi sætter post.Author til null, prøver EFC at indsætte end ny User record.
        // HVis ikke hvis sætter AuthorId prøver EFC at indsætte 0 i AuthorId kolonne.
        post.AuthorId = post.Author.Id;
        post.Author = null;

        EntityEntry<Post> newPost = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return newPost.Entity;
    }

    public async Task<IEnumerable<Post>> GetAsync(PostSearchParam searchParamParameters) {
        IQueryable<Post> posts = context.Posts.Include(post => post.Author);

        if (searchParamParameters.titleContains != null) {
            posts = posts.Where(post => post.Title.ContainsIgnoreCase(searchParamParameters.titleContains));
        }

        if (searchParamParameters.authorName != null) {
            posts = posts.Where(post => post.Author.Name.ContainsIgnoreCase(searchParamParameters.authorName));
        }

        if (searchParamParameters.bodyContains != null) {
            posts = posts.Where(post => post.Body.ContainsIgnoreCase(searchParamParameters.bodyContains));
        }

        return await posts.ToListAsync();
    }

    public async Task UpdateAsync(Post toUpdate) {
        context.Posts.Update(toUpdate);
        await context.SaveChangesAsync();
    }

    public async Task<Post?> GetByIdAsync(int id) {
        Post? post = await context.Posts.Include(post => post.Author).FirstOrDefaultAsync(post => post.Id == id);

        return post;
    }

    public async Task DeleteAsync(int id) {
        Post? post = await GetByIdAsync(id);
        if (post != null) {
            context.Posts.Remove(post);
            await context.SaveChangesAsync();
        }
    }
}
