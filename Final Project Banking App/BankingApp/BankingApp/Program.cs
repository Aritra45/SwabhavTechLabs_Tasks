using System.Text;
using BankingApp.Database;
using BankingApp.Exception;
using BankingApp.Helper;
using BankingApp.Interfaces.IRepository;
using BankingApp.Interfaces.IService;
using BankingApp.Mapper;
using BankingApp.Model.Entity;
using BankingApp.Repository;
using BankingApp.Service;
using CloudinaryDotNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Authentication
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

// Essential Services
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") 
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddMemoryCache();

// Service & Repository Registration
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
builder.Services.AddScoped<IBankServices, BankServices>();
builder.Services.AddScoped<IGenericRepository<Bank>, GenericRepository<Bank>>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IGenericRepository<Company>, GenericRepository<Company>>();

builder.Services.AddScoped<IGenericRepository<Beneficiary>, GenericRepository<Beneficiary>>();

builder.Services.AddScoped<IGenericRepository<Transaction>, GenericRepository<Transaction>>();

builder.Services.AddScoped<IGenericRepository<Employee>, GenericRepository<Employee>>();

// HttpContext & Interceptor for Audit Logging
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<AuditLogInterceptor>();

// Register DbContext with AuditLogInterceptor
builder.Services.AddDbContext<MyContext>((provider, options) =>
{
    var interceptor = provider.GetRequiredService<AuditLogInterceptor>();
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString"))
           .AddInterceptors(interceptor);
});

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Cloudinary Configuration
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));
builder.Services.AddScoped<IPhotoService, PhotoService>();

var cloudinarySettings = builder.Configuration.GetSection("CloudinarySettings").Get<CloudinarySettings>();
var cloudinaryAccount = new Account(cloudinarySettings.CloudName, cloudinarySettings.ApiKey, cloudinarySettings.ApiSecret);
var cloudinary = new Cloudinary(cloudinaryAccount);
builder.Services.AddSingleton(cloudinary);

// SMTP Configuration
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

// Swagger
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
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Global Exception Handling
builder.Services.AddExceptionHandler<GlobalNotFoundException>();

var app = builder.Build();

// Middleware & Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(_ => { });

app.UseHttpsRedirection();

app.UseAuthentication(); // Make sure authentication is used
app.UseCors("AllowFrontend");
app.UseAuthorization();

app.MapControllers();
app.Run();
