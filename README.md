This is a C# StarCraft 2 bot. The bot plays Zerg. The bot is built based on https://github.com/NikEyX/SC2-CSharpe-Starterkit
Also has parts of Tyr bot https://github.com/SimonPrins/TyrSc2

It has the laddermanager connection integrated and thus allows you to participate in the [sc2ai.net](sc2ai.net) ladder without requiring any modifications.


Structure:
* BeholderBot:
  * This is the actual logic for the bot. 
* RaxBot:
  * The original example bot written by NikEyX. 
* BotRunner/Program.cs:
  * This is the main entry point for the bot. In this file you can set the startup parameters for the program. Apart from these parameters you shouldn't need to change anything here. This part also manages the ladder manager connection.
* SC2-Connector:
  * Contains the logic needed to interact with SC2 API. 
  */Constants:
    * Contains constants needed for bot, e.g. unit types, abilities, etc.
  * /Protocol: 
    * Contains all the SC2 protobuf classes. These manage the communication aspects between SC2 and other programs. 
  * /Wrapper: 
    * Contains the wrapper that starts a 1v1 game vs the computer, or vs another bot if using the laddermanager. This is based on this [wrapper written by Simon Prins](https://raw.githubusercontent.com/SimonPrins/ExampleBot).
  * /MapAnalysis:
    * Contains useful methods to get data about the current map, expansion locations, paths, etc.
  * GameInteractionAPI:
    * This is where the backend logic happens. 