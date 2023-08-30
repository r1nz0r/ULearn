//Arr3.Перевести число из системы счисления с основанием A в систему с основанием B.
//Можно считать, что 2 ≤ A, B ≤ 10, а число дано в виде массива цифр.

using System;

namespace Arrays {
    class Program {
        private static void Main(string[] args) {
            int inputNumber = 10;
            var numArray = GenerateArrayFromNumber(inputNumber);

            PrintArray(numArray);
            Console.ReadKey();
        }

        private static int[] GenerateArrayFromNumber(int number) {
            int numArrayLength = 0;
            var numArray = new int[0];

            if (number == 0) 
                return new int[1] { 0 };

            while (number != 0) {
                int digit = number % 10;
                number /= 10;
                Array.Resize(ref numArray, ++numArrayLength);
                numArray[numArrayLength - 1] = digit;
            }

            Array.Reverse(numArray);
            return numArray;
        }

        private static void PrintArray(int[] arr) {
            foreach (var item in arr)
                Console.Write(item + " ");

            Console.WriteLine();
        }
    }
}
