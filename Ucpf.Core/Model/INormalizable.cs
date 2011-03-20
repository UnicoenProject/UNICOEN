using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Core.Model {
	public interface INormalizable {
		/// <summary>
		/// ビジターと組み合わせてコードモデルを正規化します。
		/// 正規化の内容は以下のとおりです。
		/// ・子要素がUnifiedBlockだけのUnifiedBlockを削除
		/// ・-1や+1などの単項式を定数に変換
		/// </summary>
		UnifiedElement Normalize();
	}
}
