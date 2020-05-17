using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Linq;

namespace Snippet {
    class Program {
        static Assembly asm = Assembly.GetEntryAssembly();
        static string[] names = asm.GetManifestResourceNames();

        /// <summary>
        /// Snippets
        /// </summary>
        /// <param name="list"></param>
        /// <param name="path"></param>
        /// <param name="query"></param>
        /// <param name="bat"></param>
        static void Main(bool list, string path = "", string bat = "", string query = "") {

            if (!string.IsNullOrEmpty(path)) {
                Print(path);
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
                    Console.WriteLine(item);
                }
            }
        }

        private static string GetLanguage(string path) {
            if (path.EndsWith(".cs")) return "cs";
            if (path.EndsWith(".csx")) return "cs";
            if (path.EndsWith(".xml")) return "xml";
            if (path.EndsWith(".targets")) return "xml";
            if (path.EndsWith(".sql")) return "sql";
            if (path.EndsWith(".yml")) return "yml";
            if (path.EndsWith(".yaml")) return "yml";
            if (path.EndsWith(".cake")) return "cs";
            return "cs";
        }

        private static void Query(string query) {
            var name = names.Where(x => x.Contains(query)).FirstOrDefault();
            if (name != null) {
                // Bat(name);
                Cat(name);
            }
        }

        private static void Cat(string file) {
            Print(file);
        }

        private static void Bat(string bat) {
            var language = GetLanguage(bat);
            var startInfo = new ProcessStartInfo {
                FileName = "/bin/sh",
                Arguments = $@" -c ""wk-snippet --path {bat} | bat --decorations never -l {language}""",
                UseShellExecute = false
            };
            new Process {
                StartInfo = startInfo
            }.Start();
        }

        static void Print(string path) {
            var target = path.Replace(" / ", ".");
            var stream = asm.GetManifestResourceStream(target);
            var reader = new StreamReader(stream);
            var text = reader.ReadToEnd();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(text);
            Console.WriteLine();
        }
    }
}
