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
        public static int Count(string inputPath)
        {
            FileAttributes attr = File.GetAttributes(@inputPath);
            // if inputPath is a directory
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                DirectoryInfo dirPath = new DirectoryInfo(@inputPath);
                return CountForDirectory(dirPath);
            }
            // if inputPath is a file
            else
            {
                return CountForFile(inputPath);
            }
        }

        // count  sum of blank LOC of all files in directory
        private static int CountForDirectory(DirectoryInfo dirPath)
        {
            var sum = 0;
            var files = dirPath.GetFiles("*.*");
            foreach (FileInfo file in files)
            {
                String fi = file.FullName;
                var fiLoc = CountForFile(fi);
                sum += fiLoc;
                Console.WriteLine(fi + " | bloc=" + fiLoc);
            }
            var dirs = dirPath.GetDirectories("*.*");
            foreach (DirectoryInfo dir in dirs)
            {
                sum += CountForDirectory(dir);
            }
            return sum;
        }

        // count blank LOC of a file
        private static int CountForFile(string filePath)
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
