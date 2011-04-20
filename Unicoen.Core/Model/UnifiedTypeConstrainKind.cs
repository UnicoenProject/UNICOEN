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

namespace Unicoen.Core.Model {
	/// <summary>
	///   型が持つ制約の種類を表します。
	/// </summary>
	public enum UnifiedTypeConstrainKind {
		/// <summary>
		///   継承を表します。
		///   e.g. Javeにおける継承(<c>class Child extends Parent</c>)
		/// </summary>
		Extends,
		/// <summary>
		///   実装を表します。
		///   e.g. Javeにおける実装(<c>class Child implements Interface</c>)
		/// </summary>
		Implements,
		/// <summary>
		///   継承もしくは実装を表します。
		///   e.g. C#における継承(<c>class Child : Parent, Interface</c>)
		/// </summary>
		ExtendsOrImplements,
		/// <summary>
		///   デフォルトコンストラクタの存在を表します。
		///   e.g. C#におけるnew()(<c>where T : new()</c>)
		/// </summary>
		DefaultConstructor,
		/// <summary>
		///   参照型を表します。
		///   e.g. C#におけるclass(<c>where T : class</c>)
		/// </summary>
		ReferenceType,
		/// <summary>
		///   値型を表します。
		///   e.g. C#におけるstruct(<c>where T : struct</c>)
		/// </summary>
		ValueType,
		/// <summary>
		/// </summary>
		Super
	}
}