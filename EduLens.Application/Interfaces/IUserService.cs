using EduLens.Application.DTOs;

namespace EduLens.Application.Interfaces;

public interface IUserService
{
    Task<UserDto?> GetByIdAsync(int id);

    Task<IEnumerable<UserDto>> GetAllAsync();

    Task<UserDto> CreateAsync(CreateUserDto userDto);

    Task<bool> UpdateAsync(int id, UpdateUserDto userDto);

    Task<bool> DeleteAsync(int id);
}