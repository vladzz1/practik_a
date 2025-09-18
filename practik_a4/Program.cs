namespace practik_a4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //завдання 1

            int[] arr1 = { 2, -4, 6, 3, 17, -7, -5, 14, -22 };
            int[] arr2 = arr1.Where(item => item >= 0).OrderBy(item => item).ToArray();
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write(arr2[i] + " ");
            }
            Console.WriteLine("\n------------------------------");

            //завдання 2

            int[] arr3 = { 2, 4, 6, -34, 17, -7, -14, 7, 16 };
            int[] arr4 = arr3.Where(item => item > 9 && item < 100).ToArray();
            Console.WriteLine(arr4.Average());
            Console.WriteLine("------------------------------");

            //завдання 3

            int[] arr5 = { 1995, 1996, 1997, 1998, 1999, 2000, 2001, 2002, 2003, 2004, 2005, 2006, 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015 };
            int[] arr6 = arr5.Where(item => item % 4 == 0).OrderBy(item => item).ToArray();
            for (int i = 0; i < arr6.Length; i++)
            {
                Console.Write(arr6[i] + " ");
            }
            Console.WriteLine("\n------------------------------");

            //завдання 4

            int[] arr7 = { -4, 4, 5, -34, -24, -7, 55, -17, 17 };
            int[] arr8 = arr7.Where(item => item % 2 == 0).ToArray();
            Console.WriteLine(arr8.Max());
            Console.WriteLine("------------------------------");

            //завдання 5

            string[] arr9 = { "str", "long", "int", "float", "dog" };
            for (int i = 0; i < arr9.Length; i++)
            {
                arr9[i] += "!!!";
            }
            for (int i = 0; i < arr9.Length; i++)
            {
                Console.Write(arr9[i] + " ");
            }
            Console.WriteLine("\n------------------------------");

            //завдання 6

            string[] arr10 = { "str", "long", "past", "future", "array", "oil" };
            string[] arr11 = arr10.Where(item => item.Contains('a') == true).ToArray();
            for (int i = 0; i < arr11.Length; i++)
            {
                Console.Write(arr11[i] + " ");
            }
            Console.WriteLine("\n------------------------------");

            //завдання 7

            string[] arr12 = { "str", "long", "cat", "future", "int", "oil" };
            var arr13 = arr12.GroupBy(item => item.Length);
            foreach (var item in arr13)
            {
                Console.WriteLine(item.Key);
                foreach (string item2 in item)
                {
                    Console.WriteLine(item2);
                }
            }
        }
    }
}
