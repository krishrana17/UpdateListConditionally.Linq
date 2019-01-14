using System;
using System.Collections.Generic;
using System.Linq;

namespace UpdateListConditionally.Linq
{
    public static class UtilityExtension
    {
        /// <summary>
        /// Return the list with the updated content.
        /// </summary>
        /// <param name="source">on which operation will be performed</param>
        /// <param name="predicate">predicate to check on each list item</param>
        /// <param name="takeAction">which action to perform, if predicate match</param>
        /// <returns></returns>
        public static IEnumerable<string> ConditionalUpdate(this IEnumerable<string> source, Func<string, bool> predicate,
            Func<string, string> takeAction)
        {
            return source.Select(s => (predicate(s) ? takeAction(s) : s));
        }
    }
}
