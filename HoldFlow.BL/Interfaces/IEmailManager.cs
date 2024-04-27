using Microsoft.AspNetCore.Http;

namespace HoldFlow.BL.Interfaces
{
    public interface IEmailManager
    {
        public Task SendEmailAsync(string mailTo, string subject, string body, IList<IFormFile> attachments = null);

    }
}
