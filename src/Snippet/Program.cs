using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Snippet {
    class Program {
        static Assembly asm = Assembly.GetEntryAssembly();
        static string[] names = asm.GetManifestResourceNames();

        /// <summary>
        /// Snippets
        /// </summary>
        /// <param name="list">An option whose argument is parsed as a FileInfo</param>
        /// <param name="path">An option whose argument is parsed as a FileInfo</param>
        static void Main(bool list, string path = "", string bat = "") {

            if (!string.IsNullOrEmpty(path)) {
                PrintPath(path);
                return;
            }

            if (!String.IsNullOrEmpty(bat)) {
                Bat(bat);
                return;
            }

            if (list) {
                foreach (var item in names) {
                    var localPath = item;
                    // .Replace("Snippet.obj.Debug.", "Snippet/obj/Debug/")
                    // .Replace("Snippet.", "Snippet/");

                    Console.WriteLine(localPath);
                }
            }
        }

        private static void Bat(string bat) {
            var process = new Process();
            var start = new ProcessStartInfo();

            var extension = "cs";
            if (bat.EndsWith("targets")) extension = "xml";

            start.FileName = "/bin/sh";
            start.Arguments = $@" -c ""wk-snippet --path {bat} | bat -l {extension}""";

            start.UseShellExecute = false;

            process.StartInfo = start;
            process.Start();
        }

        static void PrintPath(string path) {
            var target = path.Replace(" / ", ".");
            var stream = asm.GetManifestResourceStream(target);
            var reader = new StreamReader(stream);
            var text = reader.ReadToEnd();


            Console.WriteLine(text);
        }
    }
}
