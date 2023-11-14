using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WannabeRedditServer.Application.DaoInterfaces;
using WannabeRedditServer.Efc;
using WannabeRedditShared.Domain.DTOs;
using WannabeRedditShared.Domain.Models;

namespace WannabeRedditServer.FileData.DAOs;

public class UserEfcDao : IUserDao {
    private readonly WannabeRedditContext context;

    public UserEfcDao(WannabeRedditContext context) {
        this.context = context;
    }

    public async Task<User> CreateAsync(User user) {
        EntityEntry<User> newUser = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return newUser.Entity;
    }

    public async Task<User?> GetByUsernameAsync(string userName) {
        User? user = await context.Users.FirstOrDefaultAsync(u => u.Name == userName);
        return user;
    }

    public async Task<IEnumerable<User>> GetAsync(UserSearchParam userSearchParameters) {
        IQueryable<User> users = context.Users;
        if (userSearchParameters.UsernameContains != null)
        {
            users = users.Where(u =>
                u.Name.Contains(userSearchParameters.UsernameContains, StringComparison.OrdinalIgnoreCase));
        }

        return await users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id) {
        User? user = await context.Users.FindAsync(id);
        return user;
    }
}
