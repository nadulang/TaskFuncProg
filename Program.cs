using System.Linq;
using System.Net.WebSockets;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace TaskFuncProg
{
    class Program
    {
        static void Main(string[] args)
        {
            // var hello = "hello world again".Capitalize();
            // Console.WriteLine(hello);

            // var hello1 = "hello world again".SnakeCase();
            // Console.WriteLine(hello1);
            // var hello2 = "hello world again".KebabCase();
            // Console.WriteLine(hello2);

            // var numbers = new []{1,2,3,4,5,6,6,8,8,6,9};
            // var grades = new[]{87.5, 88.5, 60.5, 90.5, 88.5};

            // var mostNumbers = numbers.Mode();

            // var mostGrades = grades.Mode();

            // var tulisanPanjang = "ini adalah tulisan yang sangat panjang".Trim(8);
            // Console.WriteLine(tulisanPanjang);

            // var tulisanPanjang1 = "ini adalah tulisan yang sangat panjang".TrimWords(3);
            // Console.WriteLine(tulisanPanjang1);

            var satu = 1.Convert();
            Console.WriteLine(satu);
            var belasan = 15.Convert();
            Console.WriteLine(belasan);
            var puluhan = 10.Convert();
            Console.WriteLine(puluhan);
            var t = 99.Convert();
            Console.WriteLine(t);
        }
    }

    public static class IEnumerableExtension
    {
        //nomor 1
        public static string Capitalize(this string values) 
        {
                var input = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(values);
                return input;
        }

        //nomor 2
        public static string SnakeCase(this string values) => values.Replace(" ", "_");

        //nomor 3
        public static string KebabCase(this string values) => values.Replace(" ", "-");

        //nomor 6
        public static string Trim(this string values, int i) => values.Substring(0, i) + "....";

        //nomor 7
        public static string TrimWords(this string values, int i) => (string.Join(" ", values.Split(' ').ToList().GetRange(0, i)));
    
        //nomor 4
         public static T Mode<T>(this IEnumerable<T> data)
        {
            return data.GroupBy(n => n).Select(e => new {num = e.Key, count = e.Count()}).
                        OrderByDescending(e => e.count).First().num;

        }

        //nomor 5
        public static string Convert(this int number)
        {
            string u = "";
            List<string> satuan = new List<string> {"nol", "satu", "dua", "tiga", "empat", "lima", "enam", "tujuh", "delapan", "sembilan"};
            List<string> belasan = new List<string> {"nol", "se", "dua", "tiga", "empat", "lima", "enam", "tujuh", "delapan", "sembilan"};

            if (number > 20 && number < 100)
            {
                u += satuan[number/10] + " " + "puluh" + " " + satuan[number%10];
            }

            else if (number%10 == 0)
            {
                u += belasan[number/10] + "puluh";
            }
            
            else if (number > 10 && number < 20)
            {
                u += belasan[number%10] + " " + "belas";
            }

            else if (number > 0 && number < 10)
            {
                u += satuan[number];
            }
            
            return u;
        }
    }
}


