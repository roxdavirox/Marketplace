using Marketplace.App.Handlers.Users;

namespace Marketplace.App.Services.Jwt
{
    public interface IJwtService
    {
        object CreateJwt(AuthUserResponse userResponse);
    }
}
