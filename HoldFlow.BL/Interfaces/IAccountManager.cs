using HoldFlow.Models.DTOs;

namespace HoldFlow.BL.Interfaces
{
    public interface IAccountManager 
    {
        public  Task<AccountOperationResult> RegisterUser(RegisterDto registerDto);
        public Task<AccountOperationResult> ConfirmEmail(string token, string email);
        public Task<AccountOperationResult> LoginUser(LoginDto loginDto);


    }
}
