# AzurePipelinesPOC
a POC project that will build,test and publish a docker image to DockerHub

Important Terraform Note: make sure you run the command ```cdktf get``` as this will then download the required files it needs to build successfully. This might need to be ran inside the docker container.

## Things to set for it to work in Azure.
First error message 
unable to build authorizer for Resource Manager API: could not configure AzureCli Authorizer: could not parse Azure CLI version: launching Azure CLI: exec: "az": executable file not found in 

The following parameters need to be set:
    SubscriptionId = "",
    ClientId = "",
    ClientSecret = "",
    TenantId = "",