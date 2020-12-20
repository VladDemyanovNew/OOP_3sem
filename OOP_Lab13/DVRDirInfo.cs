using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OOP_Lab13
{
    class DVRDirInfo
    {
        public static void GetAllInfo(string path)
        {
            if (Directory.Exists(path))
            {
                DVRLog.WriteInfo("\n\n");
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                DirectoryInfo[] dirs = dirInfo.GetDirectories();
                DVRLog.WriteInfo("Подкаталоги:");
                foreach (DirectoryInfo item in dirs)
                {
                    DVRLog.WriteInfo(item.FullName);
                }
                DVRLog.WriteInfo($"Полное название каталога: {dirInfo.FullName}");
                DVRLog.WriteInfo($"Время создания каталога: {dirInfo.CreationTime}");
                DVRLog.WriteInfo($"Корневой каталог: {dirInfo.Root}");
                DVRLog.WriteInfo("\n\n");
            }
        }
    }
}
