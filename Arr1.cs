//Arr1. Дан массив чисел. Нужно его сдвинуть циклически на K позиций влево, не используя других массивов.

using System;

namespace Arrays {
    class Program {
        static void Main(string[] args) {
            const int arrayLength = 10;
            int maxValue = 20;
            var array = GenerateRandomArray(arrayLength, maxValue);
            PrintArray(array);
            ShiftArray(array, 2);
            PrintArray(array);
        }

        static int[] GenerateRandomArray(int length, int maxValue) {
            Random random = new Random();
            maxValue += 1;

            var array = new int[length];
            for (int i = 0; i < array.Length; ++i) {
                array[i] = random.Next(maxValue);
            }

            return array;
        }

        static void PrintArray(int[] array) {
            foreach (var item in array)
                Console.Write(item + " ");

            Console.WriteLine();
        }

        static void ShiftArray(int[] array, int shift) {
            for (int i = 0; i < shift; ++i) {
                for (int j = 0; j < array.Length - 1; ++j) {
                    var temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }
}
