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
	///   UnifiedSpecialExpressionの種類を表します。
	/// </summary>
	public enum UnifiedSpecialExpressionKind {
		Assert,
		Break,
		Continue,
		Goto,
		Return,
		YieldReturn,
		Throw,

		/// <summary>
		///   retry in Ruby
		/// </summary>
		Retry,

		/// <summary>
		///   redo in Ruby
		/// </summary>
		Redo,

		/// <summary>
		///   yield in Ruby
		/// </summary>
		Yield,

		/// <summary>
		///   print in Python
		/// </summary>
		Print,

		/// <summary>
		///   print >> in Python
		/// </summary>
		PrintChevron,

		/// <summary>
		///   pass in Python
		/// </summary>
		Pass,

		/// <summary>
		///   del in Python
		/// </summary>
		Delete,

		/// <summary>
		///   global in Python
		/// </summary>
		Global,

		/// <summary>
		///   exec in Python
		/// </summary>
		Exec,

		/// <summary>
		///   exec in Python
		/// </summary>
		StringConversion,
	}
}