using System;
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
        static void Main(bool list, string path = "") {

            if (!string.IsNullOrEmpty(path)) {
                var target = path.Replace("/", ".");
                var stream = asm.GetManifestResourceStream(target);
                var reader = new StreamReader(stream);
                var text = reader.ReadToEnd();
                Console.WriteLine(text);
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

        static void PrintPath(string path) {

        }
    }
}
