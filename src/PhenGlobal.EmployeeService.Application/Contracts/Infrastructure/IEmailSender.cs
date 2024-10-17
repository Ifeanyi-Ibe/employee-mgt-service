using PhenGlobal.EmployeeService.Application.Models;

namespace PhenGlobal.EmployeeService.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}