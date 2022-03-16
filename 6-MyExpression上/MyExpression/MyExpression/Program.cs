using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyExpression
{
    /// <summary>
    /// 表达式树（Expression Tree）
    /// 使用场景：EntityFramework/AutoMapper/ORM框架的开发
    /// 
    /// 学习三大步：
    /// 一、认识并它。
    /// 二、编写它。
    /// 三、使用它。
    /// 
    /// 初始化委托 时候 他是一个匿名方法--做事，
    /// 初始化表达式时个他是一个表达式树--描述事物
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Expression<Func<int>> fcunExp = () => 5;

            //ConstantExpression constExp = Expression.Constant(5, typeof(int));
            //Expression<Func<int>> fcunExp2 = Expression.Lambda<Func<int>>(constExp, null);

            //Expression<Func<int, int>> fcunExp = (y) => 5 + y;
            //ParameterExpression paramExp = Expression.Parameter(typeof(int), "y");//Right
            //ConstantExpression constExp = Expression.Constant(5);//Left
            //BinaryExpression binaryExp = Expression.Add(constExp, paramExp);//Body
            //Expression<Func<int, int>> fcunExp2 = Expression.Lambda<Func<int, int>>(binaryExp, new ParameterExpression[] { paramExp });


            //Expression<Func<int, int, int>> fcunExp = (y, x) => 5 + y * y - x;
            //ParameterExpression paramExp = Expression.Parameter(typeof(int), "y");
            //BinaryExpression binaryExp = Expression.Multiply(paramExp, paramExp); 
            //ConstantExpression constExp = Expression.Constant(5);
            //BinaryExpression binaryExp2 = Expression.Add(constExp, binaryExp);//(5 + (y * y)) Left
            //ParameterExpression paramExp2 = Expression.Parameter(typeof(int), "x");//x  Right
            //BinaryExpression binaryExp3 = Expression.Subtract(binaryExp2, paramExp2);//((5 + (y * y)) - x)
            //Expression<Func<int, int, int>> fcunExp2 = Expression.Lambda<Func<int, int, int>>(binaryExp3, new ParameterExpression[] { paramExp, paramExp2 });



            Expression<Func<Student, string>> fcunExp = (x) => x.Id.ToString();
            ParameterExpression paramExp = Expression.Parameter(typeof(Student), "x");
            MemberExpression memberExp = Expression.Property(paramExp, "Id");//x.Id
            MethodCallExpression methodCallExp= Expression.Call(memberExp, "ToString", null);//x.Id.ToString()
            Expression<Func<Student, String>> fcunExp2 = Expression.Lambda<Func<Student, String>>(methodCallExp, new ParameterExpression[] { paramExp });
            
            var result= fcunExp2.Compile().Invoke(new Student { Id=5,Name="ant编程"});
            Console.WriteLine(result);
            Console.Read();
            File

        }

        class Student
        {

            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
