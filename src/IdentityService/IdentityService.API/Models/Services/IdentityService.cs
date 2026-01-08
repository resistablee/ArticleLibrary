using IdentityService.API.Models.CTO;
using IdentityService.API.Models.DTO;
using IdentityService.API.Models.Interfaces;

namespace IdentityService.API.Models.Services
{
    public class IdentityService : IIdentityService
    {
        public Task<DtoLoginResponse> Login(DtoLoginRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
