using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontrolnaya
{
    class Data
    {
        public int day { set; get; }
        public int month { set; get; }
        public int year { get; }
        public Data(int d, int m, int y)
        {
            day = d;
            month = m;
            year = y;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (month == ((Data)obj).month && day == ((Data)obj).day && year == ((Data)obj).year)
                return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return month * 10 + day + year * 100;
        }
    }

    abstract class People
    {

    }
    public interface IGood
    {
        void plus();
    }
    public interface IBad
    {
        void minus();
    }
    class student : People, IGood, IBad
    {
        public void plus()
        {
            Console.WriteLine("Good student");
        }
        public void minus()
        {
            Console.WriteLine("Leniv student");
        }

    }
    class prepod : People
    {
        public void plus()
        {
            Console.WriteLine("Good Prepod");
        }
    }

    class SuperSack<T> : Stack<T>
    {
        new
        public void Push(T el)
        {
            try
            { if (Count == 3) throw new Exception();
                base.Push(el);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error 4 elem : {0}", e.Message);
            }
        }
        public static bool operator ==(SuperSack<T> t, SuperSack<T> t1)
        {
            if (t.Count == t1.Count) return true;
            else return false;
        }
        public static bool operator !=(SuperSack<T> t, SuperSack<T> t1)
        {
            if (t.Count != t1.Count) return true;
            else return false;
        }
    }

    class telephone
    {
        public delegate void Zv();
        public event Zv onZvonok;
        public void pozvon()
        {
            Console.WriteLine("TELEPHON ZVONIT!");
            onZvonok();
        }
    }
    class user
    {
        public void podnyat()
        {
            Console.WriteLine("Podnimau!!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ushort.MaxValue);
            String s = "kont12345u";
            Console.WriteLine("is 123 in {0} {1} ", s, s.Contains("123"));
            double[,] d = new double[4, 4];
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    d[i, j] = rand.Next(-10,10)*rand.NextDouble();
            for (int i = 0; i < 4; i++)
            { for (int j = 0; j < 4; j++)
                    Console.Write("{0}  ",d[i,j]);
                Console.WriteLine();
            }

            Data d1=new Data(10,2,2015);
            Data d2 = new Data(15, 3, 2016);
            Data d3 = new Data(15, 3, 2016);
            Console.WriteLine("10.02.2015==15.03.2016 {0}", d1.Equals( d2));
            Console.WriteLine("15.03.2016==15.03.2016 {0}", d3.Equals (d2));

            prepod p = new prepod();
            student st = new student();
            st.plus();
            st.minus();
            p.plus();

            SuperSack<int> n = new SuperSack<int>();
            SuperSack<int> m = new SuperSack<int>();
            n.Push(1);
            n.Push(2);
            n.Push(3);
            n.Push(5);

            m.Push(6);
            m.Push(7);
            Console.WriteLine("stack1==stack2 {0}", n==m);
            String[] str = { "12ss345", "wer", "ert124ff" };
            for (int r = 0; r < 3; r++)
            {
                Console.WriteLine("{0}", str[r]);
            }

            int y = str.Where(i=>i.Length > 5).Count();
            Console.WriteLine("Kol strok Length>5 : {0}",y);

            telephone t = new telephone();
            user u1=new user();
            user u2 = new user();
            t.onZvonok += u1.podnyat;
            t.onZvonok += u2.podnyat;
            t.pozvon();
        }
    }
}
