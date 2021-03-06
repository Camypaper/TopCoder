using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Watch = System.Diagnostics.Stopwatch;
using StringBuilder = System.Text.StringBuilder;
public class PeacefulLine
{
	public string makeLine(int[] x)
    {
        var n = x.Length;
        var a = new int[50];
        foreach (var v in x)
            a[v]++;
        var size = n / 2;
        if (n % 2 == 1)
            size++;
        foreach (var v in a)
        {
            if (v > size)
                return "impossible";
        }
		return "possible";
	}

// CUT begin
    public static void Main(string[] args)
    {
        var stream = new System.IO.StreamWriter("dbg.out");
        System.Diagnostics.Debug.Listeners.Add(new System.Diagnostics.TextWriterTraceListener(stream));
        var sc= new Scanner(Console.In);
        var t = new PeacefulLine();
        var u = new PeacefulLineTest();
        try
        {
            u.Example0();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
        finally
        {
            System.Diagnostics.Debug.Close();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
        }
    }

    public void ManualTest(int[] x)
    {
        var sw = new System.Diagnostics.Stopwatch();
        Console.WriteLine(string.Format("x:{0}",string.Join(" ",x)));        sw.Start();
        var ret = makeLine(x);
        Console.WriteLine("Result:{0}",ret);
        sw.Stop();
        Console.WriteLine("Time:{0}ms",sw.ElapsedMilliseconds);

    }
    
// CUT end
}
static public class EnumerableEX
{
    static public string AsString(this IEnumerable<char> e)
    {
        return new string(e.ToArray());
    }
    static public string AsJoinedString<T>(this IEnumerable<T> e,string s=" ")
    {
        return string.Join(s, e);
    }
}
