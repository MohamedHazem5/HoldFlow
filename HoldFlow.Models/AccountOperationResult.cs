using Microsoft.AspNetCore.Identity;

namespace HoldFlow.Models
{
    public class AccountOperationResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public SignInResult SignInResult { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
