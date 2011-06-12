using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Unicoen.Apps.Aop.Tests
{
	/// <summary>
	/// FileCollectorが正しく動作するかテストします
	/// </summary>
	[TestFixture]
	class FileCollectorTest {
		
		[Test]
		public void フォルダを再帰的に探索しファイル一覧を取得する() {
			foreach (var file in FileCollector.Collect("../../fixture/AspectCompiler/input")) {
				Console.WriteLine(file);
			}
		}
	}
}
