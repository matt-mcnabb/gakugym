namespace GakuGym.Server;

using GakuGym.Common;
using BCrypt.Net;
using JWT.Builder;

public class NoAuthAttribute : Attribute { }

public static class Security
{
    private static string? passwordHash;
    private static string? authTokenSecret;

    public static void Initialize()
    {
        passwordHash    = Settings.SecurityPasswordHash;
        authTokenSecret = Settings.SecurityTokenSecret;
    }

    public static AuthResult Authenticate(string password)
    {
        if(BCrypt.Verify(password, passwordHash))
            return new AuthResult { success = true, jwtToken = CreateAuthToken() };
        else
            return new AuthResult { success = false };
    }

    private static string CreateAuthToken()
    {
        return JwtBuilder.Create()
                         .WithAlgorithm(new JWT.Algorithms.HMACSHA512Algorithm())
                         .WithSecret(authTokenSecret)
                         .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
                         .Encode();
    }

    public static bool VerifyToken(string token)
    {
        try
        {
            JwtBuilder.Create()
                      .WithAlgorithm(new JWT.Algorithms.HMACSHA512Algorithm())
                      .WithSecret(authTokenSecret)
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
