namespace System;

public static class ObjectExtensions
{
    /// <summary>
    /// Auto mapper object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="action">The action.</param>
    /// <returns></returns>
    public static TResult Mapper<T, TResult>(this T value, Action<T, TResult>? action = null) where TResult : new()
    {
        return value.Mapper(new TResult(), action);
    }

    /// <summary>
    /// Auto mapper object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="value">The value.</param>
    /// <param name="result">The result.</param>
    /// <param name="action">The action.</param>
    /// <returns></returns>
    public static TResult Mapper<T, TResult>(this T value, TResult result, Action<T, TResult>? action = null)
    {
        var props = typeof(T).GetProperties();

        var resultProps = typeof(TResult).GetProperties();

        foreach (var resultProp in resultProps)
        {
            var prop = props.FirstOrDefault(x => x.Name == resultProp.Name);

            if (prop == null)
            {
                continue;
            }

            var resultValue = prop.GetValue(value);

            resultProp.SetValue(result, resultValue);
        }

        action?.Invoke(value, result);

        return result;
    }
}