using Vend.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vend.Data;

var builder = WebApplication.CreateBuilder(args);

// Db + Identity
builder.Services.AddDbContext<IdContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sql => sql.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)));

builder.Services.AddDefaultIdentity<AppUser>(o =>
{
    o.SignIn.RequireConfirmedAccount = false; // until email is wired up
    o.Password.RequireDigit = true;
    o.Password.RequireUppercase = true;
    o.Password.RequiredLength = 8;
})
.AddEntityFrameworkStores<IdContext>();
 
builder.Services.AddAuthentication()
    .AddIdentityCookies();
builder.Services.AddAuthorization();
 
builder.Services.AddRazorPages();

// Blazor Web App (server interactivity)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
 
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

// Identity UI pages
app.MapRazorPages();
 
app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

//// (optional) your seeding code
//using (var scope = app.Services.CreateScope())
//{
//    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
//    await IdentitySeed.SeedRolesAndAdminAsync(roleManager, userManager);
//}

await app.RunAsync();