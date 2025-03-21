using Data.Services.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
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

        builder.Services.AddMudServices(config =>
        {
            config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;
            config.SnackbarConfiguration.PreventDuplicates = true;
            config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            config.SnackbarConfiguration.ShowCloseIcon = true;
        });

        builder.Services.AddHttpClient();
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddAuthentication();
        builder.Services.AddCascadingAuthenticationState();

        //Services
        builder.Services.AddScoped<AuthorService>();
        builder.Services.AddScoped<BookService>();
        builder.Services.AddScoped<AuthorizationService>();
        builder.Services.AddScoped<ArtistService>();
        builder.Services.AddScoped<CoverService>();

        //Repos
        builder.Services.AddScoped<AuthorRepository>();
        builder.Services.AddScoped<BookRepository>();
        builder.Services.AddScoped<AuthorizationRepository>();
        builder.Services.AddScoped<ArtistRepository>();
        builder.Services.AddScoped<CoverRepository>();

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
