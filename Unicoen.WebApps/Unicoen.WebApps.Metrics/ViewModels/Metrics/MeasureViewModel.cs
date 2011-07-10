using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unicoen.WebApps.Metrics.ViewModels.Metrics {
	public class MeasureResult {
		public string Name { get; set; }
		public Dictionary<string, int> Values { get; set; }
	}

	public class MeasureViewModel {
		public string Url { get; set; }
		public List<MeasureResult> Results { get; set; }
	}
}