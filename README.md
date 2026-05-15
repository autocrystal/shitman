# Shitman
A lightweight, but terrible, AUR helper written in C# .NET for Linux.

This is *not* a serious project, thus don't actually use it (😭) and don't expect frequent updates.

## Installation
1. Make sure you have dotnet and git installed.
2. Clone this repository.g
3. Run `chmod +x ./build.sh && ./build.sh`
4. Binary will be available in `./bin/Release/net10.0/linux-x64/publish/shitman`

## Usage
| Command | Action | Description |
| :--- | :--- | :--- |
| `shitman -s <pkg>` | **Install** | Install a package. |
| `shitman -f <pkg>` | **Fetch** | Fetch a package. |
| `shitman -r <pkg>` | **Remove** | Remove a package. |
| `shitman -l` | **List** | List installed packages. |
| `shitman -u [pkg]` | **Upgrade** | Upgrade all or a specific package |
| `shitman -q <query>` | **Search** | Search for packages. |
| `shitman -h <query>` | **Help** | Display a help message. |
