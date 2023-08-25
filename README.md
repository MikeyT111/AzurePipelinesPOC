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

# Docker build commands

## Builds the terraform base image so that we can use the CDK later. 
docker build -t infrasetup --target setup -f Dockerfile.infrasetup . 

## Builds the baseimage with a different version of the BASE Image.
docker build -t infrasetup --target setup -f Dockerfile.infrasetupU .  


## Builds the terraform CDK project.
docker build -t infrabuild --target build -f Dockerfile.infrabuild .

## build the CDK image to run that will deploy it to the account
docker build -t infradeploy --target deploy -f Dockerfile.infradeploy .


docker build -t infradeploy -f Dockerfile.infradeploy .

## Run the CDK image
docker run infradeploy
