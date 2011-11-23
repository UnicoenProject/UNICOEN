using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unicoen.Apps.Loc.Util
{
    // class containing number of differential elements
    public class DiffCounter
    {
        public int NumAdded { get; set; }
        public int NumDeleted { get; set; }
        public int NumModified { get; set; }
        public int NumEqual { get; set; }

        public DiffCounter(int na, int nd, int nm, int ne)
        {
            NumAdded = na;
            NumDeleted = nd;
            NumModified = nm;
            NumEqual = ne;
        }

        public DiffCounter()
            : this(0, 0, 0, 0)
        {
        }
    }
}
