using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo.LinqToSql
{
    /// <summary>
    /// 条件访问者
    /// 表达式树的永久性：想修改一个表达式树，刚必须复制这个表达式然后替换其中节点来创建一个新的表达式
    /// </summary>
   public class ConditionVisitor:ExpressionVisitor
    {
        private Stack<string> _stringStack = new Stack<string>();

        //返回栈里面的条件字符串
        public string Condition()
        {
           string condition= string.Concat(this._stringStack.ToArray());
            this._stringStack.Clear();
            return condition;
        }

        //二元表达式
        protected override Expression VisitBinary(BinaryExpression node)
        {
            //栈是后进先出的
            this._stringStack.Push(")");
            base.Visit(node.Right);//解析右边
            this._stringStack.Push(" " + node.NodeType.TosqlOperator() + " ");
            this.Visit(node.Left);//解析左边
            this._stringStack.Push("（");
            return node;
        }
        //成员表达式
        protected override Expression VisitMember(MemberExpression node)
        {
            this._stringStack.Push(" [" + node.Member.Name + "] ");
            return node;
        }
        //常量表达式
        protected override Expression VisitConstant(ConstantExpression node)
        {
            Type type = node.Value.GetType();
            if (type.Equals(typeof(string))||type.Equals(typeof(DateTime)))//如果是字符或者日期，需要加单引号
            {
                this._stringStack.Push($"'{node.Value}'");//成员入栈不要有空格
            }
            else
            {
                this._stringStack.Push(node.Value.ToString());
            }

            return node; 
        }
        //方法表达式
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            this.Visit(node.Object);//左边：方法所在的对象，返回是成员表达式--》跳转到VisitMember
            this.Visit(node.Arguments[0]);//右边：方法参数，返回常量表达式--》VisitConstant

            //获取入栈数据，为方法解析做参数（参数和字段名）
            string right = this._stringStack.Pop();//'杭州'
            string left = this._stringStack.Pop();//Address

            //([Extent1].[Id] > 2) AND ([Extent1].[Address] LIKE N'%杭州%')
            switch (node.Method.Name)
            {
                case "Contains":
                    this._stringStack.Push($"{left} LIKE N'%{right.Replace("'","")}%'");
                    break;
                case "Equals":
                    this._stringStack.Push($"{left}={right}");
                    break;
                default:
                    throw new NotSupportedException(node.NodeType + " 不支持!");
            }

            return node;
        }
    }
}
