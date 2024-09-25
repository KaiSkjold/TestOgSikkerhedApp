using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;
using TestOgSikkerhedApp.Codes;
using TestOgSikkerhedApp.Components;
using TestOgSikkerhedApp.Components.Account;
using TestOgSikkerhedApp.Data;
using TestOgSikkerhedApp.Interfaces;
using TestOgSikkerhedApp.Repositories;
using TestOgSikkerhedApp.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddSingleton<HashingHandler>();
builder.Services.AddSingleton<SymetriskEncryptionHandler>();
builder.Services.AddSingleton<AsymetriskEncryptionHandler>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

builder.Services.AddScoped<ICpr, CprRepo>();
builder.Services.AddScoped<IToDoItem, ToDoItemRepo>();
builder.Services.AddScoped<ToDoItemRepo>();
builder.Services.AddScoped<CprRepo>();

// Database ToDoItem
var connectionString = builder.Configuration.GetConnectionString("connection") ?? throw new InvalidOperationException("Connection string 'connection' not found.");
builder.Services.AddDbContext<TodoItemContext>(options =>
    options.UseSqlServer(connectionString));

// Database Identity
var defaultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(defaultConnectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ToDoModel>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ToDoModel>, IdentityNoOpEmailSender>();

// Add authorization and role to app
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AuthenticatedUser", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
    options.AddPolicy("RequireAdministratorRole", policy =>
    {
        policy.RequireRole("Admin");
    });
});

// Kestrel configuration
builder.WebHost.UseKestrel((context, serverOptions) => {
    serverOptions.Configure(context.Configuration.GetSection("Kestrel"))
    .Endpoint("HTTPS", listenOptions => { listenOptions.HttpsOptions.SslProtocols = SslProtocols.Tls13; });
});

string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
userFolder = Path.Combine(userFolder, ".aspnet");
userFolder = Path.Combine(userFolder, "https");
userFolder = Path.Combine(userFolder, "Aisha.pfx");
builder.Configuration.GetSection("Kestrel:Endpoints:Https:Certificate:Path").Value = userFolder;

string kestrelPassword = builder.Configuration.GetValue<string>("KestrelPassword");
builder.Configuration.GetSection("Kestrel:Endpoints:Https:Certificate:Password").Value = kestrelPassword;

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 1;
});

// Add encryption
builder.Services.AddDataProtection();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// CORS Policy - so 2 processes can talk to each other
//app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
