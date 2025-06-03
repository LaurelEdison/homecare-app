using HomeCareApp.Domain.Entities;
using HomeCareApp.Domain.Enums;
using HomeCareApp.Domain.Interfaces;

namespace HomeCareApp.Application.Service.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public User? GetById(Guid id)
    {
        return _repository.GetById(id);
    }

    public User? GetByEmail(string email)
    {
        return _repository.GetByEmail(email);
    }

    public List<User> GetAll()
    {
        return _repository.GetAll();
    }
    public string CreateUser(Roles role, string firstName, string lastName, string email)
    {
        var user  = User.Create(Guid.NewGuid(), role, firstName, lastName, email);
        return _repository.Add(user);
    }

    public string UpdateUser(Guid guid,Roles role, string fullName, string email)
    {
        var user = _repository.GetById(guid);

        if (user == null)
        {
            return "Could not find user";
        }
        user.Update(fullName, email, role);

        return _repository.Update(user);
    }

    public string ChangePassword(Guid guid, string oldPassword, string newPassword)
    {
        var user = _repository.GetById(guid);
        if (user != null)
        {
            user.ChangePassword(oldPassword, newPassword);
            return "Sucessfully changed password";
        }

        if (user == null)
        {
            return "Could not find user";
        }

        return "Invalid password";
    }

    public string Delete(Guid guid)
    {
        return _repository.Delete(guid);
    }
    
}