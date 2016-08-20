using System.Collections.Generic;
using System.Web.Http.Routing;

namespace TimesheetManagement.Service.Api.Common.Helpers
{
	/// <summary>
	///     Provides an attribute route that is restricted to a specific version of the api.
	/// </summary>
	public class VersionedRoute : RouteFactoryAttribute
	{
		public int AllowedVersion { get; }

		public override IDictionary<string, object> Constraints
		{
			get
			{
				HttpRouteValueDictionary constraints = new HttpRouteValueDictionary();
				constraints.Add("Version", new VersionConstraint(this.AllowedVersion));
				return constraints;
			}
		}

		public VersionedRoute(string template, int allowedVersion)
			: base(template)
		{
			this.AllowedVersion = allowedVersion;
		}
	}
}
