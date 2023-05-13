# Git DateTime commit (dotnet cdt tool)

Provides a dotnet tool named `cdt` to add changes with a commit message and 
specific datetime.

# Usage example

dotnet cdt -d "1990-10-05" -t "01:30" -m "Initial commit."

# Parameters

`-d` sets the date (yyyy-MM-dd). The current date will be used when omitted.

`-t` sets the time (HH:mm). Seconds are always zero.

`-m` sets the commit message.

# Additional

Icon author: https://www.iconfinder.com/pongsakornjun.