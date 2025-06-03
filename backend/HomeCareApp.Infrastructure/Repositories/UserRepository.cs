using HomeCareApp.Domain.Entities;
using HomeCareApp.Domain.Interfaces;
using HomeCareApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HomeCareApp.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext  _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public User? GetById(Guid id)
    {
        return _context.Users.Find(id);
    }

    public User? GetByEmail(string email)
    {
        return _context.Users.Find(email);
    }
    
    public List<User> GetAll()
    {
        return _context.Users.ToList();
    }

    public string Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return "Successfully added user";
    }

    public string Update(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
        return "Successfully updated user";
    }

    public string Delete(Guid userId)
    {
        var  user = _context.Users.Find(userId);
        if (user == null) return "Could not find user";
        _context.Users.Remove(user);
        _context.SaveChanges();
        return "Successfully deleted user";

    }
}