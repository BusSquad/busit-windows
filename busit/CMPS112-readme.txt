Hello!

To compile and run our project, open it in Visual Studio and run it in its included mobile emulator, which is accessible from the main toolbar.

The emulator requires Hyper-V to be enabled, which is only available on Windows 8/8.1 (Pro or Enterprise) and Windows 10 (Pro, Educational, and Enterprise). Steps to enabling the Hyper-V role can be found here:

http://windows.microsoft.com/en-us/windows-8/hyper-v-run-virtual-machines
https://msdn.microsoft.com/en-us/virtualization/hyperv_on_windows/quick_start/walkthrough_install

Though we are confident that this can compile and run, we've tested this under Visual Studio Enterprise 2015, version 14.0.24720.00, Update 1. Windows Phone SDK 8.0 and Visual Studio Tools for Universal Windows Apps are among the required packages. Additionally, Visual Studio 2013 will compile our project without issue.

Known issue: Bus markers don't update. They are drawn at their correct coordinates on starting up the application, however.