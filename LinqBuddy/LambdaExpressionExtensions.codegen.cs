using System;
using System.Linq.Expressions;

namespace Kladzey.LinqBuddy
{
    public static partial class LambdaExpressionExtensions
    {
        /// <summary>
        /// Call expression with 0 arguments.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="expression">Expression to call.</param>
        /// <returns>Result.</returns>
        public static TResult Call<TResult>(this Expression<Func<TResult>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            return expression.Compile().Invoke();
        }

        /// <summary>
        /// Call expression with 1 arguments.
        /// </summary>
        /// <typeparam name="T1">The type of argument 1.</typeparam>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="expression">Expression to call.</param>
        /// <param name="arg1">Argument 1.</param>
        /// <returns>Result.</returns>
        public static TResult Call<T1, TResult>(this Expression<Func<T1, TResult>> expression, T1 arg1)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            return expression.Compile().Invoke(arg1);
        }

        /// <summary>
        /// Call expression with 2 arguments.
        /// </summary>
        /// <typeparam name="T1">The type of argument 1.</typeparam>
        /// <typeparam name="T2">The type of argument 2.</typeparam>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="expression">Expression to call.</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <returns>Result.</returns>
        public static TResult Call<T1, T2, TResult>(this Expression<Func<T1, T2, TResult>> expression, T1 arg1, T2 arg2)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            return expression.Compile().Invoke(arg1, arg2);
        }

        /// <summary>
        /// Call expression with 3 arguments.
        /// </summary>
        /// <typeparam name="T1">The type of argument 1.</typeparam>
        /// <typeparam name="T2">The type of argument 2.</typeparam>
        /// <typeparam name="T3">The type of argument 3.</typeparam>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="expression">Expression to call.</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <param name="arg3">Argument 3.</param>
        /// <returns>Result.</returns>
        public static TResult Call<T1, T2, T3, TResult>(this Expression<Func<T1, T2, T3, TResult>> expression, T1 arg1, T2 arg2, T3 arg3)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            return expression.Compile().Invoke(arg1, arg2, arg3);
        }

        /// <summary>
        /// Call expression with 4 arguments.
        /// </summary>
        /// <typeparam name="T1">The type of argument 1.</typeparam>
        /// <typeparam name="T2">The type of argument 2.</typeparam>
        /// <typeparam name="T3">The type of argument 3.</typeparam>
        /// <typeparam name="T4">The type of argument 4.</typeparam>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="expression">Expression to call.</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <param name="arg3">Argument 3.</param>
        /// <param name="arg4">Argument 4.</param>
        /// <returns>Result.</returns>
        public static TResult Call<T1, T2, T3, T4, TResult>(this Expression<Func<T1, T2, T3, T4, TResult>> expression, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            return expression.Compile().Invoke(arg1, arg2, arg3, arg4);
        }

        /// <summary>
        /// Call expression with 5 arguments.
        /// </summary>
        /// <typeparam name="T1">The type of argument 1.</typeparam>
        /// <typeparam name="T2">The type of argument 2.</typeparam>
        /// <typeparam name="T3">The type of argument 3.</typeparam>
        /// <typeparam name="T4">The type of argument 4.</typeparam>
        /// <typeparam name="T5">The type of argument 5.</typeparam>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="expression">Expression to call.</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <param name="arg3">Argument 3.</param>
        /// <param name="arg4">Argument 4.</param>
        /// <param name="arg5">Argument 5.</param>
        /// <returns>Result.</returns>
        public static TResult Call<T1, T2, T3, T4, T5, TResult>(this Expression<Func<T1, T2, T3, T4, T5, TResult>> expression, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            return expression.Compile().Invoke(arg1, arg2, arg3, arg4, arg5);
        }

        /// <summary>
        /// Call expression with 6 arguments.
        /// </summary>
        /// <typeparam name="T1">The type of argument 1.</typeparam>
        /// <typeparam name="T2">The type of argument 2.</typeparam>
        /// <typeparam name="T3">The type of argument 3.</typeparam>
        /// <typeparam name="T4">The type of argument 4.</typeparam>
        /// <typeparam name="T5">The type of argument 5.</typeparam>
        /// <typeparam name="T6">The type of argument 6.</typeparam>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="expression">Expression to call.</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <param name="arg3">Argument 3.</param>
        /// <param name="arg4">Argument 4.</param>
        /// <param name="arg5">Argument 5.</param>
        /// <param name="arg6">Argument 6.</param>
        /// <returns>Result.</returns>
        public static TResult Call<T1, T2, T3, T4, T5, T6, TResult>(this Expression<Func<T1, T2, T3, T4, T5, T6, TResult>> expression, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            return expression.Compile().Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
        }

        /// <summary>
        /// Call expression with 7 arguments.
        /// </summary>
        /// <typeparam name="T1">The type of argument 1.</typeparam>
        /// <typeparam name="T2">The type of argument 2.</typeparam>
        /// <typeparam name="T3">The type of argument 3.</typeparam>
        /// <typeparam name="T4">The type of argument 4.</typeparam>
        /// <typeparam name="T5">The type of argument 5.</typeparam>
        /// <typeparam name="T6">The type of argument 6.</typeparam>
        /// <typeparam name="T7">The type of argument 7.</typeparam>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="expression">Expression to call.</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <param name="arg3">Argument 3.</param>
        /// <param name="arg4">Argument 4.</param>
        /// <param name="arg5">Argument 5.</param>
        /// <param name="arg6">Argument 6.</param>
        /// <param name="arg7">Argument 7.</param>
        /// <returns>Result.</returns>
        public static TResult Call<T1, T2, T3, T4, T5, T6, T7, TResult>(this Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> expression, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            return expression.Compile().Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        /// <summary>
        /// Call expression with 8 arguments.
        /// </summary>
        /// <typeparam name="T1">The type of argument 1.</typeparam>
        /// <typeparam name="T2">The type of argument 2.</typeparam>
        /// <typeparam name="T3">The type of argument 3.</typeparam>
        /// <typeparam name="T4">The type of argument 4.</typeparam>
        /// <typeparam name="T5">The type of argument 5.</typeparam>
        /// <typeparam name="T6">The type of argument 6.</typeparam>
        /// <typeparam name="T7">The type of argument 7.</typeparam>
        /// <typeparam name="T8">The type of argument 8.</typeparam>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="expression">Expression to call.</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <param name="arg3">Argument 3.</param>
        /// <param name="arg4">Argument 4.</param>
        /// <param name="arg5">Argument 5.</param>
        /// <param name="arg6">Argument 6.</param>
        /// <param name="arg7">Argument 7.</param>
        /// <param name="arg8">Argument 8.</param>
        /// <returns>Result.</returns>
        public static TResult Call<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> expression, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            return expression.Compile().Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        /// <summary>
        /// Call expression with 9 arguments.
        /// </summary>
        /// <typeparam name="T1">The type of argument 1.</typeparam>
        /// <typeparam name="T2">The type of argument 2.</typeparam>
        /// <typeparam name="T3">The type of argument 3.</typeparam>
        /// <typeparam name="T4">The type of argument 4.</typeparam>
        /// <typeparam name="T5">The type of argument 5.</typeparam>
        /// <typeparam name="T6">The type of argument 6.</typeparam>
        /// <typeparam name="T7">The type of argument 7.</typeparam>
        /// <typeparam name="T8">The type of argument 8.</typeparam>
        /// <typeparam name="T9">The type of argument 9.</typeparam>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="expression">Expression to call.</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <param name="arg3">Argument 3.</param>
        /// <param name="arg4">Argument 4.</param>
        /// <param name="arg5">Argument 5.</param>
        /// <param name="arg6">Argument 6.</param>
        /// <param name="arg7">Argument 7.</param>
        /// <param name="arg8">Argument 8.</param>
        /// <param name="arg9">Argument 9.</param>
        /// <returns>Result.</returns>
        public static TResult Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>> expression, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            return expression.Compile().Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }

        /// <summary>
        /// Call expression with 10 arguments.
        /// </summary>
        /// <typeparam name="T1">The type of argument 1.</typeparam>
        /// <typeparam name="T2">The type of argument 2.</typeparam>
        /// <typeparam name="T3">The type of argument 3.</typeparam>
        /// <typeparam name="T4">The type of argument 4.</typeparam>
        /// <typeparam name="T5">The type of argument 5.</typeparam>
        /// <typeparam name="T6">The type of argument 6.</typeparam>
        /// <typeparam name="T7">The type of argument 7.</typeparam>
        /// <typeparam name="T8">The type of argument 8.</typeparam>
        /// <typeparam name="T9">The type of argument 9.</typeparam>
        /// <typeparam name="T10">The type of argument 10.</typeparam>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="expression">Expression to call.</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <param name="arg3">Argument 3.</param>
        /// <param name="arg4">Argument 4.</param>
        /// <param name="arg5">Argument 5.</param>
        /// <param name="arg6">Argument 6.</param>
        /// <param name="arg7">Argument 7.</param>
        /// <param name="arg8">Argument 8.</param>
        /// <param name="arg9">Argument 9.</param>
        /// <param name="arg10">Argument 10.</param>
        /// <returns>Result.</returns>
        public static TResult Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(this Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>> expression, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            return expression.Compile().Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
        }

        /// <summary>
        /// Call expression with 11 arguments.
        /// </summary>
        /// <typeparam name="T1">The type of argument 1.</typeparam>
        /// <typeparam name="T2">The type of argument 2.</typeparam>
        /// <typeparam name="T3">The type of argument 3.</typeparam>
        /// <typeparam name="T4">The type of argument 4.</typeparam>
        /// <typeparam name="T5">The type of argument 5.</typeparam>
        /// <typeparam name="T6">The type of argument 6.</typeparam>
        /// <typeparam name="T7">The type of argument 7.</typeparam>
        /// <typeparam name="T8">The type of argument 8.</typeparam>
        /// <typeparam name="T9">The type of argument 9.</typeparam>
        /// <typeparam name="T10">The type of argument 10.</typeparam>
        /// <typeparam name="T11">The type of argument 11.</typeparam>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="expression">Expression to call.</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <param name="arg3">Argument 3.</param>
        /// <param name="arg4">Argument 4.</param>
        /// <param name="arg5">Argument 5.</param>
        /// <param name="arg6">Argument 6.</param>
        /// <param name="arg7">Argument 7.</param>
        /// <param name="arg8">Argument 8.</param>
        /// <param name="arg9">Argument 9.</param>
        /// <param name="arg10">Argument 10.</param>
        /// <param name="arg11">Argument 11.</param>
        /// <returns>Result.</returns>
        public static TResult Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(this Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>> expression, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            return expression.Compile().Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
        }

        /// <summary>
        /// Call expression with 12 arguments.
        /// </summary>
        /// <typeparam name="T1">The type of argument 1.</typeparam>
        /// <typeparam name="T2">The type of argument 2.</typeparam>
        /// <typeparam name="T3">The type of argument 3.</typeparam>
        /// <typeparam name="T4">The type of argument 4.</typeparam>
        /// <typeparam name="T5">The type of argument 5.</typeparam>
        /// <typeparam name="T6">The type of argument 6.</typeparam>
        /// <typeparam name="T7">The type of argument 7.</typeparam>
        /// <typeparam name="T8">The type of argument 8.</typeparam>
        /// <typeparam name="T9">The type of argument 9.</typeparam>
        /// <typeparam name="T10">The type of argument 10.</typeparam>
        /// <typeparam name="T11">The type of argument 11.</typeparam>
        /// <typeparam name="T12">The type of argument 12.</typeparam>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="expression">Expression to call.</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <param name="arg3">Argument 3.</param>
        /// <param name="arg4">Argument 4.</param>
        /// <param name="arg5">Argument 5.</param>
        /// <param name="arg6">Argument 6.</param>
        /// <param name="arg7">Argument 7.</param>
        /// <param name="arg8">Argument 8.</param>
        /// <param name="arg9">Argument 9.</param>
        /// <param name="arg10">Argument 10.</param>
        /// <param name="arg11">Argument 11.</param>
        /// <param name="arg12">Argument 12.</param>
        /// <returns>Result.</returns>
        public static TResult Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(this Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>> expression, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            return expression.Compile().Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
        }

        /// <summary>
        /// Call expression with 13 arguments.
        /// </summary>
        /// <typeparam name="T1">The type of argument 1.</typeparam>
        /// <typeparam name="T2">The type of argument 2.</typeparam>
        /// <typeparam name="T3">The type of argument 3.</typeparam>
        /// <typeparam name="T4">The type of argument 4.</typeparam>
        /// <typeparam name="T5">The type of argument 5.</typeparam>
        /// <typeparam name="T6">The type of argument 6.</typeparam>
        /// <typeparam name="T7">The type of argument 7.</typeparam>
        /// <typeparam name="T8">The type of argument 8.</typeparam>
        /// <typeparam name="T9">The type of argument 9.</typeparam>
        /// <typeparam name="T10">The type of argument 10.</typeparam>
        /// <typeparam name="T11">The type of argument 11.</typeparam>
        /// <typeparam name="T12">The type of argument 12.</typeparam>
        /// <typeparam name="T13">The type of argument 13.</typeparam>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="expression">Expression to call.</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <param name="arg3">Argument 3.</param>
        /// <param name="arg4">Argument 4.</param>
        /// <param name="arg5">Argument 5.</param>
        /// <param name="arg6">Argument 6.</param>
        /// <param name="arg7">Argument 7.</param>
        /// <param name="arg8">Argument 8.</param>
        /// <param name="arg9">Argument 9.</param>
        /// <param name="arg10">Argument 10.</param>
        /// <param name="arg11">Argument 11.</param>
        /// <param name="arg12">Argument 12.</param>
        /// <param name="arg13">Argument 13.</param>
        /// <returns>Result.</returns>
        public static TResult Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(this Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>> expression, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            return expression.Compile().Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
        }

        /// <summary>
        /// Call expression with 14 arguments.
        /// </summary>
        /// <typeparam name="T1">The type of argument 1.</typeparam>
        /// <typeparam name="T2">The type of argument 2.</typeparam>
        /// <typeparam name="T3">The type of argument 3.</typeparam>
        /// <typeparam name="T4">The type of argument 4.</typeparam>
        /// <typeparam name="T5">The type of argument 5.</typeparam>
        /// <typeparam name="T6">The type of argument 6.</typeparam>
        /// <typeparam name="T7">The type of argument 7.</typeparam>
        /// <typeparam name="T8">The type of argument 8.</typeparam>
        /// <typeparam name="T9">The type of argument 9.</typeparam>
        /// <typeparam name="T10">The type of argument 10.</typeparam>
        /// <typeparam name="T11">The type of argument 11.</typeparam>
        /// <typeparam name="T12">The type of argument 12.</typeparam>
        /// <typeparam name="T13">The type of argument 13.</typeparam>
        /// <typeparam name="T14">The type of argument 14.</typeparam>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="expression">Expression to call.</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <param name="arg3">Argument 3.</param>
        /// <param name="arg4">Argument 4.</param>
        /// <param name="arg5">Argument 5.</param>
        /// <param name="arg6">Argument 6.</param>
        /// <param name="arg7">Argument 7.</param>
        /// <param name="arg8">Argument 8.</param>
        /// <param name="arg9">Argument 9.</param>
        /// <param name="arg10">Argument 10.</param>
        /// <param name="arg11">Argument 11.</param>
        /// <param name="arg12">Argument 12.</param>
        /// <param name="arg13">Argument 13.</param>
        /// <param name="arg14">Argument 14.</param>
        /// <returns>Result.</returns>
        public static TResult Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(this Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>> expression, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            return expression.Compile().Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
        }

        /// <summary>
        /// Call expression with 15 arguments.
        /// </summary>
        /// <typeparam name="T1">The type of argument 1.</typeparam>
        /// <typeparam name="T2">The type of argument 2.</typeparam>
        /// <typeparam name="T3">The type of argument 3.</typeparam>
        /// <typeparam name="T4">The type of argument 4.</typeparam>
        /// <typeparam name="T5">The type of argument 5.</typeparam>
        /// <typeparam name="T6">The type of argument 6.</typeparam>
        /// <typeparam name="T7">The type of argument 7.</typeparam>
        /// <typeparam name="T8">The type of argument 8.</typeparam>
        /// <typeparam name="T9">The type of argument 9.</typeparam>
        /// <typeparam name="T10">The type of argument 10.</typeparam>
        /// <typeparam name="T11">The type of argument 11.</typeparam>
        /// <typeparam name="T12">The type of argument 12.</typeparam>
        /// <typeparam name="T13">The type of argument 13.</typeparam>
        /// <typeparam name="T14">The type of argument 14.</typeparam>
        /// <typeparam name="T15">The type of argument 15.</typeparam>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="expression">Expression to call.</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <param name="arg3">Argument 3.</param>
        /// <param name="arg4">Argument 4.</param>
        /// <param name="arg5">Argument 5.</param>
        /// <param name="arg6">Argument 6.</param>
        /// <param name="arg7">Argument 7.</param>
        /// <param name="arg8">Argument 8.</param>
        /// <param name="arg9">Argument 9.</param>
        /// <param name="arg10">Argument 10.</param>
        /// <param name="arg11">Argument 11.</param>
        /// <param name="arg12">Argument 12.</param>
        /// <param name="arg13">Argument 13.</param>
        /// <param name="arg14">Argument 14.</param>
        /// <param name="arg15">Argument 15.</param>
        /// <returns>Result.</returns>
        public static TResult Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(this Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>> expression, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            return expression.Compile().Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
        }

        /// <summary>
        /// Call expression with 16 arguments.
        /// </summary>
        /// <typeparam name="T1">The type of argument 1.</typeparam>
        /// <typeparam name="T2">The type of argument 2.</typeparam>
        /// <typeparam name="T3">The type of argument 3.</typeparam>
        /// <typeparam name="T4">The type of argument 4.</typeparam>
        /// <typeparam name="T5">The type of argument 5.</typeparam>
        /// <typeparam name="T6">The type of argument 6.</typeparam>
        /// <typeparam name="T7">The type of argument 7.</typeparam>
        /// <typeparam name="T8">The type of argument 8.</typeparam>
        /// <typeparam name="T9">The type of argument 9.</typeparam>
        /// <typeparam name="T10">The type of argument 10.</typeparam>
        /// <typeparam name="T11">The type of argument 11.</typeparam>
        /// <typeparam name="T12">The type of argument 12.</typeparam>
        /// <typeparam name="T13">The type of argument 13.</typeparam>
        /// <typeparam name="T14">The type of argument 14.</typeparam>
        /// <typeparam name="T15">The type of argument 15.</typeparam>
        /// <typeparam name="T16">The type of argument 16.</typeparam>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="expression">Expression to call.</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <param name="arg3">Argument 3.</param>
        /// <param name="arg4">Argument 4.</param>
        /// <param name="arg5">Argument 5.</param>
        /// <param name="arg6">Argument 6.</param>
        /// <param name="arg7">Argument 7.</param>
        /// <param name="arg8">Argument 8.</param>
        /// <param name="arg9">Argument 9.</param>
        /// <param name="arg10">Argument 10.</param>
        /// <param name="arg11">Argument 11.</param>
        /// <param name="arg12">Argument 12.</param>
        /// <param name="arg13">Argument 13.</param>
        /// <param name="arg14">Argument 14.</param>
        /// <param name="arg15">Argument 15.</param>
        /// <param name="arg16">Argument 16.</param>
        /// <returns>Result.</returns>
        public static TResult Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(this Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>> expression, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            return expression.Compile().Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
        }

    }
}