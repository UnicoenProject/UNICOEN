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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unicoen.Apps.Aop.AspectElement;
using Unicoen.Apps.Aop.Visitor;
using Unicoen.Model;

namespace Unicoen.Apps.Aop {
	public static class AspectAdaptor {
		/// <summary>
		///   ポイントカットをポイントカット名で参照できるようにします
		/// </summary>
		private static readonly Dictionary<string, Pointcut> Pointcuts =
				new Dictionary<string, Pointcut>();

		public static void Weave(
				string language, UnifiedProgram model, AstVisitor visitor) {
			//以前のアスペクトファイルの情報を消去するために辞書の内容を初期化する
			Pointcuts.Clear();

			//与えられたモデルに対してインタータイプを合成する
			foreach (var intertype in visitor.Intertypes) {
				if (intertype.GetLanguageType() != language)
					continue;
				var members = CodeProcessor.CreateIntertype(
						intertype.GetLanguageType(), intertype.GetContents());
				CodeProcessor.AddIntertypeDeclaration(model, intertype.GetTarget(), members);
			}

			//ポイントカットを登録する
			foreach (var pointcut in visitor.Pointcuts) {
				var name = pointcut.GetName();
				//同じ名前のポイントカットがある場合にはエラーとする
				if (Pointcuts.ContainsKey(name))
					throw new InvalidOperationException(
							"同名のポイントカットがすでに宣言されています: " + name);
				//ポイントカットを自身の名前で登録
				Pointcuts.Add(name, pointcut);
			}

			//アドバイスの適用
			foreach (var advice in visitor.Advices) {
				//アドバイスのターゲットがポイントカット宣言されていない場合はエラーとする
				if (!Pointcuts.ContainsKey(advice.GetTarget()))
					throw new InvalidOperationException(
							"指定されたポイントカットは宣言されていません");

				//アドバイスのターゲットが登録されていれば、それに対応するポイントカットを取得する
				Pointcut target;
				Pointcuts.TryGetValue(advice.GetTarget(), out target);

				//指定された言語のアドバイスがあればそれをモデルに変換する
				UnifiedBlock code = null;
				foreach (var languageDependBlock in advice.GetFragments()) {
					//
					if (languageDependBlock.GetLanguageType().Equals(language)) {
						code = CodeProcessor.CreateAdvice(
								language, languageDependBlock.GetContents());
						break;
					}
				}
				//現在の対象ファイルの言語向けアドバイスが定義されていない場合は次のアドバイス処理に移る
				if (code == null)
					continue;

				//ポイントカットの指定に応じて適切なアドバイスの合成処理を行う
				//TODO ワイルドカードなどへの対応
				//TODO 複数のターゲットを持つポイントカットへの対応(これはそもそもパーサを改良する必要あり)

				var methodName = target.GetTargetName().ElementAt(1);
				//アドバイスタイプによる分岐
				switch (advice.GetAdviceType()) {

					case "before":
						//ポイントカットタイプによる分岐
						switch (target.GetPointcutType()) {
							case "execution":
								CodeProcessor.InsertAtBeforeExecutionByName(model, methodName, code); break;							
							case "call":
								CodeProcessor.InsertAtBeforeCallByName(model, methodName, code); break;
							case "get":
								CodeProcessor.InsertAtBeforeGetByName(model, methodName, code); break;
							case "set":
								CodeProcessor.InsertAtBeforeSetByName(model, methodName, code); break;
							default:
								throw new InvalidOperationException("ポイントカットの種類が正しくありません");
						}
					break;

					case "after":
						switch (target.GetPointcutType()) {
							case "execution":
								CodeProcessor.InsertAtAfterExecutionByName(model, methodName, code); break;						
							case "call":
								CodeProcessor.InsertAtAfterCallByName(model, methodName, code); break;
							case "get":
								CodeProcessor.InsertAtAfterGetByName(model, methodName, code); break;
							case "set":
								CodeProcessor.InsertAtAfterSetByName(model, methodName, code); break;
							default:
								throw new InvalidOperationException("ポイントカットの種類が正しくありません");
						}
					break;

				default:
					throw new InvalidOperationException(
							"アドバイスの種類が正しくありません");
				}
			}
		}

		public static IEnumerable<string> Collect(string folderRootPath) {
			//指定された文字列がフォルダじゃなかった場合
			if (!Directory.Exists(folderRootPath)) {
				var list = new List<string>();
				list.Add(folderRootPath);
				return list;
			}

			//指定された文字列に該当するフォルダがある場合
			return Directory.EnumerateFiles(
					folderRootPath, "*", SearchOption.AllDirectories);
		}
	}
}