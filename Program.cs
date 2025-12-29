using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using StorePOS.API.Repositories;
using StorePOS.API.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<DbHelper>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<RoleRepository>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "StorePOS API",
        Version = "v1"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter: Bearer {token}"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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

var app = builder.Build();   // 🔥 HERE app is created

// middlewares
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "StorePOS API V1");
    c.RoutePrefix = "swagger";
});


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();  // connects Controllers

app.Run();  // ▶ starts the web server
