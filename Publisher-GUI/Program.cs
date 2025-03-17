using MudBlazor.Services;
using Publisher_GUI.Data.Repositories;
using Publisher_GUI.Data.Services;

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

        //Services
        builder.Services.AddScoped<AuthorService>();
        builder.Services.AddScoped<BookService>();

        //Repos
        builder.Services.AddScoped<AuthorRepository>();
        builder.Services.AddScoped<BookRepository>();

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

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
