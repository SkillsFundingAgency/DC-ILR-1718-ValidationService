using FluentAssertions;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace ESFA.DC.ILR.Model.Tests.Abstract
{
    public class AbstractModelTests<T> where T : new()
    {
        protected DateTime DateTime()
        {
            return new DateTime(2018, 1, 1);
        }

        protected long Long()
        {
            return 12345678910;
        }

        protected decimal Decimal()
        {
            return 1.234M;
        }

        protected T TestNullableSpecifiedTrue<TValue, TNullable>(Expression<Func<T, TValue>> propertyExpression, TValue value,  Expression<Func<T, bool>> specifiedPropertyExpression, Expression<Func<T, TNullable>> nullablePropertyExpression)
        {
            var modelObject = new T();

            Set(modelObject, propertyExpression, value);
            Set(modelObject, specifiedPropertyExpression, true);

            var nullable = Get(modelObject, nullablePropertyExpression);

            nullable.Should().Be(value);
            nullable.Should().NotBeNull();     

            return modelObject;
        }

        protected T TestNullableSpecifiedFalse<TValue, TNullable>(Expression<Func<T, TValue>> propertyExpression, TValue value, Expression<Func<T, bool>> specifiedPropertyExpression, Expression<Func<T, TNullable>> nullablePropertyExpression)
        {
            var modelObject = new T();

            Set(modelObject, propertyExpression, value);
            Set(modelObject, specifiedPropertyExpression, false);

            var nullable = Get(modelObject, nullablePropertyExpression);

            nullable.Should().BeNull();

            return modelObject;
        }

        private T Set<TValue>(T input, Expression<Func<T, TValue>> expression, TValue value)
        {
            MemberExpression body = expression.Body as MemberExpression;

            if (body == null)
            {
                throw new ArgumentException("The provided lambda expression '" + expression.Body + "' must refer to a property of : " + typeof(T).Name);
            }

            PropertyInfo member = body.Member as PropertyInfo;

            if (member == null)
            {
                throw new ArgumentException("The provided lambda expression '" + body.Member + "'  must refer to a property of : " + typeof(T).Name);
            }

            member.SetValue(input, value, null);
            
            return input;
        }

        private TValue Get<TValue>(T input, Expression<Func<T, TValue>> expression)
        {
            MemberExpression body = expression.Body as MemberExpression;

            if (body == null)
            {
                throw new ArgumentException("The provided lambda expression '" + expression.Body + "' must refer to a property of : " + typeof(T).Name);
            }

            PropertyInfo member = body.Member as PropertyInfo;

            if (member == null)
            {
                throw new ArgumentException("The provided lambda expression '" + body.Member + "'  must refer to a property of : " + typeof(T).Name);
            }

            return (TValue)member.GetValue(input);
        }
    }
}
