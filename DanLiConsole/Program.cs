using System;
using System.Threading;

namespace DanLiConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                Thread thread = new Thread(new ThreadStart(() =>
                {
                    Singleton obj = Singleton.CreateInstance();
                }));
                thread.Start();
            }
            Console.WriteLine("ok....");
            Console.ReadKey();
        }
    }

    /// <summary>
    /// 构造对象设置private，就不能外部创建对象
    /// </summary>
    public class Singleton
    {
        private Singleton()
        {
            Console.WriteLine("构造对象1....");
        }

        private static Singleton _instarce;
        //方法只能被一个线程执行
        private static readonly object syn = new object();
        public static Singleton CreateInstance()
        {
            if (_instarce == null)
            {
                lock (syn)
                {
                    if (_instarce == null)
                    {
                        _instarce = new Singleton();
                    }
                }
            }
            return _instarce;
        }
    }


    public sealed class Singleton2
    {
        private Singleton2()
        {
            Console.WriteLine("构造对象2....");
        }

        //静态成员初始化，只在第一次使用的时候初始化一次
        private static readonly Singleton2 _instance = new Singleton2();

        public static Singleton2 GetInstance()
        {
            return _instance;
        }
    }
}
