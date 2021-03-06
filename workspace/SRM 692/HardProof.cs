using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Debug = System.Diagnostics.Debug;
using StringBuilder = System.Text.StringBuilder;
public class HardProof
{
    public int minimumCost(int[] D)
    {
        var n = 1;
        while (n * n < D.Length) n++;
        Func<int, int, bool> check = (min, m) =>
             {
                 var scc = new SCCGraph(n);
                 for (int i = 0; i < n; i++)
                     for (int j = 0; j < n; j++)
                     {
                         if (i == j) continue;
                         if (min <= D[i * n + j] && D[i * n + j] <= min + m) scc.AddEdge(i, j);
                     }
                 return scc.Decomposite() == 1;
             };
        var max = 1145141919;
        foreach (var min in D.Distinct())
        {
            var l = -1; var r = 150005;
            while (l + 1 < r)
            {
                var m = (l + r) / 2;
                if (check(min, m)) r = m;
                else l = m;
            }
            max = Math.Min(max, r);
        }
        return max;
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
public class Tester: AbstractTester
{
    static public T[] Enumerate<T>(int n, Func<int, T> f) { var a = new T[n]; for (int i = 0; i < n; ++i) a[i] = f(i); return a; }
    public Random rand = new Random(0);
    public Tester()
    {
        //test.ManualTest(new int[] { 0, 60, 120, 180, 240, 300, 360, 420, 480, 540, 600, 660, 720, 780, 840, 900, 960, 1020, 1080, 1140, 1200, 1260, 1320, 1380, 1440, 1500, 1560, 1620, 1680, 1740, 1800, 1860, 1920, 1980, 2040, 2100, 2160, 2220, 2280, 2340, 2400, 2460, 2520, 2580, 2640, 2700, 2760, 2820, 2880, 2940, 3000, 0, 3120, 3180, 3240, 3300, 3360, 3420, 3480, 3540, 3600, 3660, 3720, 3780, 3840, 3900, 3960, 4020, 4080, 4140, 4200, 4260, 4320, 4380, 4440, 4500, 4560, 4620, 4680, 4740, 4800, 4860, 4920, 4980, 5040, 5100, 5160, 5220, 5280, 5340, 5400, 5460, 5520, 5580, 5640, 5700, 5760, 5820, 5880, 5940, 6000, 6060, 0, 6180, 6240, 6300, 6360, 6420, 6480, 6540, 6600, 6660, 6720, 6780, 6840, 6900, 6960, 7020, 7080, 7140, 7200, 7260, 7320, 7380, 7440, 7500, 7560, 7620, 7680, 7740, 7800, 7860, 7920, 7980, 8040, 8100, 8160, 8220, 8280, 8340, 8400, 8460, 8520, 8580, 8640, 8700, 8760, 8820, 8880, 8940, 9000, 9060, 9120, 0, 9240, 9300, 9360, 9420, 9480, 9540, 9600, 9660, 9720, 9780, 9840, 9900, 9960, 10020, 10080, 10140, 10200, 10260, 10320, 10380, 10440, 10500, 10560, 10620, 10680, 10740, 10800, 10860, 10920, 10980, 11040, 11100, 11160, 11220, 11280, 11340, 11400, 11460, 11520, 11580, 11640, 11700, 11760, 11820, 11880, 11940, 12000, 12060, 12120, 12180, 0, 12300, 12360, 12420, 12480, 12540, 12600, 12660, 12720, 12780, 12840, 12900, 12960, 13020, 13080, 13140, 13200, 13260, 13320, 13380, 13440, 13500, 13560, 13620, 13680, 13740, 13800, 13860, 13920, 13980, 14040, 14100, 14160, 14220, 14280, 14340, 14400, 14460, 14520, 14580, 14640, 14700, 14760, 14820, 14880, 14940, 15000, 15060, 15120, 15180, 15240, 0, 15360, 15420, 15480, 15540, 15600, 15660, 15720, 15780, 15840, 15900, 15960, 16020, 16080, 16140, 16200, 16260, 16320, 16380, 16440, 16500, 16560, 16620, 16680, 16740, 16800, 16860, 16920, 16980, 17040, 17100, 17160, 17220, 17280, 17340, 17400, 17460, 17520, 17580, 17640, 17700, 17760, 17820, 17880, 17940, 18000, 18060, 18120, 18180, 18240, 18300, 0, 18420, 18480, 18540, 18600, 18660, 18720, 18780, 18840, 18900, 18960, 19020, 19080, 19140, 19200, 19260, 19320, 19380, 19440, 19500, 19560, 19620, 19680, 19740, 19800, 19860, 19920, 19980, 20040, 20100, 20160, 20220, 20280, 20340, 20400, 20460, 20520, 20580, 20640, 20700, 20760, 20820, 20880, 20940, 21000, 21060, 21120, 21180, 21240, 21300, 21360, 0, 21480, 21540, 21600, 21660, 21720, 21780, 21840, 21900, 21960, 22020, 22080, 22140, 22200, 22260, 22320, 22380, 22440, 22500, 22560, 22620, 22680, 22740, 22800, 22860, 22920, 22980, 23040, 23100, 23160, 23220, 23280, 23340, 23400, 23460, 23520, 23580, 23640, 23700, 23760, 23820, 23880, 23940, 24000, 24060, 24120, 24180, 24240, 24300, 24360, 24420, 0, 24540, 24600, 24660, 24720, 24780, 24840, 24900, 24960, 25020, 25080, 25140, 25200, 25260, 25320, 25380, 25440, 25500, 25560, 25620, 25680, 25740, 25800, 25860, 25920, 25980, 26040, 26100, 26160, 26220, 26280, 26340, 26400, 26460, 26520, 26580, 26640, 26700, 26760, 26820, 26880, 26940, 27000, 27060, 27120, 27180, 27240, 27300, 27360, 27420, 27480, 0, 27600, 27660, 27720, 27780, 27840, 27900, 27960, 28020, 28080, 28140, 28200, 28260, 28320, 28380, 28440, 28500, 28560, 28620, 28680, 28740, 28800, 28860, 28920, 28980, 29040, 29100, 29160, 29220, 29280, 29340, 29400, 29460, 29520, 29580, 29640, 29700, 29760, 29820, 29880, 29940, 30000, 30060, 30120, 30180, 30240, 30300, 30360, 30420, 30480, 30540, 0, 30660, 30720, 30780, 30840, 30900, 30960, 31020, 31080, 31140, 31200, 31260, 31320, 31380, 31440, 31500, 31560, 31620, 31680, 31740, 31800, 31860, 31920, 31980, 32040, 32100, 32160, 32220, 32280, 32340, 32400, 32460, 32520, 32580, 32640, 32700, 32760, 32820, 32880, 32940, 33000, 33060, 33120, 33180, 33240, 33300, 33360, 33420, 33480, 33540, 33600, 0, 33720, 33780, 33840, 33900, 33960, 34020, 34080, 34140, 34200, 34260, 34320, 34380, 34440, 34500, 34560, 34620, 34680, 34740, 34800, 34860, 34920, 34980, 35040, 35100, 35160, 35220, 35280, 35340, 35400, 35460, 35520, 35580, 35640, 35700, 35760, 35820, 35880, 35940, 36000, 36060, 36120, 36180, 36240, 36300, 36360, 36420, 36480, 36540, 36600, 36660, 0, 36780, 36840, 36900, 36960, 37020, 37080, 37140, 37200, 37260, 37320, 37380, 37440, 37500, 37560, 37620, 37680, 37740, 37800, 37860, 37920, 37980, 38040, 38100, 38160, 38220, 38280, 38340, 38400, 38460, 38520, 38580, 38640, 38700, 38760, 38820, 38880, 38940, 39000, 39060, 39120, 39180, 39240, 39300, 39360, 39420, 39480, 39540, 39600, 39660, 39720, 0, 39840, 39900, 39960, 40020, 40080, 40140, 40200, 40260, 40320, 40380, 40440, 40500, 40560, 40620, 40680, 40740, 40800, 40860, 40920, 40980, 41040, 41100, 41160, 41220, 41280, 41340, 41400, 41460, 41520, 41580, 41640, 41700, 41760, 41820, 41880, 41940, 42000, 42060, 42120, 42180, 42240, 42300, 42360, 42420, 42480, 42540, 42600, 42660, 42720, 42780, 0, 42900, 42960, 43020, 43080, 43140, 43200, 43260, 43320, 43380, 43440, 43500, 43560, 43620, 43680, 43740, 43800, 43860, 43920, 43980, 44040, 44100, 44160, 44220, 44280, 44340, 44400, 44460, 44520, 44580, 44640, 44700, 44760, 44820, 44880, 44940, 45000, 45060, 45120, 45180, 45240, 45300, 45360, 45420, 45480, 45540, 45600, 45660, 45720, 45780, 45840, 0, 45960, 46020, 46080, 46140, 46200, 46260, 46320, 46380, 46440, 46500, 46560, 46620, 46680, 46740, 46800, 46860, 46920, 46980, 47040, 47100, 47160, 47220, 47280, 47340, 47400, 47460, 47520, 47580, 47640, 47700, 47760, 47820, 47880, 47940, 48000, 48060, 48120, 48180, 48240, 48300, 48360, 48420, 48480, 48540, 48600, 48660, 48720, 48780, 48840, 48900, 0, 49020, 49080, 49140, 49200, 49260, 49320, 49380, 49440, 49500, 49560, 49620, 49680, 49740, 49800, 49860, 49920, 49980, 50040, 50100, 50160, 50220, 50280, 50340, 50400, 50460, 50520, 50580, 50640, 50700, 50760, 50820, 50880, 50940, 51000, 51060, 51120, 51180, 51240, 51300, 51360, 51420, 51480, 51540, 51600, 51660, 51720, 51780, 51840, 51900, 51960, 0, 52080, 52140, 52200, 52260, 52320, 52380, 52440, 52500, 52560, 52620, 52680, 52740, 52800, 52860, 52920, 52980, 53040, 53100, 53160, 53220, 53280, 53340, 53400, 53460, 53520, 53580, 53640, 53700, 53760, 53820, 53880, 53940, 54000, 54060, 54120, 54180, 54240, 54300, 54360, 54420, 54480, 54540, 54600, 54660, 54720, 54780, 54840, 54900, 54960, 55020, 0, 55140, 55200, 55260, 55320, 55380, 55440, 55500, 55560, 55620, 55680, 55740, 55800, 55860, 55920, 55980, 56040, 56100, 56160, 56220, 56280, 56340, 56400, 56460, 56520, 56580, 56640, 56700, 56760, 56820, 56880, 56940, 57000, 57060, 57120, 57180, 57240, 57300, 57360, 57420, 57480, 57540, 57600, 57660, 57720, 57780, 57840, 57900, 57960, 58020, 58080, 0, 58200, 58260, 58320, 58380, 58440, 58500, 58560, 58620, 58680, 58740, 58800, 58860, 58920, 58980, 59040, 59100, 59160, 59220, 59280, 59340, 59400, 59460, 59520, 59580, 59640, 59700, 59760, 59820, 59880, 59940, 60000, 60060, 60120, 60180, 60240, 60300, 60360, 60420, 60480, 60540, 60600, 60660, 60720, 60780, 60840, 60900, 60960, 61020, 61080, 61140, 0, 61260, 61320, 61380, 61440, 61500, 61560, 61620, 61680, 61740, 61800, 61860, 61920, 61980, 62040, 62100, 62160, 62220, 62280, 62340, 62400, 62460, 62520, 62580, 62640, 62700, 62760, 62820, 62880, 62940, 63000, 63060, 63120, 63180, 63240, 63300, 63360, 63420, 63480, 63540, 63600, 63660, 63720, 63780, 63840, 63900, 63960, 64020, 64080, 64140, 64200, 0, 64320, 64380, 64440, 64500, 64560, 64620, 64680, 64740, 64800, 64860, 64920, 64980, 65040, 65100, 65160, 65220, 65280, 65340, 65400, 65460, 65520, 65580, 65640, 65700, 65760, 65820, 65880, 65940, 66000, 66060, 66120, 66180, 66240, 66300, 66360, 66420, 66480, 66540, 66600, 66660, 66720, 66780, 66840, 66900, 66960, 67020, 67080, 67140, 67200, 67260, 0, 67380, 67440, 67500, 67560, 67620, 67680, 67740, 67800, 67860, 67920, 67980, 68040, 68100, 68160, 68220, 68280, 68340, 68400, 68460, 68520, 68580, 68640, 68700, 68760, 68820, 68880, 68940, 69000, 69060, 69120, 69180, 69240, 69300, 69360, 69420, 69480, 69540, 69600, 69660, 69720, 69780, 69840, 69900, 69960, 70020, 70080, 70140, 70200, 70260, 70320, 0, 70440, 70500, 70560, 70620, 70680, 70740, 70800, 70860, 70920, 70980, 71040, 71100, 71160, 71220, 71280, 71340, 71400, 71460, 71520, 71580, 71640, 71700, 71760, 71820, 71880, 71940, 72000, 72060, 72120, 72180, 72240, 72300, 72360, 72420, 72480, 72540, 72600, 72660, 72720, 72780, 72840, 72900, 72960, 73020, 73080, 73140, 73200, 73260, 73320, 73380, 0, 73500, 73560, 73620, 73680, 73740, 73800, 73860, 73920, 73980, 74040, 74100, 74160, 74220, 74280, 74340, 74400, 74460, 74520, 74580, 74640, 74700, 74760, 74820, 74880, 74940, 75000, 75060, 75120, 75180, 75240, 75300, 75360, 75420, 75480, 75540, 75600, 75660, 75720, 75780, 75840, 75900, 75960, 76020, 76080, 76140, 76200, 76260, 76320, 76380, 76440, 0, 76560, 76620, 76680, 76740, 76800, 76860, 76920, 76980, 77040, 77100, 77160, 77220, 77280, 77340, 77400, 77460, 77520, 77580, 77640, 77700, 77760, 77820, 77880, 77940, 78000, 78060, 78120, 78180, 78240, 78300, 78360, 78420, 78480, 78540, 78600, 78660, 78720, 78780, 78840, 78900, 78960, 79020, 79080, 79140, 79200, 79260, 79320, 79380, 79440, 79500, 0, 79620, 79680, 79740, 79800, 79860, 79920, 79980, 80040, 80100, 80160, 80220, 80280, 80340, 80400, 80460, 80520, 80580, 80640, 80700, 80760, 80820, 80880, 80940, 81000, 81060, 81120, 81180, 81240, 81300, 81360, 81420, 81480, 81540, 81600, 81660, 81720, 81780, 81840, 81900, 81960, 82020, 82080, 82140, 82200, 82260, 82320, 82380, 82440, 82500, 82560, 0, 82680, 82740, 82800, 82860, 82920, 82980, 83040, 83100, 83160, 83220, 83280, 83340, 83400, 83460, 83520, 83580, 83640, 83700, 83760, 83820, 83880, 83940, 84000, 84060, 84120, 84180, 84240, 84300, 84360, 84420, 84480, 84540, 84600, 84660, 84720, 84780, 84840, 84900, 84960, 85020, 85080, 85140, 85200, 85260, 85320, 85380, 85440, 85500, 85560, 85620, 0, 85740, 85800, 85860, 85920, 85980, 86040, 86100, 86160, 86220, 86280, 86340, 86400, 86460, 86520, 86580, 86640, 86700, 86760, 86820, 86880, 86940, 87000, 87060, 87120, 87180, 87240, 87300, 87360, 87420, 87480, 87540, 87600, 87660, 87720, 87780, 87840, 87900, 87960, 88020, 88080, 88140, 88200, 88260, 88320, 88380, 88440, 88500, 88560, 88620, 88680, 0, 88800, 88860, 88920, 88980, 89040, 89100, 89160, 89220, 89280, 89340, 89400, 89460, 89520, 89580, 89640, 89700, 89760, 89820, 89880, 89940, 90000, 90060, 90120, 90180, 90240, 90300, 90360, 90420, 90480, 90540, 90600, 90660, 90720, 90780, 90840, 90900, 90960, 91020, 91080, 91140, 91200, 91260, 91320, 91380, 91440, 91500, 91560, 91620, 91680, 91740, 0, 91860, 91920, 91980, 92040, 92100, 92160, 92220, 92280, 92340, 92400, 92460, 92520, 92580, 92640, 92700, 92760, 92820, 92880, 92940, 93000, 93060, 93120, 93180, 93240, 93300, 93360, 93420, 93480, 93540, 93600, 93660, 93720, 93780, 93840, 93900, 93960, 94020, 94080, 94140, 94200, 94260, 94320, 94380, 94440, 94500, 94560, 94620, 94680, 94740, 94800, 0, 94920, 94980, 95040, 95100, 95160, 95220, 95280, 95340, 95400, 95460, 95520, 95580, 95640, 95700, 95760, 95820, 95880, 95940, 96000, 96060, 96120, 96180, 96240, 96300, 96360, 96420, 96480, 96540, 96600, 96660, 96720, 96780, 96840, 96900, 96960, 97020, 97080, 97140, 97200, 97260, 97320, 97380, 97440, 97500, 97560, 97620, 97680, 97740, 97800, 97860, 0, 97980, 98040, 98100, 98160, 98220, 98280, 98340, 98400, 98460, 98520, 98580, 98640, 98700, 98760, 98820, 98880, 98940, 99000, 99060, 99120, 99180, 99240, 99300, 99360, 99420, 99480, 99540, 99600, 99660, 99720, 99780, 99840, 99900, 99960, 100020, 100080, 100140, 100200, 100260, 100320, 100380, 100440, 100500, 100560, 100620, 100680, 100740, 100800, 100860, 100920, 0, 101040, 101100, 101160, 101220, 101280, 101340, 101400, 101460, 101520, 101580, 101640, 101700, 101760, 101820, 101880, 101940, 102000, 102060, 102120, 102180, 102240, 102300, 102360, 102420, 102480, 102540, 102600, 102660, 102720, 102780, 102840, 102900, 102960, 103020, 103080, 103140, 103200, 103260, 103320, 103380, 103440, 103500, 103560, 103620, 103680, 103740, 103800, 103860, 103920, 103980, 0, 104100, 104160, 104220, 104280, 104340, 104400, 104460, 104520, 104580, 104640, 104700, 104760, 104820, 104880, 104940, 105000, 105060, 105120, 105180, 105240, 105300, 105360, 105420, 105480, 105540, 105600, 105660, 105720, 105780, 105840, 105900, 105960, 106020, 106080, 106140, 106200, 106260, 106320, 106380, 106440, 106500, 106560, 106620, 106680, 106740, 106800, 106860, 106920, 106980, 107040, 0, 107160, 107220, 107280, 107340, 107400, 107460, 107520, 107580, 107640, 107700, 107760, 107820, 107880, 107940, 108000, 108060, 108120, 108180, 108240, 108300, 108360, 108420, 108480, 108540, 108600, 108660, 108720, 108780, 108840, 108900, 108960, 109020, 109080, 109140, 109200, 109260, 109320, 109380, 109440, 109500, 109560, 109620, 109680, 109740, 109800, 109860, 109920, 109980, 110040, 110100, 0, 110220, 110280, 110340, 110400, 110460, 110520, 110580, 110640, 110700, 110760, 110820, 110880, 110940, 111000, 111060, 111120, 111180, 111240, 111300, 111360, 111420, 111480, 111540, 111600, 111660, 111720, 111780, 111840, 111900, 111960, 112020, 112080, 112140, 112200, 112260, 112320, 112380, 112440, 112500, 112560, 112620, 112680, 112740, 112800, 112860, 112920, 112980, 113040, 113100, 113160, 0, 113280, 113340, 113400, 113460, 113520, 113580, 113640, 113700, 113760, 113820, 113880, 113940, 114000, 114060, 114120, 114180, 114240, 114300, 114360, 114420, 114480, 114540, 114600, 114660, 114720, 114780, 114840, 114900, 114960, 115020, 115080, 115140, 115200, 115260, 115320, 115380, 115440, 115500, 115560, 115620, 115680, 115740, 115800, 115860, 115920, 115980, 116040, 116100, 116160, 116220, 0, 116340, 116400, 116460, 116520, 116580, 116640, 116700, 116760, 116820, 116880, 116940, 117000, 117060, 117120, 117180, 117240, 117300, 117360, 117420, 117480, 117540, 117600, 117660, 117720, 117780, 117840, 117900, 117960, 118020, 118080, 118140, 118200, 118260, 118320, 118380, 118440, 118500, 118560, 118620, 118680, 118740, 118800, 118860, 118920, 118980, 119040, 119100, 119160, 119220, 119280, 0, 119400, 119460, 119520, 119580, 119640, 119700, 119760, 119820, 119880, 119940, 120000, 120060, 120120, 120180, 120240, 120300, 120360, 120420, 120480, 120540, 120600, 120660, 120720, 120780, 120840, 120900, 120960, 121020, 121080, 121140, 121200, 121260, 121320, 121380, 121440, 121500, 121560, 121620, 121680, 121740, 121800, 121860, 121920, 121980, 122040, 122100, 122160, 122220, 122280, 122340, 0, 122460, 122520, 122580, 122640, 122700, 122760, 122820, 122880, 122940, 123000, 123060, 123120, 123180, 123240, 123300, 123360, 123420, 123480, 123540, 123600, 123660, 123720, 123780, 123840, 123900, 123960, 124020, 124080, 124140, 124200, 124260, 124320, 124380, 124440, 124500, 124560, 124620, 124680, 124740, 124800, 124860, 124920, 124980, 125040, 125100, 125160, 125220, 125280, 125340, 125400, 0, 125520, 125580, 125640, 125700, 125760, 125820, 125880, 125940, 126000, 126060, 126120, 126180, 126240, 126300, 126360, 126420, 126480, 126540, 126600, 126660, 126720, 126780, 126840, 126900, 126960, 127020, 127080, 127140, 127200, 127260, 127320, 127380, 127440, 127500, 127560, 127620, 127680, 127740, 127800, 127860, 127920, 127980, 128040, 128100, 128160, 128220, 128280, 128340, 128400, 128460, 0, 128580, 128640, 128700, 128760, 128820, 128880, 128940, 129000, 129060, 129120, 129180, 129240, 129300, 129360, 129420, 129480, 129540, 129600, 129660, 129720, 129780, 129840, 129900, 129960, 130020, 130080, 130140, 130200, 130260, 130320, 130380, 130440, 130500, 130560, 130620, 130680, 130740, 130800, 130860, 130920, 130980, 131040, 131100, 131160, 131220, 131280, 131340, 131400, 131460, 131520, 0, 131640, 131700, 131760, 131820, 131880, 131940, 132000, 132060, 132120, 132180, 132240, 132300, 132360, 132420, 132480, 132540, 132600, 132660, 132720, 132780, 132840, 132900, 132960, 133020, 133080, 133140, 133200, 133260, 133320, 133380, 133440, 133500, 133560, 133620, 133680, 133740, 133800, 133860, 133920, 133980, 134040, 134100, 134160, 134220, 134280, 134340, 134400, 134460, 134520, 134580, 0, 134700, 134760, 134820, 134880, 134940, 135000, 135060, 135120, 135180, 135240, 135300, 135360, 135420, 135480, 135540, 135600, 135660, 135720, 135780, 135840, 135900, 135960, 136020, 136080, 136140, 136200, 136260, 136320, 136380, 136440, 136500, 136560, 136620, 136680, 136740, 136800, 136860, 136920, 136980, 137040, 137100, 137160, 137220, 137280, 137340, 137400, 137460, 137520, 137580, 137640, 0, 137760, 137820, 137880, 137940, 138000, 138060, 138120, 138180, 138240, 138300, 138360, 138420, 138480, 138540, 138600, 138660, 138720, 138780, 138840, 138900, 138960, 139020, 139080, 139140, 139200, 139260, 139320, 139380, 139440, 139500, 139560, 139620, 139680, 139740, 139800, 139860, 139920, 139980, 140040, 140100, 140160, 140220, 140280, 140340, 140400, 140460, 140520, 140580, 140640, 140700, 0, 140820, 140880, 140940, 141000, 141060, 141120, 141180, 141240, 141300, 141360, 141420, 141480, 141540, 141600, 141660, 141720, 141780, 141840, 141900, 141960, 142020, 142080, 142140, 142200, 142260, 142320, 142380, 142440, 142500, 142560, 142620, 142680, 142740, 142800, 142860, 142920, 142980, 143040, 143100, 143160, 143220, 143280, 143340, 143400, 143460, 143520, 143580, 143640, 143700, 143760, 0, 143880, 143940, 144000, 144060, 144120, 144180, 144240, 144300, 144360, 144420, 144480, 144540, 144600, 144660, 144720, 144780, 144840, 144900, 144960, 145020, 145080, 145140, 145200, 145260, 145320, 145380, 145440, 145500, 145560, 145620, 145680, 145740, 145800, 145860, 145920, 145980, 146040, 146100, 146160, 146220, 146280, 146340, 146400, 146460, 146520, 146580, 146640, 146700, 146760, 146820, 0, 146940, 147000, 147060, 147120, 147180, 147240, 147300, 147360, 147420, 147480, 147540, 147600, 147660, 147720, 147780, 147840, 147900, 147960, 148020, 148080, 148140, 148200, 148260, 148320, 148380, 148440, 148500, 148560, 148620, 148680, 148740, 148800, 148860, 148920, 148980, 149040, 149100, 149160, 149220, 149280, 149340, 149400, 149460, 149520, 149580, 149640, 149700, 149760, 149820, 149880, 0 });
    }
}
// CUT end
#region SCCGraph
public class SCCGraph
{
    int n;

    FastList<int>[] g;

    /// <summary>
    /// 強連結成分内の集合
    /// </summary>
    public List<List<int>> scc;
    /// <summary>
    /// 元のグラフのインデックスから強連結成分分解後のインデックスへの写像
    /// </summary>
    public int[] group;

    /// <summary>
    /// 強連結成分のサイズ
    /// </summary>
    public int size;
    /// <summary>
    /// 強連結成分分解後のグラフ
    /// </summary>
    public List<int>[] G;
    /// <summary>
    /// 強連結成分分解後の自己ループの数
    /// </summary>
    public int[] L;

    public SCCGraph(int N)
    {
        n = N;
        g = new FastList<int>[n];
        scc = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            g[i] = new FastList<int>();
        }
    }
    public void AddEdge(int f, int t)
    {
        g[f].Add(t);
    }

    public void Build()
    {
        Decomposite();
        group = new int[n];
        L = new int[size];
        G = new List<int>[size];
        for (int i = 0; i < size; i++)
        {
            G[i] = new List<int>();
            foreach (var x in scc[i]) group[x] = i;
        }
        for (int i = 0; i < n; i++)
        {
            var u = group[i];
            for (int j = 0; j < g[i].Count; j++)
            {
                var v = group[g[i].data[j]];
                if (u == v) L[u]++;
                else G[u].Add(v);

            }

        }

    }
    public int Decomposite()
    {
        var S = new FastStack<int>(n + 2);
        var B = new FastStack<int>(n + 2);
        var I = new int[n];
        var iter = new int[n];
        var s = new FastStack<int>(n + 2);
        for (int i = 0; i < n; i++)
        {
            if (I[i] != 0) continue;
            //Debug.WriteLine(i);
            s.Push(i);
            while (s.Any())
            {
                DFS:
                var u = s.Peek();
                if (I[u] == 0)
                {
                    B.Push(I[u] = S.Count);
                    S.Push(u);
                    iter[u] = 0;
                }
                while (iter[u] < g[u].Count)
                {
                    var v = g[u].data[iter[u]++];
                    if (I[v] == 0)
                    {
                        //Debug.WriteLine(v);
                        s.Push(v);
                        goto DFS;
                    }
                    else while (I[v] < B.Peek()) B.Pop();
                }
                if (I[u] == B.Peek())
                {
                    var ns = new List<int>();
                    scc.Add(ns);
                    B.Pop();
                    while (I[u] < S.Count)
                    {
                        var p = S.Pop();
                        ns.Add(p);
                        I[p] = n + scc.Count;
                    }
                }
                s.Pop();

            }
        }
        return size = scc.Count;

    }
    public bool IsSameGroup(int u, int v) { return group[u] == group[v]; }
    class FastStack<T>
    {
        T[] data;
        int ptr;
        public FastStack(int size) { data = new T[size]; }
        public void Push(T item) { data[ptr++] = item; }
        public T Pop() { return data[--ptr]; }
        public T Peek() { return data[ptr - 1]; }
        public bool Any() { return ptr != 0; }
        public int Count { get { return ptr; } }
    }
    #region List<T>
    class FastList<T>
    {
        const int SIZE = 8;
        public T[] data;
        public int Count { get { return size; } }
        int size;
        public FastList() { data = new T[SIZE]; }
        public void Resize()
        {
            var ndata = new T[data.Length << 1];
            Array.Copy(data, ndata, size);
            data = ndata;
        }
        public void Add(T item)
        {
            if (size == data.Length) Resize();
            data[size++] = item;
        }
    }
    #endregion
}
#endregion