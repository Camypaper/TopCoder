using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Debug = System.Diagnostics.Debug;
using StringBuilder = System.Text.StringBuilder;
public class MoveStones
{
    public long get(int[] a, int[] b)
    {
        var n = a.Length;
        var A = a.Select(x => (long)x).ToArray();
        var B = b.Select(x => (long)x).ToArray();
        if (A.Sum() != B.Sum()) return -1;
        var G = Enumerate(2 * n + 2, x => new List<Edge<long, long>>());
        var s = 2 * n;
        var t = 2 * n + 1;
        for (int i = 0; i < n; i++)
        {
            G.AddDirectedEdge(i, n + i, 1L << 60, 0);
            G.AddDirectedEdge(i, (i + 1) % n, 1L << 60, 1);
            G.AddDirectedEdge(n + i, n + ((i + n - 1) % n), 1L << 60, 1);
            G.AddDirectedEdge(s, i, A[i], 0);
            G.AddDirectedEdge(n + i, t, B[i], 0);
        }
        var ret = Flow.PrimalDual(G, s, t, A.Sum());


        return ret.x;
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

#region CostEdge
static public class Edge
{
    static public Edge<C, V> Create<C, V>(int t, int r, C _cap, V _cost) { return new Edge<C, V>(t, r, _cap, _cost); }
}
public class Edge<C, V>
{
    public int to, rev;
    public C cap;
    public V cost;
    public Edge(int t, int r, C _cap, V _cost) { to = t; rev = r; cap = _cap; cost = _cost; }
    public override string ToString() { return string.Format("{0}: Capacity {1}, Cost{2}", to, cap, cost); }
}
#endregion

#region AddCostEdge
static public partial class Flow
{
    static public void AddDirectedEdge(this List<Edge<long, long>>[] G, int from, int to, long cap, long cost)
    {
        G[from].Add(Edge.Create(to, G[to].Count, cap, cost));
        G[to].Add(Edge.Create(from, G[from].Count - 1, 0L, -cost));
    }
    static public void AddDirectedEdge(this List<Edge<int, double>>[] G, int from, int to, int cap, double cost)
    {
        G[from].Add(Edge.Create(to, G[to].Count, cap, cost));
        G[to].Add(Edge.Create(from, G[from].Count - 1, 0, -cost));
    }

}
#endregion


#region Integer MinCostFlow
static public partial class Flow
{
    /// <summary>
    /// �ŏ���p����primal-dual�@�ł��
    /// </summary>
    /// <param name="G">�O���t</param>
    /// <param name="s">�n�_</param>
    /// <param name="t">�I�_</param>
    /// <param name="f">�����ő嗬��</param>
    /// <param name="INF">�K���ȍő�l</param>
    /// <returns></returns>
    static public Pair<long, long> PrimalDual(List<Edge<long, long>>[] G, int s, int t, long f, long INF = 1 << 60)
    {
        var n = G.Length;
        var dist = new long[n];
        var prev = new int[n];
        var prevEdge = new int[n];
        var total = new Pair<long, long>(0, 0);
        var potential = new long[n];
        while (f > 0)
        {
            for (int i = 0; i < n; i++)
                dist[i] = INF;
            //shortest path
            {
                var vis = new bool[n];
                var pq = new PriorityQueue<Pair<long, int>>();
                pq.Enqueue(new Pair<long, int>(0, s));
                dist[s] = 0;
                while (pq.Any())
                {
                    var p = pq.Dequeue().y;
                    if (vis[p]) continue;
                    vis[p] = true;
                    for (int i = 0; i < G[p].Count; i++)
                    {
                        var e = G[p][i];
                        if (e.cap <= 0) continue;
                        var j = e.to;
                        var d = dist[p] + e.cost + potential[p] - potential[j];
                        if (dist[j] > d)
                        {
                            dist[j] = d; prev[j] = p; prevEdge[j] = i;
                            pq.Enqueue(new Pair<long, int>(d, j));
                        }
                    }
                }


            }


            //update
            {
                if (dist[t] == INF) break;
                for (int i = 0; i < n; i++)
                    potential[i] += dist[i];
                var d = f; var distt = 0L;
                for (var v = t; v != s;)
                {
                    var u = prev[v]; var e = G[u][prevEdge[v]];
                    d = Math.Min(d, e.cap); distt += e.cost; v = u;
                }
                f -= d; total.x += d * distt; total.y += d;
                for (var v = t; v != s; v = prev[v])
                {
                    var e = G[prev[v]][prevEdge[v]];
                    e.cap -= d; G[e.to][e.rev].cap += d;
                }
            }

        }
        return total;
    }
}
#endregion

#region PriorityQueue and PairingHeap
public class PriorityQueue<T>
{
    PairingHeap<T> top;
    Comparison<T> compare;
    int size;
    public int Count { get { return size; } }
    public PriorityQueue() : this(Comparer<T>.Default) { }
    public PriorityQueue(Comparison<T> comparison) { compare = comparison; }
    public PriorityQueue(IComparer<T> comparer) { compare = comparer.Compare; }
    public void Enqueue(T item)
    {
        var heap = new PairingHeap<T>(item);
        top = PairingHeap<T>.Merge(top, heap, compare);
        size++;
    }
    public T Dequeue()
    {
        var ret = top.Key;
        size--;
        top = PairingHeap<T>.Pop(top, compare);
        return ret;
    }
    public bool Any() { return size > 0; }
    public T Peek() { return top.Key; }
}
#region Compair
static public class Pair
{
    static public Pair<FT, ST> Create<FT, ST>(FT f, ST s)
        where FT : IComparable<FT>
        where ST : IComparable<ST>
    { return new Pair<FT, ST>(f, s); }
    static public Pair<FT, ST> Min<FT, ST>(Pair<FT, ST> p, Pair<FT, ST> q)
        where FT : IComparable<FT>
        where ST : IComparable<ST>
    { return (p.CompareTo(q) <= 0) ? p : q; }
    static public Pair<FT, ST> Max<FT, ST>(Pair<FT, ST> p, Pair<FT, ST> q)
        where FT : IComparable<FT>
        where ST : IComparable<ST>
    { return (p.CompareTo(q) >= 0) ? p : q; }
}
public struct Pair<FT, ST> : IComparable<Pair<FT, ST>>
    where FT : IComparable<FT>
    where ST : IComparable<ST>
{
    public FT x;
    public ST y;
    public Pair(FT f, ST s) : this() { x = f; y = s; }

    public int CompareTo(Pair<FT, ST> other)
    {
        var cmp = x.CompareTo(other.x);
        return cmp != 0 ? cmp : y.CompareTo(other.y);
    }
    public override string ToString() { return string.Format("{0} {1}", x, y); }
}
#endregion
#region PairingHeap
public class PairingHeap<T>
{
    public PairingHeap(T k) { key = k; }
    private readonly T key;
    public T Key { get { return key; } }
    private PairingHeap<T> head;
    private PairingHeap<T> next;
    static public PairingHeap<T> Pop(PairingHeap<T> s, Comparison<T> compare)
    {
        return MergeLst(s.head, compare);
    }
    static public PairingHeap<T> Merge(PairingHeap<T> l, PairingHeap<T> r, Comparison<T> compare)
    {
        if (l == null || r == null) return l == null ? r : l;
        if (compare(l.key, r.key) > 0) Swap(ref l, ref r);
        r.next = l.head;
        l.head = r;
        return l;
    }
    static public PairingHeap<T> MergeLst(PairingHeap<T> s, Comparison<T> compare)
    {
        var n = new PairingHeap<T>(default(T));
        while (s != null)
        {
            PairingHeap<T> a = s, b = null;
            s = s.next; a.next = null;
            if (s != null) { b = s; s = s.next; b.next = null; }
            a = Merge(a, b, compare); a.next = n.next;
            n.next = a;
        }
        while (n.next != null)
        {
            var j = n.next;
            n.next = n.next.next;
            s = Merge(j, s, compare);
        }
        return s;
    }
    static void Swap(ref PairingHeap<T> l, ref PairingHeap<T> r) { var t = l; l = r; r = t; }
}
#endregion
#endregion