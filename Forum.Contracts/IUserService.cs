using Forum.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Contracts
{
    public interface IUserService
    {
        Task Register(RegistrationRequestDto registrationRequestDto);
        Task RegisterAdmin(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);

        Task<UserDto> GetUserByEmail(string userEmail);
        Task LockOutUser(string userId);
        Task CancelLockOut(string userId);
    }
}
