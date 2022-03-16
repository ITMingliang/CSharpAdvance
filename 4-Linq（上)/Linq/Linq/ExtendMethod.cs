using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    /// <summary>
    /// 扩展方法
    /// 静态类里的静态方法，参数列表最前面加个this +要扩展到的类型
    /// 使用场景:在不修改源码的情况下为其他类型增加功能 或者说增加方法;
    /// </summary>
    public class ExtendMethod
    {
        public void Show()
        {
            Calculate calculate = new Calculate();
            int i=0;
        }
    }


    class Calculate
    {
        public int Add(int a,int b)
        {
            return a + b;
        }
    }

   static class ClaculateNew
    {
        public static int AddNew(this Calculate calculate, int a, int b, int c)
        {
            return a + b + c;
        }
        
        
        public static void ToInt(this int i)
        {
           
        }
    }
}
