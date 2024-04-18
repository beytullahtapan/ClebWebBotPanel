using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AdminUser, AdminRole>()
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
    options.LoginPath = "/Login/Index";
});

builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
{
    opt.TokenLifespan = TimeSpan.FromMinutes(60);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
