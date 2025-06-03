using HomeCareApp.Application.Dto;
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
    public string CreateUser(CreateUserDto dto)
    {
        var user  = User.Create(Guid.NewGuid(), dto.Role, dto.FullName, dto.Email, dto.PasswordHash);
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

    public User? Login(string email, string password)
    {
        var user = _repository.GetByEmail(email);
        if (user == null)
        {
            return null;
        }

        if (user.PasswordHash != password)
        {
            return null;
        }

        return user;
    }
    
}