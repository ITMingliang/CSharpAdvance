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
    /// IQueryable实现了IEnumberable接口
    /// 
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
                    Age=25,
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
        List<StuClass> stuClasses = new List<StuClass>
        {
            new StuClass{Id=1,ClassName="小程序班"},
            new StuClass{Id=2,ClassName="C#班"},
            new StuClass{Id=3,ClassName=".net core班"},
            new StuClass{Id=4,ClassName="webAPI"},
        };
        #endregion
        //封装：变化作为参数，不变作为方法体
        public void Show()
        {

            {
                //List<Students> list = new List<Students>();
                //foreach (var item in StudentsList)
                //{
                //    if (item.ClassId==2)
                //    {
                //        list.Add(item);
                //    }
                //}

                //List<Students> list2 = new List<Students>();
                //foreach (var item in StudentsList)
                //{
                //    if (item.Age < 20)
                //    {
                //        list2.Add(item);
                //    }
                //}


                ////自定义Linq
                ////List<Students> list3 = AntWhere(StudentsList, x => x.Age < 20);
                //var list3 = StudentsList.AntWhere(x => x.Age < 20);
                ////官方的Linq(扩展方法方式的)
                //var list4 = StudentsList.Where(x => x.Age < 20);
                ////表达式方式的(这种方式最后生成代码和方法是一样的）
                //var list5 = from s in StudentsList
                //             where s.Age < 20
                //             select s ;
            }

            //select
            {
                ////扩展方法用法 
                //var query = StudentsList.Select(s => new StudentModel { Id=s.Id,Name=s.Name});
                ////表达式用法 
                //var query2 = from s in StudentsList
                //             select new  { Id = s.Id, Name = s.Name };
            }

            //Join(==要换成equals)
            {
                ////表达语法用法
                //var query = from s in StudentsList
                //            join c in stuClasses on s.ClassId equals c.Id
                //            select new StuAndClass { 
                //             Id=s.Id,
                //             Name=s.Name,
                //              ClassId=s.ClassId,
                //               Age=s.Age,
                //                ClassName=c.ClassName,
                //            };
                ////扩方法使用
                //var query2 = StudentsList.Join(stuClasses, s => s.ClassId, c => c.Id, (s, c) => new StuAndClass
                //{
                //    Id = s.Id,
                //    Name = s.Name,
                //    ClassId = s.ClassId,
                //    Age = s.Age,
                //    ClassName = c.ClassName,
                //});

            }

            //其他方法
            {
                //var query = StudentsList
                //    //.Skip(5)
                //    //.Take(3)
                //    //.OrderBy(s=>s.Name)
                //    //.OrderByDescending(s=>s.Id)
                //    .Where(s => s.Name.Contains("A")).FirstOrDefault();

            }

            //IQueryable类型
            {
                var query = StudentsList.AsQueryable().Where(s => s.Id > 0);
            }

            //EF框架简单使用
            //EF里面的Db First，Model First,Code First

            {
                //            SELECT
                //[Extent1].[BookId] AS[BookId], 
                //[Extent1].[BarCode] AS[BarCode], 
                //[Extent1].[BookName] AS[BookName], 
                //[Extent1].[Author] AS[Author], 
                //[Extent1].[PublisherId] AS[PublisherId], 
                //[Extent1].[PublisherDate] AS[PublisherDate], 
                //[Extent1].[BookCategroy] AS[BookCategroy], 
                //[Extent1].[UnitPrice] AS[UnitPrice], 
                //[Extent1].[BookImage] AS[BookImage], 
                //[Extent1].[BookCount] AS[BookCount], 
                //[Extent1].[Remainder] AS[Remainder], 
                //[Extent1].[BookPosition] AS[BookPosition], 
                //[Extent1].[RegTime] AS[RegTime]
                //FROM[dbo].[Books] AS[Extent1]

                //            SELECT
                //[Extent1].[BookId] AS[BookId], 
                //[Extent1].[BarCode] AS[BarCode], 
                //[Extent1].[BookName] AS[BookName], 
                //[Extent1].[Author] AS[Author], 
                //[Extent1].[PublisherId] AS[PublisherId], 
                //[Extent1].[PublisherDate] AS[PublisherDate], 
                //[Extent1].[BookCategroy] AS[BookCategroy], 
                //[Extent1].[UnitPrice] AS[UnitPrice], 
                //[Extent1].[BookImage] AS[BookImage], 
                //[Extent1].[BookCount] AS[BookCount], 
                //[Extent1].[Remainder] AS[Remainder], 
                //[Extent1].[BookPosition] AS[BookPosition], 
                //[Extent1].[RegTime] AS[RegTime]
                //FROM[dbo].[Books] AS[Extent1]
                //WHERE([Extent1].[BookId] > 0) AND('C#' = [Extent1].[BookName])


                DBEntities db = new DBEntities();
                var query = db.Books.Where(s => s.BookId > 0)
                            .Where(s => s.BookName == "C#").ToList();

            }

            //匿名类
            //var var1 = new { id = 1, s = 5 };
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
