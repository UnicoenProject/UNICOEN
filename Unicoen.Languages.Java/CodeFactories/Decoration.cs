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

namespace Unicoen.Languages.Java.CodeFactories {
	/// <summary>
	///   MostLeft EachLeft Element1 EachRight Delimiter EachLeft Element2 EachRight ... MostRight
	/// </summary>
	public class Decoration {
		/// <summary>
		///   左端の文字
		/// </summary>
		public string MostLeft;

		/// <summary>
		///   右端の文字
		/// </summary>
		public string MostRight;

		/// <summary>
		///   各要素の直前
		/// </summary>
		public string EachLeft;

		/// <summary>
		///   各要素の直後
		/// </summary>
		public string EachRight;

		/// <summary>
		///   区切り文字
		/// </summary>
		public string Delimiter;

		public Decoration() {
			MostLeft = "";
			MostRight = "";
			EachLeft = "";
			EachRight = "";
			Delimiter = "";
		}

		///// <summary>
		///// 親要素が集合である場合の自分自身の要素位置
		///// </summary>
		//public int Index;
	}
}