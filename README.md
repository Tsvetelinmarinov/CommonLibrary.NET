# CommonLibrary.NET is a helper .NET library targeting .NET 10.0 and provides reusable utilities for binary data manipulation,
# graphical user interfaces (GUI Message Window), web browser controlling, Windows application management, 
# and custom exceptions. 

# Project Structure & Namespaces:
The repository structure corresponds directly to the available namespaces and classes:

CommonLibrary.NET
├── BinaryManager
│   ├── Binary.cs
│   ├── BitOperations.cs
│   └── BitState.cs
├── Exceptions
│   └── FileException.cs
├── GUI
│   ├── MessageWindow.cs
│   ├── MessageWindowResult.cs
│   └── MessageWindowType.cs
├── Web
│   └── WebBrowser.cs
└── WindowsAppManager
    └── WindowsApps.cs

# Classes & Namespaces Overview. 

# 1. CommonLibrary.NET.BinaryManager provides utilities for low-level byte and bit manipulation:  
-> Binary (in Binary.cs) – Core class for encapsulating and processing binary data and byte arrays. 
-> BitOperations (in BitOperations.cs) – Static helper methods for performing 
    bitwise operations (AND, OR, bit shifts, reading/writing individual bits).  
-> BitState (in BitState.cs) – Enum/structure representing a bit state (On/Off or 1/0).

# 2. CommonLibrary.NET.GUI contains GUI components for displaying message dialogs and handling user responses:
-> MessageWindow (in MessageWindow.cs) – Class for displaying pop-up windows and custom dialog messages. 
-> MessageWindowResult (in MessageWindowResult.cs) – Enum for dialog response outcomes (e.g., OK, Cancel, Yes, No).
-> MessageWindowType (in MessageWindowType.cs) – Enum for defining dialog types (e.g., Info, Warning, Error, Question). 

# 3. CommonLibrary.NET.Web rrovides abstractions for web components and web navigation:
-> WebBrowser (in WebBrowser.cs) – Class for embedding, navigating, and loading web pages or web content.

# 4. CommonLibrary.NET.WindowsAppManager enables interaction with the Windows OS and external processes:
-> WindowsApps (in WindowsApps.cs) – Manager for launching and closing external Windows applications and processes.  

# 5. CommonLibrary.NET.Exceptions:
-> FileException (in FileException.cs) – Custom exception class for handling file system and file IO errors. 

# Code Examples =>

# Bit Operations (CommonLibrary.NET.BinaryManager):

C# code //=>

using CommonLibrary.NET.BinaryManager;

// Check and set bit states
bool isSet = BitOperations.IsActiveBit(number: 0b0000_1000, position: 3);
byte result = BitOperations.ChangeBitAt(number: 0b0000_0000, position: 1, bitState: BitState.TurnOn);
GUI Dialogs (CommonLibrary.NET.GUI)C#using CommonLibrary.NET.GUI;

// Display an error popup message
MessageWindowResult userResponse = MessageWindow.Show(
    message: "An issue occurred while loading the file.",
    title: "Error",
    windowType: MessageWindowType.WithButtonOKAndErrorIcon
);

# Application Management (CommonLibrary.NET.WindowsAppManager)C#using CommonLibrary.NET.WindowsAppManager;

C# code =>

// Launch a Windows applications
WindowsApps.OpenPowershell();
WindowsApps.OpenControlPanel();

# Unit Testing (CommonLibraryTests)The repository includes test coverage located in CommonLibraryTests: 

- BinaryTests.cs & BitOperationsTests.cs – Binary operations tests. 
- MessageWindowTests.cs – GUI window tests. 
- WebBrowserTests.cs – Web integration tests.  
- WindowsAppsTests.cs – Process management tests.  

# Run all tests via CLI: dotnet test CommonLibraryTests/CommonLibraryTests.csproj
# LicenseThis project is licensed under the terms defined in the LICENSE.txt file.