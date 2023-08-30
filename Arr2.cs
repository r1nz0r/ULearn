//Arr2. Даны два неубывающих массива чисел.
//Сформировать неубывающие массивы, являющиеся объединением,
//пересечением и разностью этих двух массивов (разность в смысле мультимножеств).

using System;

namespace Arrays {
    class Program {
        private static void Main(string[] args) {
            Random random = new Random();
            int maxValue = 9;
            var array1 = GenerateRandomSorted(random, 5, maxValue);
            var array2 = GenerateRandomSorted(random, 8, maxValue);

            Console.Write("Array 1:\t");
            Print(array1);
            Console.Write("Array 2:\t");
            Print(array2);

            Console.WriteLine();
            Console.Write("Concat:\t\t");
            Print(Concat(array1, array2));
            Console.Write("Union:\t\t");
            Print(Union(array1, array2));
            Console.Write("Intersect:\t");
            Print(Intersect(array1, array2));
            Console.Write("Except (arr1 - arr2):\t");
            Print(Except(array1, array2));
            Console.Write("Except (arr2 - arr1):\t");
            Print(Except(array2, array1));

            Console.ReadKey();
        }

        private static int[] GenerateRandomSorted(Random random, int length, int maxValue) {
            maxValue += 1;

            var array = new int[length];
            for (int i = 0; i < array.Length; ++i) {
                array[i] = random.Next(maxValue);
            }

            Array.Sort(array);
            return array;
        }

        private static void Print(int[] array) {
            foreach (var item in array)
                Console.Write(item + " ");

            Console.WriteLine();
        }

        private static int[] Intersect(int[] arr1, int[] arr2) {
            var newArray = new int[0];

            for (int i = 0; i < arr1.Length; ++i) {
                for (int j = 0; j < arr2.Length; ++j) {
                    int indexOfElement = Array.IndexOf(newArray, arr2[j]);

                    if (arr2[j] == arr1[i] && indexOfElement == -1) {
                        newArray = Resize(newArray, newArray.Length + 1);
                        newArray[newArray.Length - 1] = arr1[i];
                    }
                }
            }

            return newArray;
        }

        private static int[] Resize(int[] arr, int newSize) {
            var tempArray = new int[newSize];
            int minLength = arr.Length <= tempArray.Length ? arr.Length : tempArray.Length;

            for (int k = 0; k < minLength; ++k)
                tempArray[k] = arr[k];

            arr = tempArray;
            return arr;
        }

        private static int[] Concat(int[] arr1, int[] arr2) {
            int totalArrayLength = arr1.Length + arr2.Length;
            var newArray = new int[totalArrayLength];

            Copy(arr1, newArray);
            Copy(arr2, newArray, arr1.Length);

            Array.Sort(newArray);
            return newArray;
        }

        private static int[] MakeUnique(int[] arr) {
            int lastUniqueIndex = 0;
            int currentIndex = 0;

            if (arr.Length == 0)
                return new int[0];

            while (++currentIndex < arr.Length) {
                if (arr[lastUniqueIndex] != arr[currentIndex])
                    arr[++lastUniqueIndex] = arr[currentIndex];
            }

            int newSize = ++lastUniqueIndex;
            var uniqueArr = Resize(arr, newSize);

            return uniqueArr;
        }

        private static void Copy(int[] oldArr, int[] newArray, int indexOffset = 0) {
            for (int i = 0; i < oldArr.Length; ++i)
                newArray[i + indexOffset] = oldArr[i];
        }

        private static int[] Union(int[] arr1, int[] arr2) => MakeUnique(Concat(arr1, arr2));

        private static int[] Except(int[] arr1, int[] arr2) {
            var newArr = new int[arr1.Length];
            int indexArr1 = 0;
            int indexArr2 = 0;
            int indexNewArr = 0;

            while (indexArr1 < arr1.Length) {

                while (indexArr2 < arr2.Length && arr2[indexArr2] < arr1[indexArr1])
                    ++indexArr2;

                if (indexArr2 < arr2.Length && arr1[indexArr1] == arr2[indexArr2])
                    ++indexArr2;

                else if (indexArr2 == arr2.Length || arr2[indexArr2] > arr1[indexArr1])
                    newArr[indexNewArr++] = arr1[indexArr1];

                ++indexArr1;
            }

            return Resize(newArr, indexNewArr);
        }
    }
}
