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
using System.Collections.Generic;
using System.Linq;
using Produire;
using Produire.Model;
using Produire.Model.Phrase;
using Produire.Model.Statement;
using Produire.TypeModel;
using Unicoen.Model;
using Unicoen.ProgramGenerators;

// ReSharper disable InvocationIsSkipped

namespace Unicoen.Languages.Produire.ProgramGenerators {
	public static class ProduireProgramGeneratorHelper {
		public static Dictionary<string, UnifiedBinaryOperator>
				Sign2BinaryOperator;

		public static Dictionary<string, UnifiedUnaryOperator>
				Sign2PrefixUnaryOperator;

		static ProduireProgramGeneratorHelper() {
			Sign2BinaryOperator =
					UnifiedProgramGeneratorHelper.CreateBinaryOperatorDictionary
							();
			Sign2PrefixUnaryOperator =
					UnifiedProgramGeneratorHelper.
							CreatePrefixUnaryOperatorDictionaryForJava();
		}

		public static UnifiedProgram CreateProgram(ProduireFile rdr) {
			var program = UnifiedProgram.Create(UnifiedBlock.Create());
			ParseClass(rdr.Global, program.Body);
			foreach (var construct in rdr.GetConstructs()) {
				program.Body.Add(CreateClassDefinition(construct));
			}
			return program;
		}

		private static void ParseClass(Construct construct, UnifiedBlock block) { // コードの取得
			// ステートメントの取得
			foreach (var procedure in construct.GetProcedures()) {
				foreach (var statement in procedure.Statements) {
					block.AddRange(CreateStatement(statement));
				}
			}
			// フィールドの取得
			foreach (var field in construct.GetAllFields()) {
				block.Add(CreateField(field));
			}
		}

		private static UnifiedExpression CreateField(IPField field) {
			throw new NotImplementedException();
		}

		public static UnifiedClassDefinition CreateClassDefinition(
				Construct construct) {
			var klass = UnifiedClassDefinition.Create();
			ParseClass(construct, klass.Body);
			return klass;
		}

		private static IEnumerable<UnifiedExpression> CreateStatement(IStatement statement) {
			return TypeDispatcher<IEnumerable<UnifiedExpression>>.Create(statement)
					.Case<AssignStatement>(CreateAssignStatement)
					.Case<IfStatement>(CreateIfStatement)
					.Case<SwitchStatement>(CreateSwitchStatement)
					.Case<NewLineToken>(CreateNewLineToken)
					.Result();
		}

		private static IEnumerable<UnifiedExpression> CreateNewLineToken(NewLineToken arg) {
			yield break;
		}

		private static IEnumerable<UnifiedExpression> CreateForStatement(ForLoopStatement statement) {
			return null;
		}

		private static IEnumerable<UnifiedExpression> CreateSwitchStatement(SwitchStatement statement) {
			var cases =
					statement.CodeList.Cast<SwitchCaseBase>().Select(
							sc =>
							UnifiedCase.Create(
									CreatePhrase(sc.CaseLabel), CreateStatementCollection(sc.Statements)))
							.ToSet();
			cases.Add(UnifiedCase.CreateDefault(CreateStatementCollection(statement.ElseCase.Statements)));
			yield return UnifiedSwitch.Create(CreatePhrase(statement.Expression), cases);
		}

		private static UnifiedBlock CreateStatementCollection(StatementCollection statements) {
			return statements.SelectMany(CreateStatement).ToBlock();
		}

		private static IEnumerable<UnifiedExpression> CreateIfStatement(IfStatement statement) {
			var ifs =
					statement.CaseList.Select(
							c =>
							Tuple.Create(
									CreatePhrase(c.Condition),
									CreateStatementCollection(c.Statements)));
			var els = CreateStatementCollection(statement.ElseCase.Statements);
			yield return UnifiedIf.Create(ifs, els);
		}

		private static IEnumerable<UnifiedExpression> CreateAssignStatement(
				AssignStatement statement) {
			yield return UnifiedBinaryExpression.Create(
					CreatePhrase(statement.Left),
					UnifiedBinaryOperator.Create("=", UnifiedBinaryOperatorKind.Assign),
					CreatePhrase(statement.Right));
		}

		private static UnifiedExpression CreatePhrase(IPhrase phrase) {
			var super = phrase.GetType().BaseType;
			var pType = phrase.GetPType();
			return TypeDispatcher<UnifiedExpression>.Create(phrase)
					.Case<VariableToken>(CreateVariableToken)
					.Case<StringConstPhrase>(CreateStringConstPhrase)
					.Result();
		}

		private static UnifiedExpression CreateStringConstPhrase(StringConstPhrase phrase) {
			return UnifiedStringLiteral.Create(phrase.Text);
		}

		private static UnifiedExpression CreateVariableToken(VariableToken token) {
			return UnifiedIdentifier.CreateVariable(token.Variable.Name);
		}
	}

	public static class TypeDispatcher<TResult> {
		public static TypeDispatcher<TBase, TResult> Create<TBase>(TBase obj) {
			return new TypeDispatcher<TBase, TResult>(obj);
		}
	}

	public class TypeDispatcher<TBase, TResult> {
		private readonly TBase _obj;
		private TResult _result;
		private bool _completed;

		public TypeDispatcher(TBase obj) {
			_obj = obj;
		}

		public TResult Result() {
			if (!_completed) {
				throw new InvalidOperationException("Processing is not completed.");
			}
			return _result;
		}

		public TResult ResultOrDefault(TResult defaultValue) {
			if (!_completed) {
				return defaultValue;
			}
			return _result;
		}

		public TResult ResultOrDefault() {
			return ResultOrDefault(default(TResult));
		}

		public TypeDispatcher<TBase, TResult> Case<T>(Func<T, TResult> f)
				where T : TBase {
			if (_completed) {
				return this;
			}
			if (_obj is T) {
				_completed = true;
				_result = f((T)_obj);
			}
			return this;
		}
	}
}