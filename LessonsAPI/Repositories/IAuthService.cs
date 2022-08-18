using l14_coffeeAPI.Models;

namespace l14_coffeeAPI.Repositories;

public interface IAuthService 
{
    User CreateUser(User user);
    string SignIn(string email, string password);
}
