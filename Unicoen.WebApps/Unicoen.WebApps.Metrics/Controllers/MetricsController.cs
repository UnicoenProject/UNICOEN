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

using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using Unicoen.Apps.Metrics.Core;
using Unicoen.Apps.Metrics.Utils;
using Unicoen.Utils;
using Unicoen.WebApps.Metrics.ViewModels.Metrics;

namespace Unicoen.WebApps.Metrics.Controllers {
	public partial class MetricsController : Controller {
		//
		// GET: /Metrics/

		public virtual ActionResult Index() {
			return View();
		}

		private static int id = 0;

		public virtual ActionResult Measure(MeasureViewModel model) {
			var url = model.Url;

			//var url = "https://github.com/plone/plone.app.cmsui";
			//var url = "https://github.com/seam/faces";
			//var url = "https://github.com/mitsuhiko/flask";

			if (!url.EndsWith("/"))
			    url += "/";
			url += "zipball/master";

			string outPath = @"C:\output\" + (id++) + @"\source.zip";
			var outDirPath = Path.GetDirectoryName(outPath);
			//if (Directory.Exists(outDirPath)) {
			//    var dirPaths = Directory.EnumerateDirectories(
			//            outDirPath, "*", SearchOption.TopDirectoryOnly);
			//    foreach (var dirPath in dirPaths) {
			//        Directory.Delete(dirPath, true);
			//    }
			//    var filePaths = Directory.EnumerateFiles(
			//            outDirPath, "*", SearchOption.TopDirectoryOnly);
			//    foreach (var filePath in filePaths) {
			//        System.IO.File.Delete(filePath);
			//    }
			//}
			//Directory.CreateDirectory(outDirPath);
			//Downloader.Download(url, outPath);
			//Extractor.Unzip(outPath);

			var targetPaths = Directory.EnumerateFiles(
					outDirPath, "*", SearchOption.AllDirectories);
			model.Results = CreateMeasureResult(targetPaths);
			return View(model);
		}

		private List<MeasureResult> CreateMeasureResult(IEnumerable<string> paths) {
			var list = new List<MeasureResult>();
			foreach (var path in paths) {
				var result = CodeAnalyzer.Measure(path, Cyclomatic.GetTargetElements);
				if (result.Count == 0)
					continue;
				var langName = GetNameFromExtension(path);
				if (langName == null)
					continue;
				var langIx = list.FindIndex(m => m.Name == langName);
				if (langIx == -1) {
					list.Add(
							new MeasureResult {
									Name = langName,
									Values = new Dictionary<string, int>()
							});
					langIx = list.Count - 1;
				}
				foreach (var pair in result) {
					list[langIx].Values[pair.Key] = pair.Value;
				}
			}
			return list;
		}

		private string GetNameFromExtension(string path) {
			var ix = path.LastIndexOf(".");
			var ext = path.Substring(ix, path.Length - ix);
			switch (ext) {
			case ".c":
				return "C";
			case ".py":
				return "Python";
			case ".java":
				return "Java";
			case ".rb":
				return "Ruby";
			case ".cs":
				return "C#";
			case ".vb":
				return "VB";
			case ".js":
				return "JavaScript";
			}
			return null;
		}
	}
}