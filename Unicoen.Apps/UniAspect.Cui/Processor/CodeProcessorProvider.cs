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
using Unicoen.Model;

namespace Unicoen.Apps.UniAspect.Cui.Processor {
	public class CodeProcessorProvider {
		private static CodeProcessorProvider _instance;

#pragma warning disable 649
		[ImportMany] private IEnumerable<Pointcut.CodeProcessor> _aspects;
#pragma warning restore 649

		private CodeProcessorProvider() {
			var catalog = new AggregateCatalog();
			catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
			catalog.Catalogs.Add(new DirectoryCatalog("."));
			//catalog.Catalogs.Add(new DirectoryCatalog("Extensions"));
			var container = new CompositionContainer(catalog);
			container.ComposeParts(this);
		}

		private static CodeProcessorProvider Instance {
			get { return _instance ?? (_instance = new CodeProcessorProvider()); }
		}

		public static IEnumerable<Pointcut.CodeProcessor> Aspects {
			get { return Instance._aspects; }
		}

		public static void WeavingBefore(string name, IUnifiedElement model, string targetName, UnifiedBlock advice) {
			var aspect = GetAspectFromName(name);
			aspect.Before(model, targetName, advice);
		}

		public static void WeavingAfter(string name, IUnifiedElement model, string targetName, UnifiedBlock advice) {
			var aspect = GetAspectFromName(name);
			aspect.After(model, targetName, advice);
		}

		public static void WeavingAround(string name, IUnifiedElement model) {
			var aspect = GetAspectFromName(name);
			aspect.Around(model);
		}

		public static Pointcut.CodeProcessor GetAspectFromName(string name) {
			// TODO １つだけ取得するいい方法をみつける
			// -> UniGeneratorsの実装を見てみる？
			return Aspects.Where(e => e.PointcutName == name).First();
		}
	}
}