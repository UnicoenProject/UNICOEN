using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Unicoen.Apps.Loc.Util
{
    public class BlankLoc
    {
        // measure number of the lines which contain only space character(s) 
        // (the blank character, tab character and newline character) 
        public static int CountBlankLoc(string inputPath)
        {
            FileAttributes attr = File.GetAttributes(@inputPath);
            // if inputPath is a directory
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                DirectoryInfo dirPath = new DirectoryInfo(@inputPath);
                return DirBLoc(dirPath);
            }
            // if inputPath is a file
            else
            {
                return FileBLoc(inputPath);
            }
        }

        // count  sum of blank LOC of all files in directory
        private static int DirBLoc(DirectoryInfo dirPath)
        {
            var sum = 0;
            FileInfo[] files = dirPath.GetFiles("*.*");
            foreach (FileInfo file in files)
            {
                String fi = file.FullName;
                var fiLoc = FileBLoc(fi);
                sum += fiLoc;
                Console.WriteLine(fi + " | bloc=" + fiLoc);
            }
            DirectoryInfo[] dirs = dirPath.GetDirectories("*.*");
            foreach (DirectoryInfo dir in dirs)
            {
                sum += DirBLoc(dir);
            }
            return sum;
        }

        // count blank LOC of a file
        private static int FileBLoc(string filePath)
        {
            string line;
            int count = 0;
            var sr = new StreamReader(filePath);
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Trim().Length == 0) count++;
            }
            sr.Close();
            return count;
        }
    }
}
