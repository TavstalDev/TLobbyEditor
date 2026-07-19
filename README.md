# TLobbyEditor

![Release (latest by date)](https://img.shields.io/github/v/release/TavstalDev/TLobbyEditor?style=plastic-square)
![Workflow Status](https://img.shields.io/github/actions/workflow/status/TavstalDev/TLobbyEditor/release.yml?branch=stable&label=build&style=plastic-square)
![License](https://img.shields.io/github/license/TavstalDev/TLobbyEditor?style=plastic-square)
![Downloads](https://img.shields.io/github/downloads/TavstalDev/TLobbyEditor/total?style=plastic-square)
![Issues](https://img.shields.io/github/issues/TavstalDev/TLobbyEditor?style=plastic-square)

A [RocketMod](https://rocketmod.net/) plugin for **Unturned 3.24.x+** servers that lets you fully customize how your server appears in the Steam server browser. Modify descriptions, icons, tags, workshop data, and more.

## Features

- **Server Description** -- Set a custom short tooltip, browser hint, and multi-line server description.
- **Custom Icons & Thumbnails** -- Replace the server browser icon and thumbnail with your own image URLs.
- **Game Tags Override** -- Control PVP/PVE, cheats, BattleEye, difficulty, camera mode, and gold-only status.
- **Reserved Slots** -- Configure a number of reserved player slots with optional permission-based access.
- **Metadata Masking** -- Hide Rocket mod loader, workshop items, config entries, and plugin names from the browser.
- **Custom Data Replacement** -- Replace workshop items, config entries, plugin names, and gamemode displayed in the browser.
- **Custom Links** -- Override the server links shown in the browser.
- **Server Advertisement Toggle** -- Choose whether your server appears in the browser at all.

## Requirements

- Unturned 3.24.x or later
- [RocketMod](https://rocketmod.net/) installed on the server

## Installation

1. Download the latest release and its libraries from the [Releases](https://github.com/TavstalDev/TLobbyEditor/releases) page.
2. Place `TLobbyEditor.dll` into your server's `Rocket/Plugins/` directory.
3. Extract the libraries archive into `Rocket/Libraries` directory.
4. Start or restart the server. The plugin will generate a default YAML configuration file on first load.
5. Edit the configuration file to your liking, then reload the plugin or restart the server.

## Commands

| Command          | Permission             | Description                                |
|------------------|------------------------|--------------------------------------------|
| `/vTLobbyEditor` | `tlobbyeditor.version` | Displays the plugin version and build date |

## Building from Source

### Prerequisites

- .NET Framework 4.8 SDK / targeting pack

### Steps

1. Clone the repository:
   ```
   git clone https://github.com/TavstalDev/TLobbyEditor.git
   ```
2. Open `TLobbyEditor.sln` in your IDE.
3. Build the project:
   ```
   dotnet build -c Release
   ```
4. The output DLL will be at `TLobbyEditor/bin/Release/net48/TLobbyEditor.dll`.

## License

This project is licensed under the [GNU General Public License v3.0](LICENSE).

## Contributing

Contributions are welcome. Please open an issue first to discuss what you'd like to change, then submit a pull request to the `master` branch.

## Support

For issues or feature requests, please use the [GitHub issue tracker](https://github.com/TavstalDev/TLobbyEditor/issues).