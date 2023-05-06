using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shared.Abstraction.Modules;

namespace Modules.Mail.Api;

public class Module : IModule
{
    public string Name { get; init; } = "MailModule";

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