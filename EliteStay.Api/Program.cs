using EliteStay.Domain.BookingContext.Handlers;
using EliteStay.Domain.BookingContext.Repositories;
using EliteStay.Infra.BookingContext.Repositories;
using EliteStay.Infra.DataContexts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddScoped<EliteStayDataContext, EliteStayDataContext>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<UserHandler, UserHandler>();


var app = builder.Build();

app.MapGet("/", () => new { version = "Version 1" });
app.UseMvc();
app.Run();
