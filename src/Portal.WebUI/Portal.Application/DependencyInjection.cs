using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Portal.Data.Entities;
using Portal.Data.Infrastructure.Abstractions;
using Portal.Data.Infrastructure.Identity.Extensions;
using Portal.Data.Infrastructure.Implementations;
using Portal.Data.Infrastructure.Interfaces;
using Portal.Data.Mapping;
using Portal.Service.Implementation;
using Portal.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Portal.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMappings));
            services.AddTransient(typeof(IRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, MyUserClaimsPrincipalFactory>();
            return services;
        }

    }
}
