using Autofac;
using Autofac.Extensions.DependencyInjection;
using Hastane.Business.IoC;
using Hastane.DataAccess.Abstract;
using Hastane.DataAccess.EntityFramework.Concrete;
using Hastane.DataAccess.EntityFramework.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using NRM1_HastaneOtomasyon.Models.SeedDataFolder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HastaneDbContext>(_ =>
{
    _.UseSqlServer(builder.Configuration.GetConnectionString("HastaneConnectionString"));
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Login/Login";
    x.AccessDeniedPath = "/Home/Error";
    x.Cookie = new CookieBuilder
    {
        Name = "NRM1Cookie1",
        SecurePolicy = CookieSecurePolicy.Always, // Http istekleri tarafýndan eriþilebilir yaptýk
        HttpOnly = true, // Client-Side tarafýndan cookie'nin eriþilebilir olmasýný saðlýyoruz. DÝKKAT !!!! : Sen kendin yayýnlayacaðýn bir site yazarken Bunu False olarak iþaretliyorsun. Kötü kiþiler client side tarafýndaki bütün olaylara hakim olabildiði için senin sistemini buradan patlatabilir.
    };
    x.ExpireTimeSpan = TimeSpan.FromMinutes(15);
    x.SlidingExpiration = true;//Ýstek gelirse cookie'nin süresinin uzatýlacaðýný söyledik.
    x.Cookie.MaxAge = x.ExpireTimeSpan;
});


//AUTOFA IMPLEMENTATION
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new DependencyResolver());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


SeedData.Seed(app);
app.UseHttpsRedirection();
app.UseStaticFiles();

//app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
