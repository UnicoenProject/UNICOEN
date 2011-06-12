using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Apps.Aop.AspectElement;
using Unicoen.Apps.Aop.Visitor;
using Unicoen.Core.Model;

namespace Unicoen.Apps.Aop
{
	public static class AspectAdaptor {

		/// <summary>
		/// ポイントカットをポイントカット名で参照できるようにします
		/// </summary>
		public static Dictionary<string, Pointcut> Pointcuts =
				new Dictionary<string, Pointcut>();

		public static void Weave(string language, UnifiedProgram model, AstVisitor visitor) {
			//与えられたモデルに対してインタータイプを合成する
			foreach(var intertype in visitor.Intertypes) {
				//TODO implement インタータイプ合成メソッドの実装
			}
			
			//ポイントカットを登録する
			foreach (var pointcut in visitor.Pointcuts) {
				var name = pointcut.GetName();
				//同じ名前のポイントカットがある場合にはエラーとする
				if(Pointcuts.ContainsKey(name))
					throw new InvalidOperationException(
							"同名のポイントカットがすでに宣言されています: " + name);
				//ポイントカットを自身の名前で登録
				Pointcuts.Add(name, pointcut);
			}

			//アドバイスの適用
			foreach (var advice in visitor.Advices) {
				//アドバイスのターゲットがポイントカット宣言されていない場合はエラーとする
				if(!Pointcuts.ContainsKey(advice.GetTarget()))
					throw new InvalidOperationException(
						"指定されたポイントカットは宣言されていません");

				//アドバイスのターゲットが登録されていれば、それに対応するポイントカットを取得する
				Pointcut target;
				Pointcuts.TryGetValue(advice.GetTarget(), out target);

				//指定された言語のアドバイスがあればそれをモデルに変換する
				UnifiedBlock code = null;
				foreach (var languageDependBlock in advice.GetFragments()) {
					//
					if(languageDependBlock.GetLanguageType().Equals(language)) {
						code = CodeProcessor.CreateAdvice(
								language, languageDependBlock.GetContents());
						break;
					}
				}
				//現在の対象ファイルの言語向けアドバイスが定義されていない場合は次のアドバイス処理に移る
				if(code == null)
					continue;

				//ポイントカットの指定に応じて適切なアドバイスの合成処理を行う
				//TODO ワイルドカードなどへの対応
				switch (advice.GetAdviceType()) {
					case "before":
						if(target.GetPointcutType().Equals("execution")) {
							foreach (var function in target.GetTargetName()) {
								CodeProcessor.InsertAtBeforeExecutionByName(model, function, code);
							}
						}
						else { //call
							foreach (var call in target.GetTargetName()) {
								CodeProcessor.InsertAtBeforeCallByName(model, call, code);
							}
						}
						break;

					case "after":
						if(target.GetPointcutType().Equals("execution")) {
							foreach (var function in target.GetTargetName()) {
								CodeProcessor.InsertAtAfterExecutionByName(model, function, code);
							}
						}
						else { //call
							foreach (var call in target.GetTargetName()) {
								CodeProcessor.InsertAtAfterCallByName(model, call, code);
							}
						}
						break;

					default:
						throw new InvalidOperationException(
							"アドバイスの種類が正しくありません");
				}
			}
		}
	}
}
