using oa.Application.Core.Models;

namespace oa.Application.Core.Services
{
    public interface IEmailService
    {
        void SendEmail(Email email);
    }
}