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
using System.Diagnostics;
using System.Linq;
using Produire;
using Produire.Model;
using Produire.Model.Phrase;
using Produire.Model.Statement;
using Produire.TypeModel;
using Unicoen.Model;
using Unicoen.ProgramGenerators;

// ReSharper disable InvocationIsSkipped

namespace Unicoen.Languages.Produire.ProgramGenerators
{
	public static class ProduireProgramGeneratorHelper
	{
		public static Dictionary<string, UnifiedBinaryOperator>
				Sign2BinaryOperator;

		public static Dictionary<string, UnifiedUnaryOperator>
				Sign2PrefixUnaryOperator;

		static ProduireProgramGeneratorHelper()
		{
			Sign2BinaryOperator =
					UnifiedProgramGeneratorHelper.CreateBinaryOperatorDictionary
							();
			Sign2PrefixUnaryOperator =
					UnifiedProgramGeneratorHelper.
							CreatePrefixUnaryOperatorDictionaryForJava();
		}

		public static UnifiedProgram CreateProgram(ProduireFile rdr)
		{
			var program = UnifiedProgram.Create(UnifiedBlock.Create());
			ParseClass(rdr.Global, program.Body);
			foreach (var construct in rdr.GetConstructs()) {
				program.Body.Add(CreateClassDefinition(construct));
			}
			return program;
		}

		private static void ParseClass(Construct construct, UnifiedBlock block)
		{ // コードの取得
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

		private static UnifiedExpression CreateField(IPField field)
		{
			throw new NotImplementedException();
		}

		public static UnifiedClassDefinition CreateClassDefinition(
				Construct construct)
		{
			var klass = UnifiedClassDefinition.Create();
			ParseClass(construct, klass.Body);
			return klass;
		}

		private static IEnumerable<UnifiedExpression> Skip(IStatement arg) { yield break; }

		private static IEnumerable<UnifiedExpression> CreateStatement(IStatement statement)
		{
			return TypeDispatcher<IEnumerable<UnifiedExpression>>.Create(statement)
					.Case<ProcessAndAssignStatement>(CreateProcessAndAssignStatement)
					.Case<AssignStatement>(CreateAssignStatement)
					.Case<IfStatement>(CreateIfStatement)
					.Case<SwitchStatement>(CreateSwitchStatement)
					.Case<ForLoopStatement>(CreateForStatement)
					.Case<StaticCallExpression>(CreateCallExpression)
					.Case<NewLineToken>(Skip)
					.Case<SpaceToken>(Skip)
					.Case<BlockEndStatement>(Skip)
					.Result();
		}

		private static IEnumerable<UnifiedExpression> CreateCallExpression(StaticCallExpression statement)
		{
			var args =
					from ph in statement.Phrases.OfType<ActualComplementPhrase>()
					let arg = CreatePhrase(ph.PrefixExpression)
					let sfx = ph.Particle.Text
					select UnifiedArgument.Create(arg, UnifiedIdentifier.CreateVariable(sfx));
			yield return
					UnifiedCall.Create(
							UnifiedIdentifier.CreateVariable(statement.MethodInfo.Name), args.ToSet());
		}

		private static IEnumerable<UnifiedExpression> CreateForStatement(ForLoopStatement statement)
		{
			switch (statement.ForLoopType) {
				case ForLoopStatement.ForTypes.Count:
					yield return UnifiedCountedLoop.Create(CreatePhrase(statement.LoopCount), CreateStatementCollection(statement.Statements));
					break;
				case ForLoopStatement.ForTypes.Until:
				case ForLoopStatement.ForTypes.While:
				case ForLoopStatement.ForTypes.ToNumber:
					yield return ToNumberForStatement(statement);
				break;
				case ForLoopStatement.ForTypes.Infinity:
				case ForLoopStatement.ForTypes.Each:
					throw new NotImplementedException();
			}
		}

		private static UnifiedExpression ToNumberForStatement(ForLoopStatement statement) {
			var phrases = statement.Header.Phrases.Cast<ActualComplementPhrase>();
			Func<string, UnifiedExpression> findFromParticle = particle => phrases.Where(ph => ph.Particle.Text == particle).Select(
							ph => CreatePhrase(ph.PrefixExpression)).FirstOrDefault();
			var fromValue = findFromParticle("から");
			var stepValue = findFromParticle("ずつ");
			var toValue = findFromParticle("まで");
			var variable = findFromParticle("を");

			throw new NotImplementedException();
		}

		private static IEnumerable<UnifiedExpression> CreateSwitchStatement(SwitchStatement statement)
		{
			var cases =
					statement.CodeList.Cast<SwitchCaseBase>().Select(
							sc =>
							UnifiedCase.Create(
									CreatePhrase(sc.CaseLabel), CreateStatementCollection(sc.Statements)))
							.ToSet();
			cases.Add(UnifiedCase.CreateDefault(CreateStatementCollection(statement.ElseCase.Statements)));
			yield return UnifiedSwitch.Create(CreatePhrase(statement.Expression), cases);
		}

		private static UnifiedBlock CreateStatementCollection(StatementCollection statements)
		{
			return statements.SelectMany(CreateStatement).ToBlock();
		}

		private static IEnumerable<UnifiedExpression> CreateIfStatement(IfStatement statement)
		{
			var ifs =
					statement.CaseList.Select(
							c =>
							Tuple.Create(
									CreatePhrase(c.Condition),
									CreateStatementCollection(c.Statements)));
			var els = statement.ElseCase != null ? CreateStatementCollection(statement.ElseCase.Statements):null;
			yield return UnifiedIf.Create(ifs, els);
		}

		private static IEnumerable<UnifiedExpression> CreateProcessAndAssignStatement(ProcessAndAssignStatement statement) {
			yield return UnifiedBinaryExpression.Create(
					CreatePhrase(statement.VariablePhrase),
					UnifiedBinaryOperator.Create("=", UnifiedBinaryOperatorKind.Assign),
					CreatePhrase(statement.ValuePhrase));
		}

		private static IEnumerable<UnifiedExpression> CreateAssignStatement(
				AssignStatement statement)
		{
			yield return UnifiedBinaryExpression.Create(
					CreatePhrase(statement.Left),
					UnifiedBinaryOperator.Create("=", UnifiedBinaryOperatorKind.Assign),
					CreatePhrase(statement.Right));
		}

		private static UnifiedExpression CreatePhrase(IPhrase phrase)
		{
			//var g = phrase.GetType().GetGenericArguments();
			//if (g.Length == 1 && g[0] == typeof(Int32)) {
			//    var value = Int32.Parse(phrase.Text);
			//    return UnifiedIntegerLiteral.CreateInt32(value);
			//}

			return TypeDispatcher<UnifiedExpression>.Create(phrase)
					.Case<VariableToken>(CreateVariableToken)
					.Case<NumberToken<sbyte>>(CreateNumberToken)
					.Case<NumberToken<short>>(CreateNumberToken)
					.Case<NumberToken<int>>(CreateNumberToken)
					.Case<NumberToken<long>>(CreateNumberToken)
					.Case<NumberToken<byte>>(CreateNumberToken)
					.Case<NumberToken<ushort>>(CreateNumberToken)
					.Case<NumberToken<uint>>(CreateNumberToken)
					.Case<NumberToken<ulong>>(CreateNumberToken)
					.Case<StringConstPhrase>(CreateStringConstPhrase)
					.Case<MathFunctionStylePhrase>(CreateMathFunctionStylePhrase)
					.Case<ConditionSentenceSuffix>(CreateConditionSentenceSuffix)
					.Result();
		}

		private static UnifiedExpression CreateConditionSentenceSuffix(ConditionSentenceSuffix phrase) {
			Debug.Assert(phrase.SuffixPhrase.CompareType != CompareTypes.Not);
			Debug.Assert(phrase.SuffixPhrase.CompareType != CompareTypes.None);
			return UnifiedBinaryExpression.Create(
					CreatePhrase(phrase.LeftPhrase),
					CreateConditionSuffixToken(phrase.SuffixPhrase),
					CreatePhrase(phrase.RightPhrase));
		}

		private static UnifiedBinaryOperator CreateConditionSuffixToken(ConditionSuffixToken token) {
			switch (token.CompareType) {
			case CompareTypes.Equal:
				return UnifiedBinaryOperator.Create(
						token.Text, UnifiedBinaryOperatorKind.Equal);
			case CompareTypes.NotEqual:
				return UnifiedBinaryOperator.Create(
						token.Text, UnifiedBinaryOperatorKind.NotEqual);
			case CompareTypes.LargerThan:
				return UnifiedBinaryOperator.Create(
						token.Text, UnifiedBinaryOperatorKind.GreaterThan);
			case CompareTypes.LargerEqual:
				return UnifiedBinaryOperator.Create(
						token.Text, UnifiedBinaryOperatorKind.GreaterThanOrEqual);
			case CompareTypes.SmallerThan:
				return UnifiedBinaryOperator.Create(
						token.Text, UnifiedBinaryOperatorKind.LessThan);
			case CompareTypes.SmallEqual:
				return UnifiedBinaryOperator.Create(
						token.Text, UnifiedBinaryOperatorKind.LessThanOrEqual);
			case CompareTypes.And:
				return UnifiedBinaryOperator.Create(
						token.Text, UnifiedBinaryOperatorKind.And);
			case CompareTypes.Or:
				return UnifiedBinaryOperator.Create(
						token.Text, UnifiedBinaryOperatorKind.Or);
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		private static UnifiedExpression CreateNumberToken(NumberToken<byte> token) {
			return UnifiedIntegerLiteral.CreateUInt8(token.NumberValue);
		}

		private static UnifiedExpression CreateNumberToken(NumberToken<ushort> token) {
			return UnifiedIntegerLiteral.CreateUInt16(token.NumberValue);
		}

		private static UnifiedExpression CreateNumberToken(NumberToken<uint> token) {
			return UnifiedIntegerLiteral.CreateUInt32(token.NumberValue);
		}

		private static UnifiedExpression CreateNumberToken(NumberToken<ulong> token) {
			return UnifiedIntegerLiteral.CreateUInt64(token.NumberValue);
		}

		private static UnifiedExpression CreateNumberToken(NumberToken<sbyte> token) {
			return UnifiedIntegerLiteral.CreateInt8(token.NumberValue);
		}

		private static UnifiedExpression CreateNumberToken(NumberToken<short> token) {
			return UnifiedIntegerLiteral.CreateInt16(token.NumberValue);
		}

		private static UnifiedExpression CreateNumberToken(NumberToken<int> token) {
			return UnifiedIntegerLiteral.CreateInt32(token.NumberValue);
		}

		private static UnifiedExpression CreateNumberToken(NumberToken<long> token) {
			return UnifiedIntegerLiteral.CreateInt64(token.NumberValue);
		}

		private static UnifiedExpression CreateMathFunctionStylePhrase(MathFunctionStylePhrase phrase) {
			return UnifiedIndexer.Create(CreatePhrase(phrase.ParameterPhrase));
		}

		private static UnifiedExpression CreateStringConstPhrase(StringConstPhrase phrase) {
			return UnifiedStringLiteral.Create(phrase.Text);
		}

		private static UnifiedExpression CreateVariableToken(VariableToken token)
		{
			return UnifiedIdentifier.CreateVariable(token.Variable.Name);
		}
	}

	public static class TypeDispatcher<TResult>
	{
		public static TypeDispatcher<TBase, TResult> Create<TBase>(TBase obj)
		{
			return new TypeDispatcher<TBase, TResult>(obj);
		}
	}

	public class TypeDispatcher<TBase, TResult>
	{
		private readonly TBase _obj;
		private TResult _result;
		private bool _completed;

		public TypeDispatcher(TBase obj)
		{
			_obj = obj;
		}

		public TResult Result()
		{
			if (!_completed) {
				throw new InvalidOperationException("Processing is not completed.");
			}
			return _result;
		}

		public TResult ResultOrDefault(TResult defaultValue)
		{
			if (!_completed) {
				return defaultValue;
			}
			return _result;
		}

		public TResult ResultOrDefault()
		{
			return ResultOrDefault(default(TResult));
		}

		public TypeDispatcher<TBase, TResult> Case<T>(Func<T, TResult> f)
				where T : TBase
		{
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