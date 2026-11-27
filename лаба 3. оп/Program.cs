using System;
using System.Collections;
using System.Diagnostics;
class Program
{
    static void Main()
    { 
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("____Главное меню____");
            Console.WriteLine("1. Отгадай ответ");
            Console.WriteLine("2. Об авторе");
            Console.WriteLine("3. Сортировка массива");
            Console.WriteLine("4. Выход");
            Console.Write("Введите номер пункта: ");
            int p = ReadInt();
            switch (p)
            {
                case 1:
                    Game();
                    break;
                case 2:
                    Author();
                    break;
                case 3:
                    Sorted();
                    break;
                case 4:
                    exit = ExitProg();
                    break;
                default:
                    Console.WriteLine("Неверно:( Попробуйте снова.");
                    break;
            }
        }
        Console.WriteLine("Программа завершена! Нажмите Enter...");
        Console.ReadLine();
    }
    static int ReadInt()
    {
        int res;
        while (!int.TryParse(Console.ReadLine(), out res))
        {
            Console.WriteLine("Ошибка!:( Введите целое число: ");
        }
        return res;
    }
    static void Game()
    {
        Console.WriteLine("____Отгадай ответ____");
        Console.WriteLine("Функция: (cos^7(PI)+√(ln(b^4)))/(sin(PI/2+a)^2)");
        Console.WriteLine("ОДЗ: |b|>=1, cos(a)!=0");
        double b = ReadB();
        double a = ReadA();
        double res = Func(a, b);
        Game1(res);
    }
    static double ReadB()
    {
        double b;
        Console.Write("Введите b (|b| >= 1): ");
        while (!double.TryParse(Console.ReadLine(), out b) || Math.Abs(b) < 1)
        {
            Console.Write("Ошибка! Введите b, по модулю >= 1: ");
        }
        return b;
    }
    static double ReadA()
    {
        double a;
        Console.Write("Введите a (cos(a) != 0): ");
        while (!double.TryParse(Console.ReadLine(), out a) || Math.Abs(Math.Cos(a)) < 1e-10)
        {
            Console.Write("Ошибка! Введите a, при котором cos(a) != 0: ");
        }
        return a;
    }
    static double Func(double a, double b)
    {
        const double pi = Math.PI;
        return Math.Round((Math.Pow(Math.Cos(pi), 7) + Math.Sqrt(Math.Log(Math.Pow(b, 4)))) / Math.Pow(Math.Sin(pi / 2 + a), 2), 2);
    }
    static void Game1(double res)
    {
        int count = 3;
        bool guess = false;
        while (count > 0 && !guess)
        {
            Console.Write("Введите ваш ответ (осталось попыток: " + count + "): ");
            double us;
            while (!double.TryParse(Console.ReadLine(), out us))
            {
                Console.Write("Ошибка! Введите число: ");
            }
            us = Math.Round(us, 2);
            if (us == res)
            {
                Console.WriteLine("Верно! Вы правильно ответили!;)");
                guess = true;
            }
            else
            {
                count = count - 1;
                if (count > 0)
                {
                    Console.WriteLine("Неверно!:( Осталось попыток: " + count);
                }
            }
        }
        if (!guess)
        {
            Console.WriteLine("Вы проиграли:( Правильный ответ: " + res);
        }
    }
    static void Author()
    {
        Console.WriteLine("____Об авторе____");
        Console.WriteLine("Кузьмина Валерия Дмитриевна");
        Console.WriteLine("6105-090301D");
    }
    static bool ExitProg()
    {
        bool podt = false;
        while (!podt)
        {
            Console.WriteLine("Вы уверены, что хотите выйти? (д/н): ");
            string otv = Console.ReadLine();
            if (otv == "д")
            {
                return true;
            }
            else if (otv == "н")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Ошибка!:( Введите д или н: ");
            }
        }
        return false;
    }
    static int ReadDlin()
    {
        while(true)
        {
            Console.WriteLine("Введите длину массива(0<n<10): ");
            int n=ReadInt();
            if (n>0)
            {
                return n;
            }
            else
            {
                Console.WriteLine("Ошибка!:( Длина должна быть больше 0 и меньше 10");
            }
        }
    }
    static int[] RandomMas(int n)
    {
        Random rnd = new Random();
        int[]mas= new int[n];
        for (int i = 0; i < n; i++)
        {
            mas[i] = rnd.Next(-100, 101);
        }
        return mas;
    }
    static int[] CloneMas(int[] src)
    {
        int[] copy= new int[src.Length];
        for (int i = 0; i < src.Length; i++)
        {
            copy[i] = src[i];
        }
        return copy;
    }
    static void PrintMas(int[] mas)
    {
        if (mas.Length > 10)
        {
            Console.WriteLine("Массивы не могут быть выведены на эеран, тк длина массива больше 10");
            return;
        }
        Console.Write("[ ");
        for (int i = 0;i < mas.Length;i++)
        {
            Console.Write(mas[i]);
            if (i < mas.Length -1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine(" ]");
    }
    static int[] Gnome(int[] mas)
    {
        int i = 0;
        while (i< mas.Length)
        {
            if (i == 0 || mas[i] >= mas[i - 1])
            {
                i++;
            }
            else 
            {
                int temp = mas[i];
                mas[i] = mas[i - 1];
                mas[i - 1] = temp;
                i--;
            }
        }
        return mas;
    }
    static int[] Shak(int[] mas)
    {
        int left = 0;
        bool isSwapped = true;
        int right = mas.Length - 1;
        while(left < right && isSwapped)
        {
            isSwapped = false;
            for (int i = left; i < right; i++)
            {
                if (mas[i] > mas[i+1])
                {
                    int temp = mas[i];
                    mas[i] = mas[i + 1];
                    mas[i + 1] = temp;
                    isSwapped = true;
                }
            }
            right--;
            for(int i = right; i > left; i--)
            {
                if (mas[i - 1] > mas[i])
                {
                    int temp = mas[i];
                    mas[i] = mas[i - 1];
                    mas[i - 1] = temp;
                    isSwapped = true;
                }
            }
            left++;
        }
        return mas;
    }
    static void Sorted()
    {
        Console.WriteLine("____Сортировка массива____");
        int n = ReadDlin();
        int[] orig = RandomMas(n);
        Console.WriteLine("Исходный массив: ");
        PrintMas(orig);
        int[] forGnome = CloneMas(orig);
        int[] forShak = CloneMas(orig);
        Stopwatch sw1=Stopwatch.StartNew();
        Gnome(forGnome);
        sw1.Stop();
        Stopwatch sw2 = Stopwatch.StartNew();
        Shak(forShak);
        sw2.Stop();
        Console.WriteLine("Массив после гномьей сортировки:");
        PrintMas(forGnome);
        Console.WriteLine("Время: " + sw1.ElapsedTicks + "тиков (" + sw1.ElapsedMilliseconds + "мс)");
        Console.WriteLine("Массив после сортировки перемешиванием:");
        PrintMas(forShak);
        Console.WriteLine("Время: " + sw2.ElapsedTicks + "тиков (" + sw2.ElapsedMilliseconds + "мс)");
        if(sw1.ElapsedTicks < sw2.ElapsedTicks)
        {
            Console.WriteLine("Гномья сортировка быстрее!");
        }
        else if(sw1.ElapsedTicks > sw2.ElapsedTicks)
        {
            Console.WriteLine("Сортировка перемешиванием быстрее!");
        }
        else
        {
            Console.WriteLine("Сортировки одинаковые по времени!");
        }
    }
}
