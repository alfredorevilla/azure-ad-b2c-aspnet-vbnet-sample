# An ASP.NET Web Forms app written in VB.NET signing-in users in Azure AD B2C



### Setup
Add an appSettings.config file with the following content:
```xml
<?xml version="1.0" encoding="utf-8" ?>
<appSettings >
  <add key="ida:ClientId" value="client-id"/>
  <add key="ida:MetadataAddress" value="https://tenant-name.b2clogin.com/tfp/tenant-name.onmicrosoft.com/policy-name/v2.0/.well-known/openid-configuration"/>
  <add key="ida:RedirectUri" value="https://localhost:44321/signin-oidc"/>
</appSettings>
```

### Run
From Visual Studio: Press Ctrl+F5

---
Copyright (c) Microsoft Corporation. All rights reserved.