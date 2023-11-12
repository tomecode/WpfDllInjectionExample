using System.Runtime.InteropServices;
using System.Windows;

namespace WpfDllInjectionExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Value represent path: %windows%\system32 , for more details see: https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-setdefaultdlldirectories 
        /// </summary>
        private const int LOAD_LIBRARY_SEARCH_DEFAULT_DIRS = 0x00000800;

        /// <summary>
        /// Sets list of paths that can be used to find native libraries such as drivers, etc.
        /// </summary>
        /// <param name="directoryFlags"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetDefaultDllDirectories(int directoryFlags);

        public App()
        {
            //TODO: Uncomment the following code to disable injection
            // Excludes the application's home directory from DLL searches
            /*if (!SetDefaultDllDirectories(LOAD_LIBRARY_SEARCH_DEFAULT_DIRS))
            {
                Console.WriteLine($"Failed to exclude application directory from DLL directories, error code: {Marshal.GetLastWin32Error()}");
            }*/
        }
    }
}
