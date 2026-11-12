using EduLens.Application.DTOs;
using EduLens.Application.Interfaces;
using EduLens.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace EduLens.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserService(
        IUserRepository userRepository,
        IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    // GET BY ID
    public async Task<UserDto?> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
            return null;

        return MapToDto(user);
    }

    // GET ALL
    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();

        return users.Select(MapToDto);
    }

    // CREATE
    public async Task<UserDto> CreateAsync(CreateUserDto userDto)
    {
        // Check whether the email already exists
        var existingUser = await _userRepository.GetByEmailAsync(userDto.Email);

        if (existingUser != null)
            throw new InvalidOperationException("A user with this email already exists.");

        // Create the user entity
        var user = new User
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email,
            Role = userDto.Role,
            CreatedAt = DateTime.UtcNow
        };

        // Hash the password before saving it
        user.PasswordHash = _passwordHasher.HashPassword(
            user,
            userDto.Password
        );

        var createdUser = await _userRepository.CreateAsync(user);

        return MapToDto(createdUser);
    }

    // UPDATE
    public async Task<bool> UpdateAsync(int id, UpdateUserDto userDto)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
            return false;

        // Check whether another user already uses this email
        var existingUser = await _userRepository.GetByEmailAsync(userDto.Email);

        if (existingUser != null && existingUser.UserId != id)
            throw new InvalidOperationException("A user with this email already exists.");

        user.FirstName = userDto.FirstName;
        user.LastName = userDto.LastName;
        user.Email = userDto.Email;
        user.Role = userDto.Role;

        await _userRepository.UpdateAsync(user);

        return true;
    }

    // DELETE
    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
            return false;

        await _userRepository.DeleteAsync(user);

        return true;
    }

    // ENTITY TO DTO MAPPING
    private static UserDto MapToDto(User user)
    {
        return new UserDto
        {
            UserId = user.UserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Role = user.Role.ToString(),
            CreatedAt = user.CreatedAt
        };
    }
}