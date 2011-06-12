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
using NUnit.Framework;

namespace Unicoen.Apps.Aop.Tests {
	/// <summary>
	///   FileCollectorが正しく動作するかテストします
	/// </summary>
	[TestFixture]
	internal class FileCollectorTest {
		[Test]
		public void フォルダを再帰的に探索しファイル一覧を取得する() {
			foreach (
					var file in FileCollector.Collect("../../fixture/AspectCompiler/input")) {
				Console.WriteLine(file);
			}
		}
	}
}