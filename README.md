# NuggetMod

Write metamod plugin based on .NET 10 and later

[![](https://img.shields.io/nuget/v/DrAbc.NuggetMod.svg?label=NuggetMod&logo=NuGet)](https://www.nuget.org/packages/DrAbc.NuggetMod)
![NuGet Downloads](https://img.shields.io/nuget/dt/DrAbc.NuggetMod?label=Downloads)

## Features

- **Full MetaMod API Support**: Complete binding for MetaMod 1.21 (Interface 5:16)
- **Memory Safety**: Advanced GC lifecycle management to prevent dangling pointers
- **C#-Style API**: Modern, idiomatic C# API design with optional C++ style compatibility
- **AOT Compatible**: Native AOT compilation support for optimal performance
- **Type Safety**: Strongly-typed wrappers for all engine structures

## Installation

```bash
dotnet add package DrAbc.NuggetMod
```

## Quick Start

### Basic Plugin Structure

```csharp
using NuggetMod.Interface;
using NuggetMod.Enum.Metamod;
using NuggetMod.Wrapper.Metamod;

public class MyPlugin : IPlugin
{
    public MetaPluginInfo GetPluginInfo() => new()
    {
        InterfaceVersion = InterfaceVersion.V5_16,
        Name = "MyPlugin",
        Version = "1.0.0",
        Date = "2024-01-01",
        Author = "Your Name",
        Url = "https://github.com/yourname/myplugin",
        LogTag = "[MYPLUGIN]",
        Loadable = PluginLoadTime.Anytime,
        Unloadable = PluginLoadTime.Anytime
    };

    public void MetaInit()
    {
        // Plugin initialization code
    }

    public bool MetaQuery(InterfaceVersion interfaceVersion, MetaUtilFunctions pMetaUtilFuncs)
    {
        return true; // Return true if compatible
    }

    public bool MetaAttach(PluginLoadTime now, MetaGlobals pMGlobals, MetaGameDLLFunctions pGamedllFuncs)
    {
        // Register event handlers
        var events = new DLLEvents();
        events.ClientConnect += OnClientConnect;
        
        SafeEventRegistration.Register(new EventRegistrationBuilder()
            .WithEntityApi(events));
        
        return true;
    }

    public bool MetaDetach(PluginLoadTime now, PluginUnloadReason reason)
    {
        SafeEventRegistration.UnregisterAll();
        return true;
    }

    private (MetaResult, bool) OnClientConnect(Edict pEntity, string pszName, string pszAddress, ref string szRejectReason)
    {
        Console.WriteLine($"Player {pszName} connecting from {pszAddress}");
        return (MetaResult.Handled, true);
    }
}
```

## Usage

To quickly set up your first MetaMod plugin, refer to the template repository:

[NuggetMod.Template](https://github.com/DrAbcOfficial/NuggetMod.Template)

Or refer [ChatEngine](https://github.com/DrAbcOfficial/ChatEngine)

### Build and Publish

```bash
# Build with AOT for Windows x86
dotnet publish -c Release -r win-x86 -o ./build -p:PublishAot=true

# Build with AOT for Linux x86
dotnet publish -c Release -r linux-x86 -o ./build -p:PublishAot=true
```

## Memory Safety and GC Lifecycle

**Critical**: When passing managed delegates to native code, you must ensure they are not garbage collected while native code may still invoke them.

### Safe Event Registration (Recommended)

Always use `SafeEventRegistration` to register event handlers:

```csharp
// CORRECT: Uses SafeEventRegistration
var builder = new EventRegistrationBuilder()
    .WithEntityApi(new MyDLLEvents())
    .WithEngineFunctions(new MyEngineEvents());

SafeEventRegistration.Register(builder);
```

### Pre-registration Validation

Check for conflicts before registering:

```csharp
var builder = new EventRegistrationBuilder()
    .WithEntityApi(events);

var validation = SafeEventRegistration.ValidateRegistration(builder);
if (!validation.CanRegister)
{
    Console.WriteLine($"Conflicts: {string.Join(", ", validation.ConflictingTypes)}");
    return;
}

SafeEventRegistration.Register(builder);
```

### Manual Delegate Pinning (Advanced)

For custom native interop, use `DelegateLifetimeManager`:

```csharp
// Keep delegate alive
var myDelegate = new MyDelegateType(MyCallback);
DelegateLifetimeManager.Register("MyComponent_MyCallback", myDelegate);

// Later, when no longer needed
DelegateLifetimeManager.Unregister("MyComponent_MyCallback");
```

## API Examples

### Module Information and Code Analysis

```csharp
public void AnalyzeModules()
{
    var metaUtil = MetaMod.MetaUtilFuncs;
    
    // Get engine module information
    nint engineBase = metaUtil.GetEngineBase();
    nint engineHandle = metaUtil.GetEngineHandle();
    
    // Get code section for pattern scanning
    var (codeBase, codeSize) = metaUtil.GetCodeSection(engineBase);
    Console.WriteLine($"Engine code: 0x{codeBase:X} - 0x{codeBase + codeSize:X}");
    
    // Search for pattern in code section
    byte[] pattern = [0x55, 0x8B, 0xEC]; // x86 function prologue
    nint address = metaUtil.SearchPatternInCodeSection(engineBase, pattern);
}
```

### Hook Installation

```csharp
public void InstallHook()
{
    var metaUtil = MetaMod.MetaUtilFuncs;
    
    // Get function addresses
    nint gameDllBase = metaUtil.GetGameDllBase();
    nint targetFunc = metaUtil.GetProcAddress(gameDllBase, "TargetFunction");
    nint hookFunc = metaUtil.GetProcAddress(metaUtil.GetModuleHandle("myplugin.dll"), "HookFunction");
    
    // Install inline hook
    var hook = metaUtil.InlineHook(targetFunc, hookFunc, out nint originalCall, false);
    
    // Later: remove hook
    metaUtil.UnHook(hook);
}
```

### Client Management

```csharp
public void ManageClients()
{
    var metaUtil = MetaMod.MetaUtilFuncs;
    
    // Query client cvar
    int requestId = metaUtil.MakeRequestID();
    MetaMod.EngineFuncs.QueryClientCvarValue2(playerEdict, "cl_crosshair_color", requestId);
    
    // Get user message ID
    int msgId = metaUtil.GetUserMessageId("DeathMsg", out int size);
    
    // Send center message
    metaUtil.CenterSay("Welcome to the server!");
}
```

## Deprecated APIs

The following APIs are maintained for C++ compatibility but marked obsolete. Use the C# alternatives instead:

| Deprecated API | Recommended Alternative |
|----------------|-------------------------|
| `MetaMod.RegisterEvents()` | `SafeEventRegistration.Register()` |
| Direct delegate assignment | `EventRegistrationBuilder` |
| Manual `GCHandle` management | `DelegateLifetimeManager` |

## Supported MetaMod Interface Versions

- Interface 5:16 (Latest - MetaMod 1.21-p)
- Interface 5:15 (MetaMod 1.21)
- Interface 5:13 (MetaMod 1.20)
- All versions back to 1.0

## Testing

Run the test suite:

```bash
dotnet test
```

The test suite includes:
- Memory safety validation
- GC lifecycle tests
- API compatibility tests
- Event registration tests

## Contributing

Contributions are welcome! Please ensure:
1. All tests pass
2. New features include corresponding tests
3. Memory safety is maintained for all native interop
4. API follows C# conventions

## License

GPL-3.0-or-later
