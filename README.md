# Microsoft Entra External ID for customers (CIAM)

[![.NET](https://github.com/damienbod/EntraExternalIdCiam/actions/workflows/dotnet.yml/badge.svg)](https://github.com/damienbod/EntraExternalIdCiam/actions/workflows/dotnet.yml)

- [ASP.NET Core authentication using Microsoft Entra External ID for customers (CIAM)](https://damienbod.com/2023/05/30/asp-net-core-authentication-using-microsoft-entra-external-id-for-customers-ciam/)
- [ASP.NET Core authorization using Entra External ID CIAM and Azure AD security groups](https://damienbod.com/2023/06/05/asp-net-core-authorization-using-entra-external-id-ciam-and-azure-ad-security-groups/)

Code Flow with PKCE using Microsoft.Identity.Web client

```csharp
builder.Services.AddDistributedMemoryCache();

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("EntraExternalID"))
    .EnableTokenAcquisitionToCallDownstreamApi()
    .AddDistributedTokenCaches();
```

appsettings.json for CIAM

```json
"EntraExternalID": {
    "Authority": "https://damienbodciam.onmicrosoft.ciamlogin.com",
    "ClientId": "0990af2f-c338-484d-b23d-dfef6c65f522",
    "CallbackPath": "/signin-oidc",
    "SignedOutCallbackPath ": "/signout-callback-oidc"
    // "ClientSecret": "--in-user-secrets--" // use certificate for prod
},
```

## History

- 2023-11-03 Updated packages

## Links

https://learn.microsoft.com/en-us/azure/active-directory/external-identities/customers

https://learn.microsoft.com/en-us/azure/active-directory/external-identities/

https://www.microsoft.com/en-us/security/business/identity-access/microsoft-entra-external-id

https://www.cloudpartner.fi/?p=14685

https://developer.microsoft.com/en-us/identity/customers

https://techcommunity.microsoft.com/t5/microsoft-entra-azure-ad-blog/microsoft-entra-external-id-public-preview-developer-centric/ba-p/3823766

https://github.com/Azure-Samples/ms-identity-ciam-dotnet-tutorial
