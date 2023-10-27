namespace WannabeRedditServer.WebAPI;

public class JwtRegisteredClaimNames
{
    private List<Claim> GenerateClaims(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, config)
        };
    }
}