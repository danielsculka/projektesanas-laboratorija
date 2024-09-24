using ProLab.Domain.Users;

namespace ProLab.Application;

public interface ICurrentUserService
{
    Guid Id { get; }
    string UserName { get; }
    UserRole Role { get; }
    string IpAddress { get; }
    string RequestUrl { get; }
}
