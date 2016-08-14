using System.Web.Http;
using System.Web.Mvc;
using TimesheetManagement.Service.Areas.HelpPage.ModelDescriptions;
using TimesheetManagement.Service.Areas.HelpPage.Models;

namespace TimesheetManagement.Service.Areas.HelpPage.Controllers
{
	/// <summary>
	///     The controller that will handle requests for the help page.
	/// </summary>
	public class HelpController : Controller
	{
		private const string ErrorViewName = "Error";

		public HttpConfiguration Configuration { get; }

		public HelpController()
			: this(GlobalConfiguration.Configuration)
		{
		}

		public HelpController(HttpConfiguration config)
		{
			this.Configuration = config;
		}

		public ActionResult Index()
		{
			this.ViewBag.DocumentationProvider = this.Configuration.Services.GetDocumentationProvider();
			return this.View(this.Configuration.Services.GetApiExplorer().ApiDescriptions);
		}

		public ActionResult Api(string apiId)
		{
			if (!string.IsNullOrEmpty(apiId))
			{
				HelpPageApiModel apiModel = this.Configuration.GetHelpPageApiModel(apiId);
				if (apiModel != null)
				{
					return this.View(apiModel);
				}
			}

			return this.View(HelpController.ErrorViewName);
		}

		public ActionResult ResourceModel(string modelName)
		{
			if (!string.IsNullOrEmpty(modelName))
			{
				ModelDescriptionGenerator modelDescriptionGenerator = this.Configuration.GetModelDescriptionGenerator();
				ModelDescription modelDescription;
				if (modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out modelDescription))
				{
					return this.View(modelDescription);
				}
			}

			return this.View(HelpController.ErrorViewName);
		}
	}
}
