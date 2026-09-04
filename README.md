# CommonLibrary.NET

A small, focused .NET utility library that bundles a handful of low-level helpers that come up
often in everyday C# projects: binary file I/O, bit manipulation, a lightweight custom exception
type, and thin wrappers around Windows dialogs, Windows built-in apps, and the OS default web
browser.

- **Target Framework:** `net10.0`
- **Nullable reference types:** enabled
- **Unsafe blocks:** allowed
- **XML documentation:** generated on build

## Installation

The project currently ships as source (no published NuGet package). To use it:

1. Use the ready-to-use DLL in folder CommonLibrary.DLL of the project.

## Project Structure

```
CommonLibrary.NET/
├── BinaryManager/
│   ├── Binary.cs            # Read/write/inspect binary files
│   ├── BitOperations.cs     # Generic bit-level manipulation
│   └── BitState.cs          # TurnOn / TurnOff / Switch enum
├── Exceptions/
│   ├── FileException.cs             # Custom exception for file/path errors
│   ├── ErrorMessages/Errors.cs      # Internal shared error message constants
│   └── ThrowHelper/Throw.cs         # Guard-clause style throw helpers
├── GUI/
│   ├── IWin32DialogWindow.cs   # Internal interface backing MessageWindow (Windows only)
│   ├── MessageWindow.cs        # Public API for classic Win32 message boxes (Windows only)
│   ├── MessageWindowResult.cs  # Result codes returned by MessageWindow
│   └── MessageWindowType.cs    # Button/icon combinations for MessageWindow
├── Interoperability/
│   └── Win32InteropService.cs  # P/Invoke bindings to user32.dll / msvcrt.dll (Windows only)
├── IO/
│   └── Terminal.cs             # Low-level console printing via native printf (Windows only)
├── Web/
│   └── WebBrowser.cs           # Cross-platform "open default browser" helper
└── WindowsAppManager/
    └── WindowsApps.cs          # Launchers for built-in Windows apps (Calculator, Notepad, etc.)
```

## Platform support

Most of the library is cross-platform, but a few types are Windows-only and are marked with
`[SupportedOSPlatform("windows")]`. Calling them on another OS either throws
`PlatformNotSupportedException` or is a no-op, depending on the type:

## Usage

### Binary file operations (`BinaryManager.Binary`)

```csharp
using CommonLibrary.BinaryManager;

// Read a binary file into memory
List<byte> bytes = Binary.LoadBinary(@"C:\path\to\file.dll");

// Get file size without loading its content
long size = Binary.GetBytesCount(@"C:\path\to\file.dll");

// Write text out as a .bin file
Binary.CreateBinaryFormText("hello world", @"C:\export\directory");

// Print a file's raw bit pattern to the console
int bytesPrinted = Binary.PrintContentAndGetBytesCount(@"C:\path\to\file.dll");
```

### Bit manipulation (`BinaryManager.BitOperations` / `BitState`)

```csharp
using CommonLibrary.BinaryManager;

int number = 0b0000_1001;

int turnedOn  = BitOperations.ChangeBitAt(number, position: 1, BitState.TurnOn);
int turnedOff = BitOperations.ChangeBitAt(number, position: 0, BitState.TurnOff);
int switched  = BitOperations.ChangeBitAt(number, position: 3, BitState.Switch);

bool isSet = BitOperations.IsActiveBit(number, position: 0); // true
```

Works with any numeric type that implements `IBitwiseOperators<T, int, T>` and `INumber<T>`
(e.g. `int`, `long`, `byte`, `short`).

### Custom exceptions (`Exceptions.FileException`)

```csharp
using CommonLibrary.Exceptions;

FileException.ThrowIfFilePathIsNull(path);
FileException.ThrowIfFileDoesNotExists(path);

// or throw directly
throw new FileException("Custom error message");
```

### Windows dialogs (`GUI.MessageWindow`) — Windows only

```csharp
using CommonLibrary.GUI;

MessageWindow.ShowMessage("Operation completed!");

MessageWindowResult result = MessageWindow.AskQuestion("Do you want to continue?");

MessageWindowResult custom = MessageWindow.Show(
    message: "Something needs your attention.",
    title: "Heads up",
    windowType: MessageWindowType.WithButtonsYesNoAndWarningIcon
);
```

### Console output (`IO.Terminal`) — Windows only

```csharp
using CommonLibrary.IO;

Terminal.Print("Hello from native printf!\n");
```

### Opening the default web browser (`Web.WebBrowser`) — cross-platform

```csharp
using CommonLibrary.Web;

WebBrowser.Open();                                  // opens google.com
WebBrowser.OpenAndNavigate("https://github.com");   // opens a specific URL
```

### Launching built-in Windows apps (`WindowsAppManager.WindowsApps`) — Windows only

```csharp
using CommonLibrary.WindowsAppManager;

WindowsApps.OpenCalculator();
WindowsApps.OpenNotepad();
WindowsApps.OpenTaskManager();
WindowsApps.OpenFileManager(@"C:\Projects"); // defaults to Desktop if no path is given
```

Also available: `OpenPaint`, `OpenSnippingTool`, `OpenTerminal`, `OpenPowershell`,
`OpenControlPanel`, `OpenServices`, `OpenRegistryEditor`, `OpenResourceMonitor`.

## License

This project is licensed with MIT License.