using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet2020.Google
{
    public static class HousesAndHeaters
    {
        public static int FindRadius(int[] houses, int[] heaters)
        {
            Array.Sort(heaters);
            var result = int.MinValue;
            foreach (var house in houses)
            {
                var index = Array.BinarySearch(heaters, house);
                // we don't care about else (index >= 0) since it means a house is sitting on a heater
                if (index >= 0) continue;
                // per Microsoft document:
                // The index of the specified value in the specified array, if value is found; otherwise, a negative number.
                // If value is not found and value is less than one or more elements in array,
                // the negative number returned is the bitwise complement of the index of the first element that is larger than value.
                // If value is not found and value is greater than all elements in array,
                // the negative number returned is the bitwise complement of (the index of the last element plus 1).
                index = ~index;
                // find distance to left heater
                var left = index - 1 >= 0 ? house - heaters[index - 1] : int.MaxValue;
                var right = index < heaters.Length ? heaters[index] - house : int.MaxValue;
                // remember a house only needs to be covered by either left or right
                result = Math.Max(result, Math.Min(left, right));
            }
            return result;
        }
    }
}
