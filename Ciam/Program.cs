using Ciam;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("EntraExternalID"))
    .EnableTokenAcquisitionToCallDownstreamApi()
    .AddDistributedTokenCaches();

builder.Services.Configure<MicrosoftIdentityOptions>(
    OpenIdConnectDefaults.AuthenticationScheme, options =>
    {
        options.Prompt = "select_account";
    });

builder.Services.AddSingleton<IAuthorizationHandler, UserAdminHandler>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserPolicy", policy =>
    {
        policy.RequireClaim("roles", "user-role");
    });
    options.AddPolicy("AdminPolicy", policy =>
    {
        policy.RequireClaim("roles", "admin-role");
    });
    options.AddPolicy("UserAdminPolicy", policy =>
    {
        policy.AddRequirements(new UserAdminRequirement());
    });
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AllowAnonymousToPage("/Index");
})
.AddMvcOptions(options => { })
.AddMicrosoftIdentityUI();

var app = builder.Build();

JsonWebTokenHandler.DefaultInboundClaimTypeMap.Clear();
IdentityModelEventSource.ShowPII = true;

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

app.MapRazorPages();
app.MapControllers();

app.Run();