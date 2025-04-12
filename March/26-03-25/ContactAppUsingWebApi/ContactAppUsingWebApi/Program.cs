using System.Text;
using ContactAppUsingWebApi.Data;
using ContactAppUsingWebApi.Exception;
using ContactAppUsingWebApi.Exceptions;
using ContactAppUsingWebApi.Interface.IRepositoryes;
using ContactAppUsingWebApi.Interface.IServices;
using ContactAppUsingWebApi.Interfaces.IRepository;
using ContactAppUsingWebApi.Interfaces.IRepositoryes;
using ContactAppUsingWebApi.Interfaces.IService;
using ContactAppUsingWebApi.Mapping;
using ContactAppUsingWebApi.Model.Entity;
using ContactAppUsingWebApi.Repository;
using ContactAppUsingWebApi.Service;
using JWTImplementation.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddTransient<IRoleServices, RoleServices>();
builder.Services.AddTransient<IContactServices, ContactServices>();
builder.Services.AddTransient<IContactDetailsServices, ContactDetailsServices>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IContactDetailsRepository, ContactDetailsRepository>();
builder.Services.AddTransient<IGenericRepository<User>, GenericRepository<User> >();
builder.Services.AddTransient<IGenericRepository<Contact>, GenericRepository<Contact>>();
builder.Services.AddTransient<IGenericRepository<ContactDetails>, GenericRepository<ContactDetails>>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddExceptionHandler<GlobalNotFoundException>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<MyContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler(_ => { });
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
