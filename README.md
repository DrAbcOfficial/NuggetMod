# NuggetMod

Write metamod plugin based on .NET 9 and later

[![](https://img.shields.io/nuget/v/DrAbc.NuggetMod.svg?label=NuggetMod&logo=NuGet)](https://www.nuget.org/packages/DrAbc.NuggetMod)
![NuGet Downloads](https://img.shields.io/nuget/dt/DrAbc.NuggetMod?label=Downloads)




## Usage

To quickly set up your first MetaMod plugin, refer to the template repository:

[NuggetMod.Template](https://github.com/DrAbcOfficial/NuggetMod.Template)

Or refer [ChatEngine](https://github.com/DrAbcOfficial/ChatEngine)

### Basic Workflow

1. Create new project from the template repository
2. Customize the plugin logic for your needs
3. Publish with .NET 9 AOT

```
//In your project
dotnet publish -c Release -r win-x86 -o ./build -p:PublishAot=true
```