# Setup
## Changing things for your mod
Open example-mod.sln in your ide, then rename the solution, csproj and .cs for your mod
After that, open up the Mod folder and open the mod.json and change `id` to your mods id, `name` to your mods name, `main` to the name of the dll you will be using for your mod, and if you have any additional dependencies, you can add them to `dependencies`

## Existing Code
Within the `Mod` folder, there is an `assets_override.gin`, this is used in the code with the GinPatching.AddGinPatch method call in the .cs file
Within the .cs file there is registration for localization, this loads the `localization.json` within the `Mod` folder
Within the .cs file there is also registration for a custom trinket, its id is `SILLY` and the item id would be `TRINKET:SILLY`, its cost is 5 and it is placed before `Pain Conversion`
Within the .cs file there also is an example hook, this hook will move the player slightly to the right every frame if they have the trinket `TRINKET:SILLY` equipped

# Building
Building the mod works the same as any other c# project, however the output for the mod will be at `bin/<YOURMODNAME>`, copy this folder into your mods folder to run your mod
If you wish to make a symlink, you can open up the command prompt, navigate to your mods folder, and run `mklink /J <YOURMODNAME> "<PATHTOMOD>/bin/<YOURMODNAME>"`
