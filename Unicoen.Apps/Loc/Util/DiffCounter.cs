using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unicoen.Apps.Loc.Util
{
    // class containing number of differential elements
    public class DiffCounter
    {
        public int AddedCount { get; set; }
        public int DeletedCount { get; set; }
        public int ModifiedCount { get; set; }
        public int EqualCount { get; set; }

        public DiffCounter(int na, int nd, int nm, int ne)
        {
            AddedCount = na;
            DeletedCount = nd;
            ModifiedCount = nm;
            EqualCount = ne;
        }

        public DiffCounter()
            : this(0, 0, 0, 0)
        {
        }
    }
}
