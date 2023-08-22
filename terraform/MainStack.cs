using System;
using System.Collections.Generic;
using Constructs;
using HashiCorp.Cdktf;
using HashiCorp.Cdktf.Providers.Azurerm;
using azurerm.Provider;
using azurerm.VirtualNetwork;

namespace MyCompany.MyApp
{
    class MainStack : TerraformStack
    {
        public MainStack(Construct scope, string id) : base(scope, id)
        {
            var subscriptionId = Environment.GetEnvironmentVariable("SubscriptionId");
            var clientId = Environment.GetEnvironmentVariable("ClientId");
            var clientSecret = Environment.GetEnvironmentVariable("ClientSecret");
            var tenantId = Environment.GetEnvironmentVariable("TenantId");
            
            System.Console.WriteLine($"SubscriptionId: '{subscriptionId}'");

             new AzurermProvider(this, "AzureRm", new AzurermProviderConfig {
                Features = new AzurermProviderFeatures(),
                SubscriptionId = subscriptionId,
                ClientId = clientId,
                ClientSecret = clientSecret,
                TenantId = tenantId,
                SkipProviderRegistration = true
            });

            new VirtualNetwork(this, "TfVnet", new VirtualNetworkConfig {
                Location = "uksouth",
                AddressSpace = new [] {"10.0.0.0/24"},
                Name = "TerraformVNet",
                ResourceGroupName = "MikesApp"
            });
        }
    }
}