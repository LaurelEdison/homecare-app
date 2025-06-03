using HomeCareApp.Domain.Entities;
using HomeCareApp.Domain.Enums;

namespace HomeCareApp.Application.Service.Implementations;

public interface IUserService
{
    User? GetById(Guid id);
    User? GetByEmail(string email);
    List<User> GetAll();
    string CreateUser(Roles role, string firstName, string lastName, string email);
    string UpdateUser(Guid guid,Roles role, string fullName, string email);
    string ChangePassword(Guid guid, string oldPassword, string newPassword);
    string Delete(Guid guid);
}