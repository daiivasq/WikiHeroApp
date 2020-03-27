using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WikiHero.Helpers
{
    public static class NonGenericEnumerableExtensions
    {
        public static bool Any(this IEnumerable source)
        {
            foreach (var item in source)
            {
                return true;
            }

            return false;
        }

        public static object FirstOrNull(this IEnumerable source)
        {
            if (source != null)
            {
                foreach (var item in source)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
