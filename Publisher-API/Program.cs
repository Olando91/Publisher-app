using Applikation.ApiResponse;
using Applikation.DTOs;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using Applikation.UseCases.Create;
using Applikation.UseCases.Delete;
using Applikation.UseCases.Read;
using Applikation.UseCases.Update;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;
using Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Publisher API",
        Version = "v1",
        Description = "API registering authors and artists, as well as their books and covers"
    });
});

builder.Services.AddDbContext<PublisherDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Usecases
builder.Services.AddScoped<IUseCase<IAddAuthorRequest, IResponse<string>>, AddAuthorUseCase>();
builder.Services.AddScoped<IUseCase<IGetAuthorByIdRequest, IResponse<AuthorDTO?>>, GetAuthorByIdUseCase>();
builder.Services.AddScoped<IUseCase<IDeleteAuthorByIdRequest, IResponse<string>>, DeleteAuthorByIdUseCase>();
builder.Services.AddScoped<IUseCase<IGetAllAuthorsRequest, IResponse<List<AuthorDTO>>>, GetAllAuthorsUseCase>();
builder.Services.AddScoped<IUseCase<IEditAuthorRequest, IResponse<AuthorDTO>>, EditAuthorUseCase>();

builder.Services.AddScoped<IUseCase<IAddBookRequest, IResponse<string>>, AddBookUseCase>();
builder.Services.AddScoped<IUseCase<IEditBookRequest, IResponse<BookDTO>>, EditBookUseCase>();
builder.Services.AddScoped<IUseCase<IDeleteBookRequest, IResponse<string>>, DeleteBookUseCase>();

builder.Services.AddScoped<IUseCase<IAddArtistRequest, IResponse<string>>, AddArtistUseCase>();
builder.Services.AddScoped<IUseCase<IGetArtistByIdRequest, IResponse<ArtistDTO>>, GetArtistByIdUseCase>();
builder.Services.AddScoped<IUseCase<IDeleteArtistByIdRequest, IResponse<string>>, DeleteArtistByIdUseCase>();
builder.Services.AddScoped<IUseCase<IGetAllArtistsRequest, IResponse<List<ArtistDTO>>>, GetAllArtistsUseCase>();
builder.Services.AddScoped<IUseCase<IEditArtistRequest, IResponse<ArtistDTO>>, EditArtistUseCase>();

builder.Services.AddScoped<IUseCase<IAddCoverRequest, IResponse<string>>, AddCoverUseCase>();
builder.Services.AddScoped<IUseCase<IGetCoverByIdRequest, IResponse<CoverDTO>>, GetCoverByIdUseCase>();
builder.Services.AddScoped<IUseCase<IDeleteCoverByIdRequest, IResponse<string>>, DeleteCoverByIdUseCase>();
builder.Services.AddScoped<IUseCase<IGetAllCoversRequest, IResponse<List<CoverDTO>>>, GetAllCoversUseCase>();
builder.Services.AddScoped<IUseCase<IEditCoverRequest, IResponse<CoverDTO>>, EditCoverUseCase>();
builder.Services.AddScoped<IUseCase<IAddArtistToCoverRequest, IResponse<CoverDTO>>, AddArtistToCoverUseCase>();
builder.Services.AddScoped<IUseCase<IRemoveArtistFromCoverRequest, IResponse<CoverDTO>>, RemoveArtistFromCoverUseCase>();

// Repositories
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<ICoverRepository, CoverRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Publisher API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
