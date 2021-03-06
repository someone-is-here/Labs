﻿using System;
using System.Text;
using System.Globalization;

namespace Lab2 {
    class Program {
        static string ShakeSymbols(string str) {
            Random rand = new Random();
            StringBuilder strB = new StringBuilder(str.Length);
            int index = 0;
            try {
                for (int i = 0; i < strB.Capacity; i++) {
                    index = rand.Next(str.Length);
                    strB.Append(str[index]);
                    str = str.Remove(str.IndexOf(str[index]), 1);
                }
            } catch {
                Console.WriteLine("Wrong input!!!");
            }
            return strB.ToString();
        }
        static string ReverseString(string str) {
            Random rand = new Random();
            StringBuilder strB = new StringBuilder();
            int spaceNum = 0;
            string strC = str;
            try {
                while (strC.IndexOf(' ') != -1) {
                    strC = strC[(strC.IndexOf(' ') + 1)..];
                    spaceNum++;
                }

                string[] strArr = new string[spaceNum + 1];
                int i = 0;

                while (str.IndexOf(' ') != -1) {
                    strArr[i] = str.Substring(0, str.IndexOf(' '));
                    str = str[(str.IndexOf(' ') + 1)..];
                    i++;
                }
                strArr[i] = str;
                for (int j = strArr.Length - 1; j >= 0; j--) {
                    strB.Append(strArr[j] + ' ');
                }
            } catch {
                Console.WriteLine("Wrong input!!!");
            }


            return strB.ToString();
        }
        static void ShowMonth(string language = "en") {
            string myMonth = "";
            DateTime dateTime = new DateTime();
            int monthNum = 12;
            try {
                while (monthNum > 0) {
                    myMonth = dateTime.ToString("MMMM", CultureInfo.GetCultureInfo(language));
                    Console.WriteLine(myMonth);
                    dateTime = dateTime.AddMonths(1);
                    monthNum--;
                }
                
            } catch {
                Console.WriteLine("Wrong input!!!");
            }
        }
        static void TriangleInfo(int a = 3, int b = 4, int c = 5) {
            if ((a < b + c) && (b < a + c) && (c < a + b)) {
                int p = (a + b + c) / 2;
                Console.WriteLine($"Sides of triangle: {a}, {b}, {c}.");
                Console.WriteLine($"Perimeter: {a + b + c}");
                Console.WriteLine($"Square: {Math.Sqrt(p * (p - a) * (p - b) * (p - c))}");
                Console.WriteLine($"Radius of the circumscribed circle: {(a * b * c) / (4 * (Math.Sqrt(p * (p - a) * (p - b) * (p - c))))}");
                Console.WriteLine($"Inscribed circle radius: {(Math.Sqrt(p * (p - a) * (p - b) * (p - c))) / p}");
                Console.WriteLine($"Cos(a): {(Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2)) / (2 * a * c)}");
                Console.WriteLine($"Cos(b): {(Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) / (2 * a * b)}");
                Console.WriteLine($"Cos(c): {(Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * c * b)}");
                Console.WriteLine($"Sin(a): {Math.Round(Math.Sqrt(1 - Math.Pow(((Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2)) / (2 * a * c)), 2)), 3)}");
                Console.WriteLine($"Sin(b): {Math.Round(Math.Sqrt(1 - Math.Pow(((Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) / (2 * a * b)), 2)), 3)}");
                Console.WriteLine($"Sin(c): {Math.Round(Math.Sqrt(1 - Math.Pow(((Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * c * b)), 2)), 3)}");
                Console.WriteLine($"Angle a: {Math.Acos((Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2)) / (2 * a * c))}");
                Console.WriteLine($"Angle b: {Math.Acos((Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) / (2 * a * b))}");
                Console.WriteLine($"Angle c: {Math.Acos((Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * c * b))}");
            } else {
                Console.WriteLine("Wrong input!!!");
            }
        }
        static string ChangeSymb(string str) {
            string symbForSearching = "eyuioa";
            StringBuilder strB = new StringBuilder(str.Length);
            int temp;
            try {
                strB.Append(str[0]);
                for (int i = 1; i < str.Length; i++) {
                    if (symbForSearching.Contains(str[i - 1])) {
                        if (str[i] != 'z') {
                            temp = (int)str[i];
                            strB.Append((char)++temp);
                        } else {
                            strB.Append('a');
                        }
                    } else {
                        strB.Append(str[i]);
                    }
                }
            } catch {
                Console.WriteLine("Error! Wrong string!");
            }
            return strB.ToString();
        }
        static void Main(string[] args) {
            string language = Console.ReadLine();

            Console.WriteLine("Month: ");
            ShowMonth(language);

            string strForSymbolChange = Console.ReadLine();

            Console.WriteLine($"String: {strForSymbolChange}");
            Console.WriteLine($"NewString: {ShakeSymbols(strForSymbolChange)}");

            string strForReverseWords = Console.ReadLine();

            Console.WriteLine($"String: {strForReverseWords}");
            Console.WriteLine($"NewString: {ReverseString(strForReverseWords)}");

            try {
                int triangleA = Convert.ToInt32(Console.ReadLine());
                int triangleB = Convert.ToInt32(Console.ReadLine());
                int triangleC = Convert.ToInt32(Console.ReadLine());
                TriangleInfo(triangleA, triangleB, triangleC);

            } catch {
                Console.WriteLine("wrong input!!!");               
            }

            TriangleInfo();

            string strChangeSymbols = Console.ReadLine();

            Console.WriteLine($"String: {strChangeSymbols}");
            Console.WriteLine($"NewString: {ChangeSymb(strChangeSymbols)}");


        }
    }
}
