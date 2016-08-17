using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http.Routing;

namespace TimesheetManagement.Service.Api.Common.Helpers
{
    /// <summary>
    /// A constraint implementation that matches an HTTP header against an expected version value.
    /// Matches both custom request header ("api-version") and custom content type vnd.myservice.vX+json (or other dt type).
    /// 
    /// Adapted from ASP.NET samples.
    /// </summary>
    internal class VersionConstraint : IHttpRouteConstraint
    {
        public const string VersionHeaderName = "api-version";

        private const int DefaultVersion = 1;

        public int AllowedVersion { get; }

        public VersionConstraint(int allowedVersion)
        {
            AllowedVersion = allowedVersion;
        }

        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            //Constraint is applied when route is Resolved (not generated)
            if (routeDirection == HttpRouteDirection.UriResolution)
            {
                int? version = GetVersionFromCustomRequestHeader(request) ?? GetVersionFromCustomContentType(request);

                return (version ?? DefaultVersion) == AllowedVersion;
            }
            return true;
        }

        private int? GetVersionFromCustomContentType(HttpRequestMessage request)
        {
            string versionAsString;
            IEnumerable<string> headerValues;
            if (request.Headers.TryGetValues("api-version", out headerValues) && headerValues.Count() == 1)
            {
                versionAsString = headerValues.First();
            }
            else
            {
                return null;
            }

            int version;
            if (versionAsString != null && int.TryParse(versionAsString, out version))
            {
                return version;
            }
            return null;
        }

        private int? GetVersionFromCustomRequestHeader(HttpRequestMessage request)
        {
            string versionAsString;

            //get the accept header.
            var mediaTypes = request.Headers.Accept.Select(a => a.MediaType);
            string matchingMediaType = null;

            Regex regEx = new Regex(@"application\/vnd\.timesheetmanagement\.v([\d])\+json");

            foreach (var type in mediaTypes)
            {
                if (regEx.IsMatch(type))
                {
                    matchingMediaType = type;
                    break;
                }
            }

            if (matchingMediaType == null)
            {
                return null;
            }

            //extract version number
            Match m = regEx.Match(matchingMediaType);
            versionAsString = m.Groups[1].Value;

            int version;

            if (versionAsString != null && int.TryParse(versionAsString, out version))
            {
                return version;
            }

            return null;
        }
    }
}