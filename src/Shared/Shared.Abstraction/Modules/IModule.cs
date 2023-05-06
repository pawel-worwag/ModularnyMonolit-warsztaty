using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Abstraction.Modules;

public interface IModule
{
    public string Name { get; init; }
    public IServiceCollection Register(IServiceCollection services);
    public WebApplication Use(WebApplication app);
}