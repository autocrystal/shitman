# Shitman
A lightweight, but terrible, AUR helper written in C# .NET for Linux.

This is *not* a serious project, thus don't actually use it (😭) and don't expect frequent updates.

## Installation
1. Make sure you have dotnet and git installed.
2. Clone this repository
3. Run `chmod +x ./build.sh && ./build.sh`
4. Binary will be available in `./bin/Release/net10.0/linux-x64/publish/shitman`

## Usage
| Command | Action | Description |
| :--- | :--- | :--- |
| `shitman -S <pkg>` | **Install** | Clones, builds, and installs the AUR package and its dependencies. |
| `shitman -R <pkg>` | **Remove** | Uninstalls an existing package from the system via `pacman`. |
| `shitman -F <pkg>` | **Fetch** | Displays detailed metadata (version, deps, votes) for a specific package. |
| `shitman -Q <query>` | **Search** | Searches the AUR for packages matching the provided keywords. |
