using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Debug = System.Diagnostics.Debug;
using StringBuilder = System.Text.StringBuilder;
public class FoxAndWord
{
    public int howManyPairs(string[] words)
    {
        var cnt = 0;
        var n = words.Length;
        for (int i = 0; i < n; i++)
            for (int j = i + 1; j < n; j++)
            {
                if (words[i].Length != words[j].Length) continue;
                for (int l = 1; l < words[i].Length; l++)
                {
                    var a = words[i].Substring(0, l);
                    var b = words[i].Substring(l);
                    if (b + a == words[j]) { cnt++; break; }
                }
            }
        return cnt;
    }

    static public T[] Enumerate<T>(int n, Func<int, T> f) { var a = new T[n]; for (int i = 0; i < n; ++i) a[i] = f(i); return a; }
    static public void Swap<T>(ref T a, ref T b) { var tmp = a; a = b; b = tmp; }
}
static public class EnumerableEX
{
    static public string AsString(this IEnumerable<char> e) { return new string(e.ToArray()); }
    static public string AsJoinedString<T>(this IEnumerable<T> e, string s = " ") { return string.Join(s, e); }
}
// CUT begin
public class Tester : AbstractTester
{
    static public T[] Enumerate<T>(int n, Func<int, T> f) { var a = new T[n]; for (int i = 0; i < n; ++i) a[i] = f(i); return a; }
    public Random rand = new Random(0);
    public Tester()
    {
    }
}
// CUT end
