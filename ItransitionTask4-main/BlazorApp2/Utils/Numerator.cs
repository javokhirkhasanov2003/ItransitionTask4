using System.Collections.Generic;
using BlazorApp2.ViewModels;

namespace BlazorApp2.Utils;

public static class Numerator
{
    public static IEnumerable<T> Numerate<T>(this IEnumerable<T> list) where T : IHaveNumber
    {
        int nr = 1;
        foreach (var item in list)
        {
            item.Nr = nr++;
            yield return item;
        }
    }
}