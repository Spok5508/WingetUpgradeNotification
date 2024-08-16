# WingetUpgradeNotification

Checks the amount of programs that have available upgrades through winget and notifies the user to update at boot.

This program is made in [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

## Installation
### Clone the repository
> git clone https://github.com/Spok5508/WingetUpgradeNotification

### Build
> dotnet build --config Release

### Install
Create a shortcut to ```WingetUpgradeNotification/bin/platform/WingetUpgradeNotification.exe``` and paste it in the windows startup folder
> C:\Users\YourName\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup

### Notification behaviour
- **Hover**: Displays number of available upgrades.
- **Left click**: Runs ```winget upgrade --all``` in user shell.
- **Right click**: Closes the notification tray icon. Disregarding the prompt to update.

