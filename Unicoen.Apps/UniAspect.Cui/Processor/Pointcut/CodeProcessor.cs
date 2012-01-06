using Unicoen.Model;

namespace Unicoen.Apps.UniAspect.Cui.Processor.Pointcut {
	public abstract class CodeProcessor {
		public abstract string PointcutName { get; }

		public abstract void Before(IUnifiedElement model, string targetName, UnifiedBlock advice);
		public abstract void After(IUnifiedElement model, string targetName, UnifiedBlock advice);
		public abstract void Around(IUnifiedElement model);
	}
}
