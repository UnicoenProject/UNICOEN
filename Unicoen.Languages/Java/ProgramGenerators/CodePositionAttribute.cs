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

using System;
using System.Xml.Linq;
using Code2Xml.Core.Position;
using PostSharp.Aspects;
using Unicoen.Model;

namespace Unicoen.Languages.Java.ProgramGenerators {
	[Serializable]
	public class CodePositionAttribute : OnMethodBoundaryAspect {
		/// <summary>
		///   Method invoked after successfull execution of the method to which the current aspect is applied.
		/// </summary>
		/// <param name="args"> Information about the method being executed. </param>
		public override void OnSuccess(MethodExecutionArgs args) {
			((UnifiedElement)args.ReturnValue).Position =
					CodePositionAnalyzer.Create((XElement)args.Arguments[0]);
		}
	}
}