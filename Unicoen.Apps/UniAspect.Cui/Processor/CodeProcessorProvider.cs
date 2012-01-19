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
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using Unicoen.Apps.UniAspect.Cui.Processor.Pointcut;
using Unicoen.Model;

namespace Unicoen.Apps.UniAspect.Cui.Processor {
    /*
	 * アスペクトの織り込み処理メソッドを持つクラスの一覧をロードします
	 * CodeProcessor型のインターフェースを継承するクラスを定義することで、
	 * ユーザが実装した織り込み処理メソッドを持つクラスを使用できるようになります
	 */

    public class CodeProcessorProvider {
        private static CodeProcessorProvider _instance;

#pragma warning disable 649
        [ImportMany] private IEnumerable<CodeProcessor> _processors;
#pragma warning restore 649

        private CodeProcessorProvider() {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(
                    new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            catalog.Catalogs.Add(new DirectoryCatalog("."));
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        private static CodeProcessorProvider Instance {
            get { return _instance ?? (_instance = new CodeProcessorProvider()); }
        }

        public static IEnumerable<CodeProcessor> Processors {
            get { return Instance._processors; }
        }

        // 指定されたポイントカット(名)に対応するbeforeの織り込み処理を与えられたmodelに適用します
        public static void WeavingBefore(
                string name, IUnifiedElement model, string targetName,
                UnifiedBlock advice) {
            var aspect = GetProcessorFromName(name);
            aspect.Before(model, targetName, advice);
        }

        // 指定されたポイントカット(名)に対応するafterの織り込み処理を与えられたmodelに適用します
        public static void WeavingAfter(
                string name, IUnifiedElement model, string targetName,
                UnifiedBlock advice) {
            var aspect = GetProcessorFromName(name);
            aspect.After(model, targetName, advice);
        }

        // 指定されたポイントカット(名)に対応するaroundの織り込み処理を与えられたmodelに適用します
        public static void WeavingAround(string name, IUnifiedElement model) {
            var aspect = GetProcessorFromName(name);
            aspect.Around(model);
        }

        public static CodeProcessor GetProcessorFromName(string name) {
            return
                    Processors.Where(e => e.PointcutName == name).FirstOrDefault
                            ();
        }
    }
}