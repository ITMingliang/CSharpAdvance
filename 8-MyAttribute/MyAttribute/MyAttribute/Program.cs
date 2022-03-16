using System;

namespace MyAttribute
{
    /// <summary>
    /// Ant编程交流群：737763054
    /// 官网：https://www.antprograming.com
    /// 
    /// 特性：
    /// 前置课程：反射、泛型
    /// 一、特性的介绍--使用场景（框架中、类上面、方法上面、属性上面、字段上面、参数上面）、特性的本质（类，继承自Attribute类）
    /// 二、特性简单的定义、查找、使用、(定义--》使用--》通过反射查找到特性--》调用)
    /// 三、常用的特性验证类编写+自动特性验证
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            string tableName = CustomeAttribute.GetTableNameAttribute(student);

            Student student1 = new Student() { 
                 Id=1,
                  Name="Ant编程46465",
                   Age=18,
                    Email= "737763054@qq.com",
                     PhoneNumber="12345678900"
            };

            Student student2 = new Student()
            {
                Id = 1,
                Name = "Ant",
                Age = 18,
                Email = "737763054.com",
                PhoneNumber = "1234567890000000"
            };


          var result1=  CustomeAttribute.Validate(student1);

            var result2 = CustomeAttribute.Validate(student2);

            Console.WriteLine("Ant编程");
        }
    }
}
