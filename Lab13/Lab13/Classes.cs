using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;


namespace Lab13
{
    class WSALoger
    {
        
        public void UserInfoWrite(string name, string time)
        {
            using (StreamWriter writer = new StreamWriter("WSAlog.txt", true))
            {
                writer.WriteLine("Name: " + name +  " Time:" + time);
            }
        }
       
        public void LogWrite(string str)
        {
            using (StreamWriter writer = new StreamWriter("WSAlog.txt", true))
            {
                writer.WriteLine(str);
            }
        }

        public void LogRead()
        {
            using (StreamReader sr = new StreamReader("WSAlog.txt"))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }

        public void FindInfo(string Name)
        {
            using (StreamReader sr = new StreamReader("WSAlog.txt"))
            {
                string buf = null;
                while((buf = sr.ReadLine())!=null)
                {
                    if (buf.Contains(Name))
                    {
                        buf = sr.ReadLine();
                        if (buf != null) Console.WriteLine(buf);
                    }
                }
            }
        }



    }

    class WSADiskInfo
    {
        private DriveInfo[] info;
        

        public WSADiskInfo()
        {
            info = DriveInfo.GetDrives();
        }

        public void GetSizeCurrentDisk()
        {
            foreach (var d in info)
                if (d.Name == @"D:\")
                    Console.WriteLine("Free size in current disk: " + d.TotalFreeSpace / 1000000000);
        }

        public void GetFileSystemCurrentDisk()
        {
            foreach (var d in info)
                if (d.Name == @"D:\")
                    Console.WriteLine("File system: " + d.DriveFormat);
        }

        public void GetFullInfo()
        {
            foreach (var d in info)
            {
                Console.WriteLine();
                Console.WriteLine("Name: " + d.Name);
                Console.WriteLine("Size: " + d.TotalSize / 1000000000);
                Console.WriteLine("Free size: " + d.TotalFreeSpace / 1000000000);
                Console.WriteLine("Label: " + d.VolumeLabel);
                Console.WriteLine();
            }
        }
    }

    class WSAFileInfo
    {
        FileInfo file;
        

        public WSAFileInfo(string path)
        {
            file = new FileInfo(path);
            file.Open(FileMode.Open,FileAccess.Read,FileShare.None);
        }

        public void GetFullPath()
        {
            Console.WriteLine("Full path to " + file.Name + ": " + file.FullName);
        }

        public void GetInfo()
        {
            Console.WriteLine("Name: " + file.Name + "Type: " + file.Extension + "Size: " + file.Length/1000000);
        }

        public void DataInfo()
        {
            Console.WriteLine("Create data: " + file.CreationTime + "Last change time:" + file.LastAccessTime);
        }

    }

    class WSADirInfo
    {
        private DirectoryInfo dir;
        

        public WSADirInfo(string path)
        {
            dir = new DirectoryInfo(path);
            if (!dir.Exists) dir.Create();
        }

        public void Name()
        {
            Console.WriteLine("Name: " + dir.Name);
        }

        public void FileCount()
        {
            Console.WriteLine("Count file in this directory: " + dir.GetFiles().Length);
        }

        public void SubdirCount()
        {
            Console.WriteLine("Count subdir in this directory: " + dir.GetDirectories().Length);
        }

        public void GetCreateTime()
        {
            Console.WriteLine("Create time: " + dir.CreationTime);
        }

        public void RootElement()
        {
            Console.WriteLine("Root element: " + dir.Root);
        }
    
    }

    static class WSAFileMenager
    {

        static public void FileAndDirInDisk(DirectoryInfo disk)
        {
            Console.WriteLine();
            Console.WriteLine("All dir in disk");
            foreach(var c in disk.GetDirectories())Console.WriteLine(c.Name + " ");
            Console.WriteLine("All file in disk");
            foreach (var c in disk.GetFiles()) Console.WriteLine(c.Name + " ");
        }

        static public DirectoryInfo CreateDir(string path, WSALoger log)
        {
            var dir = new DirectoryInfo(path);
            dir.Create();
            log.UserInfoWrite(dir.Name, dir.CreationTime.ToString());
            log.LogWrite("Ctreate directory");
            return dir;
        }


        static public FileStream CreateFile(string Path, WSALoger log)
        {
            var i = File.Open(Path, FileMode.OpenOrCreate);
            
            log.UserInfoWrite(i.Name, File.GetCreationTime(Path).ToString());
            log.LogWrite("Create file");
            return i;
        }

        static public void CopyFile(FileStream f1, string path, WSALoger log)
        {
            File.Copy(f1.Name, path);
            log.UserInfoWrite(path, File.GetCreationTime(path).ToString());
            log.LogWrite("Copy file from " + f1.Name);
        }

        static public void DeleteFile(FileInfo f, WSALoger log)
        { 
            log.UserInfoWrite(f.FullName, f.CreationTime.ToString());
            log.LogWrite("Delete file");
            File.Delete(f.FullName);
        }

        static public void MoveFile(string dest, string start, WSALoger log)
        {
            log.LogWrite(start + " in " + dest);
            File.Move(start, dest);
        }

    }

}
