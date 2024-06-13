using Microsoft.EntityFrameworkCore ; 
using Api.Data ; 
using Api.Repositories ; 
using Api.Mapping ; 
using System.Text ; 
using Microsoft.AspNetCore.Authentication.JwtBearer ; 
using Microsoft.IdentityModel.Tokens ; 
using Microsoft.AspNetCore.Identity ;
using Microsoft.OpenApi.Models ; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//database
builder.Services.AddDbContext<ServiceContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("TrackedServices"))
) ; 

builder.Services.AddDbContext<ServiceAuthContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("TrackedAuthServices"))
) ;

//injecting repository
builder.Services.AddScoped<IClientRepository , SqlClientRepository>() ;
builder.Services.AddScoped<IUserRepository , SqlUserRepository>() ;
builder.Services.AddScoped<IServiceRepository , SqlServiceRepository>() ;
builder.Services.AddScoped<ITokenRepository , TokenRepository>();

//injecting automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile)) ;

//Setting up identity for authentication
builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("Tracked")
    .AddEntityFrameworkStores<ServiceAuthContext>()
    .AddDefaultTokenProviders() ;

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false ;
    options.Password.RequireLowercase = false ; 
    options.Password.RequireNonAlphanumeric = false ;
    options.Password.RequireUppercase = false ; 
    options.Password.RequiredLength = 7 ; 
    options.Password.RequiredUniqueChars = 1 ;
}) ;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//configure authorization
builder.Services.AddSwaggerGen(options => 
{

    options.SwaggerDoc("v1", new OpenApiInfo {Title = "Tracked services API" , Version ="v1"}) ;
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {

        Name    = "Authorization" ,
        In      = ParameterLocation.Header,
        Type    = SecuritySchemeType.ApiKey,
        Scheme  = JwtBearerDefaults.AuthenticationScheme

    }) ;

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id   = JwtBearerDefaults.AuthenticationScheme
                } , 

                Scheme  = "Oauth2",
                Name    = JwtBearerDefaults.AuthenticationScheme,
                In      = ParameterLocation.Header

            } ,
            new List<string>()
        }
    });

});

//Authentication method
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) 
    .AddJwtBearer( options =>
    options.TokenValidationParameters = new TokenValidationParameters{
        ValidateIssuer = true , 
        ValidateAudience = true ,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true , 
        ValidIssuer = builder.Configuration["Jwt:Issuer"] , 
        ValidAudience = builder.Configuration["Jwt:Audience"] ,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    }); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication() ;
app.UseAuthorization();

app.MapControllers();

app.Run();
