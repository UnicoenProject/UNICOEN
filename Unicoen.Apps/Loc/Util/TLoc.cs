using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Unicoen.Apps.Loc.Util
{
    class TLoc
    {
        public static int CountTLoc(string filePath)
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
