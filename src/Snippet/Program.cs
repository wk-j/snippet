using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Linq;

namespace Snippet {
    class Program {
        static Assembly asm = Assembly.GetEntryAssembly();
        static string[] names = asm.GetManifestResourceNames()
            // .Where(x => !x.Contains(".obj."))
            .ToArray();

        /// <summary>
        /// Snippets
        /// </summary>
        /// <param name="list"></param>
        /// <param name="path"></param>
        /// <param name="query"></param>
        /// <param name="bat"></param>
        static void Main(bool list, string path = "", string bat = "", string query = "") {

            if (!string.IsNullOrEmpty(path)) {
                PrintPath(path);
                return;
            }

            if (!String.IsNullOrEmpty(bat)) {
                Bat(bat);
                return;
            }

            if (!String.IsNullOrEmpty(query)) {
                Query(query);
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

        private static void Query(string query) {
            var name = names.Where(x => x.Contains(query)).FirstOrDefault();
            if (name != null) {
                Bat(name);
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
