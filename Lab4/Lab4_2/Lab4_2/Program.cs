using System;
using System.Runtime.InteropServices;
namespace Lab4_2 {
    class Program {
        [DllImport("Dll_1.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int Factorial(int num);
        [DllImport("Dll_1.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int Power(int num, int power);
        [DllImport("Dll_1.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int SumValuesInArray(int[] arr, int size);
        [DllImport("Dll_1.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int MaxInArray(int[] arr, int size);
        [DllImport("Dll_1.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int MinInArray(int[] arr, int size);
        [DllImport("Dll_1.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern bool IsValueInArray(int[] arr, int size, int value);
        [DllImport("Dll_1.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern int FindIndexOfValueInArray(int[] arr, int size, int value);
        static void Main() {
            Console.WriteLine(Factorial(7));
            Console.WriteLine(Power(2,11));
            int size = 10;
            int[] array=new int[size];
            for (int i = 0; i < size; i++) {
                array[i] = size - i;
            }
            Console.WriteLine(SumValuesInArray(array,size));
            Console.WriteLine(MinInArray(array, size));
            Console.WriteLine(IsValueInArray(array, size,7));
            Console.WriteLine(FindIndexOfValueInArray(array, size,7));
        }
    }
}
