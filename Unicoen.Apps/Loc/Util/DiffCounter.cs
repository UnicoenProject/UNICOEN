#region License

// Copyright (C) 2011 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

namespace Unicoen.Apps.Loc.Util {
    // class containing number of differential elements
    public class DiffCounter {
        public DiffCounter(int na, int nd, int nm, int ne) {
            AddedCount = na;
            DeletedCount = nd;
            ModifiedCount = nm;
            EqualCount = ne;
        }

        public DiffCounter()
                : this(0, 0, 0, 0) {}

        public int AddedCount { get; set; }
        public int DeletedCount { get; set; }
        public int ModifiedCount { get; set; }
        public int EqualCount { get; set; }
    }
}