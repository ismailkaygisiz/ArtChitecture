using System.IO;
using System.Text;

namespace AngularUI
{
    public static class Create
    {
        public static void CreateAngularProject()
        {
            var path = (Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "\\AngularUI");

            var exePath = Path.Combine(path, "UI");
            var bld = new StringBuilder();

            bld.Append("npm list -g @angular/cli@12.0.3 || npm install -g @angular/cli@12.0.3&");
            bld.Append("npm install&");
            bld.Append("code .&");

            var cmd = new System.Diagnostics.Process
            {
                StartInfo =
                {
                    UseShellExecute = false,
                    FileName = "cmd.exe",
                    WorkingDirectory = exePath,
                    Arguments = @"/c " + bld
                }
            };

            cmd.Start();
            cmd.Close();
        }
    }
}
