using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OOP_Lab13
{
    class DVRLog
    {
        private const string result = @"./../../../results/DVRlogfile.txt";
        public DVRLog (string path)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            Console.WriteLine("Ожидание...");
            watcher.Path = Path.GetDirectoryName(path);
            watcher.NotifyFilter = NotifyFilters.LastWrite |
                NotifyFilters.FileName | NotifyFilters.Size;
            watcher.Deleted += new System.IO.FileSystemEventHandler(OnDelete);
            watcher.Renamed += new System.IO.RenamedEventHandler(OnRenamed);
            watcher.Changed += new System.IO.FileSystemEventHandler(OnChanged);
            watcher.Created += new System.IO.FileSystemEventHandler(OnCreate);
            watcher.EnableRaisingEvents = true;
        }

        public static void WriteInfo(string info)
        {
            using (StreamWriter sw = new StreamWriter(result, true))
            {
                sw.WriteLine(info);
                sw.WriteLine("Дата: {0}", DateTime.Now);
            }
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            WriteInfo($"Файл: {e.FullPath} {e.ChangeType.ToString()}"); 
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            WriteInfo($"Файл переименован из {e.OldName} в {e.FullPath}");
        }

        private static void OnDelete(object source, FileSystemEventArgs e)
        {
            WriteInfo($"Файл: { e.FullPath } удален ");
        }

        private static void OnCreate(object source, FileSystemEventArgs e)
        {
            WriteInfo($"Файл: {e.FullPath} создан");
        }
    }
}
