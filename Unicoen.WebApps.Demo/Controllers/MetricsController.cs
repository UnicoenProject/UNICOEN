using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unicoen.Applications.Metrics.Cores;
using Unicoen.Applications.Metrics.Utils;
using Unicoen.Languages.Tests;
using Unicoen.WebApps.Demo.ViewModels.Metrics;

namespace Unicoen.WebApps.Demo.Controllers {
	public partial class MetricsController : Controller {
		//
		// GET: /Metrics/

		public virtual ActionResult Index() {
			return View();
		}

		public virtual ActionResult Measure(MeasureViewModel model) {

			var url = model.Url;

			//var url = "https://github.com/plone/plone.app.cmsui";
			//var url = "https://github.com/seam/faces";
			//var url = "https://github.com/mitsuhiko/flask";
			
			if (!url.EndsWith("/"))
				url += "/";
			url += "zipball/master";

			string outputPath = @"C:\output";
			if(Directory.Exists(outputPath))
				Directory.Delete(outputPath, true);
			Directory.CreateDirectory(outputPath);
			FixtureManager.DownloadStream(url, outputPath);
			var zipPath = Directory.EnumerateFiles(outputPath, "*.zip").FirstOrDefault();
			FixtureManager.Unzip(zipPath);

			var targetPaths = Directory.EnumerateFiles(
					outputPath, "*", SearchOption.AllDirectories);
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
					list.Add(new MeasureResult {
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
			case ".py":
				return "Python";
			case ".java":
				return "Java";
			case ".rb":
				return "Ruby";
			case ".cs":
				return "C#";
			case ".js":
				return "JavaScript";
			}
			return null;
		}
	}
}
