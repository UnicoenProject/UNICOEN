#region License

// Copyright (C) 2011-2012 The Unicoen Project
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

using System.Collections.Generic;
using System.Linq;
using Unicoen.Apps.Metrics.Utils;
using Unicoen.Model;

namespace Unicoen.Apps.Metrics.Core {
    public class Loc : MetricsPrinter {
        protected override string MeticName {
            get { return "LOC(lines of code)"; }
        }

        protected override IEnumerable<IUnifiedElement>
                ProtectedGetTargetElements(
                IUnifiedElement codeObject) {
            return GetTargetElements(codeObject);
        }

        public static IEnumerable<IUnifiedElement> GetTargetElements(
                IUnifiedElement codeObject) {
            return codeObject.Descendants<IUnifiedExpression>()
                    .Where(e => e.Parent is UnifiedBlock);
        }
    }
}