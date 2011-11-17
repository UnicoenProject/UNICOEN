using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Unicoen.Apps.Loc.Util
{
    public class TotalLoc
    {
        // measure number of physical lines of target source code
        public static int CountTotalLoc(string inputPath)
        {
            FileAttributes attr = File.GetAttributes(@inputPath);
            // if inputPath is a directory
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                DirectoryInfo dirPath = new DirectoryInfo(@inputPath);
                return DirTLoc(dirPath);
            }
            // if inputPath is a file
            else
            {
                return FileTLoc(inputPath);
            }
        }

        // count  sum of total LOC of all files in directory
        private static int DirTLoc(DirectoryInfo dirPath)
        {
            var sum = 0;
            FileInfo[] files = dirPath.GetFiles("*.*");
            foreach (FileInfo file in files)
            {
                String fi = file.FullName;
                var fiLoc = FileTLoc(fi);
                sum += fiLoc;
                Console.WriteLine(fi + " | tloc=" + fiLoc);
            }
            DirectoryInfo[] dirs = dirPath.GetDirectories("*.*");
            foreach (DirectoryInfo dir in dirs)
            {
                sum += DirTLoc(dir);
            }
            return sum;
        }

        // count total LOC of a file
        private static int FileTLoc(string filePath)
        {
            int count = 0;
            var sr = new StreamReader(filePath);
            while (sr.ReadLine() != null)
            {
                count++;
            }
            sr.Close();
            return count;
        }
    }
}
