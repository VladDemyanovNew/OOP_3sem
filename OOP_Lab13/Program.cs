using System;
using System.IO;

namespace OOP_Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            DVRLog test = new DVRLog(@"./../../../resources/tracked.txt");
            DVRDiskInfo.GetAllInfo();
            DVRFileInfo.GetFileInfo(@"./../../../results/DVRlogfile.txt");
            DVRDirInfo.GetAllInfo(@"./../../../../OOP_Lab13");
            DVRFileManager.ReadFilesAndDirs(@"F:\HDD\OOP_3sem");
            DVRFileManager.CreateCope(@"./../../../DVRInspect/DVRdirinfo.txt");
            DVRFileManager.DeleteFile(@"./../../../DVRInspect/DVRdirinfo.txt");
            DVRFileManager.CreateDir();
            //DVRFileManager.CopyFromUserDir(@"F:\HDD\OOP_3sem\OOP_3sem");
            //DVRFileManager.MoveDir();
            //DVRFileManager.CreateZip();
            DVRFileManager.ExtractZip();
            Console.ReadLine();

        }

        

    }
}
