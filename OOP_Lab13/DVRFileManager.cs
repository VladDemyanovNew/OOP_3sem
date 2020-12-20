using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace OOP_Lab13
{
    class DVRFileManager
    {
        public static void ReadFilesAndDirs(string driveName)
        {
            string[] dirs = Directory.GetDirectories(driveName, "", SearchOption.AllDirectories);
            string[] files = Directory.GetFiles(driveName, "*.*", SearchOption.AllDirectories);
            WriteInfo("Dirs:", dirs);
            WriteInfo("Files:", files);
        }

        public static void WriteInfo(string description, string[] arr)
        {
            string path = @"./../../../DVRInspect";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if(!dirInfo.Exists)
                dirInfo.Create();

            using (StreamWriter fs = new StreamWriter($"{dirInfo.FullName}/DVRdirinfo.txt", true))
            {
                fs.WriteLine(description);
                foreach (string item in arr)
                {
                    fs.WriteLine(item);
                }
                fs.WriteLine();
            }
        }

        public static void CreateCope(string path)
        {
            if (File.Exists(path))
            {
                File.Copy(path, @"./../../../DVRInspect/new.txt", true);
            }    
        }

        public static void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public static void CreateDir()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"./../../../DVRFiles");
            if (!dirInfo.Exists)
                dirInfo.Create();
        }

        public static void CopyFromUserDir(string path)
        {
            DirectoryInfo files = new DirectoryInfo(path);
            foreach (FileInfo file in files.GetFiles("*.txt", SearchOption.AllDirectories))
            {
                file.CopyTo(@"./../../../DVRFiles/" + file.Name, true);
            }
        }

        public static void MoveDir()
        {
            Directory.Move(@"./../../../DVRFiles", @"./../../../DVRInspect/DVRFiles");
        }

        public static void CreateZip()
        {
            ZipFile.CreateFromDirectory(@"./../../../DVRInspect/DVRFiles", @"./../../../DVRInspect/newDVRFiles.zip");
        }
        public static void ExtractZip()
        {
            ZipFile.ExtractToDirectory(@"./../../../DVRInspect/newDVRFiles.zip", @"./../../../DVRInspect/targetFolder");
        }
    }
}
