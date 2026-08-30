# **CommonLibrary.NET** is a versatile .NET utility library designed to simplify bitwise manipulations,
# binary file operations, Windows application management, browser interaction, and GUI dialog creation.

---

## 📑 Table of Contents

- [Features](#-features)
- [Project Architecture](#-project-architecture)
- [Installation](#-installation)
- [Usage Examples](#-usage-examples)
  - [Binary Operations](#1-binary-operations)
  - [Bitwise Operations](#2-bitwise-operations)
  - [GUI & Dialogs](#3-gui--dialogs)
  - [Web Navigation](#4-web-navigation)
  - [Windows App Launcher](#5-windows-app-launcher)
  - [Custom Exceptions](#6-custom-exceptions)
- [Unit Testing](#-unit-testing)
- [License](#-license)

---

## 🚀 Features

* **⚡ Binary Manipulation:** Convert raw text into binary `.bin` files, read raw bytes sequentially, 
       and print formatted binary representations.

* **🔢 Advanced Bit Operations:** Change individual bits (`TurnOn`, `TurnOff`, `Switch`) and inspect specific bit statuses (`IsActiveBit`)
       using generic constraints.

* **🖥️ Native GUI Dialogs:** Show message popups or question dialogs via Windows API (`MessageBoxW`) 
       with strongly-typed responses and icons.

* **🌐 Cross-Platform Web Operations:** Open system browsers dynamically across Windows, Linux, and OSX.

* **⚙️ Windows Utilities:** Launch built-in OS tools (Calculator, Notepad, Task Manager, Command Prompt, PowerShell, Registry Editor) 
       with single-method calls.

* **⚠️ File Exceptions:** Guard helper methods and custom exceptions to prevent invalid file or path operations.

---

## 📁 Project Architecture

```text
CommonLibrary.NET/
├── 📁 BinaryManager/
│   ├── 📄 Binary.cs
│   ├── 📄 BitOperations.cs
│   └── 📄 BitState.cs
├── 📁 Exceptions/
│   └── 📄 FileException.cs
├── 📁 GUI/
│   ├── 📄 MessageWindow.cs
│   ├── 📄 MessageWindowResult.cs
│   └── 📄 MessageWindowType.cs
├── 📁 Web/
│   └── 📄 WebBrowser.cs
└── 📁 WindowsAppManager/
    └── 📄 WindowsApps.cs

⚙️ Installation
Targeting .NET 10.0.
Add the project reference to your application(compiled DLL) or build the Release configuration:

Bash
# Clone the repository and build the library
git clone [https://github.com/your-username/CommonLibrary.NET.git](https://github.com/your-username/CommonLibrary.NET.git)
dotnet build CommonLibrary.NET/CommonLibrary.NET.csproj -c Release

After the build the DLL can be found in the Release folder.

# Direct use of compiled DLL
Download the compiled ready to use DLL from folder CommonLibrary.NET.DLL in the repository.

# 💡 Usage Examples

# 1. Binary Operations:

using CommonLibrary.NET.BinaryManager;

// Create a .bin file from plain text
Binary.CreateBinaryFormText("Hello World!", @"C:\ExportDirectory");

// Read and print raw binary content to console (returns total byte count)
int totalBytes = Binary.PrintContentAndGetBytesCount(@"C:\ExportDirectory\NewBinaryFile.bin");

// Load raw byte list from a file
List<byte> bytes = Binary.LoadBinary(@"C:\ExportDirectory\NewBinaryFile.bin");

# 2. Bitwise Operations:

using CommonLibrary.NET.BinaryManager;

byte sampleNumber = 0b0000_0100; // Value: 4

// Check if bit at index 2 is active (returns true)
bool isActive = BitOperations.IsActiveBit(sampleNumber, 2);

// Turn on bit at position 0 (Result: 0b0000_0101)
byte turnedOn = BitOperations.ChangeBitAt(sampleNumber, 0, BitState.TurnOn);

// Switch bit state at position 2 (Result: 0b0000_0000)
byte switched = BitOperations.ChangeBitAt(sampleNumber, 2, BitState.Switch);

# 3. GUI & Dialogs:

using CommonLibrary.NET.GUI;

// Show a simple information message
MessageWindow.ShowMessage("Operation completed successfully!");

// Ask a question with Yes/No response
MessageWindowResult answer = MessageWindow.AskQuestion("Do you want to save changes?");
if (answer == MessageWindowResult.ResultYes)
{
    // logic...
}

// Custom window with specific title and warning icon
MessageWindowResult customResult = MessageWindow.Show(
    message: "Low disk space warning!",
    title: "System Warning",
    windowType: MessageWindowType.WithButtonOKAndWarningIcon
);

# 4. Web Navigation

using CommonLibrary.NET.Web;

// Open default browser to Google
WebBrowser.Open();

// Open browser to a custom URL
WebBrowser.OpenAndNavigate("[https://github.com](https://github.com)");

# 5. Windows App Launcher

using CommonLibrary.NET.WindowsAppManager;

// Launch built-in applications
WindowsApps.OpenCalculator();
WindowsApps.OpenNotepad();
WindowsApps.OpenTerminal();

// Open File Explorer at a specific directory
WindowsApps.OpenFileManager(@"C:\Windows");

# 6. Custom Exceptions

using CommonLibrary.NET.Exceptions;

// Validate paths using built-in guards
FileException.ThrowIfFilePathIsNull(filePath);
FileException.ThrowIfFileDoesNotExists(filePath);

# 🧪 Unit Testing
To run the full test suite included in CommonLibraryTests:

Bash
dotnet test CommonLibraryTests/CommonLibraryTests.csproj

📜 License
This project is licensed under the terms defined in the LICENSE.txt file