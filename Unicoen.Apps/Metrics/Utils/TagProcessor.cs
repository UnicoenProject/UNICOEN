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

using System;
using System.Collections.Generic;
using Paraiba.Linq;

namespace Unicoen.Apps.Metrics.Utils {
    public static class TagProcessor {
        public static SortedSet<string> HierarchizeTags(
                IEnumerable<string> tagSet) {
            var newTagSet = new SortedSet<string>();
            foreach (var tag in tagSet) {
                HierarchizeTag(tag, newTagSet);
            }
            return newTagSet;
        }

        public static void HierarchizeTag(string tag, ISet<string> newTagSet) {
            var tagElements = tag.Split(new[] { "::" }, StringSplitOptions.None);
            var newTag = string.Empty;
            foreach (var tagEelment in tagElements.SkipLast()) {
                newTag += tagEelment + "::";
                newTagSet.Add(newTag);
            }
        }
    }
}