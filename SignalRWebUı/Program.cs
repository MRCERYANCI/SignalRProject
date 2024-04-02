using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using SignalRDataAccessLayer.Concrete;
using SignalREntityLayer.Entities;

var builder = WebApplication.CreateBuilder(args);

var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();  //T�mj Proje Seviyesinde Login �le Giri�i Zorunlu K�l

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));  //B�t�n Contorllere authentication i�lemini koy Yani Giri� Zorunlulu�unu Koy
});

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
//{
//    x.LoginPath = "/Login/Index";
//});  //EntityFramework da �al���yo

builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.LoginPath = "/Login/Index";
});  //Corede bu y�ntem �al���yo

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<SignalRContext>();
builder.Services.AddDbContext<SignalRContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();//Sistemde Oldu�umu Belirtiyoz
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
