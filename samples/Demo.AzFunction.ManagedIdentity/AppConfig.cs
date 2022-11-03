﻿using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using PnP.Core.Auth;
using System.Security.Cryptography.X509Certificates;
using PnP.Core.Services.Builder.Configuration;
using System;

namespace Demo.AzFunction.ManagedIdentity
{
    // To get an environment variable or an app setting value, use System.Environment.GetEnvironmentVariable
    // The System.Configuration.ConfigurationManager.AppSettings property is an alternative API for getting app setting values, but we recommend that you use GetEnvironmentVariable as shown here.
    // https://learn.microsoft.com/en-us/azure/azure-functions/functions-dotnet-class-library?tabs=v2%2Ccmd#environment-variables
    public class AppConfig
    {
        static string siteName = Environment.GetEnvironmentVariable("SiteName");
        static string tenantName = Environment.GetEnvironmentVariable("TenantName");

        // When MSI is enabled for an App Service, two environment variables MSI_ENDPOINT and MSI_SECRET are available
        public bool isMSI = !String.IsNullOrEmpty(Environment.GetEnvironmentVariable("MSI_SECRET"));

        public string SiteUrl = $"https://{tenantName}.sharepoint.com/sites/{siteName}";
    }
    public class AppConfigCert
    {
        public string ClientId = Environment.GetEnvironmentVariable("ClientId");
        public string TenantId = Environment.GetEnvironmentVariable("TenantId");
        public string CertificateThumbprint = Environment.GetEnvironmentVariable("CertificateThumbprint");
    }
}