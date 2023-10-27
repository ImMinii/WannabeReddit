using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WannabeRedditShared.Domain.Models;

namespace WannabeRedditShared.Auth;

public class AuthorizationPolicies
{
    public static void AddPolicies(IServiceCollection services)
    {
        services.AddAuthorizationCore(option =>
        {
            /*Options.AddPolicy("MustBeLoggedIn", a => 
                a.RequireAuthenticatedUser().RequireClaim("Domain", "id"));
            */
        });
    }
    
}