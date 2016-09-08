using System;
using System.Collections.Generic;
using System.Data.Entity.Query.LinqToEntities;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建 loop表达式体来包含我们想要执行的代码
            LoopExpression loop = Expression.Loop(
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }),
                    Expression.Constant("Hello"))
                    );

            // 创建一个代码块表达式包含我们上面创建的loop表达式
            BlockExpression block = Expression.Block(loop);

            // 将我们上面的代码块表达式
            Expression<Action> lambdaExpression = Expression.Lambda<Action>(block);
            lambdaExpression.Compile().Invoke();


            var unit = new ExpressionTests();
            unit.Expression_from_variable();
        }
    }
}
