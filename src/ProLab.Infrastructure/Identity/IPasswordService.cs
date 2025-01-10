namespace ProLab.Infrastructure.Identity;

public interface IPasswordService
{
    string GeneratePasswordHash(string password);
    bool Verify(string loginPassword, string hashedPassword);
}
