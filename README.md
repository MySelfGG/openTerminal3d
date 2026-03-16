for linux only 
1. run : sudo usermod -aG input $USER
2. grep -E "Name|Handlers" /proc/bus/input/devices | grep -A1 -E "mouse|keyboard|Mouse|Keyboard"

 . and not the eventX device
3. in raw input at the top of void start . is string? dev = "/dev/input/event7";. change that line to what ever event number you got

   side not there is a function for finding the keyboard it dosnt work :(
