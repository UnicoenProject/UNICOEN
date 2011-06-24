using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unicoen.WebApps.Demo.ViewModels.Metrics;

namespace Unicoen.WebApps.Demo.Controllers
{
	public partial class MetricsController : Controller
    {
        //
        // GET: /Metrics/

		public virtual ActionResult Index()
        {
            return View();
        }

		public virtual ActionResult Measure(MeasureViewModel model) {
			// 測定して
			model.Results = new List<MeasureResult>();
			model.Results.Add(new MeasureResult {
				Name = "Java",
				Values = new Dictionary<string, int>()
			});
			model.Results[0].Values["abc"] = 10;
			model.Results[0].Values["abc\\def"] = 20;
			model.Results.Add(new MeasureResult {
				Name = "JavaScript",
				Values = new Dictionary<string, int>()
			});
			model.Results[1].Values["abc\\def"] = 9;
			model.Results.Add(new MeasureResult {
				Name = "Python",
				Values = new Dictionary<string, int>()
			});
			model.Results[2].Values["abc"] = 8;
			model.Results[2].Values["abc\\def"] = 7;

            return View(model);
        }

    }
}
