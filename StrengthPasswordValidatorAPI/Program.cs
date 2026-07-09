using StrengthPasswordValidatorAPI.Models.Contracts;
using StrengthPasswordValidatorAPI.Services.ValidatePassword;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IPasswordRuleStrategy, MinimumLengthStrategy>();
builder.Services.AddSingleton<IPasswordRuleStrategy, NoRepeatedCharacterStrategy>();
builder.Services.AddSingleton<IPasswordRuleStrategy, RequiredLowerCaseStrategy>();
builder.Services.AddSingleton<IPasswordRuleStrategy, RequiredUpperCaseStrategy>();
builder.Services.AddSingleton<IPasswordRuleStrategy, RequiredSpecialCharacterStrategy>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
