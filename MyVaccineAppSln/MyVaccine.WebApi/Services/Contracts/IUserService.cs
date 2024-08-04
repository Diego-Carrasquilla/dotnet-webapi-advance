using MyVaccine.WebApi.Dtos;

namespace MyVaccine.WebApi.Services.Contracts
{
    public interface IUserService
    {
        Task<AuthResponseDto> AddUserAsync(RegisterRequestDto request);
        Task<AuthResponseDto> Login(LoginRequestDto request);
        Task<AuthResponseDto> RefreshToken(string email);
    }
}
