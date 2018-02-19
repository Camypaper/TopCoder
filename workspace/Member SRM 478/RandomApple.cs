using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Debug = System.Diagnostics.Debug;
using StringBuilder = System.Text.StringBuilder;
using Number = System.Double;
public class RandomApple
{
    public double[] theProbability(string[] hundred, string[] ten, string[] one)
    {
        n = hundred.Length;
        m = hundred[0].Length;
        A = Enumerate(n, x => new int[m]);
        B = new int[n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                A[i][j] = (hundred[i][j] - '0') * 100 + (ten[i][j] - '0') * 10 + one[i][j] - '0';
            }
            B[i] = A[i].Sum();
        }
        hundred = null;
        ten = null;
        one = null;
        c = 1.0 / ((1L << n) - 1);
        ret = new double[m];
        dp = new long[7][];
        dp[0] = new long[1] { 1 };
        dp[1] = new long[1 + 50 * 200 * 32];
        dp[2] = new long[1 + 50 * 200 * 48];
        dp[3] = new long[1 + 50 * 200 * 49];
        dp[4] = new long[1 + 50 * 200 * 49];
        dp[5] = new long[1 + 50 * 200 * 49];
        dp[6] = new long[1 + 50 * 200 * 49];
        var k = 1;
        while (k < n) k *= 2;
        N = k;
        dfs(1, 0, k, 0, 0);

        return ret;
    }
    int n, N;
    int m;
    double[] ret;
    int[][] A;
    int[] B;
    double c;
    long[][] dp;
    void dfs(int id, int l, int r, int sum, int d)
    {
        if (id >= N)
        {
            var i = id - N;
            var p = 0.0;
            for (int v = 0; v < dp[d].Length; v++)
            {
                p += 1.0 * dp[d][v] / (v + B[i]);

            }
            for (int j = 0; j < m; j++)
                ret[j] += c * p * A[i][j];
            return;
        }
        Debug.WriteLine("[{0},{1})", l, r);
        {
            var ll = l;
            var lr = (l + r) / 2;
            var f = lr;
            var t = Math.Min(n, r);
            var tmp = dp[d + 1];
            for (int i = 0; i < dp[d + 1].Length; i++)
                tmp[i] = (i < dp[d].Length) ? dp[d][i] : 0;
            var lsum = sum;
            for (int k = f; k < t; k++)
            {
                var v = B[k];
                for (int i = lsum; i >= 0; i--)
                    if (tmp[i] != 0) tmp[i + v] += tmp[i];
                lsum += v;
            }
            dfs(id * 2, ll, lr, lsum, d + 1);
        }

        {
            var rl = (l + r) / 2;
            var rr = r;
            if (rl >= n) return;
            var f = l;
            var t = Math.Min(n, rl);
            var tmp = dp[d + 1];
            for (int i = 0; i < dp[d + 1].Length; i++)
                tmp[i] = (i < dp[d].Length) ? dp[d][i] : 0;
            for (int k = f; k < t; k++)
            {
                var v = B[k];
                for (int i = sum; i >= 0; i--)
                    if (tmp[i] != 0) tmp[i + v] += tmp[i];
                sum += v;
            }
            dfs(id * 2 + 1, rl, rr, sum, d + 1);
        }
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
        var h = new string[] { "01001110010101101101001111011011001101000111100011", "01011010011100001011101100000110001011001111010110", "01011011100001001100110001000011110101000110011111", "01111011101100111100101010101011111100100110001000", "11110110010101111100000001010111001110010111001100", "00100001011011000111011011010100010000111101110111", "00110000000110101010001110111111110001000111110011", "01111110101110000111110001100100111011010101001111", "11100100011110011110100111111111100111000111111100", "10010100001011000100111100110010000110010101101101", "11010100010011010101100111101100011100001110111010", "10000111110011100000001101100010111101111100101000", "11110001111110111100001000100111110101011011001011", "00000000000111100100010100010100101110010010011010", "01001110100001010110101101111110111100001001100101", "00100010100100011111011100111001011110100010100100", "10101001010111111101011100110111000100010101010101", "00011100101011000100101100001111101010011010001001", "11011001101010010010011000011000011001101011000100", "01111111011011001001001011110100011010000000011110", "01000110010000010000110011001011010000111111010001", "01010000110111010010101111100100101101100001011010", "00000110001001011100010000101001101001100010000111", "10010110001110010000000111100110001011100011110101", "11100010001001110011101101101101111101110000011010", "10111111100100011001011000011010000011100110111001", "00110001100110110011101011110010010010110111101110", "11111001000011100110101001101000000010110100001000", "11101100110110100010011001011111001111000011000001", "11010000100001011001100111010000001100111111011001", "11110111010001101110101100110000101011111001001010", "11001010110001101000000001011010011101010111111110", "11011101001100111111100101011110001100001001001011", "10001100001101111011111001100110101110110111001010", "10111000110110111001011110000000101101110101001011", "10011111110110001001110010111000011001100000001110", "11000100011110110111110111110111011110100111011010", "01111001011001001111000100010101110101100001101110", "01101101100010111110110011111110111001011000001011", "01011010110001001000010110010100101011000101111000", "11111100000000100011101000011011111111111111001001", "10000010100011011111000000100011011110100010111100", "01011011110101111110111011100010111101010100000001", "10110110011100111011111111001011110111100110111100", "10111111001111110110011011000001010111110001111110", "11111001000101110111010111000011000100111101001101", "01001011001010101111111100000101010001111010010100", "01000001100010110111101100100111011010111110111011", "11101010000111111100001111010111111111110101000000", "01000010001101001111100001010110111011100000000000" };
        var t = new string[] { "96140303596097324281654930898573650209297565759779", "82835942022719719208994032454542477804392321165667", "88898972771455461673685612781545840704595317760768", "57862808159407849727550322312496107842482286847582", "45792790744550343046201297704496310585021702326805", "99949727311948864619667196878052611770964131475457", "12084694869828956023506419926730423238236100266430", "49310961212612003270416029346229709184016781497575", "20453464443183676998624255457380400603712967765414", "56403325457946651692593665759279744837031045481297", "53732389618297610132897437273292899973604709918119", "98166805508018427362364904013144392853963307486340", "15472237226037333841157085917040883148174765003323", "97553298079071965618491691482431945317368732541281", "71158591462386522546594149963870885507829877921576", "20528534942113135438647851551609297128737883933633", "48098963180055041925901628193671220985865399837446", "59971597564105174710857023400497103490897895553487", "83217876511969439814517748215642920047868950582435", "65148719142580225510596887244204153096316222874921", "49801093804589553687180947160898781999665019140836", "05300410793520745594105757830487794607648313370799", "67462269088065059845262416747588978920950625331746", "32044434001917108289359847956875956668183638462883", "10085247706932700492945241126530517629311000798073", "60384038688186978529814146204431318066594685917734", "46591978253764942921160520255242695819951946802758", "08639589263709229130995128793876856135754354445605", "38174868056298851177063192410171034652841401960393", "71357496357113309199355119626353114445803783133276", "90338220991231865280916256001104579528540287746928", "47509882053929025824464027082936729676876060991041", "76348725079962920285698692631056450041242586329149", "47864330091281709567337882160300833325897025912735", "08099991626534705904860009763367523070595054698555", "84398422463166291501334471646716576325332238196116", "29686246941542758750775155834496900236476150694682", "56684024230256353582128189249404296697084892091649", "32559158753048890570017749889380180798936131640791", "50192612282168766071473170392007718984334345677081", "54485772756994990359292925563822063694553626264754", "53230797634443853644896742948914127711996508135007", "32852950057507600213666117775095622017391147252348", "87591607364678124867922730438709693389635783012300", "68711516569679619162773561239701608568573168750876", "45504138429626733214229134589881673176710217424918", "70977507076415262510747904236832090189274524556217", "20657389554133864873380413920592821665574814615036", "93969704157853686958881729813505245965420308510733", "12276142233184388624281648194755092602823157177390" };
        var o = new string[] { "23622839876748005310431599655125849465784760864501", "49519104371941474482094884269772160492457035728442", "29097174146798297289108496319158181312558166044166", "82656278212089933193789134952863866479877657753037", "39281336942244672034112260547128204667355751317127", "92965032681292301844466850468354789387015498324210", "81416388917126128133787182910560836333420526095960", "36930164072907893001840358939353490213825236501297", "16178420492583397636728601618298854639846546280403", "20659218245209995959790145239130782983797834929291", "57097407374446796209174329025578147812493596552075", "15017525827372298440789424769181168897017618635679", "35927044836036625552586391721157308020730648135702", "57138003803823602078348303159468235307519691529439", "76538679270838953535277193433759445979405178196115", "85924841151733055175855951773827228766673937410527", "17266912062141912317558115315878112619740425206622", "16351384036604926246280811552136554501126491482570", "43360883764284470475761517118579880668931036622013", "32128906955817636271122124458532314838983233342193", "37844639351136651683746252416896115782551608794224", "13227835216976734707288734773701700360538011731721", "20343740539268041294068759230985317377826396973750", "96076426871798812499345602984890278954466381485219", "00896124096271519237832824758250072706476904162617", "82270155648571808364967434848424751469362248700687", "67629397020001978462151910091976157572209206411383", "58778470607470993073059749724815103775541753216607", "55104394056409546712015563089765791165457600615636", "45485970672536598714570937703138778276623214022616", "50701964979903350349341458094488022504823456228496", "52783398252259757352646646510275375200976653364622", "67568702248674342323461805588872898020360341587775", "06151589997795006507707646732164181355248097619749", "32284249249959389301933709753781240294868939705429", "86399793611757352573131614323676352842152830700702", "84482137575424745730026376852335522211332590369093", "58906188748331954980941482494433961026437613296458", "97668179466058303759557032655237791434270020483937", "90231053510625778191540928988853182996509196809525", "37202094819360936024794613512798886156036154195409", "97927322099377581000948494170826041751265949205521", "41067177046786423000382150384676813214103163089127", "65760020408038009268308980786405059725787804698805", "02829562747454709812534765592092844393813238158252", "13160825861245905944990484584182448605990657869209", "75701188817468441748202893722043082268528400159144", "62623424070898604634396230635327723869637626753100", "95991314496684073855084874578842555601123749931695", "79949206867307423251618018066564697168294897428752" };
        test.ManualTest(h, t, o);

    }
}
// CUT end