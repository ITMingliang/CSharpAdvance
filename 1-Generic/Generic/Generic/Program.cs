using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    /// <summary>
    /// ant编程交流群：737763054
    /// 
    /// 泛型：
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] sum1 = new int[2];//定义状态
            int i1= sum1[0];//使用状态
            int[] sum2 = new int[] { };
            double[] sum3 = new double[2];

            //定义状态
            ArrayList arrayList = new ArrayList();//这种方式 解决 每一个类型都要定义一个对应数组（代码重用）
            arrayList.Add(1);//使用状态
            arrayList.Add("ant");//缺点：1、不是类型安全的。2、效率低下，在值 类型数据进行转换的时候要进行频繁的拆装箱操作
            int i = (int)arrayList[0];


            /*
             T:Type
             泛型：带有“<>” 符号的类型  叫泛型
             优点：1，代码重用。2，类型类型安全。3、高效率。
             分类：1--从定义角度来争，分预定义（List<T>,Dictionary<TKey, TValue>）。2--自定义
             延迟声明：定义的时候就是一个站位符，使用的时候一定确定具体类型。
             */

            List<int> intList = new List<int>();//已行入使用状态
            intList.Add(1);
            int i2 = intList[0];

            //Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            //自定义泛型--泛型方法：
            Show<int>(123);
            Show<string>("这是泛型方法！");
            Show<double>(11.00);

            //自定义泛型--泛型类：
            AntList<string> antList = new AntList<string>();
            antList.Add("");

            //自定义泛型--泛型约束：
            //约束有两个主要的：class引用约束，struct值类型约束，构造器约束（多个时一定要放最后）,自定义类型约束
            Test1<Student>();
            //Student student = new Student();
            Test3<bool>();
            Test4<MyClass>();

            Console.ReadKey();
        }

        #region 泛型约束
        public static void Test1<T>() where T:class
        {
            T temp = null;
        }

        public static T Test2<T>() where T : struct
        {
            return new T();//值类型都有一个隐式的公共无参数构造方法
        }

        public static void Test3<T>() where T : new ()
        {
            //new ()作用一定要有一个无参数的构造方法（一定要放最后）
        }

        public static void Test4<T>() where T : MyClass
        {
            //new ()作用一定要有一个无参数的构造方法
        }

        public static void Test5<T>() where T : MyClass , IStudent1, IStudent2
        {
            //接口约束可以多个
        }
        public static void Test5<T,S,U>() 
            where T : MyClass, IStudent1, IStudent2
            where S :IStudent1, IStudent2
            where U : IStudent2
        {
            //接口约束可以多个
            //一个参数有多个约束，或者多个参数中每个参数都有一个或者多个约束。
        }
        #endregion


        #region 泛型方法
        //当参数使用
        public static void Show<T>(T param)
        {
            Console.WriteLine(param.GetType().Name+" "+param);
        }
        //当返回值使用
        public static T Show<T>()
        {
            //值类型不能为null，引用类型可以，
            //default,如果是引用类型 那就返回null,如果是值类型就返回0
            return default(T);
        }
        //当局部变量
        public static void Show<T>(int a,int b)
        {
            T t;//局部变量
        }

        #endregion
    }

    interface IStudent1
    {

    }

    interface IStudent2
    {

    }

    class MyClass
    {

    }



    class Student
    {
       
        public Student(int a)
        {

        }
    }

    #region 泛型类

    public class AntList<T>
    {
        private AntList<T> _list;

        public void Add(T item)
        {
            _list.Add(item);
        }
    }

    #endregion


}
