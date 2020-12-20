using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OOP_Lab13
{
    class DVRDiskInfo
    {
        public static void GetAllInfo()
        {
            string resultInfo = "";
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                resultInfo = $"Название: {drive.Name}   ";
                resultInfo += $"Тип: {drive.DriveType}  ";

                if (drive.IsReady)
                {
                    resultInfo += $"Объем диска: {drive.TotalSize}  ";
                    resultInfo += $"Свободное место: {drive.TotalFreeSpace} ";
                    resultInfo += $"Метка: {drive.VolumeLabel}  ";
                }
                DVRLog.WriteInfo($"{resultInfo}");
            }
        }
    }
}
