using System.Reflection;
using Shared.Abstraction.Modules;

namespace Bootstrap;

internal static class MopdulesLoader
{
    private static List<IModule> _modules = new List<IModule>();
    public static WebApplicationBuilder LoadModules(this WebApplicationBuilder builder)
    {
        _modules = GetModules();
        foreach (var module in _modules.OrderBy(x=>x.Name))
        {
            module.Register(builder.Services);
        }
        
        return builder;
    }

    public static WebApplication UseModules(this WebApplication app)
    {
        foreach (var module in _modules.OrderBy(x=>x.Name))
        {
            module.Use(app);
        }
        return app;
    }
    private static List<IModule> GetModules()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
        var locations = assemblies.Where(x => !x.IsDynamic).Select(x => x.Location).ToArray();
        var dlls = Directory
            .EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "Modules.*.dll", SearchOption.AllDirectories)
            .Where(x => !locations.Contains(x)).ToList();
        dlls.ForEach(x=>assemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(x))));
        return assemblies.SelectMany(x => x.GetTypes())
            .Where(x => typeof(IModule).IsAssignableFrom(x) && !x.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IModule>()
            .ToList();
    }
}