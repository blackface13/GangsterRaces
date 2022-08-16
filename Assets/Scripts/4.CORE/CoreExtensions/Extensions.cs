using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class Extensions
{
    /// <summary>
    /// Clone object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static List<T> GetClone<T>(this List<T> source)
    {
        return source.GetRange(0, source.Count);
    }

    public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
    {
        return listToClone.Select(item => (T)item.Clone()).ToList();
    }

    public static T CloneObject<T>(this T obj) where T : ICloneable
    {
        return (T)obj.Clone();
    }

    /// <summary>
    /// Clone object với json
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static T CloneJson<T>(this T source)
    {
        if (ReferenceEquals(source, null)) return default;

        var deserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };
        return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source), deserializeSettings);
    }

    /// <summary>
    /// Mapping dữ liệu giữa 2 object cùng Type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="source2"></param>
    /// <returns></returns>
    public static T Mapping<T>(this T source, T source2)
    {
        foreach (var prop in typeof(T).GetProperties())
        {
            prop.SetValue(source, prop.GetValue(source2));
        }

        return source;
    }

    /// <summary>
    /// Chuyển sang TimeSpan với các giá trị thời gian kiểu float
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static TimeSpan ToTimeSpan(this float value)
    {
        return TimeSpan.FromSeconds(value);
    }

    /// <summary>
    /// Chuyển sang milisecond với các giá trị thời gian kiểu giây
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int ToMiliseconds(this float value)
    {
        return Convert.ToInt32(value * 1000);
    }

    public static void CountTime(this object obj, Action action)
    {
        Stopwatch time = new Stopwatch();
        time.Start();
        action();
        time.Stop();
        UnityEngine.Debug.Log(action.GetMethodInfo().Name + ": " + time.ElapsedMilliseconds);
    }

    /// <summary>
    /// Di chuyển 1 item trong list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="itemSelector"></param>
    /// <param name="newIndex"></param>
    public static void Move<T>(this List<T> list, Predicate<T> itemSelector, int newIndex)
    {
        var currentIndex = list.FindIndex(itemSelector);

        var item = list[currentIndex];

        list.RemoveAt(currentIndex);

        list.Insert(newIndex, item);
    }

    public static bool EqualsCustom<TEnum>(Enum first, TEnum second)
        where TEnum : struct
    {
        var asEnumType = first as TEnum?;
        return asEnumType != null && EqualityComparer<TEnum>.Default.Equals(asEnumType.Value, second);
    }

    #region String extensions
    /// <summary>
    /// Giống EndsWith nhưng hiệu năng tốt hơn
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool EndsWithCustom(this string a, string b)
    {
        int ap = a.Length - 1;
        int bp = b.Length - 1;

        while (ap >= 0 && bp >= 0 && a[ap] == b[bp])
        {
            ap--;
            bp--;
        }

        return (bp < 0);
    }

    /// <summary>
    /// Giống StartsWith nhưng hiệu năng tốt hơn
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool StartsWithCustom(this string a, string b)
    {
        int aLen = a.Length;
        int bLen = b.Length;

        int ap = 0; int bp = 0;

        while (ap < aLen && bp < bLen && a[ap] == b[bp])
        {
            ap++;
            bp++;
        }

        return (bp == bLen);
    }
    public static string ToStr(this object str)
    {
        return str.ToString().Trim();
    }

    public static string AppendCutom(this string str, object value)
    {
        return $"{str}{value}";
    }

    /// <summary>
    /// Áp dụng color vào text
    /// </summary>
    /// <param name="str"></param>
    /// <param name="hex"></param>
    /// <returns></returns>
    public static string SetColor(this string str, string hex)
    {
        hex = hex.Replace("#", "");
        return $"<color=#{hex}>{str}</color>";
    }
    public static string SetColorStr(this string str, string colorStr)
    {
        return $"<color={colorStr}>{str}</color>";
    }
    #endregion

    #region GameObject
    public static IEnumerator AutoHidden(this GameObject obj, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        obj.SetActive(false);
    }

    public static IEnumerator ChangeWithDuration(this float thisValue, float toValue, float duration)
    {
        float time = 0;
        float rate = 1 / duration;
        while (time < 1)
        {
            time += rate * Time.deltaTime;
            thisValue = Mathf.Lerp(thisValue, toValue, time);
            yield return null;
        }
    }

    public static IEnumerator ChangeWithDuration(this float thisValue, float toValue, float duration, Action completeAction = null)
    {
        float time = 0;
        float rate = 1 / duration;
        while (time < 1)
        {
            time += rate * Time.deltaTime;
            thisValue = Mathf.Lerp(thisValue, toValue, time);
            yield return null;
        }

        if (completeAction != null)
            completeAction();
    }

    public static IEnumerator ChangeWithDuration(this float thisValue, float fromValue, float toValue, float duration)
    {
        float time = 0;
        float rate = 1 / duration;
        thisValue = fromValue;
        while (time < 1)
        {
            time += rate * Time.deltaTime;
            thisValue = Mathf.Lerp(fromValue, toValue, time);
            yield return null;
        }
    }
    #endregion
}