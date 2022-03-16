using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Linq
{
    /// <summary>
    /// Ant编程：交流群737763054
    /// Ling(link发音）
    /// 委托、Lambda、IEnumerable类型、扩展方法
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ////IEnumerable类型
            //IEnumerableShow enumerableShow = new IEnumerableShow();
            //enumerableShow.Show();

            LinqShow linqShow = new LinqShow();
            linqShow.Show();

            Console.ReadLine();
        }
    }
}
