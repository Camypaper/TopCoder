using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
[TestClass]
public class UnitTest
{
    public List<Action> Tests = new List<Action>(){};
    public UnitTest()
    {
        Tests.Add(Example0);Tests.Add(Example1);Tests.Add(Example2);Tests.Add(Example3);    }
    public void ManualTest(int n)
    {
        Console.WriteLine("n:{0}", n);
        int __result = new LongWordsDiv1().count(n);
        Console.WriteLine("__result:{0}", __result);
    }

    [TestMethod]
    public void Example0()
    {
        int n = 1;
        Console.WriteLine("n:{0}", n);
        int __expected = 1;
        Console.WriteLine("__expected:{0}", __expected);
        int __result = new LongWordsDiv1().count(n);
        Console.WriteLine("__result:{0}", __result);
        Assert.AreEqual(__expected, __result);
    }

    [TestMethod]
    public void Example1()
    {
        int n = 2;
        Console.WriteLine("n:{0}", n);
        int __expected = 2;
        Console.WriteLine("__expected:{0}", __expected);
        int __result = new LongWordsDiv1().count(n);
        Console.WriteLine("__result:{0}", __result);
        Assert.AreEqual(__expected, __result);
    }

    [TestMethod]
    public void Example2()
    {
        int n = 5;
        Console.WriteLine("n:{0}", n);
        int __expected = 1080;
        Console.WriteLine("__expected:{0}", __expected);
        int __result = new LongWordsDiv1().count(n);
        Console.WriteLine("__result:{0}", __result);
        Assert.AreEqual(__expected, __result);
    }

    [TestMethod]
    public void Example3()
    {
        int n = 100;
        Console.WriteLine("n:{0}", n);
        int __expected = 486425238;
        Console.WriteLine("__expected:{0}", __expected);
        int __result = new LongWordsDiv1().count(n);
        Console.WriteLine("__result:{0}", __result);
        Assert.AreEqual(__expected, __result);
    }

}
