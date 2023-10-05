//Global use - added
global using GitCopy.Models;
global using GitCopy.Services.PostService;
global using GitCopy.Dtos.Post;
global using GitCopy.Services.CommentService;
global using AutoMapper;
global using GitCopy.Data;
global using Microsoft.EntityFrameworkCore;
global using GitCopy.Models;
global using GitCopy.Services.CommentService;
global using GitCopy.Dtos.Comment;
global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using GitCopy.Data;
global using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.OpenApi.Models;


//------------------------------------------------------------------

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// added to the existing SwaggerGen(***)
builder.Services.AddSwaggerGen(c => {
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme {
        Description = """Standard Authorization header using the bearer scheme. Example: "bearer {token}" """,
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.OperationFilter<SecurityRequirementsOperationFilter>();
});


//added services

// AddScoped - Create a new instants of the requisted service for every Requist that comes in
// AddTransient - provide a new istants to every controller and to every service even within the same requist
// AddSingelton - Create only one Instants that is used for every request
builder.Services.AddAutoMapper(typeof(Program).Assembly);


builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommentService, CommentService>();



// Add Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => 
    {
        options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                    .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
    });
builder.Services.AddHttpContextAccessor();



//-------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



//Adding an operation
app.UseAuthentication();



app.UseAuthorization();

app.MapControllers();

app.Run();
