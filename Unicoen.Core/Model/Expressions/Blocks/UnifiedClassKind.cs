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
	///   UnifiedClassDefinitionの種類を表します。
	/// </summary>
	public enum UnifiedClassKind {

		Class,

		/// <summary>
		///   interface in Java, C#
		///   trait? in Scala
		/// </summary>
		Interface,

		/// <summary>
		///   namespace in C#, C++
		///   package in Java
		/// </summary>
		Namespace,

		/// <summary>
		///   enum in Java, C#, C++
		/// </summary>
		Enum,

		/// <summary>
		///   annotation in Java
		///   attribute in C#
		/// </summary>
		Annotation,

		/// <summary>
		///   struct in C, C++, C#
		/// </summary>
		Struct,

		/// <summary>
		///   union in C, C++
		/// </summary>
		Union,

		/// <summary>
		///   module in Ruby
		/// </summary>
		Module,
	}
}