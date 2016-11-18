using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http.Routing;

namespace TimesheetManagement.Service.Api.Common.Helpers
{
	/// <summary>
	///     A constraint implementation that matches an HTTP header against an expected version value.
	///     Matches both custom request header ("api-version") and custom content type vnd.myservice.vX+json (or other dt
	///     type).
	///     Adapted from ASP.NET samples.
	/// </summary>
	internal class VersionConstraint : IHttpRouteConstraint
	{
		public const string VersionHeaderName = "api-version";

		private const int DefaultVersion = 1;

		public int AllowedVersion { get; }

		public VersionConstraint(int allowedVersion)
		{
			this.AllowedVersion = allowedVersion;
		}

		public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
		{
			//Constraint is applied when route is Resolved (not generated)
			if (routeDirection == HttpRouteDirection.UriResolution)
			{
				int? version = this.GetVersionFromCustomRequestHeader(request) ?? this.GetVersionFromCustomContentType(request);

				return (version ?? VersionConstraint.DefaultVersion) == this.AllowedVersion;
			}

			return true;
		}

		private int? GetVersionFromCustomContentType(HttpRequestMessage request)
		{
			string versionAsString = null;
			IEnumerable<string> headerValues;
		    if (request.Headers.TryGetValues("api-version", out headerValues))
			{
		        List<string> values = headerValues.ToList();
			    if (values.Count == 1)
			    {
				    versionAsString = values.First();
			    }
			}
			else
			{
				return null;
			}

			int version;
			if ((versionAsString != null) && int.TryParse(versionAsString, out version))
			{
				return version;
			}

			return null;
		}

		private int? GetVersionFromCustomRequestHeader(HttpRequestMessage request)
		{
		    Regex regex = new Regex(@"application\/vnd\.timesheetmanagement\.v([\d])\+json");

            IEnumerable<string> mediaTypes = request.Headers.Accept.Select(a => a.MediaType);
		    string matchingMediaType = mediaTypes.FirstOrDefault(type => regex.IsMatch(type));
		    if (matchingMediaType == null)
			{
				return null;
			}
            
			Match match = regex.Match(matchingMediaType);
            string versionAsString = match.Groups[1].Value;

			int version;
			if (int.TryParse(versionAsString, out version))
			{
				return version;
			}

			return null;
		}
	}
}
