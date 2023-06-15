using System.Collections.Generic;
using System.Linq;

public static class ListExtensions{
    public static bool AreListsEqual(this List<int> list1, List<int> list2){
        if (list1.Count != list2.Count) {
            return false;
        }
        bool allElementsExist = list1.All(list2.Contains);
        return allElementsExist;
    }
}