# Lair of the Negasus

Lair of the Negasus is a text-based adventure where you climb a tower, fight some monsters, and slay the negasus!

## Required Tools

A few things are required to enjoy this game:

1. Visual Studio Code - https://code.visualstudio.com/Download
2. .NET 10 SDK - https://dotnet.microsoft.com/en-us/download/dotnet/10.0
3. The game - https://github.com/19Snail19/Lair_of_the_Negasus

## Setup Instructions

1. First, make sure you have VS Code and the .Net 10 SDK installed.
2. Open VS Code, click File > Open Folder...
3. From here, locate the downloaded game folder and select it.
4. Now that the folder is open in VS Code, you'll need to open a terminal with Ctrl + ~.
5. Click the plus sign at the top of the terminal to open a second terminal.
6. In one of the consoles, run the API. Enter into the console: `dotnet run --project Negasus.API/Negasus.API.csproj`
7. Take note of the first info line, where it says `Now listening on: http://localhost:5116`. Mine says localhost:5116. Your number will be different. Copy down that number for later.
8. In the file explorer on the right side of VS Code, click the arrow next to Negasus.Console. Then the arrow next to Tools.
9. Click `HiScore.cs` to open the file.
10. On line 14, replace the number after `localhost:` with the number you noted in step 7.
11. Press Ctrl + S to save the change.
12. Now, in the second terminal (the one that is **NOT** running the API), enter `dotnet run --project Negasus.Console/Negasus.Console.csproj` to run the game!

## Game Info

- Currently, there is no boss fight... so the Lair of the Negasus is without it's negasus. That's coming in the future! For now, the game is an endless tower climb. Challenge yourself to defeat as many enemies as possible!
- Please wait until you see an elipsis to enter your commands. Otherwise it will try to advance text you haven't seen yet. Fixing that is on the to-do list.
- Currently there are only 16 different monsters in the tower. They are all the same in regard to stats, but in the future I would like to add more and give them individual statistics!

## References

- Google Gemini, for insight on unfamiliar code structure
- Microsoft Learn, for referencing error codes
- patorjk.com, for generating the ASCII title
- makeareadme.com, for helping me write this
