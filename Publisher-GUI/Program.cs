using Data.Services.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using Publisher_GUI.Data.Repositories;
using Publisher_GUI.Data.Services;
using Publisher_GUI.Data.Services.Authentication;

namespace Publisher_GUI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services.AddMudServices();
        builder.Services.AddHttpClient();
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddAuthentication();
        builder.Services.AddCascadingAuthenticationState();

        //Services
        builder.Services.AddScoped<AuthorService>();
        builder.Services.AddScoped<BookService>();
        builder.Services.AddScoped<AuthorizationService>();

        //Repos
        builder.Services.AddScoped<AuthorRepository>();
        builder.Services.AddScoped<BookRepository>();
        builder.Services.AddScoped<AuthorizationRepository>();

        //Custom auth provider
        builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
