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
using System.ComponentModel.Composition;
using System.Text.RegularExpressions;
using Unicoen.Model;

namespace Unicoen.Apps.UniAspect.Cui.Processor.Pointcut {
    [Export(typeof(CodeProcessor))]
    public class Exception : CodeProcessor {
        public override string PointcutName {
            get { return "exception"; }
        }

        public override void Before(
                IUnifiedElement model, string targetName, UnifiedBlock advice) {
            var exceptions = model.Descendants<UnifiedCatch>();
            foreach (var e in exceptions) {
                var regex = new Regex("^" + targetName + "$");
                var type = e.Types[0].BasicTypeName as UnifiedIdentifier;
                if (type == null) {
                    continue;
                }
                var m = regex.Match(type.Name);
                if (m.Success) {
                    //アドバイスを対象関数に合成する
                    e.Body.Insert(0, advice.DeepCopy());
                }
            }
        }

        public override void After(
                IUnifiedElement model, string targetName, UnifiedBlock advice) {
            throw new NotImplementedException();
        }

        public override void Around(IUnifiedElement model) {
            throw new NotImplementedException();
        }
    }
}