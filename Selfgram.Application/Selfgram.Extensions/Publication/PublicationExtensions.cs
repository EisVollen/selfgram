using System.Linq;

namespace Selfgram.Extensions.Publication
{
    public static class PublicationExtensions
    {
        public static IOrderedQueryable<Objects.Objects.Core.Publication> OrderedQueryable(this IQueryable<Objects.Objects.Core.Publication> publications)
        {
            return publications.OrderBy(p => p.PublicDate);
        }
    }
}
