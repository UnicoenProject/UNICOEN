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
using System.Linq;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using NUnit.Framework;
using Unicoen.Apps.Aop.Visitor;
using Unicoen.Core.Tests;

namespace Aries.Tests {
	internal class PointcutTest {
		private AstVisitor _visitor;

		[SetUp]
		public void SetUp() {
			var input =
					new ANTLRFileStream(
							FixtureUtil.GetInputPath(
									"AspectCompiler",
									"simple_pointcut_sample.txt"));
							
			var lex = new AriesLexer(input);
			var tokens = new CommonTokenStream(lex);
			var parser = new AriesParser(tokens);
			parser.TraceDestination = Console.Error;

			var result = parser.aspect();
			var ast = (CommonTree)result.Tree;

			_visitor = new AstVisitor();
			_visitor.Visit(ast, 0, null);
		}

		[Test]
		public void ポイントカットの種類を取得できる() {
			var pointcutType =
					_visitor.Pointcuts.ElementAt(0).GetPointcutType();
			Assert.That(pointcutType, Is.EqualTo("execution"));
		}

		[Test]
		public void ポイントカット名を取得できる() {
			var name =
					_visitor.Pointcuts.ElementAt(0).GetName();
			Assert.That(name, Is.EqualTo("move"));
		}

		[Test, Ignore]
		public void ポイントカットのパラメータを取得できる() {
			//TODO implement
		}

		[Test]
		public void ポイントカット条件の型を取得できる() {
			var targetType =
					_visitor.Pointcuts.ElementAt(0).GetTargetType();
			Assert.That(targetType, Is.EqualTo("double"));
		}

		[Test]
		public void ポイントカット条件の識別子を取得できる() {
			var targetName =
					_visitor.Pointcuts.ElementAt(0).GetTargetName();
			var className = targetName.ElementAt(0);
			var methodName = targetName.ElementAt(1);

			Assert.That(className, Is.EqualTo("Rectangle"));
			Assert.That(methodName, Is.EqualTo("shift"));
		}
	}
}