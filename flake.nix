{
  description = "A Nix-flake-based C# development environment";

  inputs.nixpkgs.url = "github:nixos/nixpkgs/nixos-23.11";

  outputs = {
    self,
    nixpkgs,
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
  };
}
