using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace TimesheetManagement.Client.Mvc.Common.Helpers
{
	public static class HeaderParser
	{
		private const string XPaginationHeader = "X-Pagination";

		public static PagingInfo FindAndParsePagingInfo(HttpResponseHeaders responseHeaders)
		{
			if (!responseHeaders.Contains(HeaderParser.XPaginationHeader))
			{
				return null;
			}

			IEnumerable<string> xPag = responseHeaders.First(ph => ph.Key == HeaderParser.XPaginationHeader).Value;
			return JsonConvert.DeserializeObject<PagingInfo>(xPag.First());
		}
	}
}
