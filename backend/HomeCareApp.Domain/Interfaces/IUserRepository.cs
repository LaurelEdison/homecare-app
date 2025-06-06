using HomeCareApp.Domain.Entities;
using HomeCareApp.Domain.Enums;

namespace HomeCareApp.Domain.Interfaces;

public interface IUserRepository
{
    User? GetById(Guid id);
    User? GetByEmail(string email);
    List<User> GetAll();
    List<User> GetByRoles(Roles role);
    string Add(User user);
    string Update(User user);
    string Delete(Guid userId);
}