# Description
When Keepass is opening, this plugin open a selected database using his master password (it will not be locked).

# How to keep the database safe ?
The configuration of the plugin is associated to current windows user and encrypted (the configuration can be decrypted only by the associated user).
So to keep the selected database safe, you must protect your windows account with password or windows Hello, because it's your account which protect the database.

# Advices
The goal of this plugin, it's to open faster Keepass. So to optimize it, we recommand to configure Keepass like it (in Options) :
- Security > Advanced > check "Remember master password (in encrypted form) of a database while it is open"
- Integration > check "Run Keepass ar Windows startup (current user)"
- Interface > Main Window > check "Minimize to tray instead of taskbar"
- Advanced > Start and exit > check "Start minimized and locked"
