using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo
{
    /// <summary>
    /// 对象映射
    /// </summary>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
   public class ExpressionMapper<TIn,TOut>
    {
        private static Func<TIn, TOut> _Func = null;
        static ExpressionMapper()
        {
            ParameterExpression paramExp = Expression.Parameter(typeof(TIn), "p");
            List<MemberBinding> memberBindingList = new List<MemberBinding>();
            //绑定属性
            foreach (var item in typeof(TOut).GetProperties())
            {
                MemberExpression member = Expression.Property(paramExp, typeof(TIn).GetProperty(item.Name));
                MemberBinding memberBinding = Expression.Bind(item, member);
                memberBindingList.Add(memberBinding);
            }
            //绑定我们字段 
            foreach (var item in typeof(TOut).GetFields())
            {
                MemberExpression member = Expression.Field(paramExp, typeof(TIn).GetField(item.Name));
                MemberBinding memberBinding = Expression.Bind(item, member);
                memberBindingList.Add(memberBinding);
            }

            //创建新对象并初始化
            MemberInitExpression memberInitExp = Expression.MemberInit(Expression.New(typeof(TOut)), memberBindingList.ToArray());

            Expression<Func<TIn, TOut>> funcExp = Expression.Lambda<Func<TIn, TOut>>(memberInitExp, new ParameterExpression[] { paramExp });

            _Func =  funcExp.Compile();
        }

        public static TOut Mapper(TIn t)
        {
            return _Func(t);
        }
    }
}
