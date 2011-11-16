using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Unicoen.Apps.Loc.Util
{
    class BlankLoc
    {
        public static int CountBlankLoc(string filePath)
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
