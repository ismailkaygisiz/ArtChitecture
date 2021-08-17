using System.Diagnostics;

namespace AngularUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var startInfo = new ProcessStartInfo("cmd.exe",
                "/K cd ..&cd ..&cd ..&npm list -g @angular/cli@12.0.3 || npm install -g @angular/cli@12.0.3&cd angular-ui&npm install&ng serve -o");
            var cmd = Process.Start(startInfo);
            cmd.WaitForExit();
        }
    }
}