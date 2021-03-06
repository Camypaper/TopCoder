using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
[TestClass]
public class UnitTest
{
    public void ManualTest()
    {
        string[] x = Scanner.In.string_array();
        Console.WriteLine(string.Format("x:{0}",string.Join(" ",x)));
        int[] __result  = new OddEvenTree().getTree(x);; ;
        Console.WriteLine(string.Format("__result:{0}",string.Join(" ",__result)));
 
    }

    [TestMethod]
    public void Example0()
    {
        string[] x = new string[] {
            "EOE",
            "OEO",
            "EOE"
        };
        Console.WriteLine(string.Format("x:{0}",string.Join(" ",x)));
        int[] __expected = new int[] {
            0,
            1,
            2,
            1
        };
        Console.WriteLine(string.Format("__expected:{0}",string.Join(" ",__expected)));
        int[] __result = new OddEvenTree().getTree(x);
        Console.WriteLine(string.Format("__result:{0}",string.Join(" ",__result)));
        
            CollectionAssert.AreEquivalent(__expected, __result);
         }

    [TestMethod]
    public void Example1()
    {
        string[] x = new string[] {
            "EO",
            "OE"
        };
        Console.WriteLine(string.Format("x:{0}",string.Join(" ",x)));
        int[] __expected = new int[] {
            0,
            1
        };
        Console.WriteLine(string.Format("__expected:{0}",string.Join(" ",__expected)));
        int[] __result = new OddEvenTree().getTree(x);
        Console.WriteLine(string.Format("__result:{0}",string.Join(" ",__result)));
        
            CollectionAssert.AreEquivalent(__expected, __result);
         }

    [TestMethod]
    public void Example2()
    {
        string[] x = new string[] {
            "OO",
            "OE"
        };
        Console.WriteLine(string.Format("x:{0}",string.Join(" ",x)));
        int[] __expected = new int[] {
            -1
        };
        Console.WriteLine(string.Format("__expected:{0}",string.Join(" ",__expected)));
        int[] __result = new OddEvenTree().getTree(x);
        Console.WriteLine(string.Format("__result:{0}",string.Join(" ",__result)));
        
            CollectionAssert.AreEquivalent(__expected, __result);
         }

    [TestMethod]
    public void Example3()
    {
        string[] x = new string[] {
            "EO",
            "EE"
        };
        Console.WriteLine(string.Format("x:{0}",string.Join(" ",x)));
        int[] __expected = new int[] {
            -1
        };
        Console.WriteLine(string.Format("__expected:{0}",string.Join(" ",__expected)));
        int[] __result = new OddEvenTree().getTree(x);
        Console.WriteLine(string.Format("__result:{0}",string.Join(" ",__result)));
        
            CollectionAssert.AreEquivalent(__expected, __result);
         }

    [TestMethod]
    public void Example4()
    {
        string[] x = new string[] {
            "EOEO",
            "OEOE",
            "EOEO",
            "OEOE"
        };
        Console.WriteLine(string.Format("x:{0}",string.Join(" ",x)));
        int[] __expected = new int[] {
            0,
            1,
            0,
            3,
            2,
            1
        };
        Console.WriteLine(string.Format("__expected:{0}",string.Join(" ",__expected)));
        int[] __result = new OddEvenTree().getTree(x);
        Console.WriteLine(string.Format("__result:{0}",string.Join(" ",__result)));
        
            CollectionAssert.AreEquivalent(__expected, __result);
         }

}
