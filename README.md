# WpfDllInjectionExample
Example of DLL Injection in WPF

## Requirements
- VS Studio 2022
- dontet 6 (x64)
- WPF

## How it works
The project has a unique DLL, ``${WpfDllInjectionExample}/d3d9.dll``, which includes specific code to display popup window demonstrating DLL injection (with 'DLL preloading attacks').
When you start the application, this DLL is automatically copied to the app's home directory. As the app begins, the WPF Framework initalized then through PresentationFramework.dll, the special DLL is loaded automatically, triggering DLL injection (You will see empty popup window with button OK)

To prevent this pre-load DLL injection, uncomment the lines between 28-32 in ``WpfDllInjectionExample/WpfDllInjectionExample/App.xaml.cs`` and start again the application.

The main reason for the issue is default DLL loading logic (see: https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-setdefaultdlldirectories). By default, WPF (or/and the application) looks for DLLs in the home directory, which could be risky for DLL injection, also known as DLL pre-loading attack.


