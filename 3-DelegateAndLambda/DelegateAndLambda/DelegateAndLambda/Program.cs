using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateAndLambda
{
    /// <summary>
    /// Ant编程：交流群737763054
    /// 委托：也是一种类型，特殊类型，初始化时需要一个方法支持，委托是记录方法信息的一种类型--，调用委托时候也就是调用实例化委托的方法。
    /// 自定义委托：定义和类类型相似
    /// 泛型委托:
    /// 泛型：代码重用，可以写出通用代码
    /// 
    /// 预定义委托：Action无返回值委托一共16个，Func有返回值委托共17个
    /// 
    /// lambda:本质上来说就是一个匿名方法,他的作用，让我们更简单更快的完成委托初始化，而且还可以让实例化委托的方法访问局部变量
    /// 
    /// 
    /// 写委托方式：根据方法来写委托
    /// </summary>
    class Program
    {
        
        static void Main(string[] args)
        {
            #region 4-1委托和自定义委托
            ////编程语言--类型系统
            //MyClass my = new MyClass();//初始化
            //my.Hello("");//类里面方法的调用
            ////委托初始化（需要一个和委托签名一样的方法来实例化，并且只需要写方法名称就可以了）
            //HelloDelegate hello = new HelloDelegate(Hello);
            ////调用
            //hello.Invoke("");//从这里可以看出来，调用委托就是是调用了初始化委托的这个方法

            //AddDelegate addDelegate = new AddDelegate(Add);
            //int a= addDelegate.Invoke(2, 5);
            //Console.WriteLine(a);

            //ShowDelegate showDelegate = new ShowDelegate(Show);
            //showDelegate.Invoke();
            #endregion

            #region 4-2泛型委托
            //AddDelegate<int> addDelegate = new AddDelegate<int>(AddInt);
            //addDelegate(3, 4);//调用委托可以不写Invoke
            #endregion

            #region 4-3预定义委托
            ////Action无返回值委托
            //Action<string, int> action = new Action<string, int>(Show);
            //action("无返回值委托", 1);
            //Action<int, int,int> action2 = new Action<int, int,int>(Show3);
            //action2(1, 2, 3);

            ////Func有返回值委托
            //Func<string> func1 = new Func<string>(Show4);
            //Console.WriteLine(func1());

            //Func<int, int> func2 = new Func<int, int>(Show5);
            //int num= func2(5);
            #endregion

            #region 4-4Lambda

            int i = 5;
            Action<string> action = new Action<string>(Shwo);
            action("您好我是泛型委托Action");

            Action<string> action2 = new Action<string>(delegate(string msg) 
            {
                Console.WriteLine(msg);
            });
            action2("您好我是泛型委托Action,使用了匿名方法");
            //=> 念成gose to
            Action<string> action3 = new Action<string>( (string msg)=>
            {
                Console.WriteLine(msg);
            });
            action3("您好我是泛型委托Action,使用了匿名方法");


            //一个参数  一个语句的方法
            Action<string> action4 = new Action<string>(msg => Console.WriteLine(msg));
            action4("一个参数  一个语句的方法");

            //无返回值 无参数
            Action action5 = new Action(() =>  Console.WriteLine("无返回值 无参数"));
            action5();

            //有返回值，单 条件语句 
            Func<string> func = new Func<string>(() => "有返回值，单 条件语句 ");
            func();

            //有返回值，单 条件语句 
            Func<string> func2 = new Func<string>(() => {
                Console.WriteLine("有返回值，单 条件语句");
                Console.WriteLine("有返回值，单 条件语句");
                Console.WriteLine("有返回值，单 条件语句");
                return "有返回值，单 条件语句 ";
            });
            string smg= func2();

            #endregion



            Console.ReadKey();
        }

        #region 4-4Lambda
        public static void Shwo(string msg)
        {

            Console.WriteLine(msg);
        }
        #endregion

        #region 4-3预定义委托

        //public static int Show5(int a)
        //{
        //    return a;
        //}
        //public static string Show4()
        //{
        //    return "有返回值的委托";
        //}

        //public static void Show(string a,int num)
        //{
        //    Console.WriteLine(a);
        //}
        //public static void Show3(int a, int b,int c)
        //{
        //    Console.WriteLine(a);
        //}
        #endregion
        #region 4-2泛型委托
        //public static void AddInt(int a,int b)
        //{

        //}
        //public static void AddDouble(double a, double b)
        //{

        //}

        //public static void AddBool(bool a, bool b)
        //{

        //}
        #endregion
        #region 4-1委托和自定义委托

        ////定义委托方法的时候 返回值类型和参数要一样包括（参数类型，顺序 ，参数个数）
        //public static void Hello(string msg)
        //{
        //    Console.WriteLine("您好我是委托！");
        //}

        //public static int Add(int a,int b)
        //{
        //    return a + b;
        //}

        //public static void Show()
        //{
        //    Console.WriteLine("我是无返回值，无参数的委托");
        //}
        #endregion
    }

    #region 4-3预定义委托

    #endregion
    #region 4-2泛型委托
    //delegate void AddDelegate<T>(T a, T b);
    #endregion
    #region 4-1委托和自定义委托

    ////定义方式：delegate +返回值+委托名称+（参数类型  参数名称）;
    //delegate void HelloDelegate(string msg);//定义委托 
    //delegate int AddDelegate(int a, int b);
    //delegate void ShowDelegate();
    //class MyClass
    //{
    //    public  void Hello(string msg)
    //    {
    //        Console.WriteLine("您好我是委托！");
    //    }
    //}

    #endregion

}
