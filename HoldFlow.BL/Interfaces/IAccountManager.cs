using HoldFlow.Models.DTOs;

namespace HoldFlow.BL.Interfaces
{
    public interface IAccountManager
    {
        public Task<OperationResult> RegisterUser(RegisterDto registerDto);

        public Task<OperationResult> ConfirmEmail(string token, string email);

        public Task<OperationResult> LoginUser(LoginDto loginDto);

        public Task Logout();
    }
}