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
			var java = new MeasureResult {
					Name = "Java",
					Values = 
			}
			model.Results.Add();

            return View(model);
        }

    }
}
