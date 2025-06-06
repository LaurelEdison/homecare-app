using HomeCareApp.Domain.Enums;

namespace HomeCareApp.Application.Dto;

public class CreateUserDto
{
    public Roles Role { get; set; }
    public required string FullName { get; set; }
    public required string PasswordHash { get; set; }
    public required string Email { get; set; }
}