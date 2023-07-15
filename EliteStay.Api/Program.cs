using EliteStay.Domain.BookingContext.Handlers;
using EliteStay.Domain.BookingContext.Repositories;
using EliteStay.Domain.BookingContext.Utils;
using EliteStay.Infra.BookingContext.Repositories;
using EliteStay.Infra.BookingContext.DataContexts;
using EliteStay.Infra.Utils;
using Microsoft.OpenApi.Models;
using EliteStay.Shared;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using EliteStay.Domain.BookingContext.Services;
using EliteStay.Infra.BookingContext.Services;
using System.Reflection;
using Microsoft.Net.Http.Headers;
using EliteStay.Api.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddCors();

var key = Encoding.ASCII.GetBytes(Settings.Secret);
builder.Services.AddAuthentication(o =>
{
  o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
  o.RequireHttpsMetadata = true;
  o.SaveToken = true;
  o.TokenValidationParameters = new TokenValidationParameters
  {
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(key),
    ValidateIssuer = false,
    ValidateAudience = false
  };
});

builder.Services.AddScoped<EliteStayDataContext, EliteStayDataContext>();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<UserHandler, UserHandler>();

builder.Services.AddTransient<IRoomRepository, RoomRepository>();
builder.Services.AddTransient<RoomHandler, RoomHandler>();

builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<BookHandler, BookHandler>();

builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();
builder.Services.AddTransient<ITokenService, TokenService>();

builder.Services.AddSwaggerGen(x =>
{
  x.SwaggerDoc("v1", new OpenApiInfo { Title = "EliteStay", Version = "v1" });

  var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
  var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
  x.IncludeXmlComments(xmlPath);

  x.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
  {
    Description = @"JWT Authorization Header usando o padrão Bearer. <br/> 
                  Utilize a rota /authenticate do bloco User para gerar o token<br/>
                  Depois apenas cole o token gerado na caixa abaixo:
                  <br/>Exemplo: '12345abcdef'",
    Type = SecuritySchemeType.Http,
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Scheme = "bearer"
  });
  x.OperationFilter<AuthenticationRequirementsOperationFilter>();
});


var app = builder.Build();

app.UseCors(o =>
  o.AllowAnyHeader()
  .AllowAnyOrigin()
  .AllowAnyMethod()
);
app.UseStatusCodePages();

app.UseAuthorization();
app.UseAuthentication();

app.UseMvc();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(c =>
  {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
  });
}

app.Run();
