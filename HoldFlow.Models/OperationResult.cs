using Microsoft.AspNetCore.Identity;

namespace HoldFlow.Models
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}