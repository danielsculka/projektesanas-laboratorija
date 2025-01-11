namespace ProLab.Infrastructure.Identity;
public class PasswordService : IPasswordService
{
    public string GeneratePasswordHash(string password) => BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    public bool Verify(string loginPassword, string hashedPassword) => BCrypt.Net.BCrypt.EnhancedVerify(loginPassword, hashedPassword);
}
