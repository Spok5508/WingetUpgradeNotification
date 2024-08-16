# WingetUpgradeNotification

Checks amount of programs that have available upgrades through winget.

## Installation
Add latest release to startup folder.
> C:\Users\User\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\

## Usage
### Upgrade information
**Hover** over the icon for the amount of available upgrades.

### Notification behaviour
- **Double click**: runs ```winget upgrade --all``` in user shell.
- **Left click**: Closes tray icon without upgrading.

