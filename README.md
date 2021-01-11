# Description
When starting KeePass, this plugin automatically opens a specific database using its master password.

# How to keep the database safe ?
The configuration of the plugin is associated to the current windows user and encrypted (the configuration can be decrypted only by the associated user).
So to keep the selected database safe, you must protect your windows account with a password or windows Hello, because your account is the one responsible for protecting the database.

# Advices
The goal of this plugin is to open Keepass faster. To optimize it, we recommend using the following configuration in the options menu :
- Security > Advanced > check "Remember master password (in encrypted form) of a database while it is open"
- Integration > check "Run Keepass as Windows startup (current user)"
- Interface > Main Window > check "Minimize to tray instead of taskbar"
- Advanced > Start and exit > check "Start minimized and locked"
