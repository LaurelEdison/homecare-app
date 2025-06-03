using HomeCareApp.Domain.Entities;

namespace HomeCareApp.Domain.Interfaces;

public interface IUserRepository
{
    User? GetById(Guid id);
    User? GetByEmail(string email);
    List<User> GetAll();
    string Add(User user);
    string Update(User user);
    string Delete(Guid userId);
}