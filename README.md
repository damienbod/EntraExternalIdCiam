# Microsoft Entra External ID for customers (CIAM)

[![.NET](https://github.com/damienbod/EntraExternalIdCiam/actions/workflows/dotnet.yml/badge.svg)](https://github.com/damienbod/EntraExternalIdCiam/actions/workflows/dotnet.yml)

[ASP.NET Core authentication using Microsoft Entra External ID for customers (CIAM)](https://damienbod.com)

Code Flow with PKCE using Microsoft.Identity.Web client

```csharp
builder.Services.AddDistributedMemoryCache();

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
        .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("EntraExternalID"))
        .EnableTokenAcquisitionToCallDownstreamApi()
        .AddDistributedTokenCaches();
```

App.Settings for CIAM

```json
"EntraExternalID": {
    "Instance": "https://login.microsoftonline.com/",
    "ClientId": "0990af2f-c338-484d-b23d-dfef6c65f522",
    "Domain": "damienbodciam.onmicrosoft.com", // public preview
    "TenantId": "76557992-152e-4b59-9624-532b63a1e7cd",
    "CallbackPath": "/signin-oidc",
    "SignedOutCallbackPath ": "/signout-callback-oidc"
    // "ClientSecret": "--in-user-secrets--" // use certificate for prod
},
```


## Links

https://learn.microsoft.com/en-us/azure/active-directory/external-identities/

https://www.microsoft.com/en-us/security/business/identity-access/microsoft-entra-external-id

https://www.cloudpartner.fi/?p=14685

https://developer.microsoft.com/en-us/identity/customers

https://techcommunity.microsoft.com/t5/microsoft-entra-azure-ad-blog/microsoft-entra-external-id-public-preview-developer-centric/ba-p/3823766
