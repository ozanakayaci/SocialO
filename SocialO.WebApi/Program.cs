using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SocialO.DAL.DBContexts;
using SocialO.WebApi.Extensions;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
						options.AddDefaultPolicy(builder =>
													builder.AllowAnyHeader()
													.AllowAnyMethod()
													.AllowAnyOrigin()));



builder.Services.AddDbContext<SqlDBContext>(options => options.UseSqlite(@"Data Source=SocialO.db"));

builder.Services.AddSocialOServices();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
	options.RequireHttpsMetadata = false;
	options.SaveToken = true;
	options.TokenValidationParameters = new TokenValidationParameters()
	{
		ValidateAudience = true,
		ValidateIssuer = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = builder.Configuration["Token:Issuer"],
		ValidAudience = builder.Configuration["Token:Audience"],
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
		ClockSkew = TimeSpan.Zero
	};

	options.Events = new JwtBearerEvents
	{
		OnTokenValidated = context =>
		{
			var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
			if (claimsIdentity != null)
			{
				// UserType claim'ini ekleyin
				claimsIdentity.AddClaim(new Claim("UserType", "admin")); // UserType'ı dilediğiniz gibi ayarlayabilirsiniz
			}
			return Task.CompletedTask;
		}
	};
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
