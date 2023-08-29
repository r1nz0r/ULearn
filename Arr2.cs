//Arr2. Даны два неубывающих массива чисел.
//Сформировать неубывающие массивы, являющиеся объединением,
//пересечением и разностью этих двух массивов (разность в смысле мультимножеств).

using System;

namespace Arrays {
    class Program {
        private static void Main(string[] args) {
            Random random = new Random();
            int maxValue = 9;
            var array1 = GenerateRandomSortedArray(random, 5, maxValue);
            var array2 = GenerateRandomSortedArray(random, 8, maxValue);

            Console.Write("Array 1:\t");
            PrintArray(array1);
            Console.Write("Array 2:\t");
            PrintArray(array2);

            Console.WriteLine();
            Console.Write("Union:\t\t");
            PrintArray(UnionArrays(array1, array2));
            Console.Write("Intersect:\t");
            PrintArray(IntersectArrays(array1, array2));
        }

        private static int[] GenerateRandomSortedArray(Random random, int length, int maxValue) {
            maxValue += 1;

            var array = new int[length];
            for (int i = 0; i < array.Length; ++i) {
                array[i] = random.Next(maxValue);
            }

            Array.Sort(array);
            return array;
        }

        private static void PrintArray(int[] array) {
            foreach (var item in array)
                Console.Write(item + " ");

            Console.WriteLine();
        }

        private static int[] IntersectArrays(int[] arr1, int[] arr2) {
            var newArray = new int[0];
            for (int i = 0; i < arr1.Length; ++i) {
                for (int j = 0; j < arr2.Length; ++j) {
                    int indexOfElement = Array.IndexOf(newArray, arr2[j]);

                    if (arr2[j] == arr1[i] && indexOfElement == -1) {
                        var tempArray = new int[newArray.Length + 1];

                        for (int k = 0; k < newArray.Length; ++k)
                            tempArray[k] = newArray[k];

                        newArray = tempArray;
                        newArray[newArray.Length - 1] = arr1[i];
                    }
                }
            }

            return newArray;
        }

        private static int[] UnionArrays(int[] arr1, int[] arr2) {
            int totalArrayLength = arr1.Length + arr2.Length;
            var newArray = new int[totalArrayLength];

            CopyArray(arr1, newArray);
            CopyArray(arr2, newArray, arr1.Length);

            Array.Sort(newArray);
            return newArray;
        }

        private static void CopyArray(int[] oldArr, int[] newArray, int indexOffset = 0) {
            for (int i = 0; i < oldArr.Length; ++i)
                newArray[i + indexOffset] = oldArr[i];
        }
    }
}
