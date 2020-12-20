using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OOP_Lab13
{
    class DVRFileInfo
    {
        public static void GetFileInfo(string path)
        {
            string result = "";
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                result += $"Размер: {file.Length} ";
                result += $"Расширение: {file.Extension} ";
                result += $"Имя файла: {file.Name} ";
                result += $"Дата создания: {file.CreationTime} ";
                result += $"Дата последнего изменения: {file.LastWriteTime} ";

                DVRLog.WriteInfo(result);
            }
        }
    }
}
