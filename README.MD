# Phoenotopia: Awakening - Archipelago integration
This is a mod for [Phoenotopia: Awakening](https://store.steampowered.com/app/1436590/Phoenotopia_Awakening/) that integrates it into the [Archipelago Multiworld Randomizer framework](https://archipelago.gg/)

## What it does
Archipelago is a Multiworld Randomizer framework that enables different games to be randomized among alone or among each other. For example, this game's bombs can be hidden behind the first star of Jolly Roger's Bay in Super Mario 64, whereas you might be able to buy someone's Hookshot from Ocarina of Time in the Panselo Shop for just 5 rin!

Note: currently, only the first few checks of the game are randomized. Sunflower Road and anything beyond that is considered out of bounds. As this project expands, more checks will be added.

## Installing the Archipelago Mod

1. Download [BepInEx](https://docs.bepinex.dev/articles/user_guide/installation/index.html) and follow the installation guide. Be sure to download the **32bit (86x)** version, **even if you're running a 64bit operating system**.
   In the guide they refer to the game root. For you this should be `[Your Steam installation folder]\SteamLibrary\steamapps\common\Phoenotopia Awakening`.
   After following the steps, your game folder should have a `BepInEx` folder containing (among others) a `plugins` and `config` folder.
2. Download the [Phoa Archipelago Mod](https://github.com/Amphyros/Phoenotopia-Awakening-AP-client). This is a zipfile containing a bunch of .dll files. Extract these files to the `BepInEx\plugins` folder in your game folder
3. Launch the game, let it run till the Cape Cosmic logo shows and then close it. If you've done everything correctly, the `BepInEx\config` folder now contains a file called: `PhoA_AP_client.cfg`.
4. The mod is now successfully installed! You can open PhoA_AP_client.cfg with a text editor like notepad to change the connection data. More about entering a multiworld game can be found below
5. OPTIONAL: It might be a good idea to enable the console window, as most of the connection info is logged in there. In the config folder you'll find a file named `BepInEx.cfg`. Open this with a text editor and scroll down to "Logging.Console". Set the value of "Enabled" to "true".
   NOTE: Please do **not** attempt to play the vanilla game with the mod installed, as some features are critically changed. If you want to disable the mod temporarily, drag the dll files from the plugins folder to a place outside the game folder.

More information on how to set up or host an Archipelago server can be found in the [Web guide](https://archipelago.gg/tutorial/Archipelago/setup_en)

## Building from source

1. Download/clone this repository.
2. Make you've installed a .NET SDK with version 4.6.1 through 4.8.
3. Run `dotnet build` at the project root, and it should generate the necessary .dll files.
4. If you need to connect to a remote server, include [this](https://github.com/black-sliver/c-wspp-websocket-sharp/releases/tag/v0.4.1) .dll in your BepEnIx plugins folder.

For any questions regarding the project and it's code, shoot @Lenamphy a DM on discord. I can, of course, be found in the [Cape Cosmic Fan Server](https://discord.gg/Kjk6sGc)