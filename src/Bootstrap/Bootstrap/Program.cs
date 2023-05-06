using Bootstrap;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.LoadModules();

var app = builder.Build();
app.UseModules();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async ctx => { await ctx.Response.WriteAsync("Hello"); });
});

app.Run();