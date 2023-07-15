using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EliteStay.Api.Config
{
  public class AuthenticationRequirementsOperationFilter : IOperationFilter
  {
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
      if (operation.Security == null)
        operation.Security = new List<OpenApiSecurityRequirement>();


      var scheme = new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearer" } };
      operation.Security.Add(new OpenApiSecurityRequirement
      {
        [scheme] = new List<string>()
      });
    }
  }
}