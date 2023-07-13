using EliteStay.Domain.BookingContext.Handlers;
using EliteStay.Domain.BookingContext.Repositories;
using EliteStay.Infra.BookingContext.Repositories;
using EliteStay.Infra.DataContexts;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddScoped<EliteStayDataContext, EliteStayDataContext>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<UserHandler, UserHandler>();


builder.Services.AddSwaggerGen(x =>
{
  x.SwaggerDoc("v1", new OpenApiInfo { Title = "EliteStay", Version = "v1" });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(c =>
  {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
  });
}

app.UseMvc();

app.Run();
