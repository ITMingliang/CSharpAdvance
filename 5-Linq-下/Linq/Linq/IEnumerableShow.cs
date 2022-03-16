using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    /// <summary>
    /// IEnumerable可枚举类型--可迭代类型
    /// IEnumerator枚举器
    /// Enum枚举
    /// 
    /// 只要一个类型实现了IEnumerable接口  就可以对他进行遍历
    /// yield关键词 他做了什么工作？他是一个迭代器，他相当于实现了IEnumerator枚举器
    /// </summary>
    public class IEnumerableShow
    {
        public void Show()
        {

            int[] array = { 1, 2, 3, 4, 5 };
            int i = 1;
            string str = "Ant编程";
            Student student = new Student { Id = 1 };

            foreach (var item in student)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Student: IEnumerable
    {
        public int Id { get; set; }

        public IEnumerator GetEnumerator()
        {
            //yield return "Ant编程1";
            //yield return "Ant编程2";
            //yield return "Ant编程3";
            string[] student = { "Ant编程1", "Ant编程2", "Ant编程3" };
            return new StudentEnumerator(student);
        }
    }

    internal class StudentEnumerator : IEnumerator
    {
        string[] _student;
        int _position = -1;

        public StudentEnumerator(string[] student)
        {
            this._student = student;
        }

        public object Current
        {
            get
            {
                if (_position==-1)
                {
                    throw new InvalidOperationException();
                }
                if (_position >= _student.Length)
                {
                    throw new InvalidOperationException();
                }
                return _student[_position];
            }
        }

        public bool MoveNext()//就是让我们把操作推进到下一个
        {
            if (_position<_student.Length-1)
            {
                _position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}
