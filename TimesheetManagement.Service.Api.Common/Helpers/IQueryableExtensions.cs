using System;
using System.Linq;
using System.Linq.Dynamic;

namespace TimesheetManagement.Service.Api.Common.Helpers
{
	public static class IQueryableExtensions
	{
		/// <summary>
		///     Extension method for sorting collection with dynamic linq.
		///     For example, this expression collection.ApplySort("Field1,-Field2,Field3") sorts a collection by values Field1
		///     ascending, Field2 descending and Field3 ascending.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="sort"></param>
		/// <returns></returns>
		public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string sort)
		{
			if (source == null)
			{
				throw new ArgumentNullException();
			}

			if (sort == null)
			{
				return source;
			}

			//split the sort string
			string[] listSort = sort.Split(',');

			string completeSortExpression = "";
			foreach (string sortOption in listSort)
			{
				if (sortOption.StartsWith("-"))
				{
					completeSortExpression = completeSortExpression + sortOption.Remove(0, 1) + " descending,";
				}
				else
				{
					completeSortExpression = completeSortExpression + sortOption + ",";
				}
			}

			if (!string.IsNullOrEmpty(completeSortExpression))
			{
				source.OrderBy(completeSortExpression.Remove(completeSortExpression.Count() - 1));
			}

			return source;
		}
	}
}
