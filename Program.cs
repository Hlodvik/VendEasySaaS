using Vend.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vend.Data;

var builder = WebApplication.CreateBuilder(args);

// Db + Identity (yours as-is)
builder.Services.AddDbContext<IdContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sql => sql.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)));
builder.Services
    .AddDefaultIdentity<AppUser>(o =>
    {
        o.SignIn.RequireConfirmedAccount = false; // until email is wired up
        o.Password.RequireDigit = true;
        o.Password.RequireUppercase = true;
        o.Password.RequiredLength = 8;
    })
    .AddEntityFrameworkStores<IdContext>();

// Keep Razor Pages for Identity UI
builder.Services.AddRazorPages();

// This is the Blazor Web App (server interactivity)
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
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Identity UI pages
app.MapRazorPages();

// Mount your component app (replaces _Host.cshtml approach)
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