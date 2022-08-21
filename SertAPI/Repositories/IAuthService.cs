using SApi.Models;
using SApi.tokens.Models;

namespace SApi.Repositories;

public interface IAuthService 
{
    User CreateUser(User user);
    string SignIn(string email, string password);
}

