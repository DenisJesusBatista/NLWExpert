using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Contracts;

public interface IUseRepository
{
    bool ExistUserWithEmail(string email);

    User GetUserByEmail(string email);
}
