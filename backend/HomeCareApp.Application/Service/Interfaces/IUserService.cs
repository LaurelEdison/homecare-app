using HomeCareApp.Domain.Entities;
using HomeCareApp.Domain.Enums;

namespace HomeCareApp.Application.Service.Implementations;

public interface IUserService
{
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByEmailAsync(string email);
    Task<List<User>> GetAllAsync();
    Task<User> CreateUser(Roles role, string firstName, string lastName, string email);
    Task<User> UpdateUser(Guid guid,Roles role, string fullName, string email);
    Task ChangePassword(Guid guid, string oldPassword, string newPassword);
    Task DeleteAsync(Guid guid);
}