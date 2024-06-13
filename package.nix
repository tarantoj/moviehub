{
  pkgs,
  buildDotnetModule,
  ...
}:
buildDotnetModule {
  pname = "MovieHub.Api";
  version = "0.0.1";
  src = ./src;
  projectFile = "./MovieHub.Api/MovieHub.Api.csproj";
  nugetDeps = ./deps.nix;
  dotnet-sdk = pkgs.dotnet-sdk_8;
  dotnet-runtime = pkgs.dotnet-aspnetcore_8;
}
