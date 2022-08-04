using System.Reflection;
using MediatR;
using SimpleCQRSApi.Domain.Common;
using SimpleCQRSApi.Domain.Entities;
using SimpleCQRSApi.Infrastructure;
using SimpleCQRSApi.Infrastructure.Contexts;

namespace SimpleCQRSApi.Configurations;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationsDependencies(this IServiceCollection services)
    {
        AddRepositories(services);
        AddHandlers(services);

        return services;
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddSingleton<LiteDbContext>();
        services.AddScoped<IRepository<Customer>, LiteDbRepository<Customer>>();
    }

    private static void AddHandlers(IServiceCollection services)
    {
        // services.AddTransient<ICreateCustomerHandler, CreateCustomerHandler>();
        // services.AddTransient<IGetCustomerByIdHandler, GetCustomerByIdHandler>();
        services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}
