using System;

namespace dz1
{
    class Drobi
    {
        int ch;
        int zn;

        public Drobi(int a)
        {
            ch = a;
            zn = 1;
        }
        public Drobi(int a, int b)
        {
            ch = a;
            zn = b;
        }
        public Drobi(int a, int b, int z)
        {
            zn = b;
            ch = z * b + a;
        }
        public double Desyat()
        {
            return (double)(ch) / zn;
        }
        public static Drobi operator +(Drobi x, Drobi y)
        {
            return new Drobi(x.ch * y.zn + y.ch * x.zn, x.zn * y.zn);
        }
        public static Drobi operator -(Drobi x, Drobi y)
        {
            return new Drobi(x.ch * y.zn - y.ch * x.zn, x.zn * y.zn);
        }
        public static Drobi operator *(Drobi x, Drobi y)
        {
            return new Drobi(x.ch * y.ch, x.zn * y.zn);
        }
        public static Drobi operator /(Drobi x, Drobi y)
        {
            return new Drobi(x.ch * y.zn, x.zn * y.ch);
        }

        public void PlusOrMinus()
        {
            double result = ch / zn;
            if (Math.Sign(result) == 1)
            {
                Console.WriteLine("Знак дроби '+'");
            }
            else if (Math.Sign(result) == -1)
            {
                Console.WriteLine("Знак дроби '-'");
            }
            else
            {
                Console.WriteLine("Неверный ввод!");
            }
        }

        public delegate void Changed(Drobi a, int b);

        public event Changed EventChanger;
        public int Ch
        {
            get { return ch; }
            set
            {
                EventChanger(this, value);
                ch = value;
            }
        }
        public void GetDrobe(Drobi a)
        {
            Console.WriteLine(a.ch + "/" + a.zn);
        }
        public int this[int index]
        {
            get { return (index == 0) ? ch : zn; }
        }
    }
    class Method
    {
        public static void MyMethod(Drobi a, int x)
        {
            Console.WriteLine("Дробь изменена");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Drobi drob1 = new Drobi(-3, 1);
            Drobi drob2 = new Drobi(4, 1);

            drob1.GetDrobe(drob1);
            drob1.PlusOrMinus();
            Console.WriteLine(drob2[1]);

            double deciatChicl = drob1.Desyat();
            Console.WriteLine(deciatChicl);

            Drobi drobResult = drob1 + drob2;
            Console.WriteLine(drobResult.Ch);

            drob1.EventChanger += Method.MyMethod;
            drob1.Ch = 7;

            Console.ReadKey();
        }
    }
}
