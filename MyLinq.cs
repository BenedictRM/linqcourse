using System.Collections.Generic;

namespace linq.features {
    public static class MyLinq {
        public static int Count<T>(this IEnumerable<T> sequence) {
            int count = 0;

            foreach(var member in sequence)
                count++;

            return count;
        }
    }
}