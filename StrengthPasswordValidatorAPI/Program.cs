using Microsoft.Extensions.DependencyInjection;
using StrengthPasswordValidatorAPI.Models.Contracts;
using StrengthPasswordValidatorAPI.Services;
using StrengthPasswordValidatorAPI.Services.ValidatePassword;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddSingleton<IPasswordRuleStrategy, MinimumLengthStrategy>();
builder.Services.AddSingleton<IPasswordRuleStrategy, NoRepeatedCharacterStrategy>();
builder.Services.AddSingleton<IPasswordRuleStrategy, RequiredLowerCaseStrategy>();
builder.Services.AddSingleton<IPasswordRuleStrategy, RequiredUpperCaseStrategy>();
builder.Services.AddSingleton<IPasswordRuleStrategy, RequiredSpecialCharacterStrategy>();

builder.Services.AddSingleton<IValidatePasswordService, ValidatePasswordService>();

builder.Services.AddOpenApi();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapStaticAssets();


app.Run();
