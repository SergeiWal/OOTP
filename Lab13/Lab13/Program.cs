using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;


namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //---task1
                WSALoger log = new WSALoger();

                //----task2
                WSADiskInfo disk = new WSADiskInfo();
                disk.GetSizeCurrentDisk();
                disk.GetFileSystemCurrentDisk();
                disk.GetFullInfo();

                //-----task3
                WSAFileInfo file = new WSAFileInfo("file.txt");
                file.DataInfo();
                file.GetFullPath();
                file.GetInfo();
                Console.WriteLine();

                //------task4
                WSADirInfo dir = new WSADirInfo(@"..\");
                dir.Name();
                dir.FileCount();
                dir.GetCreateTime();
                dir.RootElement();
                dir.SubdirCount();

                //------task5
                DirectoryInfo d = new DirectoryInfo(@"D:\");
                WSAFileMenager.FileAndDirInDisk(d);
                var insp = WSAFileMenager.CreateDir("WSAInspect", log);
                var dirinfo = WSAFileMenager.CreateFile(@"WSAInspect\WSAdirinfo.txt", log);
                using (FileStream sw = dirinfo)
                {
                    // преобразуем строку в байты
                    byte[] array = System.Text.Encoding.Default.GetBytes("Hello, World!");
                    // запись массива байтов в файл
                    sw.Write(array, 0, array.Length);
                    log.UserInfoWrite(dirinfo.Name, File.GetCreationTime(sw.Name).ToString());
                    log.LogWrite("Write to file");
                }
                WSAFileMenager.CopyFile(dirinfo, @"WSAInspect\WSACopy.txt",log);
                File.Delete(dirinfo.Name);
                var files = WSAFileMenager.CreateDir("WSAFiles", log);
                foreach (var f in insp.GetFiles())
                {
                    if (f.Extension == ".txt") File.Copy(f.FullName, @"WSAFiles\" + f.Name);
                    log.UserInfoWrite(f.Name, f.CreationTime.ToString());
                    log.LogWrite("Скопирован файл");
                }
                var newdir = insp.CreateSubdirectory(files.Name);
                foreach (var f in files.GetFiles())
                {
                    File.Copy(f.FullName, @"WSAInspect\WSAFiles\" + f.Name);
                    log.UserInfoWrite(f.Name, f.CreationTime.ToString());
                    log.LogWrite("Скопирован файл");
                }
                //files.FullName
                ///-----
                ZipFile.CreateFromDirectory(Path.GetFullPath(files.Name), @".\result.zip");
                ZipFile.ExtractToDirectory(@".\result.zip", @".\");
                Console.WriteLine();
                //task6
                log.FindInfo("04.12.2020");
            }
            catch (Exception c)
            {
                Console.WriteLine(c.Message);
            }
            
            Console.Read();
        }
    }
}
