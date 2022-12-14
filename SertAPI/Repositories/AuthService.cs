using SApi.Migrations;
using bcrypt = BCrypt.Net.BCrypt;
using SApi.Repositories;
using SApi.tokens.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SertAPI.Repositories;

public class AuthService : IAuthService
{
private static LessonDbContext _context;
private static IConfiguration _config;


private string BuildToken(User user) {
    var secret = _config.GetValue<String>("TokenSecret");
    var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
    
    // Create Signature using secret signing key
    var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

    // Create claims to add to JWT payload
    var claims = new Claim[]
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
        new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
        new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName ?? ""),
        new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName ?? "")
    };

    // Create token
    var jwt = new JwtSecurityToken(
        claims: claims,
        expires: DateTime.Now.AddMinutes(5),
        signingCredentials: signingCredentials);
    
    // Encode token
    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

    return encodedJwt;
}
public AuthService(LessonDbContext context, IConfiguration config) {
    _context = context;
    _config = config;
}
    public User CreateUser(User user)
    {
        // TODO: Hash Password
        var passwordHash = bcrypt.HashPassword(user.Password);
        user.Password = passwordHash;

        _context.Add(user);
        _context.SaveChanges();
        return user;
    }

 public string SignIn(string email, string password)
{
    var user = _context.Users.SingleOrDefault(x => x.Email == email);
    var verified = false;

    if (user != null) {
        verified = bcrypt.Verify(password, user.Password);
    }

    if (user == null || !verified)
    {
        return String.Empty;
    }
    
    // Create & return JWT
    return BuildToken(user);
}
}