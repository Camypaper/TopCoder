using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
[TestClass]
public class UnitTest
{
    public List<Action> Tests = new List<Action>(){};
    public UnitTest()
    {
        Tests.Add(Example0);Tests.Add(Example1);Tests.Add(Example2);Tests.Add(Example3);Tests.Add(Example4);Tests.Add(Example5);    }
    public void ManualTest(int[] value)
    {
        Console.WriteLine(string.Format("value:{0}", string.Join(" ",value)));
        string __result = new FoxAndSouvenirTheNext().ableToSplit(value);
        Console.WriteLine("__result:{0}", __result);
    }

    [TestMethod]
    public void Example0()
    {
        int[] value = new int[] {
            1,
            2,
            3,
            4
        };
        Console.WriteLine(string.Format("value:{0}", string.Join(" ", value)));
        string __expected = "Possible";
        Console.WriteLine("__expected:{0}", __expected);
        string __result = new FoxAndSouvenirTheNext().ableToSplit(value);
        Console.WriteLine("__result:{0}", __result);
        Assert.AreEqual(__expected, __result);
    }

    [TestMethod]
    public void Example1()
    {
        int[] value = new int[] {
            1,
            1,
            1,
            3
        };
        Console.WriteLine(string.Format("value:{0}", string.Join(" ", value)));
        string __expected = "Impossible";
        Console.WriteLine("__expected:{0}", __expected);
        string __result = new FoxAndSouvenirTheNext().ableToSplit(value);
        Console.WriteLine("__result:{0}", __result);
        Assert.AreEqual(__expected, __result);
    }

    [TestMethod]
    public void Example2()
    {
        int[] value = new int[] {
            1,
            1,
            2,
            3,
            5,
            8
        };
        Console.WriteLine(string.Format("value:{0}", string.Join(" ", value)));
        string __expected = "Possible";
        Console.WriteLine("__expected:{0}", __expected);
        string __result = new FoxAndSouvenirTheNext().ableToSplit(value);
        Console.WriteLine("__result:{0}", __result);
        Assert.AreEqual(__expected, __result);
    }

    [TestMethod]
    public void Example3()
    {
        int[] value = new int[] {
            2,
            3,
            5,
            7,
            11,
            13
        };
        Console.WriteLine(string.Format("value:{0}", string.Join(" ", value)));
        string __expected = "Impossible";
        Console.WriteLine("__expected:{0}", __expected);
        string __result = new FoxAndSouvenirTheNext().ableToSplit(value);
        Console.WriteLine("__result:{0}", __result);
        Assert.AreEqual(__expected, __result);
    }

    [TestMethod]
    public void Example4()
    {
        int[] value = new int[] {
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10,
            11,
            12,
            13,
            14,
            15,
            16,
            17,
            18,
            19,
            20,
            21,
            22,
            23,
            24,
            25,
            26,
            27,
            28,
            29,
            30,
            31,
            32,
            33,
            34,
            35,
            36,
            37,
            38,
            39,
            40,
            41,
            42,
            43,
            44,
            45,
            46,
            47,
            48
        };
        Console.WriteLine(string.Format("value:{0}", string.Join(" ", value)));
        string __expected = "Possible";
        Console.WriteLine("__expected:{0}", __expected);
        string __result = new FoxAndSouvenirTheNext().ableToSplit(value);
        Console.WriteLine("__result:{0}", __result);
        Assert.AreEqual(__expected, __result);
    }

    [TestMethod]
    public void Example5()
    {
        int[] value = new int[] {
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10,
            11,
            12,
            13,
            14,
            15,
            16,
            17,
            18,
            19,
            20,
            21,
            22,
            23,
            24,
            25,
            26,
            27,
            28,
            29,
            30,
            31,
            32,
            33,
            34,
            35,
            36,
            37,
            38,
            39,
            40,
            41,
            42,
            43,
            44,
            45,
            46,
            47,
            48,
            49,
            50
        };
        Console.WriteLine(string.Format("value:{0}", string.Join(" ", value)));
        string __expected = "Impossible";
        Console.WriteLine("__expected:{0}", __expected);
        string __result = new FoxAndSouvenirTheNext().ableToSplit(value);
        Console.WriteLine("__result:{0}", __result);
        Assert.AreEqual(__expected, __result);
    }

}
