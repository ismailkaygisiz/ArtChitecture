using System.Diagnostics;

namespace FlutterUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var startInfo = new ProcessStartInfo("cmd.exe", "/K cd ..&cd ..&cd ..&cd flutter_ui&flutter pub get");
            var cmd = Process.Start(startInfo);
            cmd.WaitForExit();
        }
    }
}