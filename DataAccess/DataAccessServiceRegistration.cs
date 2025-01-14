﻿using Core.Extensions;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration
            .GetConnectionString("FeedbackCaseConnectionString")));

        services.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).
            Where(t => t.ServiceType.Name.EndsWith("Repository"));
        services.AddTransient<IUserOperationClaimRepository, UserOperationClaimRepository>();
        return services;
    }
}
