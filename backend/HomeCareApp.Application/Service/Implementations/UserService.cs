using HomeCareApp.Domain.Entities;
using HomeCareApp.Domain.Enums;
using HomeCareApp.Domain.Interfaces;

namespace HomeCareApp.Application.Service.Implementations;

public class UserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _repository.GetByEmailAsync(email);
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
    public async Task<User> CreateUser(Roles role, string firstName, string lastName, string email)
    {
        var user  = User.Create(Guid.NewGuid(), role, firstName, lastName, email);
        await _repository.AddAsync(user);
        return user;
    }

    public async Task<User> UpdateUser(Guid guid,Roles role, string fullName, string email)
    {
        var user = await _repository.GetByIdAsync(guid);

        if (user == null)
        {
            return null;
        }
        user.Update(fullName, email, role);

        await _repository.UpdateAsync(user);
        
        return user;
    }

    public async Task ChangePassword(Guid guid, string oldPassword, string newPassword)
    {
        var user = await _repository.GetByIdAsync(guid);
        user?.ChangePassword(oldPassword, newPassword);
    }

    public async Task DeleteAsync(Guid guid)
    {
        await _repository.DeleteAsync(guid);
    }
    
}