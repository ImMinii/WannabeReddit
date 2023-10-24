using Microsoft.AspNetCore.Mvc;
using WannabeRedditServer.WebAPI.Properties;

namespace WannabeRedditServer.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController
{
    private readonly IConfiguration config;
    private readonly IAuthService authService;

    public AuthController(IConfiguration config, IAuthService authService)
    {
        this.config = config;
        this.authService = authService;
    }
}