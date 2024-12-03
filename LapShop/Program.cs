using LapShop.Bl;
using LapShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Xml;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllersWithViews();
#region Entity Framework
builder.Services.AddDbContext<LapShopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<LapShopContext>(); 
#endregion

#region Custom Services
builder.Services.AddScoped<ICategories, ClsCategories>();
builder.Services.AddScoped<IItems, ClsItems>();
builder.Services.AddScoped<IItemTypes, ClsItemTypes>();
builder.Services.AddScoped<IOs, ClsOs>();
builder.Services.AddScoped<IItemImages, ClsItemImages>();
builder.Services.AddScoped<ISalesInvoice, ClsSalesInvoice>();
builder.Services.AddScoped<ISalesInvoiceItems, ClsSalesInvoiceItems>();
builder.Services.AddScoped<ISliders, ClsSliders>();
builder.Services.AddScoped<ISettings, ClsSettings>();
builder.Services.AddScoped<IPages, ClsPages>();
#endregion
//builder.Services.AddScoped<VmHomePage>();

#region Sesstion and cookies
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Users/AccessDenied";
    options.Cookie.Name = "Cookie";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
    options.LoginPath = "/Users/Login";
    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    options.SlidingExpiration = true;
});
#endregion

#region Swagger
//builder.Services.AddSwaggerGen(options =>
//{
//    options.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Version = "v1",
//        Title = "Lao Shop Api",
//        Description = "api to access items and related categories",
//        TermsOfService = new Uri("https://itlegend.net/"),
//        Contact = new OpenApiContact
//        {
//            Email = "info@itlegend.net",
//            Name = "Ali Shahin",
//            Url = new Uri("https://itlegend.net/")
//        },
//        License = new OpenApiLicense
//        {
//            Name = "It Legend Licence",
//            Url = new Uri("https://itlegend.net/")
//        }
//    });

//    var xmlComments = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//    var fullPath = Path.Combine(AppContext.BaseDirectory, xmlComments);
//    options.IncludeXmlComments(fullPath);
//}); 
#endregion

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

#region Swagger UI
//app.UseSwagger();
//app.UseSwaggerUI(options =>
//{
//    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
//    options.RoutePrefix = string.Empty;
//}); 
#endregion

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

#region Routing
app.UseEndpoints(endpoints =>
{
endpoints.MapControllerRoute(
name: "admin",
pattern: "{area:exists}/{controller=Home}/{action=Index}");

endpoints.MapControllerRoute(
name: "LandingPages",
pattern: "{area:exists}/{controller=Home}/{action=Index}");

endpoints.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");

endpoints.MapControllerRoute(
name: "ali",
pattern: "ali/{controller=Home}/{action=Index}/{id?}");



}
); 
#endregion

app.Run();
