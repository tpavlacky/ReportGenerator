using ReportGenerator.Model;
using System.Collections.Generic;
using System.Linq;

namespace ReportGenerator.Extenders
{
  public static class CollectionExtenders
  {
    public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunksize)
    {
      while (source.Any())
      {
        yield return source.Take(chunksize);
        source = source.Skip(chunksize);
      }
    }

		public static IEnumerable<IReportItem> Flatten(this IReportItem reportItem)
		{
			var stack = new Stack<IReportItem>();
			stack.Push(reportItem);
			while (stack.Count > 0)
			{
				var current = stack.Pop();
				yield return current;
				foreach (var child in current.Children)
					stack.Push(child);
			}
		}
	}
}