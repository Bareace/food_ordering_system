using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_3_Hash
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string[] mahalle = { "Erzene", "Kazımdirik", "Yeşilova", "Atatürk", "İnönü", "Mevlana", "Doğanlar", "Evka 3", "Rafet Paşa", "Kızılay" };
            int[] nüfusList = { 35135, 33934, 31008, 28912, 25778, 25492, 21461, 20445, 19476, 15795 };
            Hashtable nüfus = new Hashtable();

            for(int i = 0; i<mahalle.Length; i++)
            {
                nüfus[mahalle[i]] = mahalle[i] + " " + nüfusList[i];
                Console.WriteLine(nüfus[mahalle[i]]);
            }
            //Baş harfi verilen mahallelerin toplam nüfusuna 1 ekleyerek Hash Tablosunda güncelleyen kod
            void nüfusArtırma(string başHarf)
            {
                for (int i= 0; i<mahalle.Length; i++)
                {
                    if(mahalle[i].Substring(0,1) == başHarf)
                    {
                        nüfusList[i] += 1;
                        nüfus[mahalle[i]] = mahalle[i] + " " + nüfusList[i];
                    }
                    Console.WriteLine(nüfus[mahalle[i]]);
                }
            }


            nüfusArtırma("A");

            Console.ReadKey();
        }
    }
}
