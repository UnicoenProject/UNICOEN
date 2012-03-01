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

using System.Collections.Generic;
using Unicoen.Apps.Metrics.Utils;
using Unicoen.Model;

namespace Unicoen.Apps.Metrics.Core {
    public class Cyclomatic : MetricsPrinter {
        protected override string MeticName {
            get { return "Cyclomatic complexity"; }
        }

        protected override int AdditionalCount {
            get { return 1; }
        }

        protected override IEnumerable<UnifiedElement>
                ProtectedGetTargetElements(
                UnifiedElement codeObject) {
            return GetTargetElements(codeObject);
        }

        public static IEnumerable<UnifiedElement> GetTargetElements(
                UnifiedElement codeObject) {
            return
                    codeObject.Descendants
                            <UnifiedIf, UnifiedFor, UnifiedWhile, UnifiedDoWhile
                                    , UnifiedCase>();
        }
    }
}