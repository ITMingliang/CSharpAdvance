using ExpressionDemo.EF;
using ExpressionDemo.LinqToSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo
{
    /// <summary>
    /// 交流群：737763054
    /// 官网：https://www.antprograming.com
    /// 
    /// ExpressionTree使用场景一
    /// AutoMapper自动映射框架
    /// 
    /// 序列化反序列化
    /// 反射
    /// 
    /// ExpressionTree使用场景二
    /// EF框架类似功能--SQL语句解析（条件）
    /// 
    /// DbFirst--数据库优先模式
    /// 
    /// 
    ///1-手动拼接表达式
    ///2-自动拼接
    ///3-手动+自动拼接
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //自动对象映射
            {
                //Student student = new Student()
                //{
                //    Id = 123,
                //    Name = "Ant编程",
                //    Age = 20
                //};

                //NewStudent newStudent = new NewStudent()
                //{
                //    Id = student.Id,
                //    Name = student.Name,
                //    Age = student.Age
                //};

                //NewStudent newStudent2 = ExpressionMapper<Student, NewStudent>.Mapper(student);
            }

            //拼接SQL语句条件 
            {

                DBEntities db = new DBEntities();
                var query = db.Student.Where(b => b.Id > 2 && b.Address.Contains("杭州"));
                Console.WriteLine(query);


                Expression<Func<Student, bool>> func = b => b.Id > 2 && b.Address.Contains("杭州");
                Console.WriteLine(func);
                //需求，通过修改表达式树，让他变成我们数据库可以识别的SQL条件语句
                //手动拼接，--自动拼接
                //ExpressionVisitor
                Customevisitor customevisitor = new Customevisitor();
                customevisitor.Visit(func);


                ConditionVisitor conditionVisitor = new ConditionVisitor();
                conditionVisitor.Visit(func);

                Console.WriteLine(conditionVisitor.Condition());
            }

            //sql语句条件拼接


            Console.ReadLine();
        }
    }

    public class Customevisitor: ExpressionVisitor
    {
        public override Expression Visit(Expression node)
        {
            return base.Visit(node);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            return base.VisitBinary(node);
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            return base.VisitMethodCall(node);
        }
    }



    //class Student
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //}

    //class NewStudent
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //}

}
