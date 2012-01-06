using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Unicoen.Apps.UniAspect.Cui.CodeProcessor;
using Unicoen.Model;

namespace Unicoen.Apps.UniAspect.Cui.Processor.Pointcut {
	[Export(typeof(CodeProcessor))]
	public class Exception : CodeProcessor{
		public override string PointcutName {
			get { return "exception"; }
		}

		public override void Before(IUnifiedElement model, string targetName, UnifiedBlock advice) {
			var exceptions = model.Descendants<UnifiedCatch>();
			foreach (var e in exceptions) {
				var regex = new Regex("^" + targetName + "$");
				var type = e.Types[0].BasicTypeName as UnifiedIdentifier;
				if(type == null)
					continue;
				var m = regex.Match(type.Name);
				if (m.Success) {
					//アドバイスを対象関数に合成する
					e.Body.Insert(0, advice.DeepCopy());
				}
			}
		}

		public override void After(IUnifiedElement model, string targetName, UnifiedBlock advice) {
			throw new NotImplementedException();
		}

		public override void Around(IUnifiedElement model) {
			throw new NotImplementedException();
		}
	}
}
