using Applikation.ApiResponse;
using Applikation.DTOs.Artist;
using Applikation.DTOs.Author;
using Applikation.DTOs.Book;
using Applikation.DTOs.Cover;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using Applikation.UseCases.Create;
using Applikation.UseCases.Delete;
using Applikation.UseCases.Read;
using Applikation.UseCases.Update;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository;
using Repository.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Publisher API",
        Version = "v1",
        Description = "API registering authors and artists, as well as their books and covers"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
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
builder.Services.AddScoped<IUseCase<IGetBookByIdRequest, IResponse<BookDTO>>, GetBookByIdUseCase>();
builder.Services.AddScoped<IUseCase<IGetAllBooksRequest, IResponse<List<BookDTO>>>, GetAllBooksUseCase>();

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
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var secret = builder.Configuration.GetValue<string>("Jwt:Secret");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "Lasse",
        ValidAudience = "Lasse",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

//Configure the HTTP request pipeline.
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
