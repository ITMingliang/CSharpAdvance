using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using SqlServerDB;

namespace Reflection
{
    /// <summary>
    /// 泛型：代码重用
    /// 反射：就是操作dll文件的一个类库
    /// 怎么使用：1--查找DLL文件，2--通过Reflection反射类库里的各种方法来操作dll文件
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            #region 普通类+各种方法调用

            // //【1】加载DLL文件
            // //Assembly assembly1 = Assembly.Load("SqlServerDB");//方式一：这个DLL文件要在启动项目下
            // //Assembly assembly2 = Assembly.LoadFile(@"D:\Ant编程一期\3-进阶语法（使用进阶语法升级图书管理系统）\2-反射\Reflection\SqlServerDB\bin\Debug\SqlServerDB.dll");//方式二：完整路径

            // //Assembly assembly3 = Assembly.LoadFrom(@"D:\Ant编程一期\3-进阶语法（使用进阶语法升级图书管理系统）\2-反射\Reflection\SqlServerDB\bin\Debug\SqlServerDB.dll");//方式三：完整路径
            // Assembly assembly4 = Assembly.LoadFrom(@"SqlServerDB.dll");//方式三：完整路径

            // //【2】获取指定类型
            // Type type = assembly4.GetType("SqlServerDB.ReflectionTest");
            // foreach (var item in assembly4.GetTypes())//查找所有的类型
            // {
            //     Console.WriteLine(item.Name);
            // }

            // foreach (var ctor in type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic|BindingFlags.Public))
            // {
            //     Console.WriteLine($"构造方法：{ctor.Name}");
            //     foreach (var param in ctor.GetParameters())
            //     {
            //         Console.WriteLine($"构造方法的参数：{param.ParameterType}");
            //     }
            // }
            // //【3】实例化
            // //ReflectionTest reflectionTest = new ReflectionTest();//这种实例化是知道具体类型--静态
            // //object objTest1=Activator.CreateInstance(type);//动态实例化--调用我们的构造方法
            // //object objTest2 = Activator.CreateInstance(type,new object[] { "Ant编程"});//动态实例化--调用我们的有参数构造方法

            // //调用私有构造函数
            // //ReflectionTest reflectionTest = new ReflectionTest();
            // object objTest2 = Activator.CreateInstance(type,true);

            // //调用普通方法
            // ReflectionTest reflectionTest = objTest2 as ReflectionTest;//as转换的好处，他不报错，类型不对的话就返回null
            // reflectionTest.Show1();
            // //调用私有方法
            //var method= type.GetMethod("Show2", BindingFlags.Instance | BindingFlags.NonPublic);
            // method.Invoke(objTest2,new object[] { });

            // Console.WriteLine("--------------------泛型方法调用 ------------------");
            // //无参数
            // var method3 = type.GetMethod("Show3");//查找指定方法
            // var genericMethod = method3.MakeGenericMethod(new Type[] {typeof(int)});//指定泛型参数类型T
            // genericMethod.Invoke(objTest2, new object[] { });


            // //有参数
            // var method4 = type.GetMethod("Show4");//查找指定方法
            // var genericMethod4 = method4.MakeGenericMethod(new Type[] { typeof(string) });//指定泛型参数类型T
            // genericMethod4.Invoke(objTest2, new object[] {123,"Ant编程" });


            #endregion

            #region 泛型类+泛型方法（一定给定具体类型参数）
            //【1】加载DLL文件
            Assembly assembly = Assembly.LoadFrom(@"SqlServerDB.dll");
            //【2】获取指定类型
            Type type = assembly.GetType("SqlServerDB.GenericClass`2").MakeGenericType(typeof(int), typeof(string));
            object objTest2 = Activator.CreateInstance(type);
            var method = type.GetMethod("GenericMethod").MakeGenericMethod(typeof(int));
            method.Invoke(objTest2, new object[] { });
            #endregion

            #region 操作属性和字段
            Assembly assembly2 = Assembly.LoadFrom("SqlServerDB.dll");
            Type type2 = assembly2.GetType("SqlServerDB.PropertyClass");
            object obj = Activator.CreateInstance(type2);
            foreach (var property in type2.GetProperties())
            {
                Console.WriteLine(property.Name);
                //给属性设置值
                if (property.Name.Equals("Id"))
                {
                    property.SetValue(obj, 1);
                }else if (property.Name.Equals("Name"))
                {
                    property.SetValue(obj, "Ant编程");
                }
                else if (property.Name.Equals("Phone"))
                {
                    property.SetValue(obj, "123459789");
                }
                //获取属性值
                Console.WriteLine(property.GetValue(obj));
            }

            //作业：让大家写一类，里面写上3-5个字段，设置字段值 ，并且打印出来
            #endregion

            Console.Read();
        }
    }
}
