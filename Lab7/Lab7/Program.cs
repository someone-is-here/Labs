using System;
using System.Collections.Generic;

namespace Lab7 {
    class Program {
        static void Main(string[] args) {
            RationalNum num1 = new RationalNum(11, -2);
            RationalNum num2 = new RationalNum(11, -2);
            Console.WriteLine(num1 + num2);
            Console.WriteLine((double)(num1 - num2));
            Console.WriteLine(num1 * num2);
            Console.WriteLine(num1 / num2);
            Console.WriteLine(num1);
            Console.WriteLine(num1 > num2);
            Console.WriteLine(num1 < num2);
            Console.WriteLine(num1 >= num2);
            Console.WriteLine(num1 <= num2);
            Console.WriteLine(num1 != num2);
            Console.WriteLine(num1 == num2);
            Console.WriteLine(num1.Equals(-5.5));
            Console.WriteLine(num1.Equals(num2));
            Console.WriteLine(num1.GetHashCode());
            Console.WriteLine(num2.GetHashCode());
            Console.WriteLine(num1.ToString("D"));
            Console.WriteLine(num1.ToString("F"));
            Console.WriteLine(num2.ToString("E"));
            Console.WriteLine(num2.ToString("G"));
            Console.WriteLine();
            Console.WriteLine("{0:D}", num1);
            Console.WriteLine("{0:F}", num1);
            Console.WriteLine("{0:E}", num2);
            Console.WriteLine("{0:G}", num2);
            Console.WriteLine();
            Console.WriteLine(num1.ToString() + " [ ]");
            Console.WriteLine(Convert.ToInt32(num1));
            Console.WriteLine(Convert.ToDecimal(num1));
            Console.WriteLine(Convert.ToString(num1));
            Console.WriteLine("Bool " + Convert.ToBoolean(num1));
            List<RationalNum> listWithNumbers = new List<RationalNum>() {
                new RationalNum(1,4),
                new RationalNum(2),
                new RationalNum(3, 4)
            };
            listWithNumbers.Add(RationalNum.Parse("4/-7"));
            listWithNumbers.Add(RationalNum.Parse("-2"));
            listWithNumbers.Add(RationalNum.Parse("-0.75"));
            listWithNumbers.Add(RationalNum.Parse("-0,89"));
            listWithNumbers.Add(RationalNum.Parse("1,1"));
            listWithNumbers.Add(RationalNum.Parse("-1/3"));
            foreach (RationalNum num in listWithNumbers) {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            listWithNumbers.Sort();
            foreach (RationalNum num in listWithNumbers) {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            RationalNum number;
            Console.WriteLine(RationalNum.TryParse("Some text", out number));
            Console.WriteLine(RationalNum.TryParse("2/5", out number));
            Console.WriteLine(RationalNum.TryParse("()v/4)", out number));

        }
    }
}
