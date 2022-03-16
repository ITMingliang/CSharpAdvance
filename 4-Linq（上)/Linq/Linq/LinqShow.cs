using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    /// <summary>
    /// Linq to object(数组、list集合)--内存里面的数据
    /// linq to sql  (查询数据库用的)--在数据库数据
    /// Linq to XML  查询XML文件
    /// 
    /// 委托他是不可以把一个代码块，或者一段代码独立出来
    /// 扩展方法方式的
    /// 表达式方式 
    /// </summary>
   public class LinqShow
    {
        #region 初始化数据
        List<Students> StudentsList = new List<Students>()
            {
                new Students()
                {
                    Id=0,
                    Name="Ant编程1",
                    ClassId=3,
                    Age=25
                },
                new Students()
                {
                    Id=1,
                    Name="Ant编程2",
                    ClassId=2,
                    Age=13
                },
                 new Students()
                {
                    Id=2,
                    Name="Ant编程3",
                    ClassId=2,
                    Age=17
                },
                 new Students()
                {
                    Id=3,
                    Name="Ant编程4",
                    ClassId=2,
                    Age=16
                },
                new Students()
                {
                    Id=4,
                    Name="Ant编程5",
                    ClassId=2,
                    Age=25
                },
                new Students()
                {
                    Id=5,
                    Name="Ant编程6",
                    ClassId=3,
                    Age=24
                },
                new Students()
                {
                    Id=6,
                    Name="Ant编程7",
                    ClassId=2,
                    Age=21
                },
                 new Students()
                {
                    Id=7,
                    Name="Ant编程8",
                    ClassId=2,
                    Age=18
                },
                 new Students()
                {
                    Id=8,
                    Name="Ant编程9",
                    ClassId=2,
                    Age=34
                },
                 new Students()
                {
                    Id=9,
                    Name="Ant编程10",
                    ClassId=3,
                    Age=30
                },
                new Students()
                {
                    Id=10,
                    Name="Ant编程13",
                    ClassId=3,
                    Age=30
                },
                new Students()
                {
                    Id=11,
                    Name="Ant编程11",
                    ClassId=3,
                    Age=25
                },
                new Students()
                {
                    Id=12,
                    Name="Ant编程12",
                    ClassId=3,
                    Age=28
                }
            };
        #endregion
        //封装：变化作为参数，不变作为方法体
        public void Show()
        {


            List<Students> list = new List<Students>();
            foreach (var item in StudentsList)
            {
                if (item.ClassId==2)
                {
                    list.Add(item);
                }
            }

            List<Students> list2 = new List<Students>();
            foreach (var item in StudentsList)
            {
                if (item.Age < 20)
                {
                    list2.Add(item);
                }
            }


            //自定义Linq
            //List<Students> list3 = AntWhere(StudentsList, x => x.Age < 20);
            var list3 = StudentsList.AntWhere(x => x.Age < 20);
            //官方的Linq(扩展方法方式的)
            var list4 = StudentsList.Where(x => x.Age < 20);
            //表达式方式的(这种方式最后生成代码和方法是一样的）
            var list5 = from s in StudentsList
                         where s.Age < 20
                         select s ;

        }

        //Func<Students, bool> func = test;

        //public static bool test(Students students)
        //{
        //    return students.Age < 20;

        //}

      
    }

    public static class LinqExtend
    {
        public static IEnumerable<TSource> AntWhere<TSource>(this IEnumerable<TSource> resource, Func<TSource, bool> func)
        {
            List<TSource> list2 = new List<TSource>();
            foreach (var item in resource)
            {
               
                if (func.Invoke(item))
                {
                    list2.Add(item);
                }
            }
            return list2;
        }
    }
}
