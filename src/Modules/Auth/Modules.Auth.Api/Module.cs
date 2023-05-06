using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shared.Abstraction.Modules;

namespace Modules.Auth.Api;

public class Module : IModule
{
    public string Name { get; init; } = "AuthModule";

    public IServiceCollection Register(IServiceCollection services)
    {
        Console.WriteLine($"Register: {Name}");
        return services;
    }

    public WebApplication Use(WebApplication app)
    {
        Console.WriteLine($"Use: {Name}");
        return app;
    }
}