using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_3_Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1500, 11, 100, 619, 311, 666, 269, 9 };

            int temp = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }

            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");

            Console.ReadKey();
        }
    }
}
