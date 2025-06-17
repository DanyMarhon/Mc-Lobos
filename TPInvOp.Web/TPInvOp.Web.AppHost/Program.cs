var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.TPInvOp_Web_ApiService>("apiservice");

builder.AddProject<Projects.TPInvOp_Web_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
