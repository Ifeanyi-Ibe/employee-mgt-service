using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Ardalis.GuardClauses;

using PhenGlobal.EmployeeService.Infrastructure.Data;
using PhenGlobal.EmployeeService.Application.Contracts.Persistence;
using PhenGlobal.EmployeeService.Infrastructure.Data.Repositories;
using PhenGlobal.EmployeeService.Application.Models;
using PhenGlobal.EmployeeService.Application.Contracts.Infrastructure;
using PhenGlobal.EmployeeService.Infrastructure.Mail;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

            services.AddDbContext<EmployeeDbContext>((sp, options) =>
            {
                options.UseNpgsql(connectionString);
            });

            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();

            return services;
        }
    }
}