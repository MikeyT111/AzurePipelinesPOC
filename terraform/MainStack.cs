using System;
using System.Collections.Generic;
using Constructs;
using HashiCorp.Cdktf;
using HashiCorp.Cdktf.Providers.Azurerm;


namespace MyCompany.MyApp
{
    class MainStack : TerraformStack
    {
        public MainStack(Construct scope, string id) : base(scope, id)
        {
             new AzurermProvider(this, "AzureRm", new AzurermProviderConfig {
                Features = new AzurermProviderFeatures()
            });

            new VirtualNetwork(this, "TfVnet", new VirtualNetworkConfig {
                Location = "uksouth",
                AddressSpace = new [] {"10.0.0.0/24"},
                Name = "TerraformVNet",
                ResourceGroupName = "<YOUR_RESOURCE_GROUP_NAME>"
            }); new AzurermProvider(this, "AzureRm", new AzurermProviderConfig {
                Features = new AzurermProviderFeatures()
            });

            new VirtualNetwork(this, "TfVnet", new VirtualNetworkConfig {
                Location = "uksouth",
                AddressSpace = new [] {"10.0.0.0/24"},
                Name = "TerraformVNet",
                ResourceGroupName = "<YOUR_RESOURCE_GROUP_NAME>"
            });
        }
    }
}