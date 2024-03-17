using IdentityService.API.Models.CTO;
using IdentityService.API.Models.DTO;

namespace IdentityService.API.Models.Interfaces
{
    public interface IIdentityService
    {
        Task<DtoLoginResponse> Login(DtoLoginRequest request);
    }
}
