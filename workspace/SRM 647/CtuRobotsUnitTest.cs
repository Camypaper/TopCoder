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
    public void ManualTest(int B, int[] cost, int[] cap)
    {
        Console.WriteLine("B:{0}", B);
        Console.WriteLine(string.Format("cost:{0}", string.Join(" ",cost)));
        Console.WriteLine(string.Format("cap:{0}", string.Join(" ",cap)));
        double __result = new CtuRobots().maxDist(B, cost, cap);
        Console.WriteLine("__result:{0}", __result);
    }

    [TestMethod]
    public void Example0()
    {
        int B = 100;
        Console.WriteLine("B:{0}", B);
        int[] cost = new int[] {
            50,
            25
        };
        Console.WriteLine(string.Format("cost:{0}", string.Join(" ", cost)));
        int[] cap = new int[] {
            1,
            1
        };
        Console.WriteLine(string.Format("cap:{0}", string.Join(" ", cap)));
        double __expected = 0.6666666666666666;
        Console.WriteLine("__expected:{0}", __expected);
        double __result = new CtuRobots().maxDist(B, cost, cap);
        Console.WriteLine("__result:{0}", __result);
        Assert.AreEqual(__expected, __result, 1e-9);
}

    [TestMethod]
    public void Example1()
    {
        int B = 25;
        Console.WriteLine("B:{0}", B);
        int[] cost = new int[] {
            23,
            5,
            8,
            20,
            15
        };
        Console.WriteLine(string.Format("cost:{0}", string.Join(" ", cost)));
        int[] cap = new int[] {
            108,
            30,
            42,
            100,
            94
        };
        Console.WriteLine(string.Format("cap:{0}", string.Join(" ", cap)));
        double __expected = 55.0;
        Console.WriteLine("__expected:{0}", __expected);
        double __result = new CtuRobots().maxDist(B, cost, cap);
        Console.WriteLine("__result:{0}", __result);
        Assert.AreEqual(__expected, __result, 1e-9);
}

    [TestMethod]
    public void Example2()
    {
        int B = 1382;
        Console.WriteLine("B:{0}", B);
        int[] cost = new int[] {
            0,
            0,
            0,
            1000,
            1000,
            0,
            1000,
            0
        };
        Console.WriteLine(string.Format("cost:{0}", string.Join(" ", cost)));
        int[] cap = new int[] {
            2039,
            4819,
            5923,
            1577,
            8749,
            9182,
            3652,
            4918
        };
        Console.WriteLine(string.Format("cap:{0}", string.Join(" ", cap)));
        double __expected = 6503.238683127572;
        Console.WriteLine("__expected:{0}", __expected);
        double __result = new CtuRobots().maxDist(B, cost, cap);
        Console.WriteLine("__result:{0}", __result);
        Assert.AreEqual(__expected, __result, 1e-9);
}

    [TestMethod]
    public void Example3()
    {
        int B = 209;
        Console.WriteLine("B:{0}", B);
        int[] cost = new int[] {
            185,
            130,
            109,
            1,
            45,
            117,
            127,
            13,
            2,
            37,
            6,
            1,
            2
        };
        Console.WriteLine(string.Format("cost:{0}", string.Join(" ", cost)));
        int[] cap = new int[] {
            93,
            5,
            278,
            4,
            20,
            54,
            93,
            213,
            103,
            5,
            225,
            32,
            5
        };
        Console.WriteLine(string.Format("cap:{0}", string.Join(" ", cap)));
        double __expected = 190.48376771833563;
        Console.WriteLine("__expected:{0}", __expected);
        double __result = new CtuRobots().maxDist(B, cost, cap);
        Console.WriteLine("__result:{0}", __result);
        Assert.AreEqual(__expected, __result, 1e-9);
}

    [TestMethod]
    public void Example4()
    {
        int B = 9956;
        Console.WriteLine("B:{0}", B);
        int[] cost = new int[] {
            3229,
            736,
            1325,
            2680,
            410,
            1227,
            1378,
            499,
            1525,
            1722,
            1262,
            2080,
            2581,
            1505,
            1019,
            480,
            3155,
            836,
            2697,
            616,
            136,
            2032,
            2345,
            3154,
            1953,
            1654,
            344,
            3079,
            1426,
            199,
            2857,
            1714,
            2952,
            996,
            1567,
            2674,
            2054,
            2110,
            949,
            2412,
            2148,
            1016,
            234,
            1932,
            1554,
            1943,
            1625,
            1266,
            258,
            2924,
            49,
            1693,
            3140,
            309,
            557,
            12,
            2760,
            227,
            2497,
            330,
            646,
            1935,
            3032,
            2671,
            2433,
            164,
            1472,
            3080,
            717,
            221,
            2483,
            1309,
            1174,
            12,
            917,
            2335,
            3086,
            148,
            64,
            189,
            2628,
            1660,
            2983,
            109,
            1920,
            2470
        };
        Console.WriteLine(string.Format("cost:{0}", string.Join(" ", cost)));
        int[] cap = new int[] {
            934850,
            214,
            15807606,
            2426,
            176520,
            1900009,
            1184867,
            40550,
            1774843,
            2953,
            77834310,
            7276,
            3139890,
            695,
            213862217,
            13,
            193864,
            189,
            557664,
            1206555,
            85133,
            381662,
            4887,
            115027,
            2186890,
            218075,
            1,
            2024,
            9,
            95244962,
            7,
            906,
            3485642,
            52962078,
            58645759,
            785706,
            303,
            18,
            189,
            819600,
            17528041,
            11616471,
            92719012,
            82351,
            12752,
            634,
            26122233,
            215485,
            58,
            5506810,
            101874,
            130429471,
            2,
            1,
            68966,
            76303,
            321766922,
            463,
            26,
            225,
            207,
            52,
            1739,
            246841,
            496,
            228,
            4749453,
            191,
            79,
            10560,
            1414194,
            7529,
            13,
            521935,
            1,
            2,
            11590618,
            4020,
            105,
            3,
            28,
            3,
            2855,
            189909573,
            1,
            295052
        };
        Console.WriteLine(string.Format("cap:{0}", string.Join(" ", cap)));
        double __expected = 2.1034261053998655E8;
        Console.WriteLine("__expected:{0}", __expected);
        double __result = new CtuRobots().maxDist(B, cost, cap);
        Console.WriteLine("__result:{0}", __result);
        Assert.AreEqual(__expected, __result, 1e-9);
}

    [TestMethod]
    public void Example5()
    {
        int B = 8852;
        Console.WriteLine("B:{0}", B);
        int[] cost = new int[] {
            2547,
            912,
            2592,
            1085,
            296,
            523,
            2257,
            2347,
            1822,
            261,
            334,
            2159,
            528,
            2739,
            201,
            964,
            427,
            2038,
            26,
            2361,
            234,
            2063,
            2885,
            2178,
            2708,
            730,
            2902,
            326,
            306,
            2794,
            1725,
            13,
            137,
            2169,
            388,
            1124,
            1464,
            2120,
            2357,
            1544,
            2794,
            2260,
            185,
            650,
            2852,
            124,
            1767,
            453,
            1331,
            1397,
            1991,
            1166,
            413,
            1428,
            2862,
            1194,
            1139,
            571,
            1299,
            1232,
            267,
            2027,
            746,
            1971,
            2695,
            2586,
            185,
            1319,
            1088,
            2818,
            2604,
            1798,
            475,
            1252,
            1767,
            2277,
            545,
            601,
            2160,
            325,
            2749,
            1161,
            1172,
            1075,
            1925,
            2468,
            1596,
            1116,
            1558,
            2226,
            1302,
            796,
            775,
            1105,
            418,
            334,
            2872,
            1921,
            2830,
            2448,
            2914,
            2634,
            1386,
            2516,
            492,
            1029,
            1134,
            2934,
            2017,
            1741,
            1675,
            2593,
            2233,
            2401,
            68,
            683,
            2053,
            155,
            183,
            923,
            2276,
            1823,
            65,
            2290,
            2448,
            92,
            2468,
            819,
            837,
            303,
            1440,
            705,
            291,
            2348,
            2562,
            765,
            1926,
            14,
            2514,
            2403,
            2671,
            1143,
            1358,
            121,
            376,
            2874,
            2447,
            1769,
            1686,
            967,
            967,
            2492,
            2472,
            2014,
            1686,
            2291,
            1093,
            1801,
            818
        };
        Console.WriteLine(string.Format("cost:{0}", string.Join(" ", cost)));
        int[] cap = new int[] {
            263268,
            256181,
            476791,
            365614,
            265352,
            19307,
            243180,
            84909,
            98175,
            367524,
            241474,
            479623,
            277638,
            111229,
            155356,
            415525,
            234382,
            97870,
            451466,
            58375,
            268277,
            404582,
            484789,
            458230,
            529286,
            449840,
            103208,
            199505,
            319373,
            294746,
            78005,
            326456,
            14418,
            257144,
            135669,
            238651,
            411723,
            99122,
            20421,
            298154,
            278407,
            153564,
            24778,
            73065,
            110408,
            392693,
            510192,
            362399,
            333830,
            125893,
            130946,
            345134,
            261418,
            230632,
            306751,
            451242,
            175675,
            459988,
            150787,
            349338,
            134594,
            255227,
            263645,
            180770,
            436965,
            502871,
            242085,
            318340,
            220576,
            189202,
            395789,
            390659,
            101649,
            337117,
            440471,
            466547,
            513054,
            316694,
            30382,
            38826,
            472506,
            67698,
            223953,
            397305,
            325564,
            57949,
            194651,
            443500,
            443188,
            431386,
            220061,
            400640,
            286085,
            189461,
            324214,
            171813,
            420711,
            260549,
            426526,
            208052,
            83343,
            429483,
            366076,
            52443,
            224742,
            333286,
            544259,
            335276,
            93282,
            326772,
            82841,
            225256,
            270357,
            547610,
            397526,
            193336,
            182374,
            439866,
            255860,
            111363,
            509167,
            228847,
            218257,
            39438,
            212242,
            378338,
            88972,
            127544,
            59230,
            428847,
            155553,
            116333,
            255176,
            396356,
            223463,
            226360,
            38283,
            6238,
            173455,
            447707,
            332111,
            60485,
            398523,
            462205,
            55397,
            148417,
            529738,
            460063,
            177715,
            404809,
            336155,
            50750,
            24165,
            530386,
            394811,
            512481,
            230296,
            45797,
            370008
        };
        Console.WriteLine(string.Format("cap:{0}", string.Join(" ", cap)));
        double __expected = 408339.73124862404;
        Console.WriteLine("__expected:{0}", __expected);
        double __result = new CtuRobots().maxDist(B, cost, cap);
        Console.WriteLine("__result:{0}", __result);
        Assert.AreEqual(__expected, __result, 1e-9);
}

}
