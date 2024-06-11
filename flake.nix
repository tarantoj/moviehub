{
  description = "A Nix-flake-based C# development environment";

  inputs.nixpkgs.url = "github:nixos/nixpkgs/nixos-24.05";
  inputs.pre-commit-hooks = {
    url = "github:cachix/pre-commit-hooks.nix";
    inputs.nixpkgs.follows = "nixpkgs";
  };

  outputs = {
    self,
    nixpkgs,
    pre-commit-hooks,
  }: let
    supportedSystems = ["x86_64-linux" "aarch64-linux" "x86_64-darwin" "aarch64-darwin"];
    forEachSupportedSystem = f:
      nixpkgs.lib.genAttrs supportedSystems (system:
        f {
          pkgs = import nixpkgs {inherit system;};
        });
  in {
    devShells = forEachSupportedSystem ({pkgs}: {
      default = let
        dotnet-combined = with pkgs.dotnetCorePackages; combinePackages [sdk_6_0 sdk_8_0];
      in
        pkgs.mkShell {
          DOTNET_CLI_TELEMETRY_OPTOUT = true;
          DOTNET_ROOT = "${dotnet-combined}";
          packages = with pkgs; [
            dotnet-combined
            # omnisharp-roslyn
            # mono
            # msbuild
          ];
        };
    });
    packages = forEachSupportedSystem ({pkgs}: rec {
      default = pkgs.callPackage ./package.nix {};
      dockerImage = pkgs.dockerTools.buildLayeredImage {
        name = "moviehub";
        tag = "latest";
        contents = [default];
        config = {
          Entrypoint = ["${default}/bin/MovieHub.Api"];
          Env = [
            "ConnectionStrings__MovieHubDatabase=Data Source=MovieHub.sqlite"
            "ConnectionStrings__Cache=cache.sqlite"
          ];
          WorkingDir = "/var/lib/moviehub";
          Volumes = {
            "/var/lib/moviehub/MovieHub.sqlite" = {};
            "/var/lib/moviehub/cache.sqlite" = {};
          };
        };
      };
    });
  };
}
