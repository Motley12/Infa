using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.Net.Sockets;
using System.Threading.Tasks.Sources;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.CancelKeyPress += new ConsoleCancelEventHandler(alo);
        bool random;
        random = ask();
        int[,] matric = new int[4, 4];
        if (random)
        {
            matric = Generate();
        }
        else
        {
            matric = userinput();
        }
        for(int i = 0; i < 4; i++)
        {
            for (int j=0;j<4;j++)
            {
                Console.Write(matric[i, j]+"\t");
            }
            Console.WriteLine();
        }
        int[]kak = prost(matric);
        kak = sort(kak);
        Console.WriteLine("отсортированые");
        foreach (int pochemy in kak)
            if (pochemy!=0)
            {
                Console.WriteLine(pochemy);
            }
    }

    private static int[] sort(int[] kak)
    {
        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                if (kak[j]< kak[j+1])
                {
                    int f = kak[j];
                    kak[j] = kak[j+1];
                    kak[j+1] = f;
                }
            }
        }
        return kak;
    }

    private static int[] prost(int[,] matric)
    {
        int[] mat = new int[16];
        int p = 0;
        for (int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                bool simple = true;
                for( int k = 2; k < matric[i,j]; k++)
                {
                    if(matric[i,j] % k ==0)
                    {
                        simple = false;
                        break;
                    }
                }
                if (simple)
                {
                    mat[p]=matric[i,j];
                    p++;
                }
            }
        }
        return mat;
    }

    private static int[,] userinput()
    {
        int[,] mr = new int[4, 4];
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine($"Введите 4 значения {i+1} строки через пробел");
            string text=Console.ReadLine();
            if (text == null)//чтобы была запись
            {
                i--;
                continue;
            }
            string[] row = text.Split(" ");// разделят числа которые через пробел
            if(row.Length != 4)
            {
                i--;
                continue;
            }
            for (int j = 0; j < 4; j++)
            {
                int k;
                if (!int.TryParse(row[j], out k))//конвертирует число если не получится заново
                {
                    i--;
                    break;
                }
                mr[i,j] = k;
            }
        }
        return mr;
    }

    static void alo(object? sender, ConsoleCancelEventArgs e)
    {
        e.Cancel = true;
    }
    static int[,] Generate()
    {
        int[,] mr = new int[4, 4];
        Random gerran = new Random();//генератор случайных чисел
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                mr[i, j] = gerran.Next(0, 101);
            }
        }
        return mr;
    }

    static bool ask()
    {
        string input = "";
        while (input != "2" && input != "1")
        {
            Console.WriteLine("1-работа ручками или 2-так уж и быть машина все сделает");
            input = Console.ReadLine();
        }
        if (input == "1") return false;
        return true;
    }
}