using Routine.NET.Infrastructure;
using Routine.NET.Application;
using Routine.NET.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<IdentityContext>();
builder.Services.AddInfrastructure(builder.Configuration).AddApplication();

if (app.Environment.IsDevelopment())
{
    builder.Services.Configure<IdentityOptions>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.SignIn.RequireConfirmedAccount = false;
        options.SignIn.RequireConfirmedPhoneNumber = false;
    });
    
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{

}

app.UseHttpsRedirection();
app.MapIdentityApi<IdentityUser>();
app.UseAuthorization();
app.MapControllers();
app.Run();