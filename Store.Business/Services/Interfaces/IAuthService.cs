using Store.Entities.DTOs;

namespace Store.Business.Services.Interfaces
{
    public interface IAuthService
    {
        string Login(LoginDto loginDto);

    }
}
