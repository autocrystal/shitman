# Shitman
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Git](https://img.shields.io/badge/git-F05032?style=for-the-badge&logo=git&logoColor=white)
![AUR](https://img.shields.io/badge/AUR-1793D1?style=for-the-badge&logo=arch-linux&logoColor=white)

A lightweight, but terrible, AUR helper written in C# .NET for Linux.

This is *not* a serious project, thus don't actually use it (😭) and don't expect frequent updates.

## Installation
### Pre-built binaries
1. Install [git](https://git-scm.com/)
2. Download the [latest release](https://github.com/autocrystal/shitman/releases/latest)
3. Make it executable: `chmod +x ./shitman`
4. Optionally move it to `/usr/local/bin` for system-wide access
5. You now (unfortunately) have Shitman installed!

### Building it yourself
1. Install [git](https://git-scm.com/) and [dotnet v10](https://dotnet.microsoft.com/en-us/download)
2. Clone this repository
3. Run `chmod +x ./build.sh && ./build.sh`
4. Binary will be available in `./bin/Release/net10.0/linux-x64/publish/shitman`
5. To run the binary, follow the pre-built guide from step 3

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
