namespace Day22.UnitTests
{
    public static class Constants
    {
        public static readonly (int, int, int) FRONT_BOTTOM_LEFT = (10, 12, 10);
        public static readonly (int, int, int) FRONT_BOTTOM_RIGHT = (12, 12, 10);
        public static readonly (int, int, int) BACK_BOTTOM_LEFT = (10, 10, 10);

        public const string SAMPLE_INSTRUCTIONS = @"on x=-20..26,y=-36..17,z=-47..7
on x=-20..33,y=-21..23,z=-26..28
on x=-22..28,y=-29..23,z=-38..16
on x=-46..7,y=-6..46,z=-50..-1
on x=-49..1,y=-3..46,z=-24..28
on x=2..47,y=-22..22,z=-23..27
on x=-27..23,y=-28..26,z=-21..29
on x=-39..5,y=-6..47,z=-3..44
on x=-30..21,y=-8..43,z=-13..34
on x=-22..26,y=-27..20,z=-29..19
off x=-48..-32,y=26..41,z=-47..-37
on x=-12..35,y=6..50,z=-50..-2
off x=-48..-32,y=-32..-16,z=-15..-5
on x=-18..26,y=-33..15,z=-7..46
off x=-40..-22,y=-38..-28,z=23..41
on x=-16..35,y=-41..10,z=-47..6
off x=-32..-23,y=11..30,z=-14..3
on x=-49..-5,y=-3..45,z=-29..18
off x=18..30,y=-20..-8,z=-3..13
on x=-41..9,y=-7..43,z=-33..15
on x=-54112..-39298,y=-85059..-49293,z=-27449..7877
on x=967..23432,y=45373..81175,z=27513..53682";

        public const string SAMPLE_REBOOT_INSTRUCTIONS = @"on x=-5..47,y=-31..22,z=-19..33
on x=-44..5,y=-27..21,z=-14..35
on x=-49..-1,y=-11..42,z=-10..38
on x=-20..34,y=-40..6,z=-44..1
off x=26..39,y=40..50,z=-2..11
on x=-41..5,y=-41..6,z=-36..8
off x=-43..-33,y=-45..-28,z=7..25
on x=-33..15,y=-32..19,z=-34..11
off x=35..47,y=-46..-34,z=-11..5
on x=-14..36,y=-6..44,z=-16..29
on x=-57795..-6158,y=29564..72030,z=20435..90618
on x=36731..105352,y=-21140..28532,z=16094..90401
on x=30999..107136,y=-53464..15513,z=8553..71215
on x=13528..83982,y=-99403..-27377,z=-24141..23996
on x=-72682..-12347,y=18159..111354,z=7391..80950
on x=-1060..80757,y=-65301..-20884,z=-103788..-16709
on x=-83015..-9461,y=-72160..-8347,z=-81239..-26856
on x=-52752..22273,y=-49450..9096,z=54442..119054
on x=-29982..40483,y=-108474..-28371,z=-24328..38471
on x=-4958..62750,y=40422..118853,z=-7672..65583
on x=55694..108686,y=-43367..46958,z=-26781..48729
on x=-98497..-18186,y=-63569..3412,z=1232..88485
on x=-726..56291,y=-62629..13224,z=18033..85226
on x=-110886..-34664,y=-81338..-8658,z=8914..63723
on x=-55829..24974,y=-16897..54165,z=-121762..-28058
on x=-65152..-11147,y=22489..91432,z=-58782..1780
on x=-120100..-32970,y=-46592..27473,z=-11695..61039
on x=-18631..37533,y=-124565..-50804,z=-35667..28308
on x=-57817..18248,y=49321..117703,z=5745..55881
on x=14781..98692,y=-1341..70827,z=15753..70151
on x=-34419..55919,y=-19626..40991,z=39015..114138
on x=-60785..11593,y=-56135..2999,z=-95368..-26915
on x=-32178..58085,y=17647..101866,z=-91405..-8878
on x=-53655..12091,y=50097..105568,z=-75335..-4862
on x=-111166..-40997,y=-71714..2688,z=5609..50954
on x=-16602..70118,y=-98693..-44401,z=5197..76897
on x=16383..101554,y=4615..83635,z=-44907..18747
off x=-95822..-15171,y=-19987..48940,z=10804..104439
on x=-89813..-14614,y=16069..88491,z=-3297..45228
on x=41075..99376,y=-20427..49978,z=-52012..13762
on x=-21330..50085,y=-17944..62733,z=-112280..-30197
on x=-16478..35915,y=36008..118594,z=-7885..47086
off x=-98156..-27851,y=-49952..43171,z=-99005..-8456
off x=2032..69770,y=-71013..4824,z=7471..94418
on x=43670..120875,y=-42068..12382,z=-24787..38892
off x=37514..111226,y=-45862..25743,z=-16714..54663
off x=25699..97951,y=-30668..59918,z=-15349..69697
off x=-44271..17935,y=-9516..60759,z=49131..112598
on x=-61695..-5813,y=40978..94975,z=8655..80240
off x=-101086..-9439,y=-7088..67543,z=33935..83858
off x=18020..114017,y=-48931..32606,z=21474..89843
off x=-77139..10506,y=-89994..-18797,z=-80..59318
off x=8476..79288,y=-75520..11602,z=-96624..-24783
on x=-47488..-1262,y=24338..100707,z=16292..72967
off x=-84341..13987,y=2429..92914,z=-90671..-1318
off x=-37810..49457,y=-71013..-7894,z=-105357..-13188
off x=-27365..46395,y=31009..98017,z=15428..76570
off x=-70369..-16548,y=22648..78696,z=-1892..86821
on x=-53470..21291,y=-120233..-33476,z=-44150..38147
off x=-93533..-4276,y=-16170..68771,z=-104985..-24507";

        public const string REAL_INSTRUCTIONS = @"on x=-37..10,y=-38..8,z=-18..35
on x=-4..42,y=-31..21,z=-2..45
on x=-46..4,y=-37..14,z=-41..4
on x=-3..47,y=-48..0,z=-7..44
on x=-13..36,y=-39..12,z=-31..16
on x=-37..8,y=-38..9,z=-38..11
on x=-35..16,y=-12..39,z=-34..15
on x=-9..45,y=-49..4,z=-45..-1
on x=-8..46,y=-33..13,z=-22..32
on x=-18..36,y=2..47,z=-16..38
off x=17..31,y=19..33,z=27..43
on x=-29..15,y=-4..46,z=-21..23
off x=34..46,y=3..16,z=29..41
on x=-11..34,y=-33..15,z=-1..48
off x=37..46,y=28..40,z=-38..-28
on x=-49..3,y=-19..34,z=-48..5
off x=-7..7,y=4..17,z=-21..-9
on x=-14..34,y=-49..5,z=-27..21
off x=31..43,y=-30..-19,z=-35..-22
on x=-5..43,y=-15..30,z=-10..36
on x=1947..32687,y=-15868..-4827,z=74913..89456
on x=-40329..-34595,y=-11992..-2661,z=63459..88270
on x=70051..75438,y=-21442..11484,z=24279..48084
on x=22489..34742,y=26456..59386,z=50315..58184
on x=-9620..1800,y=-82917..-59893,z=-37427..-28815
on x=45950..61251,y=14498..40348,z=-56753..-37213
on x=10391..47024,y=-16929..2719,z=-86843..-60224
on x=-6033..1429,y=25670..38164,z=-76032..-56075
on x=11626..35219,y=-4483..2154,z=-75338..-61813
on x=-38262..-10689,y=-50530..-30214,z=-69739..-55320
on x=-38960..-14492,y=-29361..-12531,z=-84225..-63816
on x=52822..81756,y=-13335..-10316,z=-48710..-41912
on x=-61331..-46012,y=16124..46377,z=30021..58251
on x=13523..38898,y=39757..51802,z=-80849..-47997
on x=-76565..-59468,y=-57669..-33215,z=-34630..-20509
on x=-1400..21705,y=2422..35923,z=65082..92708
on x=27173..33546,y=-32438..-5517,z=55534..74202
on x=742..13194,y=37510..69530,z=-71457..-44018
on x=-19002..5260,y=-25290..4257,z=74695..87855
on x=-58363..-33447,y=-83097..-46482,z=-3951..18854
on x=28257..54523,y=-12927..163,z=55716..68287
on x=-55035..-42787,y=-74598..-60601,z=-12347..10128
on x=-62156..-41368,y=-74777..-53620,z=1866..36062
on x=-74617..-63939,y=10063..31210,z=19837..42948
on x=65805..84962,y=-17277..-2998,z=-7935..1483
on x=51703..60399,y=-61929..-37543,z=-29370..-2561
on x=15740..42233,y=63708..84428,z=11383..36056
on x=-42732..-21419,y=-32411..-16372,z=66928..86844
on x=-52486..-38318,y=-9682..26282,z=-86082..-62163
on x=-7123..993,y=52948..67923,z=49669..65243
on x=19088..42696,y=-21822..6500,z=62076..87400
on x=-52958..-34321,y=61278..86126,z=-13763..-70
on x=-15101..-11247,y=22686..42715,z=-80534..-56264
on x=-46261..-23031,y=-82826..-68865,z=-3459..17151
on x=-58096..-27944,y=6888..11134,z=49657..68128
on x=48546..80464,y=-50357..-19939,z=31840..53793
on x=-21970..6415,y=-27807..-22157,z=68884..92720
on x=9153..28224,y=-78681..-59781,z=22289..33422
on x=-20712..-9892,y=-40377..-15252,z=-83815..-64487
on x=-39497..-21911,y=-84881..-54996,z=-16784..-9986
on x=49949..57637,y=17939..34965,z=37003..64800
on x=4692..24520,y=-85484..-75927,z=5267..27659
on x=36131..39665,y=29462..47124,z=34815..67018
on x=-41896..-12785,y=2675..23054,z=68711..89315
on x=71005..89113,y=2233..18466,z=-2688..11139
on x=-63652..-45278,y=-29842..-8926,z=57521..72421
on x=40267..44170,y=441..5710,z=-79598..-48806
on x=-28495..-8070,y=-90280..-55322,z=22624..35233
on x=1027..19541,y=-13836..6910,z=-92607..-66167
on x=-75935..-49114,y=-59649..-22105,z=-19799..1629
on x=7857..13485,y=63294..75170,z=36454..58731
on x=28331..47560,y=58222..68057,z=5217..18069
on x=-87608..-66688,y=-38062..-10679,z=4187..11042
on x=12977..42259,y=27949..35778,z=55761..80343
on x=70986..88739,y=-28498..-7556,z=-32649..-16525
on x=17149..30581,y=-4413..15849,z=56729..93439
on x=-21890..7091,y=-68328..-47029,z=-58888..-43745
on x=21484..37422,y=54086..71986,z=-29447..-6806
on x=15095..34026,y=-11880..17575,z=66625..83590
on x=11953..40331,y=52550..61932,z=-66251..-37789
on x=-30264..-27193,y=6182..16498,z=-84928..-56236
on x=-43369..-24543,y=-5046..3232,z=54101..79083
on x=5738..13682,y=-70346..-52526,z=-68616..-46922
on x=-2534..14172,y=-12170..12871,z=-79852..-76760
on x=-86147..-74989,y=-37600..-12696,z=-24746..-11211
on x=29873..59794,y=-77831..-49500,z=-32583..-15719
on x=-86032..-54986,y=-48300..-33549,z=-7787..12962
on x=-72715..-54120,y=37937..47214,z=40705..48901
on x=-92475..-64330,y=5360..29448,z=-37793..-27963
on x=40404..60843,y=11548..25111,z=-69956..-56964
on x=54246..81187,y=-15079..3255,z=-50885..-27386
on x=-24912..-9663,y=-20639..15429,z=67789..93208
on x=-2927..17582,y=-76610..-50899,z=47794..60363
on x=42449..64006,y=15111..36212,z=54464..75222
on x=41887..68593,y=-49656..-37558,z=-36868..-28650
on x=-15939..-2979,y=-23944..-1797,z=-87989..-77579
on x=8268..45902,y=-62706..-39472,z=-53552..-47799
on x=-44128..-16403,y=70160..78079,z=-19950..-7312
on x=-73424..-61281,y=-10564..5808,z=34490..50071
on x=44083..63495,y=42259..67644,z=-33849..-2333
on x=-9770..21432,y=-85042..-57670,z=-33315..-22609
on x=-76893..-55792,y=-40582..-13131,z=14145..21427
on x=56369..85932,y=-25829..9805,z=-24747..-17227
on x=-92014..-60349,y=4667..20917,z=-28043..-18375
on x=-22125..-2528,y=37213..70789,z=-66075..-36939
on x=-80310..-62718,y=-12253..16399,z=-7182..13282
on x=19604..21410,y=-26817..-5574,z=-90427..-61613
on x=14832..30711,y=-72125..-54222,z=41210..75841
on x=-45517..-25337,y=35721..50577,z=53874..74122
on x=-75179..-40171,y=-70174..-36530,z=-11370..13837
on x=22450..37061,y=-81465..-52779,z=8059..22711
on x=-25696..-7576,y=17606..35508,z=58767..82495
on x=-66861..-58712,y=-55885..-36331,z=-32783..-21378
on x=-29707..-6587,y=-38860..-21551,z=57880..78462
on x=-24290..-1697,y=73156..85237,z=9457..29769
on x=77708..85912,y=-15058..14573,z=464..17102
on x=48482..69872,y=-32313..-16480,z=-35446..-31417
on x=15087..29428,y=-51225..-25057,z=-84333..-54252
on x=-75993..-66314,y=-51277..-39068,z=-2482..34636
on x=47370..61193,y=-59411..-34580,z=-46403..-34734
on x=462..33671,y=-24840..-4601,z=-87331..-74274
on x=70121..87520,y=-29832..-10723,z=-10877..-1220
on x=42405..49379,y=12345..33953,z=-76791..-45281
on x=25827..53335,y=70681..86551,z=-29527..-9333
on x=-24220..-13376,y=-90635..-57951,z=-38671..-17627
on x=34089..46319,y=-30257..-3262,z=59766..83414
on x=-3543..24212,y=72845..97116,z=-15914..12199
on x=45797..70569,y=44223..73222,z=-14065..6709
on x=-48892..-28408,y=-73568..-56899,z=-58681..-32671
on x=4174..30365,y=-20514..-6291,z=-96665..-64810
on x=20300..39400,y=44422..75262,z=28427..46313
on x=-55624..-41820,y=-65432..-56978,z=-31652..286
on x=-11450..9091,y=-10872..13402,z=-96991..-73152
on x=21204..34163,y=-80092..-60720,z=-1684..22431
on x=17060..46228,y=69336..79113,z=-24273..5415
on x=-25163..-7939,y=-86858..-57398,z=-27038..-2085
on x=43391..63223,y=-56781..-28733,z=45855..50674
on x=-76143..-64377,y=12639..30333,z=-46616..-21890
on x=-50212..-37219,y=33871..46916,z=-57463..-50434
on x=-44846..-19148,y=-35934..-11791,z=49850..84697
on x=-640..22899,y=48209..65287,z=49133..73177
on x=54592..84319,y=24803..47688,z=2114..8678
on x=-92617..-59588,y=-29289..-10626,z=-14724..12609
on x=-25964..-3050,y=-73374..-57992,z=34305..66132
on x=-12245..13398,y=34318..53204,z=-87397..-60158
on x=-36485..-11107,y=-68013..-37892,z=-62787..-49434
on x=37115..55733,y=8383..15941,z=47494..75368
on x=-75971..-53751,y=22021..44775,z=-28873..-18032
on x=-49008..-21039,y=-8267..18986,z=-80986..-51927
on x=-83798..-70456,y=20888..40141,z=11927..24455
on x=34270..53974,y=40135..56157,z=43902..57438
on x=-82512..-67096,y=-23820..-5110,z=-37958..-17304
on x=6189..32274,y=-49266..-34156,z=47226..74149
on x=-2306..9175,y=-3892..14291,z=61061..96907
on x=48988..68463,y=-47383..-22949,z=10336..40294
on x=-56417..-43602,y=55500..70059,z=-13647..19293
on x=11811..33624,y=49294..81746,z=-54399..-25909
on x=46830..76409,y=-55090..-27702,z=-30918..-221
on x=38636..41083,y=46479..67076,z=-31378..-9906
on x=62579..77937,y=29662..47239,z=5201..34711
on x=-490..22015,y=-74767..-43669,z=37167..70764
on x=27504..47421,y=-82673..-58150,z=-22281..-3213
on x=-44896..-25622,y=852..19607,z=-81359..-69705
on x=28151..46436,y=58745..77168,z=-20668..8390
on x=-17715..9403,y=62066..75363,z=44786..55218
on x=-75940..-67265,y=-10213..-924,z=-38628..-31640
on x=31217..40710,y=17314..31717,z=65117..74572
on x=-20308..6174,y=43205..71982,z=29619..63139
on x=-17308..1659,y=-86208..-59633,z=-52006..-26842
on x=29589..59624,y=-37433..-8568,z=-79309..-56762
on x=65031..84055,y=-49205..-15112,z=11006..30050
on x=-21372..396,y=66959..76952,z=-48526..-15155
on x=61009..85874,y=-56544..-31835,z=-20281..7229
on x=39829..62015,y=7017..31719,z=-55310..-31538
on x=-60821..-44446,y=28090..49610,z=25989..40026
on x=-49222..-27762,y=-32609..-21439,z=52500..64630
on x=21167..42918,y=-84816..-52147,z=-25105..3457
on x=-53259..-29694,y=-64196..-46099,z=-48196..-33493
on x=-68316..-44311,y=-5009..12609,z=-78019..-42683
on x=74083..83368,y=-415..18724,z=23447..33253
on x=-40955..-11861,y=-52836..-34367,z=-80653..-66499
on x=-56851..-44271,y=7377..24996,z=-81605..-50284
on x=32861..40473,y=50341..87968,z=-36863..-2409
on x=5180..22440,y=24817..42675,z=52609..78955
on x=-20916..-11921,y=-2061..27136,z=69474..81153
on x=19358..47015,y=65233..91739,z=-14281..2968
on x=-33616..-12752,y=-78053..-54794,z=22887..42429
on x=-19205..1023,y=-255..18187,z=73021..96834
on x=-87808..-56140,y=21971..36015,z=-6804..5044
on x=16535..26930,y=-88551..-57919,z=-3602..23438
on x=-43384..-34834,y=42115..51388,z=35954..62475
on x=46842..67996,y=-30561..-10572,z=34391..61693
on x=65308..75105,y=-45336..-34318,z=-38603..-14593
on x=-29381..-842,y=39635..66374,z=-72505..-51783
on x=19541..43924,y=-27964..-1156,z=56998..71795
on x=-41599..-12907,y=57236..77873,z=-33254..-7202
on x=-12925..3772,y=9682..10440,z=60251..86455
on x=-38091..-15052,y=68317..79649,z=-6530..19197
on x=-27876..-245,y=-92866..-70732,z=14258..40146
on x=28338..54825,y=-66679..-47549,z=28405..61405
on x=27924..61969,y=-17469..7058,z=-85265..-56396
on x=27392..41945,y=-43260..-33414,z=46547..75933
on x=-78511..-63734,y=-24678..-14998,z=9915..37752
on x=-49364..-35496,y=-60349..-53447,z=7361..31514
on x=-71936..-47233,y=-15001..-5888,z=32696..65996
on x=57923..71056,y=-55069..-28399,z=-14127..5767
on x=-888..27644,y=-55228..-33657,z=-84157..-61628
on x=28089..46471,y=-53900..-23619,z=-74597..-58117
on x=-72265..-40139,y=-58596..-43497,z=-20143..4004
on x=33497..62632,y=33177..48726,z=45154..61718
on x=1671..25927,y=-62814..-49988,z=54990..72902
on x=-87473..-66985,y=-38979..-14679,z=-23773..1855
on x=-62582..-54735,y=-46368..-33411,z=35640..51508
on x=-61035..-34907,y=-54395..-24848,z=-72074..-42444
on x=17065..28809,y=46461..67244,z=-60449..-36152
on x=-23832..5385,y=-45973..-30838,z=-73488..-70531
on x=65148..88912,y=-2847..19944,z=-19967..-6140
on x=-19497..-4667,y=-64163..-30991,z=-78025..-48785
on x=-26451..-11823,y=-29224..-7737,z=73658..88731
on x=-82932..-52735,y=-45539..-30979,z=10567..21179
off x=-92771..-59379,y=-16457..4257,z=-19007..-9574
on x=-1367..31248,y=57471..87356,z=15551..28220
on x=-75012..-54630,y=-55900..-44885,z=30346..44985
off x=-15223..13088,y=-78880..-72375,z=4734..25256
on x=43236..52577,y=-69839..-51984,z=6755..32230
on x=583..22257,y=61453..79467,z=10416..40175
off x=-31804..-16150,y=4824..26831,z=-83185..-72155
off x=-9285..15493,y=-79971..-64647,z=15044..23748
on x=-20558..-907,y=-1511..16475,z=-94408..-68211
on x=9349..16066,y=-88459..-69703,z=9486..29642
off x=-66218..-55058,y=-55821..-31885,z=-23035..-7855
on x=48865..64085,y=37794..61139,z=-26580..-14009
on x=-95078..-63802,y=8335..29234,z=-2237..20065
off x=-69508..-56123,y=27252..31289,z=-38156..-19650
off x=-70922..-51507,y=-50382..-31957,z=-40660..-4985
off x=-57541..-50973,y=-72014..-48391,z=3526..33520
off x=773..17047,y=73688..78799,z=-21496..8612
on x=61668..87418,y=-28084..-20481,z=5607..28174
off x=-73265..-43940,y=-71319..-31963,z=330..2606
off x=-62083..-52201,y=49013..77320,z=4148..15653
off x=26642..41317,y=40506..46548,z=51535..79896
off x=52972..66990,y=445..14012,z=-51681..-42025
on x=42853..70560,y=-15867..1001,z=-69206..-47437
on x=265..30834,y=10388..17493,z=-77188..-73360
on x=-78212..-60790,y=-46357..-17341,z=-19705..7414
off x=-76352..-67476,y=-37933..-12763,z=-42438..-19895
on x=-75518..-54964,y=9426..27692,z=35057..60978
on x=2146..20631,y=4395..27477,z=71606..85235
on x=56391..85365,y=31311..50805,z=-23143..-8347
off x=-43966..-10016,y=34807..66384,z=-60754..-50829
on x=-15094..8503,y=-27728..-8538,z=-79377..-72993
on x=29190..57302,y=46506..72855,z=-30671..-7542
on x=-64255..-51681,y=11753..42628,z=-57110..-38832
on x=-80699..-55614,y=8369..38347,z=13371..25973
off x=-78348..-61911,y=-34350..-12108,z=15236..18924
off x=67082..79129,y=14861..30463,z=-21904..-1187
on x=-38339..-10096,y=68418..92762,z=14007..24434
on x=6408..10962,y=-87098..-75403,z=-12865..6329
on x=-57661..-33118,y=-64601..-58093,z=-16187..5034
on x=55082..85478,y=22775..40291,z=9832..20490
off x=33050..40034,y=-73707..-57249,z=4699..9429
on x=-17542..-4918,y=-7211..11870,z=63570..83676
off x=19487..43578,y=36308..63914,z=34798..68427
on x=22912..30894,y=-12217..-3410,z=-83243..-71225
off x=-55370..-48528,y=40393..52276,z=21306..49482
on x=66160..86330,y=229..19595,z=-7009..13869
on x=-27177..-21723,y=-67893..-39523,z=42055..70588
off x=-68346..-43122,y=34800..53170,z=38717..58704
off x=-80284..-62731,y=14493..39505,z=-26685..2374
off x=-34567..-21284,y=-54882..-31559,z=56989..65462
on x=55380..83881,y=-9599..5560,z=18154..43897
on x=-70828..-59888,y=-26580..-3497,z=37494..39828
off x=-71116..-48814,y=-38215..-21127,z=23543..27328
off x=-34528..230,y=1852..33753,z=72155..86121
on x=67116..78066,y=-40050..-6174,z=8388..32390
on x=13410..43479,y=-55125..-25746,z=-74768..-53351
on x=49063..63781,y=-61106..-46135,z=9895..22870
off x=-1425..9223,y=66508..92068,z=-13899..16756
off x=-9117..16063,y=-15752..-12115,z=-94562..-72728
on x=-58753..-51534,y=-49165..-17671,z=33901..53822
on x=7153..22158,y=-83289..-61209,z=16596..45537
off x=7637..29944,y=-43030..-25380,z=49845..81541
on x=42943..67786,y=22270..49157,z=-68053..-31422
off x=-22060..13939,y=-85803..-54518,z=-47498..-23790
on x=-67789..-56980,y=29536..53811,z=16555..41405
off x=8783..36105,y=-74490..-57458,z=-47532..-28500
on x=-39728..-10832,y=15549..34402,z=-75059..-58634
on x=31427..56607,y=-67918..-42061,z=20909..39524
off x=25479..49327,y=-55403..-27845,z=-70293..-33988
off x=-83124..-67063,y=10786..30836,z=-5409..4272
on x=48388..74069,y=-20126..-9891,z=45754..57214
on x=-83319..-72508,y=-44758..-6078,z=-7461..12714
off x=-51710..-29174,y=-71805..-59459,z=-39495..-9286
on x=11397..25603,y=62844..80298,z=-33884..-3361
off x=-41952..-25840,y=67515..77092,z=625..16326
on x=61728..82893,y=26424..59431,z=23104..30590
on x=15920..46476,y=-26919..9275,z=53439..81334
off x=31455..47096,y=37517..57362,z=-52330..-33037
off x=31507..60699,y=49115..60004,z=8569..27924
on x=-63375..-47681,y=-59637..-36566,z=7657..31139
on x=-5321..6583,y=24676..37612,z=73380..87922
on x=-33355..-21974,y=-49605..-28786,z=-59731..-44638
off x=-88258..-74995,y=8221..20922,z=-23664..-9367
off x=-7332..14472,y=4110..22213,z=71160..94830
on x=-2767..16221,y=69925..85459,z=-36754..-11679
on x=-53366..-28050,y=25154..47084,z=59437..83245
on x=28475..39110,y=49964..74955,z=34604..43348
off x=-56937..-50782,y=-70141..-41181,z=537..4650
on x=-44639..-22992,y=-63641..-38656,z=28938..62580
on x=48280..83512,y=-26457..-12540,z=24110..49982
on x=19947..45036,y=-3989..17108,z=-86265..-57378
on x=-60872..-39283,y=7992..14709,z=63886..83432
off x=-51941..-37880,y=35276..51515,z=-54439..-30474
off x=24503..47865,y=11066..33542,z=55048..75103
off x=-50711..-36369,y=25865..44688,z=42144..75991
off x=-28199..-23045,y=17550..39078,z=-88417..-66145
off x=54837..65647,y=-48274..-28576,z=-42539..-24309
off x=-47795..-17051,y=27580..37807,z=63653..79743
off x=-60130..-42268,y=11555..34572,z=63159..77298
on x=-79005..-56674,y=23641..40328,z=-58031..-27561
off x=31626..43749,y=18580..35707,z=-66906..-60834
off x=-13653..20014,y=8405..31911,z=63944..91665
off x=40172..61732,y=-21572..12900,z=56708..72005
off x=-67236..-52715,y=-35224..-25687,z=-59722..-26819
off x=-67455..-37128,y=35866..59440,z=41145..63188
off x=5803..42135,y=-84172..-58861,z=-8..16604
off x=52192..72300,y=43741..63019,z=-18039..14759
off x=-22453..2437,y=24464..46409,z=63184..82625
on x=-44310..-9655,y=-70059..-49907,z=-56238..-23669
off x=-17621..7155,y=-88485..-62501,z=-24602..-8009
on x=13276..40408,y=4606..41676,z=65311..80515
on x=-1006..24995,y=18113..38645,z=-84569..-72217
off x=64437..83136,y=1890..23367,z=16476..27363
on x=35010..53193,y=-55320..-43774,z=20373..51087
on x=-64384..-48267,y=44423..56003,z=-18857..-9400
off x=31205..43280,y=-43836..-19524,z=51886..74790
off x=-5947..9322,y=-81930..-78866,z=-7683..-2477
on x=54017..63005,y=-5488..18126,z=-64387..-33315
on x=-7665..19314,y=-87204..-71260,z=-12799..25207
on x=39193..63881,y=52000..62411,z=3795..27504
on x=-24990..-7300,y=-77790..-69904,z=31621..47387
off x=-38510..-28288,y=57807..67545,z=15554..47422
off x=-34944..3388,y=77165..93727,z=-16170..9641
off x=-41415..-21700,y=60257..82802,z=-56333..-25675
off x=62770..97851,y=-7291..10726,z=-13608..22487
off x=-48699..-41800,y=-31006..-11249,z=-74209..-50407
off x=-78388..-50804,y=32344..42083,z=-50438..-26976
on x=26305..40943,y=12820..27310,z=-77487..-68283
on x=31671..48537,y=-75532..-47870,z=-15406..12899
on x=59169..84490,y=-12765..15733,z=23259..28835
off x=-51323..-24129,y=60227..76675,z=-35769..-29926
on x=-15798..6117,y=57711..74446,z=-60488..-41049
on x=21147..32666,y=43096..58631,z=-56614..-36478
on x=10377..38912,y=-64602..-45304,z=-63854..-31795
on x=-31665..-6977,y=59619..90993,z=-6283..2294
on x=60812..84211,y=-35898..314,z=-21245..12959
on x=47111..70846,y=-1397..20856,z=-59002..-45577
off x=2199..23957,y=58797..75241,z=-28476..-587
off x=68508..72590,y=-39118..-14205,z=25501..36916
off x=54353..83388,y=-1999..14388,z=22363..45016
on x=-12427..19508,y=-3861..35431,z=-94183..-71829
on x=-9064..962,y=67313..91954,z=-29762..-6435
off x=-881..15774,y=-95061..-66106,z=-22649..5343
on x=26090..43628,y=19086..48156,z=59268..64826
on x=13925..23438,y=49815..81694,z=22718..54246
on x=-29167..-18018,y=-65567..-44797,z=-57668..-52005
on x=-12743..1442,y=-78440..-66511,z=22892..50938
on x=-57883..-52350,y=44703..53300,z=26801..55081
off x=-28980..-2788,y=47385..66723,z=-72168..-37213
on x=36215..64744,y=-64592..-52748,z=9520..24557
on x=47942..68987,y=-28105..5362,z=-55396..-22040
on x=62037..65643,y=-6893..24359,z=-57169..-42400
on x=-43695..-24044,y=45383..77918,z=-55007..-21204
off x=-74002..-58100,y=-4488..20127,z=-69873..-43514
off x=-8561..13460,y=-75084..-69913,z=-49438..-26923
off x=-40321..-16124,y=-26832..1874,z=-94992..-62985
on x=33941..57894,y=23060..45229,z=-59031..-50766
off x=8919..16828,y=-85554..-68188,z=-12984..9433
on x=34743..44353,y=-73173..-57374,z=18404..49220
off x=-81768..-57232,y=1136..37228,z=-45326..-29507
off x=-37088..-19193,y=1847..27592,z=66581..78184
off x=4478..25254,y=-33024..-17970,z=-87648..-63250
off x=4460..19630,y=41737..61017,z=46373..80528
off x=-67697..-47052,y=-15585..8024,z=34467..56438
off x=-13248..18021,y=-41905..-14364,z=-81154..-61452
on x=28825..50192,y=-46951..-34745,z=30973..58633
off x=1020..26298,y=63206..75945,z=-42362..-21527
off x=-61697..-39985,y=6813..24047,z=42212..73204
on x=27916..45500,y=48978..62342,z=37904..41296
on x=-76876..-56049,y=17644..48556,z=-16011..9274
off x=54782..66404,y=32617..58336,z=39026..59781
off x=-3518..11894,y=12741..50819,z=56777..81740
off x=49919..55504,y=-75565..-55817,z=4242..19862
on x=-38082..-27626,y=-20410..-11250,z=60824..86367
off x=-21695..454,y=-28773..-25700,z=69788..76674
off x=69885..90686,y=2372..30936,z=26127..39085
on x=-77300..-54769,y=21606..41995,z=-9235..21141
on x=41828..67228,y=-72110..-50770,z=8799..14057
on x=-72954..-67838,y=-30443..-15818,z=5814..24267
on x=-85602..-66786,y=-15910..7735,z=27067..56631
on x=-47556..-31886,y=-1133..15883,z=-86994..-51175
on x=-19068..-9928,y=-9125..5457,z=64607..86052
off x=-8774..13180,y=-37519..-17879,z=61146..91746
off x=-81128..-57345,y=1437..19322,z=28966..46183
off x=8893..42429,y=-80767..-53599,z=-30603..-14432
off x=-69558..-57397,y=-51936..-38238,z=-46930..-26311
on x=-14953..11765,y=-81486..-68749,z=1306..28342
on x=-51953..-35667,y=-71311..-47093,z=-14698..17598
on x=-18321..-2908,y=-72297..-57565,z=-56058..-40444
off x=-75865..-65179,y=-27284..-3890,z=-51487..-35823
off x=-8857..-1295,y=-49171..-37514,z=58010..83011
off x=2069..34305,y=16099..40442,z=-72675..-64954
off x=-41164..-31749,y=36265..67646,z=35332..57760
on x=-14757..3123,y=-74970..-40823,z=48397..58528
off x=48931..60409,y=7243..13678,z=46406..63757
off x=-55140..-24134,y=66480..86956,z=-18559..17916
off x=10389..17046,y=3161..18093,z=68157..89555
on x=41075..47341,y=-37638..-21308,z=-62935..-57527
on x=-37115..-22996,y=-77183..-53520,z=-50827..-20078
on x=42851..49378,y=21471..33110,z=51101..73578";
    }
}