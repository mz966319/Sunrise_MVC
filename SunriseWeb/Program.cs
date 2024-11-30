using Microsoft.EntityFrameworkCore;
using Sunrise.DataAccess.Data;
using Sunrise.DataAccess.Repository;
using Sunrise.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Sunrise.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;
using Sunrise.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
//        sqlServerOptionsAction: sqlOptions =>
//        {
//            sqlOptions.EnableRetryOnFailure(
//                maxRetryCount: 5, // Number of retries before failing
//                maxRetryDelay: TimeSpan.FromSeconds(10), // Maximum delay between retries
//                errorNumbersToAdd: null // List of additional error numbers that need retry logic, can be null
//            );
//        }));


builder.Services.AddIdentity<IdentityUser,IdentityRole>(/*options => options.SignIn.RequireConfirmedAccount = true*/).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Disable password requirements
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 4; // Set to minimum acceptable length (e.g., 1)
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 1; // Set to minimum value
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";

});
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<UserManager<IdentityUser>>();


var app = builder.Build();


// Call the method to seed the default user
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    await SeedDefaultUserAsync(userManager, roleManager);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Teacher}/{controller=Home}/{action=Index}/{id?}");

app.Run();


async Task SeedDefaultUserAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
{
    // Define the default role and user details
    string roleName = SD.Role_Super_Admin;
    string userName = "admin";
    //string userEmail = "admin@example.com";
    string userPassword = "pass";

    // Create the Admin role if it doesn't exist
    if (!await roleManager.RoleExistsAsync(roleName))
    {
        await roleManager.CreateAsync(new IdentityRole(roleName));
    }

    // Create the default user if it doesn't exist
    if (await userManager.FindByNameAsync(userName) == null)
    {
        var user = new ApplicationUser
        {
            UserName = userName,
            //Email = userEmail,
            //EmailConfirmed = true // Skip email confirmation for default user
        };

        var result = await userManager.CreateAsync(user, userPassword);
        user.FullName = "Admin";
        user.userType = roleName;
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, roleName);
        }
    }
}