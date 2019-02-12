using Marketplace.Domain.Entities;

namespace Marketplace.App.Services.Jwt
{
    public interface IJwtService
    {
        object CreateJwt(User user);
    }
}
