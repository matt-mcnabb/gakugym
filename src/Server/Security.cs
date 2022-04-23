namespace GakuGym.Server;

using GakuGym.Common;
using BCrypt.Net;
using JWT.Builder;

public class NoAuthAttribute : Attribute { }

internal class Security
{
    private readonly Settings Settings;

    public Security(Settings settings)
    {
        Settings = settings;
    }


    public AuthResult Authenticate(string password)
    {
        if(BCrypt.Verify(password, Settings.SecurityPasswordHash))
            return new AuthResult { success = true, jwtToken = CreateAuthToken() };
        else
            return new AuthResult { success = false };
    }

    private string CreateAuthToken()
    {
        return JwtBuilder.Create()
                         .WithAlgorithm(new JWT.Algorithms.HMACSHA512Algorithm())
                         .WithSecret(Settings.SecurityTokenSecret)
                         .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
                         .Encode();
    }

    public virtual bool AuthorizeRequest(HttpContext httpContext) 
        => VerifyToken(httpContext.Request.Headers["Authorization"]);

    private bool VerifyToken(string token)
    {
        try
        {
            JwtBuilder.Create()
                      .WithAlgorithm(new JWT.Algorithms.HMACSHA512Algorithm())
                      .WithSecret(Settings.SecurityTokenSecret)
                      .MustVerifySignature()
                      .Decode(token);
        }
        catch
        {
            return false;
        }

        return true;
    }
}


internal class NoAuthSecurity : Security
{
    public NoAuthSecurity(Settings settings) : base(settings) { }

    public override bool AuthorizeRequest(HttpContext httpContext) => true;
}
