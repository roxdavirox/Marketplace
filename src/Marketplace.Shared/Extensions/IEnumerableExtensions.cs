using System;
using System.Collections.Generic;

namespace Marketplace.Shared.Extensions
{
    public static class IEnumerableExtensions {
        public static void ForEach<T>(this IEnumerable<T> elements, Action<T> callbackAction)
        {
            foreach (var element in elements)
                callbackAction?.Invoke(element);
        }
    }
}