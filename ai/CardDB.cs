namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public struct targett
    {
        public int target;
        public int targetEntity;

        public targett(int targ, int ent)
        {
            this.target = targ;
            this.targetEntity = ent;
        }
    }


    public class CardDB
    {
        // Data is stored in hearthstone-folder -> data->win cardxml0
        //(data-> cardxml0 seems outdated (blutelfkleriker has 3hp there >_>)
        public enum cardtype
        {
            NONE,
            MOB,
            SPELL,
            WEAPON,
            HEROPWR,
            ENCHANTMENT,

        }

        public enum cardrace
        {
            INVALID,
            BLOODELF,
            DRAENEI,
            DWARF,
            GNOME,
            GOBLIN,
            HUMAN,
            NIGHTELF,
            ORC,
            TAUREN,
            TROLL,
            UNDEAD,
            WORGEN,
            GOBLIN2,
            MURLOC,
            DEMON,
            SCOURGE,
            MECHANICAL,
            ELEMENTAL,
            OGRE,
            PET,
            TOTEM,
            NERUBIAN,
            PIRATE,
            DRAGON
        }


        public enum cardIDEnum
        {
            None,
            XXX_040,
            NAX5_01H,
            CS2_188o,
            NAX6_02H,
            NEW1_007b,
            NAX6_02e,
            TU4c_003,
            XXX_024,
            EX1_613,
            NAX8_01,
            EX1_295o,
            CS2_059o,
            EX1_133,
            NEW1_018,
            NAX15_03t,
            EX1_012,
            EX1_178a,
            CS2_231,
            EX1_019e,
            CRED_12,
            CS2_179,
            CS2_045e,
            EX1_244,
            EX1_178b,
            XXX_030,
            NAX8_05,
            EX1_573b,
            TU4d_001,
            NEW1_007a,
            NAX12_02H,
            EX1_345t,
            FP1_007t,
            EX1_025,
            EX1_396,
            NAX9_03,
            NEW1_017,
            NEW1_008a,
            EX1_587e,
            EX1_533,
            EX1_522,
            NAX11_04,
            NEW1_026,
            EX1_398,
            NAX4_04,
            EX1_007,
            CS1_112,
            CRED_17,
            NEW1_036,
            NAX3_03,
            EX1_355e,
            EX1_258,
            HERO_01,
            XXX_009,
            NAX6_01H,
            NAX12_04e,
            CS2_087,
            DREAM_05,
            NEW1_036e,
            CS2_092,
            CS2_022,
            EX1_046,
            XXX_005,
            PRO_001b,
            XXX_022,
            PRO_001a,
            NAX6_04,
            NAX7_05,
            CS2_103,
            NEW1_041,
            EX1_360,
            FP1_023,
            NEW1_038,
            CS2_009,
            NAX10_01H,
            EX1_010,
            CS2_024,
            NAX9_05,
            EX1_565,
            CS2_076,
            FP1_004,
            CS2_046e,
            CS2_162,
            EX1_110t,
            CS2_104e,
            CS2_181,
            EX1_309,
            EX1_354,
            NAX10_02H,
            NAX7_04H,
            TU4f_001,
            XXX_018,
            EX1_023,
            XXX_048,
            XXX_049,
            NEW1_034,
            CS2_003,
            HERO_06,
            CS2_201,
            EX1_508,
            EX1_259,
            EX1_341,
            DREAM_05e,
            CRED_09,
            EX1_103,
            FP1_021,
            EX1_411,
            NAX1_04,
            CS2_053,
            CS2_182,
            CS2_008,
            CS2_233,
            EX1_626,
            EX1_059,
            EX1_334,
            EX1_619,
            NEW1_032,
            EX1_158t,
            EX1_006,
            NEW1_031,
            NAX10_03,
            DREAM_04,
            NAX1h_01,
            CS2_022e,
            EX1_611e,
            EX1_004,
            EX1_014te,
            FP1_005e,
            NAX12_03e,
            EX1_095,
            NEW1_007,
            EX1_275,
            EX1_245,
            EX1_383,
            FP1_016,
            EX1_016t,
            CS2_125,
            EX1_137,
            EX1_178ae,
            DS1_185,
            FP1_010,
            EX1_598,
            NAX9_07,
            EX1_304,
            EX1_302,
            XXX_017,
            CS2_011o,
            EX1_614t,
            TU4a_006,
            Mekka3e,
            CS2_108,
            CS2_046,
            EX1_014t,
            NEW1_005,
            EX1_062,
            EX1_366e,
            Mekka1,
            XXX_007,
            tt_010a,
            CS2_017o,
            CS2_072,
            EX1_tk28,
            EX1_604o,
            FP1_014,
            EX1_084e,
            NAX3_01H,
            NAX2_01,
            EX1_409t,
            CRED_07,
            NAX3_02H,
            TU4e_002,
            EX1_507,
            EX1_144,
            CS2_038,
            EX1_093,
            CS2_080,
            CS1_129e,
            XXX_013,
            EX1_005,
            EX1_382,
            NAX13_02e,
            FP1_020e,
            EX1_603e,
            CS2_028,
            TU4f_002,
            EX1_538,
            GAME_003e,
            DREAM_02,
            EX1_581,
            NAX15_01H,
            EX1_131t,
            CS2_147,
            CS1_113,
            CS2_161,
            CS2_031,
            EX1_166b,
            EX1_066,
            TU4c_007,
            EX1_355,
            EX1_507e,
            EX1_534,
            EX1_162,
            TU4a_004,
            EX1_363,
            EX1_164a,
            CS2_188,
            EX1_016,
            NAX6_03t,
            EX1_tk31,
            EX1_603,
            EX1_238,
            EX1_166,
            DS1h_292,
            DS1_183,
            NAX15_03n,
            NAX8_02H,
            NAX7_01H,
            NAX9_02H,
            CRED_11,
            XXX_019,
            EX1_076,
            EX1_048,
            CS2_038e,
            FP1_026,
            CS2_074,
            FP1_027,
            EX1_323w,
            EX1_129,
            NEW1_024o,
            NAX11_02,
            EX1_405,
            EX1_317,
            EX1_606,
            EX1_590e,
            XXX_044,
            CS2_074e,
            TU4a_005,
            FP1_006,
            EX1_258e,
            TU4f_004o,
            NEW1_008,
            CS2_119,
            NEW1_017e,
            EX1_334e,
            TU4e_001,
            CS2_121,
            CS1h_001,
            EX1_tk34,
            NEW1_020,
            CS2_196,
            EX1_312,
            NAX1_01,
            FP1_022,
            EX1_160b,
            EX1_563,
            XXX_039,
            FP1_031,
            CS2_087e,
            EX1_613e,
            NAX9_02,
            NEW1_029,
            CS1_129,
            HERO_03,
            Mekka4t,
            EX1_158,
            XXX_010,
            NEW1_025,
            FP1_012t,
            EX1_083,
            EX1_295,
            EX1_407,
            NEW1_004,
            FP1_019,
            PRO_001at,
            NAX13_03e,
            EX1_625t,
            EX1_014,
            CRED_04,
            NAX12_01H,
            CS2_097,
            EX1_558,
            XXX_047,
            EX1_tk29,
            CS2_186,
            EX1_084,
            NEW1_012,
            FP1_014t,
            NAX1_03,
            EX1_623e,
            EX1_578,
            CS2_073e2,
            CS2_221,
            EX1_019,
            NAX15_04a,
            FP1_019t,
            EX1_132,
            EX1_284,
            EX1_105,
            NEW1_011,
            NAX9_07e,
            EX1_017,
            EX1_249,
            EX1_162o,
            FP1_002t,
            NAX3_02,
            EX1_313,
            EX1_549o,
            EX1_091o,
            CS2_084e,
            EX1_155b,
            NAX11_01,
            NEW1_033,
            CS2_106,
            XXX_002,
            FP1_018,
            NEW1_036e2,
            XXX_004,
            NAX11_02H,
            CS2_122e,
            DS1_233,
            DS1_175,
            NEW1_024,
            CS2_189,
            CRED_10,
            NEW1_037,
            EX1_414,
            EX1_538t,
            FP1_030e,
            EX1_586,
            EX1_310,
            NEW1_010,
            CS2_103e,
            EX1_080o,
            CS2_005o,
            EX1_363e2,
            EX1_534t,
            FP1_028,
            EX1_604,
            EX1_160,
            EX1_165t1,
            CS2_062,
            CS2_155,
            CS2_213,
            TU4f_007,
            GAME_004,
            NAX5_01,
            XXX_020,
            NAX15_02H,
            CS2_004,
            NAX2_03H,
            EX1_561e,
            CS2_023,
            EX1_164,
            EX1_009,
            NAX6_01,
            FP1_007,
            NAX1h_04,
            NAX2_05H,
            NAX10_02,
            EX1_345,
            EX1_116,
            EX1_399,
            EX1_587,
            XXX_026,
            EX1_571,
            EX1_335,
            XXX_050,
            TU4e_004,
            HERO_08,
            EX1_166a,
            NAX2_03,
            EX1_finkle,
            NAX4_03H,
            EX1_164b,
            EX1_283,
            EX1_339,
            CRED_13,
            EX1_178be,
            EX1_531,
            EX1_134,
            EX1_350,
            EX1_308,
            CS2_197,
            skele21,
            CS2_222o,
            XXX_015,
            FP1_013,
            NEW1_006,
            EX1_399e,
            EX1_509,
            EX1_612,
            NAX8_05t,
            NAX9_05H,
            EX1_021,
            CS2_041e,
            CS2_226,
            EX1_608,
            NAX13_05H,
            NAX13_04H,
            TU4c_008,
            EX1_624,
            EX1_616,
            EX1_008,
            PlaceholderCard,
            XXX_016,
            EX1_045,
            EX1_015,
            GAME_003,
            CS2_171,
            CS2_041,
            EX1_128,
            CS2_112,
            HERO_07,
            EX1_412,
            EX1_612o,
            CS2_117,
            XXX_009e,
            EX1_562,
            EX1_055,
            NAX9_06,
            TU4e_007,
            FP1_012,
            EX1_317t,
            EX1_004e,
            EX1_278,
            CS2_tk1,
            EX1_590,
            CS1_130,
            NEW1_008b,
            EX1_365,
            CS2_141,
            PRO_001,
            NAX8_04t,
            CS2_173,
            CS2_017,
            CRED_16,
            EX1_392,
            EX1_593,
            FP1_023e,
            NAX1_05,
            TU4d_002,
            CRED_15,
            EX1_049,
            EX1_002,
            TU4f_005,
            NEW1_029t,
            TU4a_001,
            CS2_056,
            EX1_596,
            EX1_136,
            EX1_323,
            CS2_073,
            EX1_246e,
            NAX12_01,
            EX1_244e,
            EX1_001,
            EX1_607e,
            EX1_044,
            EX1_573ae,
            XXX_025,
            CRED_06,
            Mekka4,
            CS2_142,
            TU4f_004,
            NAX5_02H,
            EX1_411e2,
            EX1_573,
            FP1_009,
            CS2_050,
            NAX4_03,
            CS2_063e,
            NAX2_05,
            EX1_390,
            EX1_610,
            hexfrog,
            CS2_181e,
            NAX6_02,
            XXX_027,
            CS2_082,
            NEW1_040,
            DREAM_01,
            EX1_595,
            CS2_013,
            CS2_077,
            NEW1_014,
            CRED_05,
            GAME_002,
            EX1_165,
            CS2_013t,
            NAX4_04H,
            EX1_tk11,
            EX1_591,
            EX1_549,
            CS2_045,
            CS2_237,
            CS2_027,
            EX1_508o,
            NAX14_03,
            CS2_101t,
            CS2_063,
            EX1_145,
            NAX1h_03,
            EX1_110,
            EX1_408,
            EX1_544,
            TU4c_006,
            NAXM_001,
            CS2_151,
            CS2_073e,
            XXX_006,
            CS2_088,
            EX1_057,
            FP1_020,
            CS2_169,
            EX1_573t,
            EX1_323h,
            EX1_tk9,
            NEW1_018e,
            CS2_037,
            CS2_007,
            EX1_059e2,
            CS2_227,
            NAX7_03H,
            NAX9_01H,
            EX1_570e,
            NEW1_003,
            GAME_006,
            EX1_320,
            EX1_097,
            tt_004,
            EX1_360e,
            EX1_096,
            DS1_175o,
            EX1_596e,
            XXX_014,
            EX1_158e,
            NAX14_01,
            CRED_01,
            CRED_08,
            EX1_126,
            EX1_577,
            EX1_319,
            EX1_611,
            CS2_146,
            EX1_154b,
            skele11,
            EX1_165t2,
            CS2_172,
            CS2_114,
            CS1_069,
            XXX_003,
            XXX_042,
            NAX8_02,
            EX1_173,
            CS1_042,
            NAX8_03,
            EX1_506a,
            EX1_298,
            CS2_104,
            FP1_001,
            HERO_02,
            EX1_316e,
            NAX7_01,
            EX1_044e,
            CS2_051,
            NEW1_016,
            EX1_304e,
            EX1_033,
            NAX8_04,
            EX1_028,
            XXX_011,
            EX1_621,
            EX1_554,
            EX1_091,
            FP1_017,
            EX1_409,
            EX1_363e,
            EX1_410,
            TU4e_005,
            CS2_039,
            NAX12_04,
            EX1_557,
            CS2_105e,
            EX1_128e,
            XXX_021,
            DS1_070,
            CS2_033,
            EX1_536,
            TU4a_003,
            EX1_559,
            XXX_023,
            NEW1_033o,
            NAX15_04H,
            CS2_004e,
            CS2_052,
            EX1_539,
            EX1_575,
            CS2_083b,
            CS2_061,
            NEW1_021,
            DS1_055,
            EX1_625,
            EX1_382e,
            CS2_092e,
            CS2_026,
            NAX14_04,
            NEW1_012o,
            EX1_619e,
            EX1_294,
            EX1_287,
            EX1_509e,
            EX1_625t2,
            CS2_118,
            CS2_124,
            Mekka3,
            NAX13_02,
            EX1_112,
            FP1_011,
            CS2_009e,
            HERO_04,
            EX1_607,
            DREAM_03,
            NAX11_04e,
            EX1_103e,
            XXX_046,
            FP1_003,
            CS2_105,
            FP1_002,
            TU4c_002,
            CRED_14,
            EX1_567,
            TU4c_004,
            NAX10_03H,
            FP1_008,
            DS1_184,
            CS2_029,
            GAME_005,
            CS2_187,
            EX1_020,
            NAX15_01He,
            EX1_011,
            CS2_057,
            EX1_274,
            EX1_306,
            NEW1_038o,
            EX1_170,
            EX1_617,
            CS1_113e,
            CS2_101,
            FP1_015,
            NAX13_03,
            CS2_005,
            EX1_537,
            EX1_384,
            TU4a_002,
            NAX9_04,
            EX1_362,
            NAX12_02,
            FP1_028e,
            TU4c_005,
            EX1_301,
            CS2_235,
            NAX4_05,
            EX1_029,
            CS2_042,
            EX1_155a,
            CS2_102,
            EX1_609,
            NEW1_027,
            CS2_236e,
            CS2_083e,
            NAX6_03te,
            EX1_165a,
            EX1_570,
            EX1_131,
            EX1_556,
            EX1_543,
            XXX_096,
            TU4c_008e,
            EX1_379e,
            NEW1_009,
            EX1_100,
            EX1_274e,
            CRED_02,
            EX1_573a,
            CS2_084,
            EX1_582,
            EX1_043,
            EX1_050,
            TU4b_001,
            FP1_005,
            EX1_620,
            NAX15_01,
            NAX6_03,
            EX1_303,
            HERO_09,
            EX1_067,
            XXX_028,
            EX1_277,
            Mekka2,
            NAX14_01H,
            NAX15_04,
            FP1_024,
            FP1_030,
            CS2_221e,
            EX1_178,
            CS2_222,
            EX1_409e,
            tt_004o,
            EX1_155ae,
            NAX11_01H,
            EX1_160a,
            NAX15_02,
            NAX15_05,
            NEW1_025e,
            CS2_012,
            XXX_099,
            EX1_246,
            EX1_572,
            EX1_089,
            CS2_059,
            EX1_279,
            NAX12_02e,
            CS2_168,
            tt_010,
            NEW1_023,
            CS2_075,
            EX1_316,
            CS2_025,
            CS2_234,
            XXX_043,
            GAME_001,
            NAX5_02,
            EX1_130,
            EX1_584e,
            CS2_064,
            EX1_161,
            CS2_049,
            NAX13_01,
            EX1_154,
            EX1_080,
            NEW1_022,
            NAX2_01H,
            EX1_160be,
            NAX12_03,
            EX1_251,
            FP1_025,
            EX1_371,
            CS2_mirror,
            NAX4_01H,
            EX1_594,
            NAX14_02,
            TU4c_006e,
            EX1_560,
            CS2_236,
            TU4f_006,
            EX1_402,
            NAX3_01,
            EX1_506,
            NEW1_027e,
            DS1_070o,
            XXX_045,
            XXX_029,
            DS1_178,
            XXX_098,
            EX1_315,
            CS2_094,
            NAX13_01H,
            TU4e_002t,
            EX1_046e,
            NEW1_040t,
            GAME_005e,
            CS2_131,
            XXX_008,
            EX1_531e,
            CS2_226e,
            XXX_022e,
            DS1_178e,
            CS2_226o,
            NAX9_04H,
            Mekka4e,
            EX1_082,
            CS2_093,
            EX1_411e,
            NAX8_03t,
            EX1_145o,
            NAX7_04,
            CS2_boar,
            NEW1_019,
            EX1_289,
            EX1_025t,
            EX1_398t,
            NAX12_03H,
            EX1_055o,
            CS2_091,
            EX1_241,
            EX1_085,
            CS2_200,
            CS2_034,
            EX1_583,
            EX1_584,
            EX1_155,
            EX1_622,
            CS2_203,
            EX1_124,
            EX1_379,
            NAX7_02,
            CS2_053e,
            EX1_032,
            NAX9_01,
            TU4e_003,
            CS2_146o,
            NAX8_01H,
            XXX_041,
            NAXM_002,
            EX1_391,
            EX1_366,
            EX1_059e,
            XXX_012,
            EX1_565o,
            EX1_001e,
            TU4f_003,
            EX1_400,
            EX1_614,
            EX1_561,
            EX1_332,
            HERO_05,
            CS2_065,
            ds1_whelptoken,
            EX1_536e,
            CS2_032,
            CS2_120,
            EX1_155be,
            EX1_247,
            EX1_154a,
            EX1_554t,
            CS2_103e2,
            TU4d_003,
            NEW1_026t,
            EX1_623,
            EX1_383t,
            NAX7_03,
            EX1_597,
            TU4f_006o,
            EX1_130a,
            CS2_011,
            EX1_169,
            EX1_tk33,
            NAX11_03,
            NAX4_01,
            NAX10_01,
            EX1_250,
            EX1_564,
            NAX5_03,
            EX1_043e,
            EX1_349,
            XXX_097,
            EX1_102,
            EX1_058,
            EX1_243,
            PRO_001c,
            EX1_116t,
            NAX15_01e,
            FP1_029,
            CS2_089,
            TU4c_001,
            EX1_248,
            NEW1_037e,
            CS2_122,
            EX1_393,
            CS2_232,
            EX1_165b,
            NEW1_030,
            EX1_161o,
            EX1_093e,
            CS2_150,
            CS2_152,
            NAX9_03H,
            EX1_160t,
            CS2_127,
            CRED_03,
            DS1_188,
            XXX_001,
        }

        public cardIDEnum cardIdstringToEnum(string s)
        {
            switch (s)
            {
                case "XXX_040":
                    return cardIDEnum.XXX_040;
                case "NAX5_01H":
                    return cardIDEnum.NAX5_01H;
                case "CS2_188o":
                    return cardIDEnum.CS2_188o;
                case "NAX6_02H":
                    return cardIDEnum.NAX6_02H;
                case "NEW1_007b":
                    return cardIDEnum.NEW1_007b;
                case "NAX6_02e":
                    return cardIDEnum.NAX6_02e;
                case "TU4c_003":
                    return cardIDEnum.TU4c_003;
                case "XXX_024":
                    return cardIDEnum.XXX_024;
                case "EX1_613":
                    return cardIDEnum.EX1_613;
                case "NAX8_01":
                    return cardIDEnum.NAX8_01;
                case "EX1_295o":
                    return cardIDEnum.EX1_295o;
                case "CS2_059o":
                    return cardIDEnum.CS2_059o;
                case "EX1_133":
                    return cardIDEnum.EX1_133;
                case "NEW1_018":
                    return cardIDEnum.NEW1_018;
                case "NAX15_03t":
                    return cardIDEnum.NAX15_03t;
                case "EX1_012":
                    return cardIDEnum.EX1_012;
                case "EX1_178a":
                    return cardIDEnum.EX1_178a;
                case "CS2_231":
                    return cardIDEnum.CS2_231;
                case "EX1_019e":
                    return cardIDEnum.EX1_019e;
                case "CRED_12":
                    return cardIDEnum.CRED_12;
                case "CS2_179":
                    return cardIDEnum.CS2_179;
                case "CS2_045e":
                    return cardIDEnum.CS2_045e;
                case "EX1_244":
                    return cardIDEnum.EX1_244;
                case "EX1_178b":
                    return cardIDEnum.EX1_178b;
                case "XXX_030":
                    return cardIDEnum.XXX_030;
                case "NAX8_05":
                    return cardIDEnum.NAX8_05;
                case "EX1_573b":
                    return cardIDEnum.EX1_573b;
                case "TU4d_001":
                    return cardIDEnum.TU4d_001;
                case "NEW1_007a":
                    return cardIDEnum.NEW1_007a;
                case "NAX12_02H":
                    return cardIDEnum.NAX12_02H;
                case "EX1_345t":
                    return cardIDEnum.EX1_345t;
                case "FP1_007t":
                    return cardIDEnum.FP1_007t;
                case "EX1_025":
                    return cardIDEnum.EX1_025;
                case "EX1_396":
                    return cardIDEnum.EX1_396;
                case "NAX9_03":
                    return cardIDEnum.NAX9_03;
                case "NEW1_017":
                    return cardIDEnum.NEW1_017;
                case "NEW1_008a":
                    return cardIDEnum.NEW1_008a;
                case "EX1_587e":
                    return cardIDEnum.EX1_587e;
                case "EX1_533":
                    return cardIDEnum.EX1_533;
                case "EX1_522":
                    return cardIDEnum.EX1_522;
                case "NAX11_04":
                    return cardIDEnum.NAX11_04;
                case "NEW1_026":
                    return cardIDEnum.NEW1_026;
                case "EX1_398":
                    return cardIDEnum.EX1_398;
                case "NAX4_04":
                    return cardIDEnum.NAX4_04;
                case "EX1_007":
                    return cardIDEnum.EX1_007;
                case "CS1_112":
                    return cardIDEnum.CS1_112;
                case "CRED_17":
                    return cardIDEnum.CRED_17;
                case "NEW1_036":
                    return cardIDEnum.NEW1_036;
                case "NAX3_03":
                    return cardIDEnum.NAX3_03;
                case "EX1_355e":
                    return cardIDEnum.EX1_355e;
                case "EX1_258":
                    return cardIDEnum.EX1_258;
                case "HERO_01":
                    return cardIDEnum.HERO_01;
                case "XXX_009":
                    return cardIDEnum.XXX_009;
                case "NAX6_01H":
                    return cardIDEnum.NAX6_01H;
                case "NAX12_04e":
                    return cardIDEnum.NAX12_04e;
                case "CS2_087":
                    return cardIDEnum.CS2_087;
                case "DREAM_05":
                    return cardIDEnum.DREAM_05;
                case "NEW1_036e":
                    return cardIDEnum.NEW1_036e;
                case "CS2_092":
                    return cardIDEnum.CS2_092;
                case "CS2_022":
                    return cardIDEnum.CS2_022;
                case "EX1_046":
                    return cardIDEnum.EX1_046;
                case "XXX_005":
                    return cardIDEnum.XXX_005;
                case "PRO_001b":
                    return cardIDEnum.PRO_001b;
                case "XXX_022":
                    return cardIDEnum.XXX_022;
                case "PRO_001a":
                    return cardIDEnum.PRO_001a;
                case "NAX6_04":
                    return cardIDEnum.NAX6_04;
                case "NAX7_05":
                    return cardIDEnum.NAX7_05;
                case "CS2_103":
                    return cardIDEnum.CS2_103;
                case "NEW1_041":
                    return cardIDEnum.NEW1_041;
                case "EX1_360":
                    return cardIDEnum.EX1_360;
                case "FP1_023":
                    return cardIDEnum.FP1_023;
                case "NEW1_038":
                    return cardIDEnum.NEW1_038;
                case "CS2_009":
                    return cardIDEnum.CS2_009;
                case "NAX10_01H":
                    return cardIDEnum.NAX10_01H;
                case "EX1_010":
                    return cardIDEnum.EX1_010;
                case "CS2_024":
                    return cardIDEnum.CS2_024;
                case "NAX9_05":
                    return cardIDEnum.NAX9_05;
                case "EX1_565":
                    return cardIDEnum.EX1_565;
                case "CS2_076":
                    return cardIDEnum.CS2_076;
                case "FP1_004":
                    return cardIDEnum.FP1_004;
                case "CS2_046e":
                    return cardIDEnum.CS2_046e;
                case "CS2_162":
                    return cardIDEnum.CS2_162;
                case "EX1_110t":
                    return cardIDEnum.EX1_110t;
                case "CS2_104e":
                    return cardIDEnum.CS2_104e;
                case "CS2_181":
                    return cardIDEnum.CS2_181;
                case "EX1_309":
                    return cardIDEnum.EX1_309;
                case "EX1_354":
                    return cardIDEnum.EX1_354;
                case "NAX10_02H":
                    return cardIDEnum.NAX10_02H;
                case "NAX7_04H":
                    return cardIDEnum.NAX7_04H;
                case "TU4f_001":
                    return cardIDEnum.TU4f_001;
                case "XXX_018":
                    return cardIDEnum.XXX_018;
                case "EX1_023":
                    return cardIDEnum.EX1_023;
                case "XXX_048":
                    return cardIDEnum.XXX_048;
                case "XXX_049":
                    return cardIDEnum.XXX_049;
                case "NEW1_034":
                    return cardIDEnum.NEW1_034;
                case "CS2_003":
                    return cardIDEnum.CS2_003;
                case "HERO_06":
                    return cardIDEnum.HERO_06;
                case "CS2_201":
                    return cardIDEnum.CS2_201;
                case "EX1_508":
                    return cardIDEnum.EX1_508;
                case "EX1_259":
                    return cardIDEnum.EX1_259;
                case "EX1_341":
                    return cardIDEnum.EX1_341;
                case "DREAM_05e":
                    return cardIDEnum.DREAM_05e;
                case "CRED_09":
                    return cardIDEnum.CRED_09;
                case "EX1_103":
                    return cardIDEnum.EX1_103;
                case "FP1_021":
                    return cardIDEnum.FP1_021;
                case "EX1_411":
                    return cardIDEnum.EX1_411;
                case "NAX1_04":
                    return cardIDEnum.NAX1_04;
                case "CS2_053":
                    return cardIDEnum.CS2_053;
                case "CS2_182":
                    return cardIDEnum.CS2_182;
                case "CS2_008":
                    return cardIDEnum.CS2_008;
                case "CS2_233":
                    return cardIDEnum.CS2_233;
                case "EX1_626":
                    return cardIDEnum.EX1_626;
                case "EX1_059":
                    return cardIDEnum.EX1_059;
                case "EX1_334":
                    return cardIDEnum.EX1_334;
                case "EX1_619":
                    return cardIDEnum.EX1_619;
                case "NEW1_032":
                    return cardIDEnum.NEW1_032;
                case "EX1_158t":
                    return cardIDEnum.EX1_158t;
                case "EX1_006":
                    return cardIDEnum.EX1_006;
                case "NEW1_031":
                    return cardIDEnum.NEW1_031;
                case "NAX10_03":
                    return cardIDEnum.NAX10_03;
                case "DREAM_04":
                    return cardIDEnum.DREAM_04;
                case "NAX1h_01":
                    return cardIDEnum.NAX1h_01;
                case "CS2_022e":
                    return cardIDEnum.CS2_022e;
                case "EX1_611e":
                    return cardIDEnum.EX1_611e;
                case "EX1_004":
                    return cardIDEnum.EX1_004;
                case "EX1_014te":
                    return cardIDEnum.EX1_014te;
                case "FP1_005e":
                    return cardIDEnum.FP1_005e;
                case "NAX12_03e":
                    return cardIDEnum.NAX12_03e;
                case "EX1_095":
                    return cardIDEnum.EX1_095;
                case "NEW1_007":
                    return cardIDEnum.NEW1_007;
                case "EX1_275":
                    return cardIDEnum.EX1_275;
                case "EX1_245":
                    return cardIDEnum.EX1_245;
                case "EX1_383":
                    return cardIDEnum.EX1_383;
                case "FP1_016":
                    return cardIDEnum.FP1_016;
                case "EX1_016t":
                    return cardIDEnum.EX1_016t;
                case "CS2_125":
                    return cardIDEnum.CS2_125;
                case "EX1_137":
                    return cardIDEnum.EX1_137;
                case "EX1_178ae":
                    return cardIDEnum.EX1_178ae;
                case "DS1_185":
                    return cardIDEnum.DS1_185;
                case "FP1_010":
                    return cardIDEnum.FP1_010;
                case "EX1_598":
                    return cardIDEnum.EX1_598;
                case "NAX9_07":
                    return cardIDEnum.NAX9_07;
                case "EX1_304":
                    return cardIDEnum.EX1_304;
                case "EX1_302":
                    return cardIDEnum.EX1_302;
                case "XXX_017":
                    return cardIDEnum.XXX_017;
                case "CS2_011o":
                    return cardIDEnum.CS2_011o;
                case "EX1_614t":
                    return cardIDEnum.EX1_614t;
                case "TU4a_006":
                    return cardIDEnum.TU4a_006;
                case "Mekka3e":
                    return cardIDEnum.Mekka3e;
                case "CS2_108":
                    return cardIDEnum.CS2_108;
                case "CS2_046":
                    return cardIDEnum.CS2_046;
                case "EX1_014t":
                    return cardIDEnum.EX1_014t;
                case "NEW1_005":
                    return cardIDEnum.NEW1_005;
                case "EX1_062":
                    return cardIDEnum.EX1_062;
                case "EX1_366e":
                    return cardIDEnum.EX1_366e;
                case "Mekka1":
                    return cardIDEnum.Mekka1;
                case "XXX_007":
                    return cardIDEnum.XXX_007;
                case "tt_010a":
                    return cardIDEnum.tt_010a;
                case "CS2_017o":
                    return cardIDEnum.CS2_017o;
                case "CS2_072":
                    return cardIDEnum.CS2_072;
                case "EX1_tk28":
                    return cardIDEnum.EX1_tk28;
                case "EX1_604o":
                    return cardIDEnum.EX1_604o;
                case "FP1_014":
                    return cardIDEnum.FP1_014;
                case "EX1_084e":
                    return cardIDEnum.EX1_084e;
                case "NAX3_01H":
                    return cardIDEnum.NAX3_01H;
                case "NAX2_01":
                    return cardIDEnum.NAX2_01;
                case "EX1_409t":
                    return cardIDEnum.EX1_409t;
                case "CRED_07":
                    return cardIDEnum.CRED_07;
                case "NAX3_02H":
                    return cardIDEnum.NAX3_02H;
                case "TU4e_002":
                    return cardIDEnum.TU4e_002;
                case "EX1_507":
                    return cardIDEnum.EX1_507;
                case "EX1_144":
                    return cardIDEnum.EX1_144;
                case "CS2_038":
                    return cardIDEnum.CS2_038;
                case "EX1_093":
                    return cardIDEnum.EX1_093;
                case "CS2_080":
                    return cardIDEnum.CS2_080;
                case "CS1_129e":
                    return cardIDEnum.CS1_129e;
                case "XXX_013":
                    return cardIDEnum.XXX_013;
                case "EX1_005":
                    return cardIDEnum.EX1_005;
                case "EX1_382":
                    return cardIDEnum.EX1_382;
                case "NAX13_02e":
                    return cardIDEnum.NAX13_02e;
                case "FP1_020e":
                    return cardIDEnum.FP1_020e;
                case "EX1_603e":
                    return cardIDEnum.EX1_603e;
                case "CS2_028":
                    return cardIDEnum.CS2_028;
                case "TU4f_002":
                    return cardIDEnum.TU4f_002;
                case "EX1_538":
                    return cardIDEnum.EX1_538;
                case "GAME_003e":
                    return cardIDEnum.GAME_003e;
                case "DREAM_02":
                    return cardIDEnum.DREAM_02;
                case "EX1_581":
                    return cardIDEnum.EX1_581;
                case "NAX15_01H":
                    return cardIDEnum.NAX15_01H;
                case "EX1_131t":
                    return cardIDEnum.EX1_131t;
                case "CS2_147":
                    return cardIDEnum.CS2_147;
                case "CS1_113":
                    return cardIDEnum.CS1_113;
                case "CS2_161":
                    return cardIDEnum.CS2_161;
                case "CS2_031":
                    return cardIDEnum.CS2_031;
                case "EX1_166b":
                    return cardIDEnum.EX1_166b;
                case "EX1_066":
                    return cardIDEnum.EX1_066;
                case "TU4c_007":
                    return cardIDEnum.TU4c_007;
                case "EX1_355":
                    return cardIDEnum.EX1_355;
                case "EX1_507e":
                    return cardIDEnum.EX1_507e;
                case "EX1_534":
                    return cardIDEnum.EX1_534;
                case "EX1_162":
                    return cardIDEnum.EX1_162;
                case "TU4a_004":
                    return cardIDEnum.TU4a_004;
                case "EX1_363":
                    return cardIDEnum.EX1_363;
                case "EX1_164a":
                    return cardIDEnum.EX1_164a;
                case "CS2_188":
                    return cardIDEnum.CS2_188;
                case "EX1_016":
                    return cardIDEnum.EX1_016;
                case "NAX6_03t":
                    return cardIDEnum.NAX6_03t;
                case "EX1_tk31":
                    return cardIDEnum.EX1_tk31;
                case "EX1_603":
                    return cardIDEnum.EX1_603;
                case "EX1_238":
                    return cardIDEnum.EX1_238;
                case "EX1_166":
                    return cardIDEnum.EX1_166;
                case "DS1h_292":
                    return cardIDEnum.DS1h_292;
                case "DS1_183":
                    return cardIDEnum.DS1_183;
                case "NAX15_03n":
                    return cardIDEnum.NAX15_03n;
                case "NAX8_02H":
                    return cardIDEnum.NAX8_02H;
                case "NAX7_01H":
                    return cardIDEnum.NAX7_01H;
                case "NAX9_02H":
                    return cardIDEnum.NAX9_02H;
                case "CRED_11":
                    return cardIDEnum.CRED_11;
                case "XXX_019":
                    return cardIDEnum.XXX_019;
                case "EX1_076":
                    return cardIDEnum.EX1_076;
                case "EX1_048":
                    return cardIDEnum.EX1_048;
                case "CS2_038e":
                    return cardIDEnum.CS2_038e;
                case "FP1_026":
                    return cardIDEnum.FP1_026;
                case "CS2_074":
                    return cardIDEnum.CS2_074;
                case "FP1_027":
                    return cardIDEnum.FP1_027;
                case "EX1_323w":
                    return cardIDEnum.EX1_323w;
                case "EX1_129":
                    return cardIDEnum.EX1_129;
                case "NEW1_024o":
                    return cardIDEnum.NEW1_024o;
                case "NAX11_02":
                    return cardIDEnum.NAX11_02;
                case "EX1_405":
                    return cardIDEnum.EX1_405;
                case "EX1_317":
                    return cardIDEnum.EX1_317;
                case "EX1_606":
                    return cardIDEnum.EX1_606;
                case "EX1_590e":
                    return cardIDEnum.EX1_590e;
                case "XXX_044":
                    return cardIDEnum.XXX_044;
                case "CS2_074e":
                    return cardIDEnum.CS2_074e;
                case "TU4a_005":
                    return cardIDEnum.TU4a_005;
                case "FP1_006":
                    return cardIDEnum.FP1_006;
                case "EX1_258e":
                    return cardIDEnum.EX1_258e;
                case "TU4f_004o":
                    return cardIDEnum.TU4f_004o;
                case "NEW1_008":
                    return cardIDEnum.NEW1_008;
                case "CS2_119":
                    return cardIDEnum.CS2_119;
                case "NEW1_017e":
                    return cardIDEnum.NEW1_017e;
                case "EX1_334e":
                    return cardIDEnum.EX1_334e;
                case "TU4e_001":
                    return cardIDEnum.TU4e_001;
                case "CS2_121":
                    return cardIDEnum.CS2_121;
                case "CS1h_001":
                    return cardIDEnum.CS1h_001;
                case "EX1_tk34":
                    return cardIDEnum.EX1_tk34;
                case "NEW1_020":
                    return cardIDEnum.NEW1_020;
                case "CS2_196":
                    return cardIDEnum.CS2_196;
                case "EX1_312":
                    return cardIDEnum.EX1_312;
                case "NAX1_01":
                    return cardIDEnum.NAX1_01;
                case "FP1_022":
                    return cardIDEnum.FP1_022;
                case "EX1_160b":
                    return cardIDEnum.EX1_160b;
                case "EX1_563":
                    return cardIDEnum.EX1_563;
                case "XXX_039":
                    return cardIDEnum.XXX_039;
                case "FP1_031":
                    return cardIDEnum.FP1_031;
                case "CS2_087e":
                    return cardIDEnum.CS2_087e;
                case "EX1_613e":
                    return cardIDEnum.EX1_613e;
                case "NAX9_02":
                    return cardIDEnum.NAX9_02;
                case "NEW1_029":
                    return cardIDEnum.NEW1_029;
                case "CS1_129":
                    return cardIDEnum.CS1_129;
                case "HERO_03":
                    return cardIDEnum.HERO_03;
                case "Mekka4t":
                    return cardIDEnum.Mekka4t;
                case "EX1_158":
                    return cardIDEnum.EX1_158;
                case "XXX_010":
                    return cardIDEnum.XXX_010;
                case "NEW1_025":
                    return cardIDEnum.NEW1_025;
                case "FP1_012t":
                    return cardIDEnum.FP1_012t;
                case "EX1_083":
                    return cardIDEnum.EX1_083;
                case "EX1_295":
                    return cardIDEnum.EX1_295;
                case "EX1_407":
                    return cardIDEnum.EX1_407;
                case "NEW1_004":
                    return cardIDEnum.NEW1_004;
                case "FP1_019":
                    return cardIDEnum.FP1_019;
                case "PRO_001at":
                    return cardIDEnum.PRO_001at;
                case "NAX13_03e":
                    return cardIDEnum.NAX13_03e;
                case "EX1_625t":
                    return cardIDEnum.EX1_625t;
                case "EX1_014":
                    return cardIDEnum.EX1_014;
                case "CRED_04":
                    return cardIDEnum.CRED_04;
                case "NAX12_01H":
                    return cardIDEnum.NAX12_01H;
                case "CS2_097":
                    return cardIDEnum.CS2_097;
                case "EX1_558":
                    return cardIDEnum.EX1_558;
                case "XXX_047":
                    return cardIDEnum.XXX_047;
                case "EX1_tk29":
                    return cardIDEnum.EX1_tk29;
                case "CS2_186":
                    return cardIDEnum.CS2_186;
                case "EX1_084":
                    return cardIDEnum.EX1_084;
                case "NEW1_012":
                    return cardIDEnum.NEW1_012;
                case "FP1_014t":
                    return cardIDEnum.FP1_014t;
                case "NAX1_03":
                    return cardIDEnum.NAX1_03;
                case "EX1_623e":
                    return cardIDEnum.EX1_623e;
                case "EX1_578":
                    return cardIDEnum.EX1_578;
                case "CS2_073e2":
                    return cardIDEnum.CS2_073e2;
                case "CS2_221":
                    return cardIDEnum.CS2_221;
                case "EX1_019":
                    return cardIDEnum.EX1_019;
                case "NAX15_04a":
                    return cardIDEnum.NAX15_04a;
                case "FP1_019t":
                    return cardIDEnum.FP1_019t;
                case "EX1_132":
                    return cardIDEnum.EX1_132;
                case "EX1_284":
                    return cardIDEnum.EX1_284;
                case "EX1_105":
                    return cardIDEnum.EX1_105;
                case "NEW1_011":
                    return cardIDEnum.NEW1_011;
                case "NAX9_07e":
                    return cardIDEnum.NAX9_07e;
                case "EX1_017":
                    return cardIDEnum.EX1_017;
                case "EX1_249":
                    return cardIDEnum.EX1_249;
                case "EX1_162o":
                    return cardIDEnum.EX1_162o;
                case "FP1_002t":
                    return cardIDEnum.FP1_002t;
                case "NAX3_02":
                    return cardIDEnum.NAX3_02;
                case "EX1_313":
                    return cardIDEnum.EX1_313;
                case "EX1_549o":
                    return cardIDEnum.EX1_549o;
                case "EX1_091o":
                    return cardIDEnum.EX1_091o;
                case "CS2_084e":
                    return cardIDEnum.CS2_084e;
                case "EX1_155b":
                    return cardIDEnum.EX1_155b;
                case "NAX11_01":
                    return cardIDEnum.NAX11_01;
                case "NEW1_033":
                    return cardIDEnum.NEW1_033;
                case "CS2_106":
                    return cardIDEnum.CS2_106;
                case "XXX_002":
                    return cardIDEnum.XXX_002;
                case "FP1_018":
                    return cardIDEnum.FP1_018;
                case "NEW1_036e2":
                    return cardIDEnum.NEW1_036e2;
                case "XXX_004":
                    return cardIDEnum.XXX_004;
                case "NAX11_02H":
                    return cardIDEnum.NAX11_02H;
                case "CS2_122e":
                    return cardIDEnum.CS2_122e;
                case "DS1_233":
                    return cardIDEnum.DS1_233;
                case "DS1_175":
                    return cardIDEnum.DS1_175;
                case "NEW1_024":
                    return cardIDEnum.NEW1_024;
                case "CS2_189":
                    return cardIDEnum.CS2_189;
                case "CRED_10":
                    return cardIDEnum.CRED_10;
                case "NEW1_037":
                    return cardIDEnum.NEW1_037;
                case "EX1_414":
                    return cardIDEnum.EX1_414;
                case "EX1_538t":
                    return cardIDEnum.EX1_538t;
                case "FP1_030e":
                    return cardIDEnum.FP1_030e;
                case "EX1_586":
                    return cardIDEnum.EX1_586;
                case "EX1_310":
                    return cardIDEnum.EX1_310;
                case "NEW1_010":
                    return cardIDEnum.NEW1_010;
                case "CS2_103e":
                    return cardIDEnum.CS2_103e;
                case "EX1_080o":
                    return cardIDEnum.EX1_080o;
                case "CS2_005o":
                    return cardIDEnum.CS2_005o;
                case "EX1_363e2":
                    return cardIDEnum.EX1_363e2;
                case "EX1_534t":
                    return cardIDEnum.EX1_534t;
                case "FP1_028":
                    return cardIDEnum.FP1_028;
                case "EX1_604":
                    return cardIDEnum.EX1_604;
                case "EX1_160":
                    return cardIDEnum.EX1_160;
                case "EX1_165t1":
                    return cardIDEnum.EX1_165t1;
                case "CS2_062":
                    return cardIDEnum.CS2_062;
                case "CS2_155":
                    return cardIDEnum.CS2_155;
                case "CS2_213":
                    return cardIDEnum.CS2_213;
                case "TU4f_007":
                    return cardIDEnum.TU4f_007;
                case "GAME_004":
                    return cardIDEnum.GAME_004;
                case "NAX5_01":
                    return cardIDEnum.NAX5_01;
                case "XXX_020":
                    return cardIDEnum.XXX_020;
                case "NAX15_02H":
                    return cardIDEnum.NAX15_02H;
                case "CS2_004":
                    return cardIDEnum.CS2_004;
                case "NAX2_03H":
                    return cardIDEnum.NAX2_03H;
                case "EX1_561e":
                    return cardIDEnum.EX1_561e;
                case "CS2_023":
                    return cardIDEnum.CS2_023;
                case "EX1_164":
                    return cardIDEnum.EX1_164;
                case "EX1_009":
                    return cardIDEnum.EX1_009;
                case "NAX6_01":
                    return cardIDEnum.NAX6_01;
                case "FP1_007":
                    return cardIDEnum.FP1_007;
                case "NAX1h_04":
                    return cardIDEnum.NAX1h_04;
                case "NAX2_05H":
                    return cardIDEnum.NAX2_05H;
                case "NAX10_02":
                    return cardIDEnum.NAX10_02;
                case "EX1_345":
                    return cardIDEnum.EX1_345;
                case "EX1_116":
                    return cardIDEnum.EX1_116;
                case "EX1_399":
                    return cardIDEnum.EX1_399;
                case "EX1_587":
                    return cardIDEnum.EX1_587;
                case "XXX_026":
                    return cardIDEnum.XXX_026;
                case "EX1_571":
                    return cardIDEnum.EX1_571;
                case "EX1_335":
                    return cardIDEnum.EX1_335;
                case "XXX_050":
                    return cardIDEnum.XXX_050;
                case "TU4e_004":
                    return cardIDEnum.TU4e_004;
                case "HERO_08":
                    return cardIDEnum.HERO_08;
                case "EX1_166a":
                    return cardIDEnum.EX1_166a;
                case "NAX2_03":
                    return cardIDEnum.NAX2_03;
                case "EX1_finkle":
                    return cardIDEnum.EX1_finkle;
                case "NAX4_03H":
                    return cardIDEnum.NAX4_03H;
                case "EX1_164b":
                    return cardIDEnum.EX1_164b;
                case "EX1_283":
                    return cardIDEnum.EX1_283;
                case "EX1_339":
                    return cardIDEnum.EX1_339;
                case "CRED_13":
                    return cardIDEnum.CRED_13;
                case "EX1_178be":
                    return cardIDEnum.EX1_178be;
                case "EX1_531":
                    return cardIDEnum.EX1_531;
                case "EX1_134":
                    return cardIDEnum.EX1_134;
                case "EX1_350":
                    return cardIDEnum.EX1_350;
                case "EX1_308":
                    return cardIDEnum.EX1_308;
                case "CS2_197":
                    return cardIDEnum.CS2_197;
                case "skele21":
                    return cardIDEnum.skele21;
                case "CS2_222o":
                    return cardIDEnum.CS2_222o;
                case "XXX_015":
                    return cardIDEnum.XXX_015;
                case "FP1_013":
                    return cardIDEnum.FP1_013;
                case "NEW1_006":
                    return cardIDEnum.NEW1_006;
                case "EX1_399e":
                    return cardIDEnum.EX1_399e;
                case "EX1_509":
                    return cardIDEnum.EX1_509;
                case "EX1_612":
                    return cardIDEnum.EX1_612;
                case "NAX8_05t":
                    return cardIDEnum.NAX8_05t;
                case "NAX9_05H":
                    return cardIDEnum.NAX9_05H;
                case "EX1_021":
                    return cardIDEnum.EX1_021;
                case "CS2_041e":
                    return cardIDEnum.CS2_041e;
                case "CS2_226":
                    return cardIDEnum.CS2_226;
                case "EX1_608":
                    return cardIDEnum.EX1_608;
                case "NAX13_05H":
                    return cardIDEnum.NAX13_05H;
                case "NAX13_04H":
                    return cardIDEnum.NAX13_04H;
                case "TU4c_008":
                    return cardIDEnum.TU4c_008;
                case "EX1_624":
                    return cardIDEnum.EX1_624;
                case "EX1_616":
                    return cardIDEnum.EX1_616;
                case "EX1_008":
                    return cardIDEnum.EX1_008;
                case "PlaceholderCard":
                    return cardIDEnum.PlaceholderCard;
                case "XXX_016":
                    return cardIDEnum.XXX_016;
                case "EX1_045":
                    return cardIDEnum.EX1_045;
                case "EX1_015":
                    return cardIDEnum.EX1_015;
                case "GAME_003":
                    return cardIDEnum.GAME_003;
                case "CS2_171":
                    return cardIDEnum.CS2_171;
                case "CS2_041":
                    return cardIDEnum.CS2_041;
                case "EX1_128":
                    return cardIDEnum.EX1_128;
                case "CS2_112":
                    return cardIDEnum.CS2_112;
                case "HERO_07":
                    return cardIDEnum.HERO_07;
                case "EX1_412":
                    return cardIDEnum.EX1_412;
                case "EX1_612o":
                    return cardIDEnum.EX1_612o;
                case "CS2_117":
                    return cardIDEnum.CS2_117;
                case "XXX_009e":
                    return cardIDEnum.XXX_009e;
                case "EX1_562":
                    return cardIDEnum.EX1_562;
                case "EX1_055":
                    return cardIDEnum.EX1_055;
                case "NAX9_06":
                    return cardIDEnum.NAX9_06;
                case "TU4e_007":
                    return cardIDEnum.TU4e_007;
                case "FP1_012":
                    return cardIDEnum.FP1_012;
                case "EX1_317t":
                    return cardIDEnum.EX1_317t;
                case "EX1_004e":
                    return cardIDEnum.EX1_004e;
                case "EX1_278":
                    return cardIDEnum.EX1_278;
                case "CS2_tk1":
                    return cardIDEnum.CS2_tk1;
                case "EX1_590":
                    return cardIDEnum.EX1_590;
                case "CS1_130":
                    return cardIDEnum.CS1_130;
                case "NEW1_008b":
                    return cardIDEnum.NEW1_008b;
                case "EX1_365":
                    return cardIDEnum.EX1_365;
                case "CS2_141":
                    return cardIDEnum.CS2_141;
                case "PRO_001":
                    return cardIDEnum.PRO_001;
                case "NAX8_04t":
                    return cardIDEnum.NAX8_04t;
                case "CS2_173":
                    return cardIDEnum.CS2_173;
                case "CS2_017":
                    return cardIDEnum.CS2_017;
                case "CRED_16":
                    return cardIDEnum.CRED_16;
                case "EX1_392":
                    return cardIDEnum.EX1_392;
                case "EX1_593":
                    return cardIDEnum.EX1_593;
                case "FP1_023e":
                    return cardIDEnum.FP1_023e;
                case "NAX1_05":
                    return cardIDEnum.NAX1_05;
                case "TU4d_002":
                    return cardIDEnum.TU4d_002;
                case "CRED_15":
                    return cardIDEnum.CRED_15;
                case "EX1_049":
                    return cardIDEnum.EX1_049;
                case "EX1_002":
                    return cardIDEnum.EX1_002;
                case "TU4f_005":
                    return cardIDEnum.TU4f_005;
                case "NEW1_029t":
                    return cardIDEnum.NEW1_029t;
                case "TU4a_001":
                    return cardIDEnum.TU4a_001;
                case "CS2_056":
                    return cardIDEnum.CS2_056;
                case "EX1_596":
                    return cardIDEnum.EX1_596;
                case "EX1_136":
                    return cardIDEnum.EX1_136;
                case "EX1_323":
                    return cardIDEnum.EX1_323;
                case "CS2_073":
                    return cardIDEnum.CS2_073;
                case "EX1_246e":
                    return cardIDEnum.EX1_246e;
                case "NAX12_01":
                    return cardIDEnum.NAX12_01;
                case "EX1_244e":
                    return cardIDEnum.EX1_244e;
                case "EX1_001":
                    return cardIDEnum.EX1_001;
                case "EX1_607e":
                    return cardIDEnum.EX1_607e;
                case "EX1_044":
                    return cardIDEnum.EX1_044;
                case "EX1_573ae":
                    return cardIDEnum.EX1_573ae;
                case "XXX_025":
                    return cardIDEnum.XXX_025;
                case "CRED_06":
                    return cardIDEnum.CRED_06;
                case "Mekka4":
                    return cardIDEnum.Mekka4;
                case "CS2_142":
                    return cardIDEnum.CS2_142;
                case "TU4f_004":
                    return cardIDEnum.TU4f_004;
                case "NAX5_02H":
                    return cardIDEnum.NAX5_02H;
                case "EX1_411e2":
                    return cardIDEnum.EX1_411e2;
                case "EX1_573":
                    return cardIDEnum.EX1_573;
                case "FP1_009":
                    return cardIDEnum.FP1_009;
                case "CS2_050":
                    return cardIDEnum.CS2_050;
                case "NAX4_03":
                    return cardIDEnum.NAX4_03;
                case "CS2_063e":
                    return cardIDEnum.CS2_063e;
                case "NAX2_05":
                    return cardIDEnum.NAX2_05;
                case "EX1_390":
                    return cardIDEnum.EX1_390;
                case "EX1_610":
                    return cardIDEnum.EX1_610;
                case "hexfrog":
                    return cardIDEnum.hexfrog;
                case "CS2_181e":
                    return cardIDEnum.CS2_181e;
                case "NAX6_02":
                    return cardIDEnum.NAX6_02;
                case "XXX_027":
                    return cardIDEnum.XXX_027;
                case "CS2_082":
                    return cardIDEnum.CS2_082;
                case "NEW1_040":
                    return cardIDEnum.NEW1_040;
                case "DREAM_01":
                    return cardIDEnum.DREAM_01;
                case "EX1_595":
                    return cardIDEnum.EX1_595;
                case "CS2_013":
                    return cardIDEnum.CS2_013;
                case "CS2_077":
                    return cardIDEnum.CS2_077;
                case "NEW1_014":
                    return cardIDEnum.NEW1_014;
                case "CRED_05":
                    return cardIDEnum.CRED_05;
                case "GAME_002":
                    return cardIDEnum.GAME_002;
                case "EX1_165":
                    return cardIDEnum.EX1_165;
                case "CS2_013t":
                    return cardIDEnum.CS2_013t;
                case "NAX4_04H":
                    return cardIDEnum.NAX4_04H;
                case "EX1_tk11":
                    return cardIDEnum.EX1_tk11;
                case "EX1_591":
                    return cardIDEnum.EX1_591;
                case "EX1_549":
                    return cardIDEnum.EX1_549;
                case "CS2_045":
                    return cardIDEnum.CS2_045;
                case "CS2_237":
                    return cardIDEnum.CS2_237;
                case "CS2_027":
                    return cardIDEnum.CS2_027;
                case "EX1_508o":
                    return cardIDEnum.EX1_508o;
                case "NAX14_03":
                    return cardIDEnum.NAX14_03;
                case "CS2_101t":
                    return cardIDEnum.CS2_101t;
                case "CS2_063":
                    return cardIDEnum.CS2_063;
                case "EX1_145":
                    return cardIDEnum.EX1_145;
                case "NAX1h_03":
                    return cardIDEnum.NAX1h_03;
                case "EX1_110":
                    return cardIDEnum.EX1_110;
                case "EX1_408":
                    return cardIDEnum.EX1_408;
                case "EX1_544":
                    return cardIDEnum.EX1_544;
                case "TU4c_006":
                    return cardIDEnum.TU4c_006;
                case "NAXM_001":
                    return cardIDEnum.NAXM_001;
                case "CS2_151":
                    return cardIDEnum.CS2_151;
                case "CS2_073e":
                    return cardIDEnum.CS2_073e;
                case "XXX_006":
                    return cardIDEnum.XXX_006;
                case "CS2_088":
                    return cardIDEnum.CS2_088;
                case "EX1_057":
                    return cardIDEnum.EX1_057;
                case "FP1_020":
                    return cardIDEnum.FP1_020;
                case "CS2_169":
                    return cardIDEnum.CS2_169;
                case "EX1_573t":
                    return cardIDEnum.EX1_573t;
                case "EX1_323h":
                    return cardIDEnum.EX1_323h;
                case "EX1_tk9":
                    return cardIDEnum.EX1_tk9;
                case "NEW1_018e":
                    return cardIDEnum.NEW1_018e;
                case "CS2_037":
                    return cardIDEnum.CS2_037;
                case "CS2_007":
                    return cardIDEnum.CS2_007;
                case "EX1_059e2":
                    return cardIDEnum.EX1_059e2;
                case "CS2_227":
                    return cardIDEnum.CS2_227;
                case "NAX7_03H":
                    return cardIDEnum.NAX7_03H;
                case "NAX9_01H":
                    return cardIDEnum.NAX9_01H;
                case "EX1_570e":
                    return cardIDEnum.EX1_570e;
                case "NEW1_003":
                    return cardIDEnum.NEW1_003;
                case "GAME_006":
                    return cardIDEnum.GAME_006;
                case "EX1_320":
                    return cardIDEnum.EX1_320;
                case "EX1_097":
                    return cardIDEnum.EX1_097;
                case "tt_004":
                    return cardIDEnum.tt_004;
                case "EX1_360e":
                    return cardIDEnum.EX1_360e;
                case "EX1_096":
                    return cardIDEnum.EX1_096;
                case "DS1_175o":
                    return cardIDEnum.DS1_175o;
                case "EX1_596e":
                    return cardIDEnum.EX1_596e;
                case "XXX_014":
                    return cardIDEnum.XXX_014;
                case "EX1_158e":
                    return cardIDEnum.EX1_158e;
                case "NAX14_01":
                    return cardIDEnum.NAX14_01;
                case "CRED_01":
                    return cardIDEnum.CRED_01;
                case "CRED_08":
                    return cardIDEnum.CRED_08;
                case "EX1_126":
                    return cardIDEnum.EX1_126;
                case "EX1_577":
                    return cardIDEnum.EX1_577;
                case "EX1_319":
                    return cardIDEnum.EX1_319;
                case "EX1_611":
                    return cardIDEnum.EX1_611;
                case "CS2_146":
                    return cardIDEnum.CS2_146;
                case "EX1_154b":
                    return cardIDEnum.EX1_154b;
                case "skele11":
                    return cardIDEnum.skele11;
                case "EX1_165t2":
                    return cardIDEnum.EX1_165t2;
                case "CS2_172":
                    return cardIDEnum.CS2_172;
                case "CS2_114":
                    return cardIDEnum.CS2_114;
                case "CS1_069":
                    return cardIDEnum.CS1_069;
                case "XXX_003":
                    return cardIDEnum.XXX_003;
                case "XXX_042":
                    return cardIDEnum.XXX_042;
                case "NAX8_02":
                    return cardIDEnum.NAX8_02;
                case "EX1_173":
                    return cardIDEnum.EX1_173;
                case "CS1_042":
                    return cardIDEnum.CS1_042;
                case "NAX8_03":
                    return cardIDEnum.NAX8_03;
                case "EX1_506a":
                    return cardIDEnum.EX1_506a;
                case "EX1_298":
                    return cardIDEnum.EX1_298;
                case "CS2_104":
                    return cardIDEnum.CS2_104;
                case "FP1_001":
                    return cardIDEnum.FP1_001;
                case "HERO_02":
                    return cardIDEnum.HERO_02;
                case "EX1_316e":
                    return cardIDEnum.EX1_316e;
                case "NAX7_01":
                    return cardIDEnum.NAX7_01;
                case "EX1_044e":
                    return cardIDEnum.EX1_044e;
                case "CS2_051":
                    return cardIDEnum.CS2_051;
                case "NEW1_016":
                    return cardIDEnum.NEW1_016;
                case "EX1_304e":
                    return cardIDEnum.EX1_304e;
                case "EX1_033":
                    return cardIDEnum.EX1_033;
                case "NAX8_04":
                    return cardIDEnum.NAX8_04;
                case "EX1_028":
                    return cardIDEnum.EX1_028;
                case "XXX_011":
                    return cardIDEnum.XXX_011;
                case "EX1_621":
                    return cardIDEnum.EX1_621;
                case "EX1_554":
                    return cardIDEnum.EX1_554;
                case "EX1_091":
                    return cardIDEnum.EX1_091;
                case "FP1_017":
                    return cardIDEnum.FP1_017;
                case "EX1_409":
                    return cardIDEnum.EX1_409;
                case "EX1_363e":
                    return cardIDEnum.EX1_363e;
                case "EX1_410":
                    return cardIDEnum.EX1_410;
                case "TU4e_005":
                    return cardIDEnum.TU4e_005;
                case "CS2_039":
                    return cardIDEnum.CS2_039;
                case "NAX12_04":
                    return cardIDEnum.NAX12_04;
                case "EX1_557":
                    return cardIDEnum.EX1_557;
                case "CS2_105e":
                    return cardIDEnum.CS2_105e;
                case "EX1_128e":
                    return cardIDEnum.EX1_128e;
                case "XXX_021":
                    return cardIDEnum.XXX_021;
                case "DS1_070":
                    return cardIDEnum.DS1_070;
                case "CS2_033":
                    return cardIDEnum.CS2_033;
                case "EX1_536":
                    return cardIDEnum.EX1_536;
                case "TU4a_003":
                    return cardIDEnum.TU4a_003;
                case "EX1_559":
                    return cardIDEnum.EX1_559;
                case "XXX_023":
                    return cardIDEnum.XXX_023;
                case "NEW1_033o":
                    return cardIDEnum.NEW1_033o;
                case "NAX15_04H":
                    return cardIDEnum.NAX15_04H;
                case "CS2_004e":
                    return cardIDEnum.CS2_004e;
                case "CS2_052":
                    return cardIDEnum.CS2_052;
                case "EX1_539":
                    return cardIDEnum.EX1_539;
                case "EX1_575":
                    return cardIDEnum.EX1_575;
                case "CS2_083b":
                    return cardIDEnum.CS2_083b;
                case "CS2_061":
                    return cardIDEnum.CS2_061;
                case "NEW1_021":
                    return cardIDEnum.NEW1_021;
                case "DS1_055":
                    return cardIDEnum.DS1_055;
                case "EX1_625":
                    return cardIDEnum.EX1_625;
                case "EX1_382e":
                    return cardIDEnum.EX1_382e;
                case "CS2_092e":
                    return cardIDEnum.CS2_092e;
                case "CS2_026":
                    return cardIDEnum.CS2_026;
                case "NAX14_04":
                    return cardIDEnum.NAX14_04;
                case "NEW1_012o":
                    return cardIDEnum.NEW1_012o;
                case "EX1_619e":
                    return cardIDEnum.EX1_619e;
                case "EX1_294":
                    return cardIDEnum.EX1_294;
                case "EX1_287":
                    return cardIDEnum.EX1_287;
                case "EX1_509e":
                    return cardIDEnum.EX1_509e;
                case "EX1_625t2":
                    return cardIDEnum.EX1_625t2;
                case "CS2_118":
                    return cardIDEnum.CS2_118;
                case "CS2_124":
                    return cardIDEnum.CS2_124;
                case "Mekka3":
                    return cardIDEnum.Mekka3;
                case "NAX13_02":
                    return cardIDEnum.NAX13_02;
                case "EX1_112":
                    return cardIDEnum.EX1_112;
                case "FP1_011":
                    return cardIDEnum.FP1_011;
                case "CS2_009e":
                    return cardIDEnum.CS2_009e;
                case "HERO_04":
                    return cardIDEnum.HERO_04;
                case "EX1_607":
                    return cardIDEnum.EX1_607;
                case "DREAM_03":
                    return cardIDEnum.DREAM_03;
                case "NAX11_04e":
                    return cardIDEnum.NAX11_04e;
                case "EX1_103e":
                    return cardIDEnum.EX1_103e;
                case "XXX_046":
                    return cardIDEnum.XXX_046;
                case "FP1_003":
                    return cardIDEnum.FP1_003;
                case "CS2_105":
                    return cardIDEnum.CS2_105;
                case "FP1_002":
                    return cardIDEnum.FP1_002;
                case "TU4c_002":
                    return cardIDEnum.TU4c_002;
                case "CRED_14":
                    return cardIDEnum.CRED_14;
                case "EX1_567":
                    return cardIDEnum.EX1_567;
                case "TU4c_004":
                    return cardIDEnum.TU4c_004;
                case "NAX10_03H":
                    return cardIDEnum.NAX10_03H;
                case "FP1_008":
                    return cardIDEnum.FP1_008;
                case "DS1_184":
                    return cardIDEnum.DS1_184;
                case "CS2_029":
                    return cardIDEnum.CS2_029;
                case "GAME_005":
                    return cardIDEnum.GAME_005;
                case "CS2_187":
                    return cardIDEnum.CS2_187;
                case "EX1_020":
                    return cardIDEnum.EX1_020;
                case "NAX15_01He":
                    return cardIDEnum.NAX15_01He;
                case "EX1_011":
                    return cardIDEnum.EX1_011;
                case "CS2_057":
                    return cardIDEnum.CS2_057;
                case "EX1_274":
                    return cardIDEnum.EX1_274;
                case "EX1_306":
                    return cardIDEnum.EX1_306;
                case "NEW1_038o":
                    return cardIDEnum.NEW1_038o;
                case "EX1_170":
                    return cardIDEnum.EX1_170;
                case "EX1_617":
                    return cardIDEnum.EX1_617;
                case "CS1_113e":
                    return cardIDEnum.CS1_113e;
                case "CS2_101":
                    return cardIDEnum.CS2_101;
                case "FP1_015":
                    return cardIDEnum.FP1_015;
                case "NAX13_03":
                    return cardIDEnum.NAX13_03;
                case "CS2_005":
                    return cardIDEnum.CS2_005;
                case "EX1_537":
                    return cardIDEnum.EX1_537;
                case "EX1_384":
                    return cardIDEnum.EX1_384;
                case "TU4a_002":
                    return cardIDEnum.TU4a_002;
                case "NAX9_04":
                    return cardIDEnum.NAX9_04;
                case "EX1_362":
                    return cardIDEnum.EX1_362;
                case "NAX12_02":
                    return cardIDEnum.NAX12_02;
                case "FP1_028e":
                    return cardIDEnum.FP1_028e;
                case "TU4c_005":
                    return cardIDEnum.TU4c_005;
                case "EX1_301":
                    return cardIDEnum.EX1_301;
                case "CS2_235":
                    return cardIDEnum.CS2_235;
                case "NAX4_05":
                    return cardIDEnum.NAX4_05;
                case "EX1_029":
                    return cardIDEnum.EX1_029;
                case "CS2_042":
                    return cardIDEnum.CS2_042;
                case "EX1_155a":
                    return cardIDEnum.EX1_155a;
                case "CS2_102":
                    return cardIDEnum.CS2_102;
                case "EX1_609":
                    return cardIDEnum.EX1_609;
                case "NEW1_027":
                    return cardIDEnum.NEW1_027;
                case "CS2_236e":
                    return cardIDEnum.CS2_236e;
                case "CS2_083e":
                    return cardIDEnum.CS2_083e;
                case "NAX6_03te":
                    return cardIDEnum.NAX6_03te;
                case "EX1_165a":
                    return cardIDEnum.EX1_165a;
                case "EX1_570":
                    return cardIDEnum.EX1_570;
                case "EX1_131":
                    return cardIDEnum.EX1_131;
                case "EX1_556":
                    return cardIDEnum.EX1_556;
                case "EX1_543":
                    return cardIDEnum.EX1_543;
                case "XXX_096":
                    return cardIDEnum.XXX_096;
                case "TU4c_008e":
                    return cardIDEnum.TU4c_008e;
                case "EX1_379e":
                    return cardIDEnum.EX1_379e;
                case "NEW1_009":
                    return cardIDEnum.NEW1_009;
                case "EX1_100":
                    return cardIDEnum.EX1_100;
                case "EX1_274e":
                    return cardIDEnum.EX1_274e;
                case "CRED_02":
                    return cardIDEnum.CRED_02;
                case "EX1_573a":
                    return cardIDEnum.EX1_573a;
                case "CS2_084":
                    return cardIDEnum.CS2_084;
                case "EX1_582":
                    return cardIDEnum.EX1_582;
                case "EX1_043":
                    return cardIDEnum.EX1_043;
                case "EX1_050":
                    return cardIDEnum.EX1_050;
                case "TU4b_001":
                    return cardIDEnum.TU4b_001;
                case "FP1_005":
                    return cardIDEnum.FP1_005;
                case "EX1_620":
                    return cardIDEnum.EX1_620;
                case "NAX15_01":
                    return cardIDEnum.NAX15_01;
                case "NAX6_03":
                    return cardIDEnum.NAX6_03;
                case "EX1_303":
                    return cardIDEnum.EX1_303;
                case "HERO_09":
                    return cardIDEnum.HERO_09;
                case "EX1_067":
                    return cardIDEnum.EX1_067;
                case "XXX_028":
                    return cardIDEnum.XXX_028;
                case "EX1_277":
                    return cardIDEnum.EX1_277;
                case "Mekka2":
                    return cardIDEnum.Mekka2;
                case "NAX14_01H":
                    return cardIDEnum.NAX14_01H;
                case "NAX15_04":
                    return cardIDEnum.NAX15_04;
                case "FP1_024":
                    return cardIDEnum.FP1_024;
                case "FP1_030":
                    return cardIDEnum.FP1_030;
                case "CS2_221e":
                    return cardIDEnum.CS2_221e;
                case "EX1_178":
                    return cardIDEnum.EX1_178;
                case "CS2_222":
                    return cardIDEnum.CS2_222;
                case "EX1_409e":
                    return cardIDEnum.EX1_409e;
                case "tt_004o":
                    return cardIDEnum.tt_004o;
                case "EX1_155ae":
                    return cardIDEnum.EX1_155ae;
                case "NAX11_01H":
                    return cardIDEnum.NAX11_01H;
                case "EX1_160a":
                    return cardIDEnum.EX1_160a;
                case "NAX15_02":
                    return cardIDEnum.NAX15_02;
                case "NAX15_05":
                    return cardIDEnum.NAX15_05;
                case "NEW1_025e":
                    return cardIDEnum.NEW1_025e;
                case "CS2_012":
                    return cardIDEnum.CS2_012;
                case "XXX_099":
                    return cardIDEnum.XXX_099;
                case "EX1_246":
                    return cardIDEnum.EX1_246;
                case "EX1_572":
                    return cardIDEnum.EX1_572;
                case "EX1_089":
                    return cardIDEnum.EX1_089;
                case "CS2_059":
                    return cardIDEnum.CS2_059;
                case "EX1_279":
                    return cardIDEnum.EX1_279;
                case "NAX12_02e":
                    return cardIDEnum.NAX12_02e;
                case "CS2_168":
                    return cardIDEnum.CS2_168;
                case "tt_010":
                    return cardIDEnum.tt_010;
                case "NEW1_023":
                    return cardIDEnum.NEW1_023;
                case "CS2_075":
                    return cardIDEnum.CS2_075;
                case "EX1_316":
                    return cardIDEnum.EX1_316;
                case "CS2_025":
                    return cardIDEnum.CS2_025;
                case "CS2_234":
                    return cardIDEnum.CS2_234;
                case "XXX_043":
                    return cardIDEnum.XXX_043;
                case "GAME_001":
                    return cardIDEnum.GAME_001;
                case "NAX5_02":
                    return cardIDEnum.NAX5_02;
                case "EX1_130":
                    return cardIDEnum.EX1_130;
                case "EX1_584e":
                    return cardIDEnum.EX1_584e;
                case "CS2_064":
                    return cardIDEnum.CS2_064;
                case "EX1_161":
                    return cardIDEnum.EX1_161;
                case "CS2_049":
                    return cardIDEnum.CS2_049;
                case "NAX13_01":
                    return cardIDEnum.NAX13_01;
                case "EX1_154":
                    return cardIDEnum.EX1_154;
                case "EX1_080":
                    return cardIDEnum.EX1_080;
                case "NEW1_022":
                    return cardIDEnum.NEW1_022;
                case "NAX2_01H":
                    return cardIDEnum.NAX2_01H;
                case "EX1_160be":
                    return cardIDEnum.EX1_160be;
                case "NAX12_03":
                    return cardIDEnum.NAX12_03;
                case "EX1_251":
                    return cardIDEnum.EX1_251;
                case "FP1_025":
                    return cardIDEnum.FP1_025;
                case "EX1_371":
                    return cardIDEnum.EX1_371;
                case "CS2_mirror":
                    return cardIDEnum.CS2_mirror;
                case "NAX4_01H":
                    return cardIDEnum.NAX4_01H;
                case "EX1_594":
                    return cardIDEnum.EX1_594;
                case "NAX14_02":
                    return cardIDEnum.NAX14_02;
                case "TU4c_006e":
                    return cardIDEnum.TU4c_006e;
                case "EX1_560":
                    return cardIDEnum.EX1_560;
                case "CS2_236":
                    return cardIDEnum.CS2_236;
                case "TU4f_006":
                    return cardIDEnum.TU4f_006;
                case "EX1_402":
                    return cardIDEnum.EX1_402;
                case "NAX3_01":
                    return cardIDEnum.NAX3_01;
                case "EX1_506":
                    return cardIDEnum.EX1_506;
                case "NEW1_027e":
                    return cardIDEnum.NEW1_027e;
                case "DS1_070o":
                    return cardIDEnum.DS1_070o;
                case "XXX_045":
                    return cardIDEnum.XXX_045;
                case "XXX_029":
                    return cardIDEnum.XXX_029;
                case "DS1_178":
                    return cardIDEnum.DS1_178;
                case "XXX_098":
                    return cardIDEnum.XXX_098;
                case "EX1_315":
                    return cardIDEnum.EX1_315;
                case "CS2_094":
                    return cardIDEnum.CS2_094;
                case "NAX13_01H":
                    return cardIDEnum.NAX13_01H;
                case "TU4e_002t":
                    return cardIDEnum.TU4e_002t;
                case "EX1_046e":
                    return cardIDEnum.EX1_046e;
                case "NEW1_040t":
                    return cardIDEnum.NEW1_040t;
                case "GAME_005e":
                    return cardIDEnum.GAME_005e;
                case "CS2_131":
                    return cardIDEnum.CS2_131;
                case "XXX_008":
                    return cardIDEnum.XXX_008;
                case "EX1_531e":
                    return cardIDEnum.EX1_531e;
                case "CS2_226e":
                    return cardIDEnum.CS2_226e;
                case "XXX_022e":
                    return cardIDEnum.XXX_022e;
                case "DS1_178e":
                    return cardIDEnum.DS1_178e;
                case "CS2_226o":
                    return cardIDEnum.CS2_226o;
                case "NAX9_04H":
                    return cardIDEnum.NAX9_04H;
                case "Mekka4e":
                    return cardIDEnum.Mekka4e;
                case "EX1_082":
                    return cardIDEnum.EX1_082;
                case "CS2_093":
                    return cardIDEnum.CS2_093;
                case "EX1_411e":
                    return cardIDEnum.EX1_411e;
                case "NAX8_03t":
                    return cardIDEnum.NAX8_03t;
                case "EX1_145o":
                    return cardIDEnum.EX1_145o;
                case "NAX7_04":
                    return cardIDEnum.NAX7_04;
                case "CS2_boar":
                    return cardIDEnum.CS2_boar;
                case "NEW1_019":
                    return cardIDEnum.NEW1_019;
                case "EX1_289":
                    return cardIDEnum.EX1_289;
                case "EX1_025t":
                    return cardIDEnum.EX1_025t;
                case "EX1_398t":
                    return cardIDEnum.EX1_398t;
                case "NAX12_03H":
                    return cardIDEnum.NAX12_03H;
                case "EX1_055o":
                    return cardIDEnum.EX1_055o;
                case "CS2_091":
                    return cardIDEnum.CS2_091;
                case "EX1_241":
                    return cardIDEnum.EX1_241;
                case "EX1_085":
                    return cardIDEnum.EX1_085;
                case "CS2_200":
                    return cardIDEnum.CS2_200;
                case "CS2_034":
                    return cardIDEnum.CS2_034;
                case "EX1_583":
                    return cardIDEnum.EX1_583;
                case "EX1_584":
                    return cardIDEnum.EX1_584;
                case "EX1_155":
                    return cardIDEnum.EX1_155;
                case "EX1_622":
                    return cardIDEnum.EX1_622;
                case "CS2_203":
                    return cardIDEnum.CS2_203;
                case "EX1_124":
                    return cardIDEnum.EX1_124;
                case "EX1_379":
                    return cardIDEnum.EX1_379;
                case "NAX7_02":
                    return cardIDEnum.NAX7_02;
                case "CS2_053e":
                    return cardIDEnum.CS2_053e;
                case "EX1_032":
                    return cardIDEnum.EX1_032;
                case "NAX9_01":
                    return cardIDEnum.NAX9_01;
                case "TU4e_003":
                    return cardIDEnum.TU4e_003;
                case "CS2_146o":
                    return cardIDEnum.CS2_146o;
                case "NAX8_01H":
                    return cardIDEnum.NAX8_01H;
                case "XXX_041":
                    return cardIDEnum.XXX_041;
                case "NAXM_002":
                    return cardIDEnum.NAXM_002;
                case "EX1_391":
                    return cardIDEnum.EX1_391;
                case "EX1_366":
                    return cardIDEnum.EX1_366;
                case "EX1_059e":
                    return cardIDEnum.EX1_059e;
                case "XXX_012":
                    return cardIDEnum.XXX_012;
                case "EX1_565o":
                    return cardIDEnum.EX1_565o;
                case "EX1_001e":
                    return cardIDEnum.EX1_001e;
                case "TU4f_003":
                    return cardIDEnum.TU4f_003;
                case "EX1_400":
                    return cardIDEnum.EX1_400;
                case "EX1_614":
                    return cardIDEnum.EX1_614;
                case "EX1_561":
                    return cardIDEnum.EX1_561;
                case "EX1_332":
                    return cardIDEnum.EX1_332;
                case "HERO_05":
                    return cardIDEnum.HERO_05;
                case "CS2_065":
                    return cardIDEnum.CS2_065;
                case "ds1_whelptoken":
                    return cardIDEnum.ds1_whelptoken;
                case "EX1_536e":
                    return cardIDEnum.EX1_536e;
                case "CS2_032":
                    return cardIDEnum.CS2_032;
                case "CS2_120":
                    return cardIDEnum.CS2_120;
                case "EX1_155be":
                    return cardIDEnum.EX1_155be;
                case "EX1_247":
                    return cardIDEnum.EX1_247;
                case "EX1_154a":
                    return cardIDEnum.EX1_154a;
                case "EX1_554t":
                    return cardIDEnum.EX1_554t;
                case "CS2_103e2":
                    return cardIDEnum.CS2_103e2;
                case "TU4d_003":
                    return cardIDEnum.TU4d_003;
                case "NEW1_026t":
                    return cardIDEnum.NEW1_026t;
                case "EX1_623":
                    return cardIDEnum.EX1_623;
                case "EX1_383t":
                    return cardIDEnum.EX1_383t;
                case "NAX7_03":
                    return cardIDEnum.NAX7_03;
                case "EX1_597":
                    return cardIDEnum.EX1_597;
                case "TU4f_006o":
                    return cardIDEnum.TU4f_006o;
                case "EX1_130a":
                    return cardIDEnum.EX1_130a;
                case "CS2_011":
                    return cardIDEnum.CS2_011;
                case "EX1_169":
                    return cardIDEnum.EX1_169;
                case "EX1_tk33":
                    return cardIDEnum.EX1_tk33;
                case "NAX11_03":
                    return cardIDEnum.NAX11_03;
                case "NAX4_01":
                    return cardIDEnum.NAX4_01;
                case "NAX10_01":
                    return cardIDEnum.NAX10_01;
                case "EX1_250":
                    return cardIDEnum.EX1_250;
                case "EX1_564":
                    return cardIDEnum.EX1_564;
                case "NAX5_03":
                    return cardIDEnum.NAX5_03;
                case "EX1_043e":
                    return cardIDEnum.EX1_043e;
                case "EX1_349":
                    return cardIDEnum.EX1_349;
                case "XXX_097":
                    return cardIDEnum.XXX_097;
                case "EX1_102":
                    return cardIDEnum.EX1_102;
                case "EX1_058":
                    return cardIDEnum.EX1_058;
                case "EX1_243":
                    return cardIDEnum.EX1_243;
                case "PRO_001c":
                    return cardIDEnum.PRO_001c;
                case "EX1_116t":
                    return cardIDEnum.EX1_116t;
                case "NAX15_01e":
                    return cardIDEnum.NAX15_01e;
                case "FP1_029":
                    return cardIDEnum.FP1_029;
                case "CS2_089":
                    return cardIDEnum.CS2_089;
                case "TU4c_001":
                    return cardIDEnum.TU4c_001;
                case "EX1_248":
                    return cardIDEnum.EX1_248;
                case "NEW1_037e":
                    return cardIDEnum.NEW1_037e;
                case "CS2_122":
                    return cardIDEnum.CS2_122;
                case "EX1_393":
                    return cardIDEnum.EX1_393;
                case "CS2_232":
                    return cardIDEnum.CS2_232;
                case "EX1_165b":
                    return cardIDEnum.EX1_165b;
                case "NEW1_030":
                    return cardIDEnum.NEW1_030;
                case "EX1_161o":
                    return cardIDEnum.EX1_161o;
                case "EX1_093e":
                    return cardIDEnum.EX1_093e;
                case "CS2_150":
                    return cardIDEnum.CS2_150;
                case "CS2_152":
                    return cardIDEnum.CS2_152;
                case "NAX9_03H":
                    return cardIDEnum.NAX9_03H;
                case "EX1_160t":
                    return cardIDEnum.EX1_160t;
                case "CS2_127":
                    return cardIDEnum.CS2_127;
                case "CRED_03":
                    return cardIDEnum.CRED_03;
                case "DS1_188":
                    return cardIDEnum.DS1_188;
                case "XXX_001":
                    return cardIDEnum.XXX_001;
            }

            return cardIDEnum.None;
        }

        public enum cardName
        {
            unknown,
            hogger,
            heigantheunclean,
            necroticaura,
            starfall,
            barrel,
            damagereflector,
            edwinvancleef,
            gothiktheharvester,
            perditionsblade,
            bloodsailraider,
            guardianoficecrown,
            bloodmagethalnos,
            rooted,
            wisp,
            rachelledavis,
            senjinshieldmasta,
            totemicmight,
            uproot,
            opponentdisconnect,
            unrelentingrider,
            shandoslesson,
            hemetnesingwary,
            decimate,
            shadowofnothing,
            nerubian,
            dragonlingmechanic,
            mogushanwarden,
            thanekorthazz,
            hungrycrab,
            ancientteachings,
            misdirection,
            patientassassin,
            mutatinginjection,
            violetteacher,
            arathiweaponsmith,
            raisedead,
            acolyteofpain,
            holynova,
            robpardo,
            commandingshout,
            necroticpoison,
            unboundelemental,
            garroshhellscream,
            enchant,
            loatheb,
            blessingofmight,
            nightmare,
            blessingofkings,
            polymorph,
            darkirondwarf,
            destroy,
            roguesdoit,
            freecards,
            iammurloc,
            sporeburst,
            mindcontrolcrystal,
            charge,
            stampedingkodo,
            humility,
            darkcultist,
            gruul,
            markofthewild,
            patchwerk,
            worgeninfiltrator,
            frostbolt,
            runeblade,
            flametonguetotem,
            assassinate,
            madscientist,
            lordofthearena,
            bainebloodhoof,
            injuredblademaster,
            siphonsoul,
            layonhands,
            hook,
            massiveruneblade,
            lorewalkercho,
            destroyallminions,
            silvermoonguardian,
            destroyallmana,
            huffer,
            mindvision,
            malfurionstormrage,
            corehound,
            grimscaleoracle,
            lightningstorm,
            lightwell,
            benthompson,
            coldlightseer,
            deathsbite,
            gorehowl,
            skitter,
            farsight,
            chillwindyeti,
            moonfire,
            bladeflurry,
            massdispel,
            crazedalchemist,
            shadowmadness,
            equality,
            misha,
            treant,
            alarmobot,
            animalcompanion,
            hatefulstrike,
            dream,
            anubrekhan,
            youngpriestess,
            gadgetzanauctioneer,
            coneofcold,
            earthshock,
            tirionfordring,
            wailingsoul,
            skeleton,
            ironfurgrizzly,
            headcrack,
            arcaneshot,
            maexxna,
            imp,
            markofthehorsemen,
            voidterror,
            mortalcoil,
            draw3cards,
            flameofazzinoth,
            jainaproudmoore,
            execute,
            bloodlust,
            bananas,
            kidnapper,
            oldmurkeye,
            homingchicken,
            enableforattack,
            spellbender,
            backstab,
            squirrel,
            stalagg,
            grandwidowfaerlina,
            heavyaxe,
            zwick,
            webwrap,
            flamesofazzinoth,
            murlocwarleader,
            shadowstep,
            ancestralspirit,
            defenderofargus,
            assassinsblade,
            discard,
            biggamehunter,
            aldorpeacekeeper,
            blizzard,
            pandarenscout,
            unleashthehounds,
            yseraawakens,
            sap,
            kelthuzad,
            defiasbandit,
            gnomishinventor,
            mindcontrol,
            ravenholdtassassin,
            icelance,
            dispel,
            acidicswampooze,
            muklasbigbrother,
            blessedchampion,
            savannahhighmane,
            direwolfalpha,
            hoggersmash,
            blessingofwisdom,
            nourish,
            abusivesergeant,
            sylvanaswindrunner,
            spore,
            crueltaskmaster,
            lightningbolt,
            keeperofthegrove,
            steadyshot,
            multishot,
            harvest,
            instructorrazuvious,
            ladyblaumeux,
            jaybaxter,
            molasses,
            pintsizedsummoner,
            spellbreaker,
            anubarambusher,
            deadlypoison,
            stoneskingargoyle,
            bloodfury,
            fanofknives,
            poisoncloud,
            shieldbearer,
            sensedemons,
            shieldblock,
            handswapperminion,
            massivegnoll,
            deathcharger,
            ancientoflore,
            oasissnapjaw,
            illidanstormrage,
            frostwolfgrunt,
            lesserheal,
            infernal,
            wildpyromancer,
            razorfenhunter,
            twistingnether,
            voidcaller,
            leaderofthepack,
            malygos,
            becomehogger,
            baronrivendare,
            millhousemanastorm,
            innerfire,
            valeerasanguinar,
            chicken,
            souloftheforest,
            silencedebug,
            bloodsailcorsair,
            slime,
            tinkmasteroverspark,
            iceblock,
            brawl,
            vanish,
            poisonseeds,
            murloc,
            mindspike,
            kingmukla,
            stevengabriel,
            gluth,
            truesilverchampion,
            harrisonjones,
            destroydeck,
            devilsaur,
            wargolem,
            warsongcommander,
            manawyrm,
            thaddius,
            savagery,
            spitefulsmith,
            shatteredsuncleric,
            eyeforaneye,
            azuredrake,
            mountaingiant,
            korkronelite,
            junglepanther,
            barongeddon,
            spectralspider,
            pitlord,
            markofnature,
            grobbulus,
            leokk,
            fierywaraxe,
            damage5,
            duplicate,
            restore5,
            mindblast,
            timberwolf,
            captaingreenskin,
            elvenarcher,
            michaelschweitzer,
            masterswordsmith,
            grommashhellscream,
            hound,
            seagiant,
            doomguard,
            alakirthewindlord,
            hyena,
            undertaker,
            frothingberserker,
            powerofthewild,
            druidoftheclaw,
            hellfire,
            archmage,
            recklessrocketeer,
            crazymonkey,
            damageallbut1,
            frostblast,
            powerwordshield,
            rainoffire,
            arcaneintellect,
            angrychicken,
            nerubianegg,
            worshipper,
            mindgames,
            leeroyjenkins,
            gurubashiberserker,
            windspeaker,
            enableemotes,
            forceofnature,
            lightspawn,
            destroyamanacrystal,
            warglaiveofazzinoth,
            finkleeinhorn,
            frostelemental,
            thoughtsteal,
            brianschwab,
            scavenginghyena,
            si7agent,
            prophetvelen,
            soulfire,
            ogremagi,
            damagedgolem,
            crash,
            adrenalinerush,
            murloctidecaller,
            kirintormage,
            spectralrider,
            thrallmarfarseer,
            frostwolfwarlord,
            sorcerersapprentice,
            feugen,
            willofmukla,
            holyfire,
            manawraith,
            argentsquire,
            placeholdercard,
            snakeball,
            ancientwatcher,
            noviceengineer,
            stonetuskboar,
            ancestralhealing,
            conceal,
            arcanitereaper,
            guldan,
            ragingworgen,
            earthenringfarseer,
            onyxia,
            manaaddict,
            unholyshadow,
            dualwarglaives,
            sludgebelcher,
            worthlessimp,
            shiv,
            sheep,
            bloodknight,
            holysmite,
            ancientsecrets,
            holywrath,
            ironforgerifleman,
            elitetaurenchieftain,
            spectralwarrior,
            bluegillwarrior,
            shapeshift,
            hamiltonchu,
            battlerage,
            nightblade,
            locustswarm,
            crazedhunter,
            andybrock,
            youthfulbrewmaster,
            theblackknight,
            brewmaster,
            lifetap,
            demonfire,
            redemption,
            lordjaraxxus,
            coldblood,
            lightwarden,
            questingadventurer,
            donothing,
            dereksakamoto,
            poultryizer,
            koboldgeomancer,
            legacyoftheemperor,
            eruption,
            cenarius,
            deathlord,
            searingtotem,
            taurenwarrior,
            explosivetrap,
            frog,
            servercrash,
            wickedknife,
            laughingsister,
            cultmaster,
            wildgrowth,
            sprint,
            masterofdisguise,
            kyleharrison,
            avatarofthecoin,
            excessmana,
            spiritwolf,
            auchenaisoulpriest,
            bestialwrath,
            rockbiterweapon,
            starvingbuzzard,
            mirrorimage,
            frozenchampion,
            silverhandrecruit,
            corruption,
            preparation,
            cairnebloodhoof,
            mortalstrike,
            flare,
            necroknight,
            silverhandknight,
            breakweapon,
            guardianofkings,
            ancientbrewmaster,
            avenge,
            youngdragonhawk,
            frostshock,
            healingtouch,
            venturecomercenary,
            unbalancingstrike,
            sacrificialpact,
            noooooooooooo,
            baneofdoom,
            abomination,
            flesheatingghoul,
            loothoarder,
            mill10,
            sapphiron,
            jasonchayes,
            benbrode,
            betrayal,
            thebeast,
            flameimp,
            freezingtrap,
            southseadeckhand,
            wrath,
            bloodfenraptor,
            cleave,
            fencreeper,
            restore1,
            handtodeck,
            starfire,
            goldshirefootman,
            unrelentingtrainee,
            murlocscout,
            ragnarosthefirelord,
            rampage,
            zombiechow,
            thrall,
            stoneclawtotem,
            captainsparrot,
            windfuryharpy,
            unrelentingwarrior,
            stranglethorntiger,
            summonarandomsecret,
            circleofhealing,
            snaketrap,
            cabalshadowpriest,
            nerubarweblord,
            upgrade,
            shieldslam,
            flameburst,
            windfury,
            enrage,
            natpagle,
            restoreallhealth,
            houndmaster,
            waterelemental,
            eaglehornbow,
            gnoll,
            archmageantonidas,
            destroyallheroes,
            chains,
            wrathofairtotem,
            killcommand,
            manatidetotem,
            daggermastery,
            drainlife,
            doomsayer,
            darkscalehealer,
            shadowform,
            frostnova,
            purecold,
            mirrorentity,
            counterspell,
            mindshatter,
            magmarager,
            wolfrider,
            emboldener3000,
            polarityshift,
            gelbinmekkatorque,
            webspinner,
            utherlightbringer,
            innerrage,
            emeralddrake,
            forceaitouseheropower,
            echoingooze,
            heroicstrike,
            hauntedcreeper,
            barreltoss,
            yongwoo,
            doomhammer,
            stomp,
            spectralknight,
            tracking,
            fireball,
            thecoin,
            bootybaybodyguard,
            scarletcrusader,
            voodoodoctor,
            shadowbolt,
            etherealarcanist,
            succubus,
            emperorcobra,
            deadlyshot,
            reinforce,
            supercharge,
            claw,
            explosiveshot,
            avengingwrath,
            riverpawgnoll,
            sirzeliek,
            argentprotector,
            hiddengnome,
            felguard,
            northshirecleric,
            plague,
            lepergnome,
            fireelemental,
            armorup,
            snipe,
            southseacaptain,
            catform,
            bite,
            defiasringleader,
            harvestgolem,
            kingkrush,
            aibuddydamageownhero5,
            healingtotem,
            ericdodds,
            demigodsfavor,
            huntersmark,
            dalaranmage,
            twilightdrake,
            coldlightoracle,
            shadeofnaxxramas,
            moltengiant,
            deathbloom,
            shadowflame,
            anduinwrynn,
            argentcommander,
            revealhand,
            arcanemissiles,
            repairbot,
            unstableghoul,
            ancientofwar,
            stormwindchampion,
            summonapanther,
            mrbigglesworth,
            swipe,
            aihelperbuddy,
            hex,
            ysera,
            arcanegolem,
            bloodimp,
            pyroblast,
            murlocraider,
            faeriedragon,
            sinisterstrike,
            poweroverwhelming,
            arcaneexplosion,
            shadowwordpain,
            mill30,
            noblesacrifice,
            dreadinfernal,
            naturalize,
            totemiccall,
            secretkeeper,
            dreadcorsair,
            jaws,
            forkedlightning,
            reincarnate,
            handofprotection,
            noththeplaguebringer,
            vaporize,
            frostbreath,
            nozdormu,
            divinespirit,
            transcendence,
            armorsmith,
            murloctidehunter,
            stealcard,
            opponentconcede,
            tundrarhino,
            summoningportal,
            hammerofwrath,
            stormwindknight,
            freeze,
            madbomber,
            consecration,
            spectraltrainee,
            boar,
            knifejuggler,
            icebarrier,
            mechanicaldragonling,
            battleaxe,
            lightsjustice,
            lavaburst,
            mindcontroltech,
            boulderfistogre,
            fireblast,
            priestessofelune,
            ancientmage,
            shadowworddeath,
            ironbeakowl,
            eviscerate,
            repentance,
            understudy,
            sunwalker,
            nagamyrmidon,
            destroyheropower,
            skeletalsmith,
            slam,
            swordofjustice,
            bounce,
            shadopanmonk,
            whirlwind,
            alexstrasza,
            silence,
            rexxar,
            voidwalker,
            whelp,
            flamestrike,
            rivercrocolisk,
            stormforgedaxe,
            snake,
            shotgunblast,
            violetapprentice,
            templeenforcer,
            ashbringer,
            impmaster,
            defender,
            savageroar,
            innervate,
            inferno,
            falloutslime,
            earthelemental,
            facelessmanipulator,
            mindpocalypse,
            divinefavor,
            aibuddydestroyminions,
            demolisher,
            sunfuryprotector,
            dustdevil,
            powerofthehorde,
            dancingswords,
            holylight,
            feralspirit,
            raidleader,
            amaniberserker,
            ironbarkprotector,
            bearform,
            deathwing,
            stormpikecommando,
            squire,
            panther,
            silverbackpatriarch,
            bobfitch,
            gladiatorslongbow,
            damage1,
        }

        public cardName cardNamestringToEnum(string s)
        {
            switch (s)
            {
                case "unknown":
                    return cardName.unknown;
                case "hogger":
                    return cardName.hogger;
                case "heigantheunclean":
                    return cardName.heigantheunclean;
                case "necroticaura":
                    return cardName.necroticaura;
                case "starfall":
                    return cardName.starfall;
                case "barrel":
                    return cardName.barrel;
                case "damagereflector":
                    return cardName.damagereflector;
                case "edwinvancleef":
                    return cardName.edwinvancleef;
                case "gothiktheharvester":
                    return cardName.gothiktheharvester;
                case "perditionsblade":
                    return cardName.perditionsblade;
                case "bloodsailraider":
                    return cardName.bloodsailraider;
                case "guardianoficecrown":
                    return cardName.guardianoficecrown;
                case "bloodmagethalnos":
                    return cardName.bloodmagethalnos;
                case "rooted":
                    return cardName.rooted;
                case "wisp":
                    return cardName.wisp;
                case "rachelledavis":
                    return cardName.rachelledavis;
                case "senjinshieldmasta":
                    return cardName.senjinshieldmasta;
                case "totemicmight":
                    return cardName.totemicmight;
                case "uproot":
                    return cardName.uproot;
                case "opponentdisconnect":
                    return cardName.opponentdisconnect;
                case "unrelentingrider":
                    return cardName.unrelentingrider;
                case "shandoslesson":
                    return cardName.shandoslesson;
                case "hemetnesingwary":
                    return cardName.hemetnesingwary;
                case "decimate":
                    return cardName.decimate;

                case "shadowofnothing":
                    return cardName.shadowofnothing;

                case "nerubian":
                    return cardName.nerubian;

                case "dragonlingmechanic":
                    return cardName.dragonlingmechanic;

                case "mogushanwarden":
                    return cardName.mogushanwarden;

                case "thanekorthazz":
                    return cardName.thanekorthazz;

                case "hungrycrab":
                    return cardName.hungrycrab;

                case "ancientteachings":
                    return cardName.ancientteachings;

                case "misdirection":
                    return cardName.misdirection;

                case "patientassassin":
                    return cardName.patientassassin;

                case "mutatinginjection":
                    return cardName.mutatinginjection;

                case "violetteacher":
                    return cardName.violetteacher;

                case "arathiweaponsmith":
                    return cardName.arathiweaponsmith;

                case "raisedead":
                    return cardName.raisedead;

                case "acolyteofpain":
                    return cardName.acolyteofpain;

                case "holynova":
                    return cardName.holynova;

                case "robpardo":
                    return cardName.robpardo;

                case "commandingshout":
                    return cardName.commandingshout;

                case "necroticpoison":
                    return cardName.necroticpoison;

                case "unboundelemental":
                    return cardName.unboundelemental;

                case "garroshhellscream":
                    return cardName.garroshhellscream;

                case "enchant":
                    return cardName.enchant;

                case "loatheb":
                    return cardName.loatheb;

                case "blessingofmight":
                    return cardName.blessingofmight;

                case "nightmare":
                    return cardName.nightmare;

                case "blessingofkings":
                    return cardName.blessingofkings;

                case "polymorph":
                    return cardName.polymorph;

                case "darkirondwarf":
                    return cardName.darkirondwarf;

                case "destroy":
                    return cardName.destroy;

                case "roguesdoit":
                    return cardName.roguesdoit;

                case "freecards":
                    return cardName.freecards;

                case "iammurloc":
                    return cardName.iammurloc;

                case "sporeburst":
                    return cardName.sporeburst;

                case "mindcontrolcrystal":
                    return cardName.mindcontrolcrystal;

                case "charge":
                    return cardName.charge;

                case "stampedingkodo":
                    return cardName.stampedingkodo;

                case "humility":
                    return cardName.humility;

                case "darkcultist":
                    return cardName.darkcultist;

                case "gruul":
                    return cardName.gruul;

                case "markofthewild":
                    return cardName.markofthewild;

                case "patchwerk":
                    return cardName.patchwerk;

                case "worgeninfiltrator":
                    return cardName.worgeninfiltrator;

                case "frostbolt":
                    return cardName.frostbolt;

                case "runeblade":
                    return cardName.runeblade;

                case "flametonguetotem":
                    return cardName.flametonguetotem;

                case "assassinate":
                    return cardName.assassinate;

                case "madscientist":
                    return cardName.madscientist;

                case "lordofthearena":
                    return cardName.lordofthearena;

                case "bainebloodhoof":
                    return cardName.bainebloodhoof;

                case "injuredblademaster":
                    return cardName.injuredblademaster;

                case "siphonsoul":
                    return cardName.siphonsoul;

                case "layonhands":
                    return cardName.layonhands;

                case "hook":
                    return cardName.hook;

                case "massiveruneblade":
                    return cardName.massiveruneblade;

                case "lorewalkercho":
                    return cardName.lorewalkercho;

                case "destroyallminions":
                    return cardName.destroyallminions;

                case "silvermoonguardian":
                    return cardName.silvermoonguardian;

                case "destroyallmana":
                    return cardName.destroyallmana;

                case "huffer":
                    return cardName.huffer;

                case "mindvision":
                    return cardName.mindvision;

                case "malfurionstormrage":
                    return cardName.malfurionstormrage;

                case "corehound":
                    return cardName.corehound;

                case "grimscaleoracle":
                    return cardName.grimscaleoracle;

                case "lightningstorm":
                    return cardName.lightningstorm;

                case "lightwell":
                    return cardName.lightwell;

                case "benthompson":
                    return cardName.benthompson;

                case "coldlightseer":
                    return cardName.coldlightseer;

                case "deathsbite":
                    return cardName.deathsbite;

                case "gorehowl":
                    return cardName.gorehowl;

                case "skitter":
                    return cardName.skitter;

                case "farsight":
                    return cardName.farsight;

                case "chillwindyeti":
                    return cardName.chillwindyeti;

                case "moonfire":
                    return cardName.moonfire;

                case "bladeflurry":
                    return cardName.bladeflurry;

                case "massdispel":
                    return cardName.massdispel;

                case "crazedalchemist":
                    return cardName.crazedalchemist;

                case "shadowmadness":
                    return cardName.shadowmadness;

                case "equality":
                    return cardName.equality;

                case "misha":
                    return cardName.misha;

                case "treant":
                    return cardName.treant;

                case "alarmobot":
                    return cardName.alarmobot;

                case "animalcompanion":
                    return cardName.animalcompanion;

                case "hatefulstrike":
                    return cardName.hatefulstrike;

                case "dream":
                    return cardName.dream;

                case "anubrekhan":
                    return cardName.anubrekhan;

                case "youngpriestess":
                    return cardName.youngpriestess;

                case "gadgetzanauctioneer":
                    return cardName.gadgetzanauctioneer;

                case "coneofcold":
                    return cardName.coneofcold;

                case "earthshock":
                    return cardName.earthshock;

                case "tirionfordring":
                    return cardName.tirionfordring;

                case "wailingsoul":
                    return cardName.wailingsoul;

                case "skeleton":
                    return cardName.skeleton;

                case "ironfurgrizzly":
                    return cardName.ironfurgrizzly;

                case "headcrack":
                    return cardName.headcrack;

                case "arcaneshot":
                    return cardName.arcaneshot;

                case "maexxna":
                    return cardName.maexxna;

                case "imp":
                    return cardName.imp;

                case "markofthehorsemen":
                    return cardName.markofthehorsemen;

                case "voidterror":
                    return cardName.voidterror;

                case "mortalcoil":
                    return cardName.mortalcoil;

                case "draw3cards":
                    return cardName.draw3cards;

                case "flameofazzinoth":
                    return cardName.flameofazzinoth;

                case "jainaproudmoore":
                    return cardName.jainaproudmoore;

                case "execute":
                    return cardName.execute;

                case "bloodlust":
                    return cardName.bloodlust;

                case "bananas":
                    return cardName.bananas;

                case "kidnapper":
                    return cardName.kidnapper;

                case "oldmurkeye":
                    return cardName.oldmurkeye;

                case "homingchicken":
                    return cardName.homingchicken;

                case "enableforattack":
                    return cardName.enableforattack;

                case "spellbender":
                    return cardName.spellbender;

                case "backstab":
                    return cardName.backstab;

                case "squirrel":
                    return cardName.squirrel;

                case "stalagg":
                    return cardName.stalagg;

                case "grandwidowfaerlina":
                    return cardName.grandwidowfaerlina;

                case "heavyaxe":
                    return cardName.heavyaxe;

                case "zwick":
                    return cardName.zwick;

                case "webwrap":
                    return cardName.webwrap;

                case "flamesofazzinoth":
                    return cardName.flamesofazzinoth;

                case "murlocwarleader":
                    return cardName.murlocwarleader;

                case "shadowstep":
                    return cardName.shadowstep;

                case "ancestralspirit":
                    return cardName.ancestralspirit;

                case "defenderofargus":
                    return cardName.defenderofargus;

                case "assassinsblade":
                    return cardName.assassinsblade;

                case "discard":
                    return cardName.discard;

                case "biggamehunter":
                    return cardName.biggamehunter;

                case "aldorpeacekeeper":
                    return cardName.aldorpeacekeeper;

                case "blizzard":
                    return cardName.blizzard;

                case "pandarenscout":
                    return cardName.pandarenscout;

                case "unleashthehounds":
                    return cardName.unleashthehounds;

                case "yseraawakens":
                    return cardName.yseraawakens;

                case "sap":
                    return cardName.sap;

                case "kelthuzad":
                    return cardName.kelthuzad;

                case "defiasbandit":
                    return cardName.defiasbandit;

                case "gnomishinventor":
                    return cardName.gnomishinventor;

                case "mindcontrol":
                    return cardName.mindcontrol;

                case "ravenholdtassassin":
                    return cardName.ravenholdtassassin;

                case "icelance":
                    return cardName.icelance;

                case "dispel":
                    return cardName.dispel;

                case "acidicswampooze":
                    return cardName.acidicswampooze;

                case "muklasbigbrother":
                    return cardName.muklasbigbrother;

                case "blessedchampion":
                    return cardName.blessedchampion;

                case "savannahhighmane":
                    return cardName.savannahhighmane;

                case "direwolfalpha":
                    return cardName.direwolfalpha;

                case "hoggersmash":
                    return cardName.hoggersmash;

                case "blessingofwisdom":
                    return cardName.blessingofwisdom;

                case "nourish":
                    return cardName.nourish;

                case "abusivesergeant":
                    return cardName.abusivesergeant;

                case "sylvanaswindrunner":
                    return cardName.sylvanaswindrunner;

                case "spore":
                    return cardName.spore;

                case "crueltaskmaster":
                    return cardName.crueltaskmaster;

                case "lightningbolt":
                    return cardName.lightningbolt;

                case "keeperofthegrove":
                    return cardName.keeperofthegrove;

                case "steadyshot":
                    return cardName.steadyshot;

                case "multishot":
                    return cardName.multishot;

                case "harvest":
                    return cardName.harvest;

                case "instructorrazuvious":
                    return cardName.instructorrazuvious;

                case "ladyblaumeux":
                    return cardName.ladyblaumeux;

                case "jaybaxter":
                    return cardName.jaybaxter;

                case "molasses":
                    return cardName.molasses;

                case "pintsizedsummoner":
                    return cardName.pintsizedsummoner;

                case "spellbreaker":
                    return cardName.spellbreaker;

                case "anubarambusher":
                    return cardName.anubarambusher;

                case "deadlypoison":
                    return cardName.deadlypoison;

                case "stoneskingargoyle":
                    return cardName.stoneskingargoyle;

                case "bloodfury":
                    return cardName.bloodfury;

                case "fanofknives":
                    return cardName.fanofknives;

                case "poisoncloud":
                    return cardName.poisoncloud;

                case "shieldbearer":
                    return cardName.shieldbearer;

                case "sensedemons":
                    return cardName.sensedemons;

                case "shieldblock":
                    return cardName.shieldblock;

                case "handswapperminion":
                    return cardName.handswapperminion;

                case "massivegnoll":
                    return cardName.massivegnoll;

                case "deathcharger":
                    return cardName.deathcharger;

                case "ancientoflore":
                    return cardName.ancientoflore;

                case "oasissnapjaw":
                    return cardName.oasissnapjaw;

                case "illidanstormrage":
                    return cardName.illidanstormrage;

                case "frostwolfgrunt":
                    return cardName.frostwolfgrunt;

                case "lesserheal":
                    return cardName.lesserheal;

                case "infernal":
                    return cardName.infernal;

                case "wildpyromancer":
                    return cardName.wildpyromancer;

                case "razorfenhunter":
                    return cardName.razorfenhunter;

                case "twistingnether":
                    return cardName.twistingnether;

                case "voidcaller":
                    return cardName.voidcaller;

                case "leaderofthepack":
                    return cardName.leaderofthepack;

                case "malygos":
                    return cardName.malygos;

                case "becomehogger":
                    return cardName.becomehogger;

                case "baronrivendare":
                    return cardName.baronrivendare;

                case "millhousemanastorm":
                    return cardName.millhousemanastorm;

                case "innerfire":
                    return cardName.innerfire;

                case "valeerasanguinar":
                    return cardName.valeerasanguinar;

                case "chicken":
                    return cardName.chicken;

                case "souloftheforest":
                    return cardName.souloftheforest;

                case "silencedebug":
                    return cardName.silencedebug;

                case "bloodsailcorsair":
                    return cardName.bloodsailcorsair;

                case "slime":
                    return cardName.slime;

                case "tinkmasteroverspark":
                    return cardName.tinkmasteroverspark;

                case "iceblock":
                    return cardName.iceblock;

                case "brawl":
                    return cardName.brawl;

                case "vanish":
                    return cardName.vanish;

                case "poisonseeds":
                    return cardName.poisonseeds;

                case "murloc":
                    return cardName.murloc;

                case "mindspike":
                    return cardName.mindspike;

                case "kingmukla":
                    return cardName.kingmukla;

                case "stevengabriel":
                    return cardName.stevengabriel;

                case "gluth":
                    return cardName.gluth;

                case "truesilverchampion":
                    return cardName.truesilverchampion;

                case "harrisonjones":
                    return cardName.harrisonjones;

                case "destroydeck":
                    return cardName.destroydeck;

                case "devilsaur":
                    return cardName.devilsaur;

                case "wargolem":
                    return cardName.wargolem;

                case "warsongcommander":
                    return cardName.warsongcommander;

                case "manawyrm":
                    return cardName.manawyrm;

                case "thaddius":
                    return cardName.thaddius;

                case "savagery":
                    return cardName.savagery;

                case "spitefulsmith":
                    return cardName.spitefulsmith;

                case "shatteredsuncleric":
                    return cardName.shatteredsuncleric;

                case "eyeforaneye":
                    return cardName.eyeforaneye;

                case "azuredrake":
                    return cardName.azuredrake;

                case "mountaingiant":
                    return cardName.mountaingiant;

                case "korkronelite":
                    return cardName.korkronelite;

                case "junglepanther":
                    return cardName.junglepanther;

                case "barongeddon":
                    return cardName.barongeddon;

                case "spectralspider":
                    return cardName.spectralspider;

                case "pitlord":
                    return cardName.pitlord;

                case "markofnature":
                    return cardName.markofnature;

                case "grobbulus":
                    return cardName.grobbulus;

                case "leokk":
                    return cardName.leokk;

                case "fierywaraxe":
                    return cardName.fierywaraxe;

                case "damage5":
                    return cardName.damage5;

                case "duplicate":
                    return cardName.duplicate;

                case "restore5":
                    return cardName.restore5;

                case "mindblast":
                    return cardName.mindblast;

                case "timberwolf":
                    return cardName.timberwolf;

                case "captaingreenskin":
                    return cardName.captaingreenskin;

                case "elvenarcher":
                    return cardName.elvenarcher;

                case "michaelschweitzer":
                    return cardName.michaelschweitzer;

                case "masterswordsmith":
                    return cardName.masterswordsmith;

                case "grommashhellscream":
                    return cardName.grommashhellscream;

                case "hound":
                    return cardName.hound;

                case "seagiant":
                    return cardName.seagiant;

                case "doomguard":
                    return cardName.doomguard;

                case "alakirthewindlord":
                    return cardName.alakirthewindlord;

                case "hyena":
                    return cardName.hyena;

                case "undertaker":
                    return cardName.undertaker;

                case "frothingberserker":
                    return cardName.frothingberserker;

                case "powerofthewild":
                    return cardName.powerofthewild;

                case "druidoftheclaw":
                    return cardName.druidoftheclaw;

                case "hellfire":
                    return cardName.hellfire;

                case "archmage":
                    return cardName.archmage;

                case "recklessrocketeer":
                    return cardName.recklessrocketeer;

                case "crazymonkey":
                    return cardName.crazymonkey;

                case "damageallbut1":
                    return cardName.damageallbut1;

                case "frostblast":
                    return cardName.frostblast;

                case "powerwordshield":
                    return cardName.powerwordshield;

                case "rainoffire":
                    return cardName.rainoffire;

                case "arcaneintellect":
                    return cardName.arcaneintellect;

                case "angrychicken":
                    return cardName.angrychicken;

                case "nerubianegg":
                    return cardName.nerubianegg;

                case "worshipper":
                    return cardName.worshipper;

                case "mindgames":
                    return cardName.mindgames;

                case "leeroyjenkins":
                    return cardName.leeroyjenkins;

                case "gurubashiberserker":
                    return cardName.gurubashiberserker;

                case "windspeaker":
                    return cardName.windspeaker;

                case "enableemotes":
                    return cardName.enableemotes;

                case "forceofnature":
                    return cardName.forceofnature;

                case "lightspawn":
                    return cardName.lightspawn;

                case "destroyamanacrystal":
                    return cardName.destroyamanacrystal;

                case "warglaiveofazzinoth":
                    return cardName.warglaiveofazzinoth;

                case "finkleeinhorn":
                    return cardName.finkleeinhorn;

                case "frostelemental":
                    return cardName.frostelemental;

                case "thoughtsteal":
                    return cardName.thoughtsteal;

                case "brianschwab":
                    return cardName.brianschwab;

                case "scavenginghyena":
                    return cardName.scavenginghyena;

                case "si7agent":
                    return cardName.si7agent;

                case "prophetvelen":
                    return cardName.prophetvelen;

                case "soulfire":
                    return cardName.soulfire;

                case "ogremagi":
                    return cardName.ogremagi;

                case "damagedgolem":
                    return cardName.damagedgolem;

                case "crash":
                    return cardName.crash;

                case "adrenalinerush":
                    return cardName.adrenalinerush;

                case "murloctidecaller":
                    return cardName.murloctidecaller;

                case "kirintormage":
                    return cardName.kirintormage;

                case "spectralrider":
                    return cardName.spectralrider;

                case "thrallmarfarseer":
                    return cardName.thrallmarfarseer;

                case "frostwolfwarlord":
                    return cardName.frostwolfwarlord;

                case "sorcerersapprentice":
                    return cardName.sorcerersapprentice;

                case "feugen":
                    return cardName.feugen;

                case "willofmukla":
                    return cardName.willofmukla;

                case "holyfire":
                    return cardName.holyfire;

                case "manawraith":
                    return cardName.manawraith;

                case "argentsquire":
                    return cardName.argentsquire;

                case "placeholdercard":
                    return cardName.placeholdercard;

                case "snakeball":
                    return cardName.snakeball;

                case "ancientwatcher":
                    return cardName.ancientwatcher;

                case "noviceengineer":
                    return cardName.noviceengineer;

                case "stonetuskboar":
                    return cardName.stonetuskboar;

                case "ancestralhealing":
                    return cardName.ancestralhealing;

                case "conceal":
                    return cardName.conceal;

                case "arcanitereaper":
                    return cardName.arcanitereaper;

                case "guldan":
                    return cardName.guldan;

                case "ragingworgen":
                    return cardName.ragingworgen;

                case "earthenringfarseer":
                    return cardName.earthenringfarseer;

                case "onyxia":
                    return cardName.onyxia;

                case "manaaddict":
                    return cardName.manaaddict;

                case "unholyshadow":
                    return cardName.unholyshadow;

                case "dualwarglaives":
                    return cardName.dualwarglaives;

                case "sludgebelcher":
                    return cardName.sludgebelcher;

                case "worthlessimp":
                    return cardName.worthlessimp;

                case "shiv":
                    return cardName.shiv;

                case "sheep":
                    return cardName.sheep;

                case "bloodknight":
                    return cardName.bloodknight;

                case "holysmite":
                    return cardName.holysmite;

                case "ancientsecrets":
                    return cardName.ancientsecrets;

                case "holywrath":
                    return cardName.holywrath;

                case "ironforgerifleman":
                    return cardName.ironforgerifleman;

                case "elitetaurenchieftain":
                    return cardName.elitetaurenchieftain;

                case "spectralwarrior":
                    return cardName.spectralwarrior;

                case "bluegillwarrior":
                    return cardName.bluegillwarrior;

                case "shapeshift":
                    return cardName.shapeshift;

                case "hamiltonchu":
                    return cardName.hamiltonchu;

                case "battlerage":
                    return cardName.battlerage;

                case "nightblade":
                    return cardName.nightblade;

                case "locustswarm":
                    return cardName.locustswarm;

                case "crazedhunter":
                    return cardName.crazedhunter;

                case "andybrock":
                    return cardName.andybrock;

                case "youthfulbrewmaster":
                    return cardName.youthfulbrewmaster;

                case "theblackknight":
                    return cardName.theblackknight;

                case "brewmaster":
                    return cardName.brewmaster;

                case "lifetap":
                    return cardName.lifetap;

                case "demonfire":
                    return cardName.demonfire;

                case "redemption":
                    return cardName.redemption;

                case "lordjaraxxus":
                    return cardName.lordjaraxxus;

                case "coldblood":
                    return cardName.coldblood;

                case "lightwarden":
                    return cardName.lightwarden;

                case "questingadventurer":
                    return cardName.questingadventurer;

                case "donothing":
                    return cardName.donothing;

                case "dereksakamoto":
                    return cardName.dereksakamoto;

                case "poultryizer":
                    return cardName.poultryizer;

                case "koboldgeomancer":
                    return cardName.koboldgeomancer;

                case "legacyoftheemperor":
                    return cardName.legacyoftheemperor;

                case "eruption":
                    return cardName.eruption;

                case "cenarius":
                    return cardName.cenarius;

                case "deathlord":
                    return cardName.deathlord;

                case "searingtotem":
                    return cardName.searingtotem;

                case "taurenwarrior":
                    return cardName.taurenwarrior;

                case "explosivetrap":
                    return cardName.explosivetrap;

                case "frog":
                    return cardName.frog;

                case "servercrash":
                    return cardName.servercrash;

                case "wickedknife":
                    return cardName.wickedknife;

                case "laughingsister":
                    return cardName.laughingsister;

                case "cultmaster":
                    return cardName.cultmaster;

                case "wildgrowth":
                    return cardName.wildgrowth;

                case "sprint":
                    return cardName.sprint;

                case "masterofdisguise":
                    return cardName.masterofdisguise;

                case "kyleharrison":
                    return cardName.kyleharrison;

                case "avatarofthecoin":
                    return cardName.avatarofthecoin;

                case "excessmana":
                    return cardName.excessmana;

                case "spiritwolf":
                    return cardName.spiritwolf;

                case "auchenaisoulpriest":
                    return cardName.auchenaisoulpriest;

                case "bestialwrath":
                    return cardName.bestialwrath;

                case "rockbiterweapon":
                    return cardName.rockbiterweapon;

                case "starvingbuzzard":
                    return cardName.starvingbuzzard;

                case "mirrorimage":
                    return cardName.mirrorimage;

                case "frozenchampion":
                    return cardName.frozenchampion;

                case "silverhandrecruit":
                    return cardName.silverhandrecruit;

                case "corruption":
                    return cardName.corruption;

                case "preparation":
                    return cardName.preparation;

                case "cairnebloodhoof":
                    return cardName.cairnebloodhoof;

                case "mortalstrike":
                    return cardName.mortalstrike;

                case "flare":
                    return cardName.flare;

                case "necroknight":
                    return cardName.necroknight;

                case "silverhandknight":
                    return cardName.silverhandknight;

                case "breakweapon":
                    return cardName.breakweapon;

                case "guardianofkings":
                    return cardName.guardianofkings;

                case "ancientbrewmaster":
                    return cardName.ancientbrewmaster;

                case "avenge":
                    return cardName.avenge;

                case "youngdragonhawk":
                    return cardName.youngdragonhawk;

                case "frostshock":
                    return cardName.frostshock;

                case "healingtouch":
                    return cardName.healingtouch;

                case "venturecomercenary":
                    return cardName.venturecomercenary;

                case "unbalancingstrike":
                    return cardName.unbalancingstrike;

                case "sacrificialpact":
                    return cardName.sacrificialpact;

                case "noooooooooooo":
                    return cardName.noooooooooooo;

                case "baneofdoom":
                    return cardName.baneofdoom;

                case "abomination":
                    return cardName.abomination;

                case "flesheatingghoul":
                    return cardName.flesheatingghoul;

                case "loothoarder":
                    return cardName.loothoarder;

                case "mill10":
                    return cardName.mill10;

                case "sapphiron":
                    return cardName.sapphiron;

                case "jasonchayes":
                    return cardName.jasonchayes;

                case "benbrode":
                    return cardName.benbrode;

                case "betrayal":
                    return cardName.betrayal;

                case "thebeast":
                    return cardName.thebeast;

                case "flameimp":
                    return cardName.flameimp;

                case "freezingtrap":
                    return cardName.freezingtrap;

                case "southseadeckhand":
                    return cardName.southseadeckhand;

                case "wrath":
                    return cardName.wrath;

                case "bloodfenraptor":
                    return cardName.bloodfenraptor;

                case "cleave":
                    return cardName.cleave;

                case "fencreeper":
                    return cardName.fencreeper;

                case "restore1":
                    return cardName.restore1;

                case "handtodeck":
                    return cardName.handtodeck;

                case "starfire":
                    return cardName.starfire;

                case "goldshirefootman":
                    return cardName.goldshirefootman;

                case "unrelentingtrainee":
                    return cardName.unrelentingtrainee;

                case "murlocscout":
                    return cardName.murlocscout;

                case "ragnarosthefirelord":
                    return cardName.ragnarosthefirelord;

                case "rampage":
                    return cardName.rampage;

                case "zombiechow":
                    return cardName.zombiechow;

                case "thrall":
                    return cardName.thrall;

                case "stoneclawtotem":
                    return cardName.stoneclawtotem;

                case "captainsparrot":
                    return cardName.captainsparrot;

                case "windfuryharpy":
                    return cardName.windfuryharpy;

                case "unrelentingwarrior":
                    return cardName.unrelentingwarrior;

                case "stranglethorntiger":
                    return cardName.stranglethorntiger;

                case "summonarandomsecret":
                    return cardName.summonarandomsecret;

                case "circleofhealing":
                    return cardName.circleofhealing;

                case "snaketrap":
                    return cardName.snaketrap;

                case "cabalshadowpriest":
                    return cardName.cabalshadowpriest;

                case "nerubarweblord":
                    return cardName.nerubarweblord;

                case "upgrade":
                    return cardName.upgrade;

                case "shieldslam":
                    return cardName.shieldslam;

                case "flameburst":
                    return cardName.flameburst;

                case "windfury":
                    return cardName.windfury;

                case "enrage":
                    return cardName.enrage;

                case "natpagle":
                    return cardName.natpagle;

                case "restoreallhealth":
                    return cardName.restoreallhealth;

                case "houndmaster":
                    return cardName.houndmaster;

                case "waterelemental":
                    return cardName.waterelemental;

                case "eaglehornbow":
                    return cardName.eaglehornbow;

                case "gnoll":
                    return cardName.gnoll;

                case "archmageantonidas":
                    return cardName.archmageantonidas;

                case "destroyallheroes":
                    return cardName.destroyallheroes;

                case "chains":
                    return cardName.chains;

                case "wrathofairtotem":
                    return cardName.wrathofairtotem;

                case "killcommand":
                    return cardName.killcommand;

                case "manatidetotem":
                    return cardName.manatidetotem;

                case "daggermastery":
                    return cardName.daggermastery;

                case "drainlife":
                    return cardName.drainlife;

                case "doomsayer":
                    return cardName.doomsayer;

                case "darkscalehealer":
                    return cardName.darkscalehealer;

                case "shadowform":
                    return cardName.shadowform;

                case "frostnova":
                    return cardName.frostnova;

                case "purecold":
                    return cardName.purecold;

                case "mirrorentity":
                    return cardName.mirrorentity;

                case "counterspell":
                    return cardName.counterspell;

                case "mindshatter":
                    return cardName.mindshatter;

                case "magmarager":
                    return cardName.magmarager;

                case "wolfrider":
                    return cardName.wolfrider;

                case "emboldener3000":
                    return cardName.emboldener3000;

                case "polarityshift":
                    return cardName.polarityshift;

                case "gelbinmekkatorque":
                    return cardName.gelbinmekkatorque;

                case "webspinner":
                    return cardName.webspinner;

                case "utherlightbringer":
                    return cardName.utherlightbringer;

                case "innerrage":
                    return cardName.innerrage;

                case "emeralddrake":
                    return cardName.emeralddrake;

                case "forceaitouseheropower":
                    return cardName.forceaitouseheropower;

                case "echoingooze":
                    return cardName.echoingooze;

                case "heroicstrike":
                    return cardName.heroicstrike;

                case "hauntedcreeper":
                    return cardName.hauntedcreeper;

                case "barreltoss":
                    return cardName.barreltoss;

                case "yongwoo":
                    return cardName.yongwoo;

                case "doomhammer":
                    return cardName.doomhammer;

                case "stomp":
                    return cardName.stomp;

                case "spectralknight":
                    return cardName.spectralknight;

                case "tracking":
                    return cardName.tracking;

                case "fireball":
                    return cardName.fireball;

                case "thecoin":
                    return cardName.thecoin;

                case "bootybaybodyguard":
                    return cardName.bootybaybodyguard;

                case "scarletcrusader":
                    return cardName.scarletcrusader;

                case "voodoodoctor":
                    return cardName.voodoodoctor;

                case "shadowbolt":
                    return cardName.shadowbolt;

                case "etherealarcanist":
                    return cardName.etherealarcanist;

                case "succubus":
                    return cardName.succubus;

                case "emperorcobra":
                    return cardName.emperorcobra;

                case "deadlyshot":
                    return cardName.deadlyshot;

                case "reinforce":
                    return cardName.reinforce;

                case "supercharge":
                    return cardName.supercharge;

                case "claw":
                    return cardName.claw;

                case "explosiveshot":
                    return cardName.explosiveshot;

                case "avengingwrath":
                    return cardName.avengingwrath;

                case "riverpawgnoll":
                    return cardName.riverpawgnoll;

                case "sirzeliek":
                    return cardName.sirzeliek;

                case "argentprotector":
                    return cardName.argentprotector;

                case "hiddengnome":
                    return cardName.hiddengnome;

                case "felguard":
                    return cardName.felguard;

                case "northshirecleric":
                    return cardName.northshirecleric;

                case "plague":
                    return cardName.plague;

                case "lepergnome":
                    return cardName.lepergnome;

                case "fireelemental":
                    return cardName.fireelemental;

                case "armorup":
                    return cardName.armorup;

                case "snipe":
                    return cardName.snipe;

                case "southseacaptain":
                    return cardName.southseacaptain;

                case "catform":
                    return cardName.catform;

                case "bite":
                    return cardName.bite;

                case "defiasringleader":
                    return cardName.defiasringleader;

                case "harvestgolem":
                    return cardName.harvestgolem;

                case "kingkrush":
                    return cardName.kingkrush;

                case "aibuddydamageownhero5":
                    return cardName.aibuddydamageownhero5;

                case "healingtotem":
                    return cardName.healingtotem;

                case "ericdodds":
                    return cardName.ericdodds;

                case "demigodsfavor":
                    return cardName.demigodsfavor;

                case "huntersmark":
                    return cardName.huntersmark;

                case "dalaranmage":
                    return cardName.dalaranmage;

                case "twilightdrake":
                    return cardName.twilightdrake;

                case "coldlightoracle":
                    return cardName.coldlightoracle;

                case "shadeofnaxxramas":
                    return cardName.shadeofnaxxramas;

                case "moltengiant":
                    return cardName.moltengiant;

                case "deathbloom":
                    return cardName.deathbloom;

                case "shadowflame":
                    return cardName.shadowflame;

                case "anduinwrynn":
                    return cardName.anduinwrynn;

                case "argentcommander":
                    return cardName.argentcommander;

                case "revealhand":
                    return cardName.revealhand;

                case "arcanemissiles":
                    return cardName.arcanemissiles;

                case "repairbot":
                    return cardName.repairbot;

                case "unstableghoul":
                    return cardName.unstableghoul;

                case "ancientofwar":
                    return cardName.ancientofwar;

                case "stormwindchampion":
                    return cardName.stormwindchampion;

                case "summonapanther":
                    return cardName.summonapanther;

                case "mrbigglesworth":
                    return cardName.mrbigglesworth;

                case "swipe":
                    return cardName.swipe;

                case "aihelperbuddy":
                    return cardName.aihelperbuddy;

                case "hex":
                    return cardName.hex;

                case "ysera":
                    return cardName.ysera;

                case "arcanegolem":
                    return cardName.arcanegolem;

                case "bloodimp":
                    return cardName.bloodimp;

                case "pyroblast":
                    return cardName.pyroblast;

                case "murlocraider":
                    return cardName.murlocraider;

                case "faeriedragon":
                    return cardName.faeriedragon;

                case "sinisterstrike":
                    return cardName.sinisterstrike;

                case "poweroverwhelming":
                    return cardName.poweroverwhelming;

                case "arcaneexplosion":
                    return cardName.arcaneexplosion;

                case "shadowwordpain":
                    return cardName.shadowwordpain;

                case "mill30":
                    return cardName.mill30;

                case "noblesacrifice":
                    return cardName.noblesacrifice;

                case "dreadinfernal":
                    return cardName.dreadinfernal;

                case "naturalize":
                    return cardName.naturalize;

                case "totemiccall":
                    return cardName.totemiccall;

                case "secretkeeper":
                    return cardName.secretkeeper;

                case "dreadcorsair":
                    return cardName.dreadcorsair;

                case "jaws":
                    return cardName.jaws;

                case "forkedlightning":
                    return cardName.forkedlightning;

                case "reincarnate":
                    return cardName.reincarnate;

                case "handofprotection":
                    return cardName.handofprotection;

                case "noththeplaguebringer":
                    return cardName.noththeplaguebringer;

                case "vaporize":
                    return cardName.vaporize;

                case "frostbreath":
                    return cardName.frostbreath;

                case "nozdormu":
                    return cardName.nozdormu;

                case "divinespirit":
                    return cardName.divinespirit;

                case "transcendence":
                    return cardName.transcendence;

                case "armorsmith":
                    return cardName.armorsmith;

                case "murloctidehunter":
                    return cardName.murloctidehunter;

                case "stealcard":
                    return cardName.stealcard;

                case "opponentconcede":
                    return cardName.opponentconcede;

                case "tundrarhino":
                    return cardName.tundrarhino;

                case "summoningportal":
                    return cardName.summoningportal;

                case "hammerofwrath":
                    return cardName.hammerofwrath;

                case "stormwindknight":
                    return cardName.stormwindknight;

                case "freeze":
                    return cardName.freeze;

                case "madbomber":
                    return cardName.madbomber;

                case "consecration":
                    return cardName.consecration;

                case "spectraltrainee":
                    return cardName.spectraltrainee;

                case "boar":
                    return cardName.boar;

                case "knifejuggler":
                    return cardName.knifejuggler;

                case "icebarrier":
                    return cardName.icebarrier;

                case "mechanicaldragonling":
                    return cardName.mechanicaldragonling;

                case "battleaxe":
                    return cardName.battleaxe;

                case "lightsjustice":
                    return cardName.lightsjustice;

                case "lavaburst":
                    return cardName.lavaburst;

                case "mindcontroltech":
                    return cardName.mindcontroltech;

                case "boulderfistogre":
                    return cardName.boulderfistogre;

                case "fireblast":
                    return cardName.fireblast;

                case "priestessofelune":
                    return cardName.priestessofelune;

                case "ancientmage":
                    return cardName.ancientmage;

                case "shadowworddeath":
                    return cardName.shadowworddeath;

                case "ironbeakowl":
                    return cardName.ironbeakowl;

                case "eviscerate":
                    return cardName.eviscerate;

                case "repentance":
                    return cardName.repentance;

                case "understudy":
                    return cardName.understudy;

                case "sunwalker":
                    return cardName.sunwalker;

                case "nagamyrmidon":
                    return cardName.nagamyrmidon;

                case "destroyheropower":
                    return cardName.destroyheropower;

                case "skeletalsmith":
                    return cardName.skeletalsmith;

                case "slam":
                    return cardName.slam;

                case "swordofjustice":
                    return cardName.swordofjustice;

                case "bounce":
                    return cardName.bounce;

                case "shadopanmonk":
                    return cardName.shadopanmonk;

                case "whirlwind":
                    return cardName.whirlwind;

                case "alexstrasza":
                    return cardName.alexstrasza;

                case "silence":
                    return cardName.silence;

                case "rexxar":
                    return cardName.rexxar;

                case "voidwalker":
                    return cardName.voidwalker;

                case "whelp":
                    return cardName.whelp;

                case "flamestrike":
                    return cardName.flamestrike;

                case "rivercrocolisk":
                    return cardName.rivercrocolisk;

                case "stormforgedaxe":
                    return cardName.stormforgedaxe;

                case "snake":
                    return cardName.snake;

                case "shotgunblast":
                    return cardName.shotgunblast;

                case "violetapprentice":
                    return cardName.violetapprentice;

                case "templeenforcer":
                    return cardName.templeenforcer;

                case "ashbringer":
                    return cardName.ashbringer;

                case "impmaster":
                    return cardName.impmaster;

                case "defender":
                    return cardName.defender;

                case "savageroar":
                    return cardName.savageroar;

                case "innervate":
                    return cardName.innervate;

                case "inferno":
                    return cardName.inferno;

                case "falloutslime":
                    return cardName.falloutslime;

                case "earthelemental":
                    return cardName.earthelemental;

                case "facelessmanipulator":
                    return cardName.facelessmanipulator;

                case "mindpocalypse":
                    return cardName.mindpocalypse;

                case "divinefavor":
                    return cardName.divinefavor;

                case "aibuddydestroyminions":
                    return cardName.aibuddydestroyminions;

                case "demolisher":
                    return cardName.demolisher;

                case "sunfuryprotector":
                    return cardName.sunfuryprotector;

                case "dustdevil":
                    return cardName.dustdevil;

                case "powerofthehorde":
                    return cardName.powerofthehorde;

                case "dancingswords":
                    return cardName.dancingswords;

                case "holylight":
                    return cardName.holylight;

                case "feralspirit":
                    return cardName.feralspirit;

                case "raidleader":
                    return cardName.raidleader;

                case "amaniberserker":
                    return cardName.amaniberserker;

                case "ironbarkprotector":
                    return cardName.ironbarkprotector;

                case "bearform":
                    return cardName.bearform;

                case "deathwing":
                    return cardName.deathwing;

                case "stormpikecommando":
                    return cardName.stormpikecommando;

                case "squire":
                    return cardName.squire;

                case "panther":
                    return cardName.panther;

                case "silverbackpatriarch":
                    return cardName.silverbackpatriarch;

                case "bobfitch":
                    return cardName.bobfitch;

                case "gladiatorslongbow":
                    return cardName.gladiatorslongbow;

                case "damage1":
                    return cardName.damage1;
            }

            return cardName.unknown;
        }

        public enum ErrorType2
        {
            NONE,//=0
            REQ_MINION_TARGET,//=1
            REQ_FRIENDLY_TARGET,//=2
            REQ_ENEMY_TARGET,//=3
            REQ_DAMAGED_TARGET,//=4
            REQ_ENCHANTED_TARGET,
            REQ_FROZEN_TARGET,
            REQ_CHARGE_TARGET,
            REQ_TARGET_MAX_ATTACK,//=8
            REQ_NONSELF_TARGET,//=9
            REQ_TARGET_WITH_RACE,//=10
            REQ_TARGET_TO_PLAY,//=11 
            REQ_NUM_MINION_SLOTS,//=12 
            REQ_WEAPON_EQUIPPED,//=13
            REQ_ENOUGH_MANA,//=14
            REQ_YOUR_TURN,
            REQ_NONSTEALTH_ENEMY_TARGET,
            REQ_HERO_TARGET,//17
            REQ_SECRET_CAP,
            REQ_MINION_CAP_IF_TARGET_AVAILABLE,//19
            REQ_MINION_CAP,
            REQ_TARGET_ATTACKED_THIS_TURN,
            REQ_TARGET_IF_AVAILABLE,//=22
            REQ_MINIMUM_ENEMY_MINIONS,//=23 /like spalen :D
            REQ_TARGET_FOR_COMBO,//=24
            REQ_NOT_EXHAUSTED_ACTIVATE,
            REQ_UNIQUE_SECRET,
            REQ_TARGET_TAUNTER,
            REQ_CAN_BE_ATTACKED,
            REQ_ACTION_PWR_IS_MASTER_PWR,
            REQ_TARGET_MAGNET,
            REQ_ATTACK_GREATER_THAN_0,
            REQ_ATTACKER_NOT_FROZEN,
            REQ_HERO_OR_MINION_TARGET,
            REQ_CAN_BE_TARGETED_BY_SPELLS,
            REQ_SUBCARD_IS_PLAYABLE,
            REQ_TARGET_FOR_NO_COMBO,
            REQ_NOT_MINION_JUST_PLAYED,
            REQ_NOT_EXHAUSTED_HERO_POWER,
            REQ_CAN_BE_TARGETED_BY_OPPONENTS,
            REQ_ATTACKER_CAN_ATTACK,
            REQ_TARGET_MIN_ATTACK,//=41
            REQ_CAN_BE_TARGETED_BY_HERO_POWERS,
            REQ_ENEMY_TARGET_NOT_IMMUNE,
            REQ_ENTIRE_ENTOURAGE_NOT_IN_PLAY,//44 (totemic call)
            REQ_MINIMUM_TOTAL_MINIONS,//45 (scharmuetzel)
            REQ_MUST_TARGET_TAUNTER,//=46
            REQ_UNDAMAGED_TARGET//=47
        }

        public class Card
        {
            //public string CardID = "";
            public cardName name = cardName.unknown;
            public int race = 0;
            public int rarity = 0;
            public int cost = 0;
            public cardtype type = CardDB.cardtype.NONE;
            //public string description = "";

            public int Attack = 0;
            public int Health = 0;
            public int Durability = 0;//for weapons
            public bool target = false;
            //public string targettext = "";
            public bool tank = false;
            public bool Silence = false;
            public bool choice = false;
            public bool windfury = false;
            public bool poisionous = false;
            public bool deathrattle = false;
            public bool battlecry = false;
            public bool oneTurnEffect = false;
            public bool Enrage = false;
            public bool Aura = false;
            public bool Elite = false;
            public bool Combo = false;
            public bool Recall = false;
            public int recallValue = 0;
            public bool immuneWhileAttacking = false;
            public bool immuneToSpellpowerg = false;
            public bool Stealth = false;
            public bool Freeze = false;
            public bool AdjacentBuff = false;
            public bool Shield = false;
            public bool Charge = false;
            public bool Secret = false;
            public bool Morph = false;
            public bool Spellpower = false;
            public bool GrantCharge = false;
            public bool HealTarget = false;
            //playRequirements, reqID= siehe PlayErrors->ErrorType
            public int needEmptyPlacesForPlaying = 0;
            public int needWithMinAttackValueOf = 0;
            public int needWithMaxAttackValueOf = 0;
            public int needRaceForPlaying = 0;
            public int needMinNumberOfEnemy = 0;
            public int needMinTotalMinions = 0;
            public int needMinionsCapIfAvailable = 0;


            //additional data
            public bool isToken = false;
            public int isCarddraw = 0;
            public bool damagesTarget = false;
            public bool damagesTargetWithSpecial = false;
            public int targetPriority = 0;
            public bool isSpecialMinion = false;

            public int spellpowervalue = 0;
            public cardIDEnum cardIDenum = cardIDEnum.None;
            public List<ErrorType2> playrequires;

            public SimTemplate sim_card;

            public Card()
            {
                playrequires = new List<ErrorType2>();
            }

            public Card(Card c)
            {
                //this.entityID = c.entityID;
                this.rarity = c.rarity;
                this.AdjacentBuff = c.AdjacentBuff;
                this.Attack = c.Attack;
                this.Aura = c.Aura;
                this.battlecry = c.battlecry;
                //this.CardID = c.CardID;
                this.Charge = c.Charge;
                this.choice = c.choice;
                this.Combo = c.Combo;
                this.cost = c.cost;
                this.deathrattle = c.deathrattle;
                //this.description = c.description;
                this.Durability = c.Durability;
                this.Elite = c.Elite;
                this.Enrage = c.Enrage;
                this.Freeze = c.Freeze;
                this.GrantCharge = c.GrantCharge;
                this.HealTarget = c.HealTarget;
                this.Health = c.Health;
                this.immuneToSpellpowerg = c.immuneToSpellpowerg;
                this.immuneWhileAttacking = c.immuneWhileAttacking;
                this.Morph = c.Morph;
                this.name = c.name;
                this.needEmptyPlacesForPlaying = c.needEmptyPlacesForPlaying;
                this.needMinionsCapIfAvailable = c.needMinionsCapIfAvailable;
                this.needMinNumberOfEnemy = c.needMinNumberOfEnemy;
                this.needMinTotalMinions = c.needMinTotalMinions;
                this.needRaceForPlaying = c.needRaceForPlaying;
                this.needWithMaxAttackValueOf = c.needWithMaxAttackValueOf;
                this.needWithMinAttackValueOf = c.needWithMinAttackValueOf;
                this.oneTurnEffect = c.oneTurnEffect;
                this.playrequires = new List<ErrorType2>(c.playrequires);
                this.poisionous = c.poisionous;
                this.race = c.race;
                this.Recall = c.Recall;
                this.recallValue = c.recallValue;
                this.Secret = c.Secret;
                this.Shield = c.Shield;
                this.Silence = c.Silence;
                this.Spellpower = c.Spellpower;
                this.spellpowervalue = c.spellpowervalue;
                this.Stealth = c.Stealth;
                this.tank = c.tank;
                this.target = c.target;
                //this.targettext = c.targettext;
                this.type = c.type;
                this.windfury = c.windfury;
                this.cardIDenum = c.cardIDenum;
                this.sim_card = c.sim_card;
                this.isToken = c.isToken;
            }

            public bool isRequirementInList(CardDB.ErrorType2 et)
            {
                return this.playrequires.Contains(et);
            }

            public List<Minion> getTargetsForCard(Playfield p)
            {
                //todo make it faster!! 
                //todo remove the isRequirementInList with an big list of bools to ask the state of the bool
                bool addOwnHero = false;
                bool addEnemyHero = false;
                bool[] ownMins = new bool[p.ownMinions.Count];
                bool[] enemyMins = new bool[p.enemyMinions.Count];
                for (int i = 0; i < ownMins.Length; i++) ownMins[i] = false;
                for (int i = 0; i < enemyMins.Length; i++) enemyMins[i] = false;

                int k = 0;
                List<Minion> retval = new List<Minion>();

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_FOR_COMBO) && p.cardsPlayedThisTurn == 0) return retval;

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_TO_PLAY) || isRequirementInList(CardDB.ErrorType2.REQ_NONSELF_TARGET) || isRequirementInList(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE) || isRequirementInList(CardDB.ErrorType2.REQ_TARGET_FOR_COMBO))
                {
                    addEnemyHero = true;
                    addOwnHero = true;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if ((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.name == CardDB.cardName.faeriedragon || m.name == CardDB.cardName.laughingsister || m.name == CardDB.cardName.spectralknight)) continue;
                        ownMins[k] = true;

                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.name == CardDB.cardName.faeriedragon || m.name == CardDB.cardName.laughingsister || m.name == CardDB.cardName.spectralknight)) || m.stealth) continue;
                        enemyMins[k] = true;
                    }

                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_HERO_TARGET))
                {
                    for (int i = 0; i < ownMins.Length; i++) ownMins[i] = false;
                    for (int i = 0; i < enemyMins.Length; i++) enemyMins[i] = false;

                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_MINION_TARGET))
                {
                    addOwnHero = false;
                    addEnemyHero = false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_FRIENDLY_TARGET))
                {
                    addEnemyHero = false;
                    for (int i = 0; i < enemyMins.Length; i++) enemyMins[i] = false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_ENEMY_TARGET))
                {
                    addOwnHero = false;
                    for (int i = 0; i < ownMins.Length; i++) ownMins[i] = false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_DAMAGED_TARGET))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (!m.wounded)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (!m.wounded)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_UNDAMAGED_TARGET))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (m.wounded)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (m.wounded)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_MAX_ATTACK))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (m.Angr > this.needWithMaxAttackValueOf)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (m.Angr > this.needWithMaxAttackValueOf)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_MIN_ATTACK))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (m.Angr < this.needWithMinAttackValueOf)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (m.Angr < this.needWithMinAttackValueOf)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_WITH_RACE))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    addOwnHero = (p.ownHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON);
                    addEnemyHero = (p.enemyHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON);
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if ((m.handcard.card.race != this.needRaceForPlaying))
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if ((m.handcard.card.race != this.needRaceForPlaying))
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_MUST_TARGET_TAUNTER))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (!m.taunt)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (!m.taunt)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (addEnemyHero) retval.Add(p.enemyHero);
                if (addOwnHero) retval.Add(p.ownHero);

                k = -1;
                foreach (Minion m in p.ownMinions)
                {
                    k++;
                    if (ownMins[k]) retval.Add(m);
                }
                k = -1;
                foreach (Minion m in p.enemyMinions)
                {
                    k++;
                    if (enemyMins[k]) retval.Add(m);
                }

                return retval;

            }

            public List<Minion> getTargetsForCardEnemy(Playfield p)
            {
                //todo make it faster!! 
                //todo remove the isRequirementInList with an big list of bools to ask the state of the bool
                bool addOwnHero = false;
                bool addEnemyHero = false;
                bool[] ownMins = new bool[p.ownMinions.Count];
                bool[] enemyMins = new bool[p.enemyMinions.Count];
                for (int i = 0; i < ownMins.Length; i++) ownMins[i] = false;
                for (int i = 0; i < enemyMins.Length; i++) enemyMins[i] = false;

                int k = 0;
                List<Minion> retval = new List<Minion>();

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_FOR_COMBO) && p.cardsPlayedThisTurn == 0) return retval;

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_TO_PLAY) || isRequirementInList(CardDB.ErrorType2.REQ_NONSELF_TARGET) || isRequirementInList(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE) || isRequirementInList(CardDB.ErrorType2.REQ_TARGET_FOR_COMBO))
                {
                    addEnemyHero = true;
                    addOwnHero = true;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.name == CardDB.cardName.faeriedragon || m.name == CardDB.cardName.laughingsister || m.name == CardDB.cardName.spectralknight)) || m.stealth) continue;
                        ownMins[k] = true;

                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (((this.type == cardtype.SPELL || this.type == cardtype.HEROPWR) && (m.name == CardDB.cardName.faeriedragon || m.name == CardDB.cardName.laughingsister) || m.name == CardDB.cardName.spectralknight)) continue;
                        enemyMins[k] = true;
                    }

                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_HERO_TARGET))
                {
                    for (int i = 0; i < ownMins.Length; i++) ownMins[i] = false;
                    for (int i = 0; i < enemyMins.Length; i++) enemyMins[i] = false;

                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_MINION_TARGET))
                {
                    addOwnHero = false;
                    addEnemyHero = false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_FRIENDLY_TARGET))
                {
                    addOwnHero = false;
                    for (int i = 0; i < ownMins.Length; i++) ownMins[i] = false;

                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_ENEMY_TARGET))
                {
                    addEnemyHero = false;
                    for (int i = 0; i < enemyMins.Length; i++) enemyMins[i] = false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_DAMAGED_TARGET))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (!m.wounded)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (!m.wounded)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_UNDAMAGED_TARGET))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (m.wounded)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (m.wounded)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_MAX_ATTACK))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (m.Angr > this.needWithMaxAttackValueOf)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (m.Angr > this.needWithMaxAttackValueOf)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_MIN_ATTACK))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (m.Angr < this.needWithMinAttackValueOf)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (m.Angr < this.needWithMinAttackValueOf)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_WITH_RACE))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    addOwnHero = (p.ownHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON);
                    addEnemyHero = (p.enemyHeroName == HeroEnum.lordjaraxxus && (TAG_RACE)this.needRaceForPlaying == TAG_RACE.DEMON);
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if ((m.handcard.card.race != this.needRaceForPlaying))
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if ((m.handcard.card.race != this.needRaceForPlaying))
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_MUST_TARGET_TAUNTER))
                {
                    addEnemyHero = false;
                    addOwnHero = false;
                    k = -1;
                    foreach (Minion m in p.ownMinions)
                    {
                        k++;
                        if (!m.taunt)
                        {
                            ownMins[k] = false;
                        }
                    }
                    k = -1;
                    foreach (Minion m in p.enemyMinions)
                    {
                        k++;
                        if (!m.taunt)
                        {
                            enemyMins[k] = false;
                        }
                    }
                }

                if (addEnemyHero) retval.Add(p.enemyHero);
                if (addOwnHero) retval.Add(p.ownHero);

                k = -1;
                foreach (Minion m in p.ownMinions)
                {
                    k++;
                    if (ownMins[k]) retval.Add(m);
                }
                k = -1;
                foreach (Minion m in p.enemyMinions)
                {
                    k++;
                    if (enemyMins[k]) retval.Add(m);
                }

                return retval;

            }

            public int calculateManaCost(Playfield p)//calculates the mana from orginal mana, needed for back-to hand effects
            {
                int retval = this.cost;
                int offset = 0;

                if (this.type == cardtype.MOB)
                {
                    offset += p.soeldnerDerVenture * 3;

                    offset += p.managespenst;

                    int temp = -(p.startedWithbeschwoerungsportal) * 2;
                    if (retval + temp <= 0) temp = -retval + 1;
                    offset = offset + temp;

                    if (p.mobsplayedThisTurn == 0)
                    {
                        offset -= p.winzigebeschwoererin;
                    }

                    if (this.battlecry)
                    {
                        offset += p.nerubarweblord * 2;
                    }

                }

                if (this.type == cardtype.SPELL)
                { //if the number of zauberlehrlings change
                    offset -= (p.anzOwnsorcerersapprentice);
                    if (p.playedPreparation)
                    { //if the number of zauberlehrlings change
                        offset -= 3;
                    }

                }

                switch (this.name)
                {
                    case CardDB.cardName.dreadcorsair:
                        retval = retval + offset - p.ownWeaponAttack;
                        break;
                    case CardDB.cardName.seagiant:
                        retval = retval + offset - p.ownMinions.Count - p.enemyMinions.Count;
                        break;
                    case CardDB.cardName.mountaingiant:
                        retval = retval + offset - p.owncards.Count;
                        break;
                    case CardDB.cardName.moltengiant:
                        retval = retval + offset - p.ownHero.Hp;
                        break;
                    default:
                        retval = retval + offset;
                        break;
                }

                if (this.Secret && p.playedmagierinderkirintor)
                {
                    retval = 0;
                }

                retval = Math.Max(0, retval);

                return retval;
            }

            public int getManaCost(Playfield p, int currentcost)//calculates mana from current mana
            {
                int retval = currentcost;


                int offset = 0; // if offset < 0 costs become lower, if >0 costs are higher at the end

                // CARDS that increase the manacosts of others ##############################
                //Manacosts changes with soeldner der venture co.
                if (p.soeldnerDerVenture != p.startedWithsoeldnerDerVenture && this.type == cardtype.MOB)
                {
                    offset += (p.soeldnerDerVenture - p.startedWithsoeldnerDerVenture) * 3;
                }

                //Manacosts changes with mana-ghost
                if (p.managespenst != p.startedWithManagespenst && this.type == cardtype.MOB)
                {
                    offset += (p.managespenst - p.startedWithManagespenst);
                }

                if (this.battlecry && p.nerubarweblord != p.startedWithnerubarweblord && this.type == cardtype.MOB)
                {
                    offset += (p.nerubarweblord - p.startedWithnerubarweblord) * 2;
                }


                // CARDS that decrease the manacosts of others ##############################

                //Manacosts changes with the summoning-portal >_>
                if (p.startedWithbeschwoerungsportal != p.beschwoerungsportal && this.type == cardtype.MOB)
                { //cant lower the mana to 0
                    int temp = (p.startedWithbeschwoerungsportal - p.beschwoerungsportal) * 2;
                    if (retval + temp <= 0) temp = -retval + 1;
                    offset = offset + temp;
                }

                //Manacosts changes with the pint-sized summoner
                if (p.winzigebeschwoererin >= 1 && p.mobsplayedThisTurn >= 1 && p.startedWithMobsPlayedThisTurn == 0 && this.type == cardtype.MOB)
                { // if we start oure calculations with 0 mobs played, then the cardcost are 1 mana to low in the further calculations (with the little summoner on field)
                    offset += p.winzigebeschwoererin;
                }
                if (p.mobsplayedThisTurn == 0 && p.winzigebeschwoererin <= p.startedWithWinzigebeschwoererin && this.type == cardtype.MOB)
                { // one pint-sized summoner got killed, before we played the first mob -> the manacost are higher of all mobs
                    offset += (p.startedWithWinzigebeschwoererin - p.winzigebeschwoererin);
                }

                //Manacosts changes with the zauberlehrling summoner
                if (p.anzOwnsorcerersapprentice != p.anzOwnsorcerersapprenticeStarted && this.type == cardtype.SPELL)
                { //if the number of zauberlehrlings change
                    offset += (p.anzOwnsorcerersapprenticeStarted - p.anzOwnsorcerersapprentice);
                }



                //manacosts are lowered, after we played preparation
                if (p.playedPreparation && this.type == cardtype.SPELL)
                { //if the number of zauberlehrlings change
                    offset -= 3;
                }


                switch (this.name)
                {
                    case CardDB.cardName.dreadcorsair:
                        retval = retval + offset - p.ownWeaponAttack + p.ownWeaponAttackStarted; // if weapon attack change we change manacost
                        break;
                    case CardDB.cardName.seagiant:
                        retval = retval + offset - p.ownMinions.Count - p.enemyMinions.Count + p.ownMobsCountStarted;
                        break;
                    case CardDB.cardName.mountaingiant:
                        retval = retval + offset - p.owncards.Count + p.ownCardsCountStarted;
                        break;
                    case CardDB.cardName.moltengiant:
                        retval = retval + offset - p.ownHero.Hp + p.ownHeroHpStarted;
                        break;
                    default:
                        retval = retval + offset;
                        break;
                }

                if (this.Secret && p.playedmagierinderkirintor)
                {
                    retval = 0;
                }

                retval = Math.Max(0, retval);

                return retval;
            }

            public bool canplayCard(Playfield p, int manacost)
            {
                //is playrequirement?
                bool haveToDoRequires = isRequirementInList(CardDB.ErrorType2.REQ_TARGET_TO_PLAY);
                bool retval = true;
                // cant play if i have to few mana

                if (p.mana < this.getManaCost(p, manacost)) return false;

                // cant play mob, if i have allready 7 mininos
                if (this.type == CardDB.cardtype.MOB && p.ownMinions.Count >= 7) return false;

                if (isRequirementInList(CardDB.ErrorType2.REQ_MINIMUM_ENEMY_MINIONS))
                {
                    if (p.enemyMinions.Count < this.needMinNumberOfEnemy) return false;
                }
                if (isRequirementInList(CardDB.ErrorType2.REQ_NUM_MINION_SLOTS))
                {
                    if (p.ownMinions.Count > 7 - this.needEmptyPlacesForPlaying) return false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_WEAPON_EQUIPPED))
                {
                    if (p.ownWeaponName == CardDB.cardName.unknown) return false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_MINIMUM_TOTAL_MINIONS))
                {
                    if (this.needMinTotalMinions > p.ownMinions.Count + p.enemyMinions.Count) return false;
                }

                if (haveToDoRequires)
                {
                    if (this.getTargetsForCard(p).Count == 0) return false;

                    //it requires a target-> return false if 
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE) && isRequirementInList(CardDB.ErrorType2.REQ_MINION_CAP_IF_TARGET_AVAILABLE))
                {
                    if (this.getTargetsForCard(p).Count >= 1 && p.ownMinions.Count > 7 - this.needMinionsCapIfAvailable) return false;
                }

                if (isRequirementInList(CardDB.ErrorType2.REQ_ENTIRE_ENTOURAGE_NOT_IN_PLAY))
                {
                    int difftotem = 0;
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.name == CardDB.cardName.healingtotem || m.name == CardDB.cardName.wrathofairtotem || m.name == CardDB.cardName.searingtotem || m.name == CardDB.cardName.stoneclawtotem) difftotem++;
                    }
                    if (difftotem == 4) return false;
                }


                if (this.Secret)
                {
                    if (p.ownSecretsIDList.Contains(this.cardIDenum)) return false;
                    if (p.ownSecretsIDList.Count >= 5) return false;
                }


                return true;
            }



        }

        List<string> namelist = new List<string>();
        List<Card> cardlist = new List<Card>();
        Dictionary<cardIDEnum, Card> cardidToCardList = new Dictionary<cardIDEnum, Card>();
        List<string> allCardIDS = new List<string>();
        public Card unknownCard;
        public bool installedWrong = false;

        public Card teacherminion;
        public Card illidanminion;

        private static CardDB instance;

        public static CardDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CardDB();
                    //instance.enumCreator();// only call this to get latest cardids
                    /*foreach (KeyValuePair<cardIDEnum, Card> kvp in instance.cardidToCardList)
                    {
                        Helpfunctions.Instance.logg(kvp.Value.name + " " + kvp.Value.Attack);
                    }*/
                    // have to do it 2 times (or the kids inside the simcards will not have a simcard :D
                    foreach (Card c in instance.cardlist)
                    {
                        c.sim_card = instance.getSimCard(c.cardIDenum);
                    }
                    instance.setAdditionalData();
                }
                return instance;
            }
        }

        private CardDB()
        {
            string[] lines = new string[0] { };
            try
            {
                string path = Settings.Instance.path;
                lines = System.IO.File.ReadAllLines(path + "_carddb.txt");
                Helpfunctions.Instance.ErrorLog("read carddb.txt");
            }
            catch
            {
                Helpfunctions.Instance.logg("cant find _carddb.txt");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("cant find _carddb.txt in " + Settings.Instance.path);
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("you installed it wrong");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                this.installedWrong = true;
            }
            cardlist.Clear();
            this.cardidToCardList.Clear();
            Card c = new Card();
            int de = 0;
            //placeholdercard
            Card plchldr = new Card { name = cardName.unknown, cost = 1000 };
            this.namelist.Add("unknown");
            this.cardlist.Add(plchldr);
            this.unknownCard = cardlist[0];
            string name = "";
            foreach (string s in lines)
            {
                if (s.Contains("/Entity"))
                {
                    if (c.type == cardtype.ENCHANTMENT)
                    {
                        //Helpfunctions.Instance.logg(c.CardID);
                        //Helpfunctions.Instance.logg(c.name);
                        //Helpfunctions.Instance.logg(c.description);
                        continue;
                    }
                    if (name != "")
                    {
                        this.namelist.Add(name);
                    }
                    name = "";
                    if (c.name != CardDB.cardName.unknown)
                    {

                        this.cardlist.Add(c);
                        //Helpfunctions.Instance.logg(c.name);

                        if (!this.cardidToCardList.ContainsKey(c.cardIDenum))
                        {
                            this.cardidToCardList.Add(c.cardIDenum, c);
                        }
                    }

                }
                if (s.Contains("<Entity version=\"") && s.Contains(" CardID=\""))
                {
                    c = new Card();
                    de = 0;
                    string temp = s.Split(new string[] { "CardID=\"" }, StringSplitOptions.None)[1];
                    temp = temp.Replace("\">", "");
                    //c.CardID = temp;
                    allCardIDS.Add(temp);
                    c.cardIDenum = this.cardIdstringToEnum(temp);

                    //token:
                    if (temp.EndsWith("t"))
                    {
                        c.isToken = true;
                    }
                    if (temp.Equals("ds1_whelptoken")) c.isToken = true;
                    if (temp.Equals("CS2_mirror")) c.isToken = true;
                    if (temp.Equals("CS2_050")) c.isToken = true;
                    if (temp.Equals("CS2_052")) c.isToken = true;
                    if (temp.Equals("CS2_051")) c.isToken = true;
                    if (temp.Equals("NEW1_009")) c.isToken = true;
                    if (temp.Equals("CS2_152")) c.isToken = true;
                    if (temp.Equals("CS2_boar")) c.isToken = true;
                    if (temp.Equals("EX1_tk11")) c.isToken = true;
                    if (temp.Equals("EX1_506a")) c.isToken = true;
                    if (temp.Equals("skele21")) c.isToken = true;
                    if (temp.Equals("EX1_tk9")) c.isToken = true;
                    if (temp.Equals("EX1_finkle")) c.isToken = true;
                    if (temp.Equals("EX1_598")) c.isToken = true;
                    if (temp.Equals("EX1_tk34")) c.isToken = true;
                    //if (c.isToken) Helpfunctions.Instance.ErrorLog(temp);

                    continue;
                }
                /*
                if (s.Contains("<Entity version=\"1\" CardID=\""))
                {
                    c = new Card();
                    de = 0;
                    string temp = s.Replace("<Entity version=\"1\" CardID=\"", "");
                    temp = temp.Replace("\">", "");
                    //c.CardID = temp;
                    allCardIDS.Add(temp);
                    c.cardIDenum = this.cardIdstringToEnum(temp);
                    continue;
                }*/

                if (s.Contains("<Tag name=\"Health\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Health = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("<Tag name=\"Atk\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Attack = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("<Tag name=\"Race\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.race = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("<Tag name=\"Rarity\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.rarity = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("<Tag name=\"Cost\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.cost = Convert.ToInt32(temp);
                    continue;
                }

                if (s.Contains("<Tag name=\"CardType\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    if (c.name != CardDB.cardName.unknown)
                    {
                        //Helpfunctions.Instance.logg(temp);
                    }

                    int crdtype = Convert.ToInt32(temp);
                    if (crdtype == 10)
                    {
                        c.type = CardDB.cardtype.HEROPWR;
                    }
                    if (crdtype == 4)
                    {
                        c.type = CardDB.cardtype.MOB;
                    }
                    if (crdtype == 5)
                    {
                        c.type = CardDB.cardtype.SPELL;
                    }
                    if (crdtype == 6)
                    {
                        c.type = CardDB.cardtype.ENCHANTMENT;
                    }
                    if (crdtype == 7)
                    {
                        c.type = CardDB.cardtype.WEAPON;
                    }
                    continue;
                }

                if (s.Contains("<Tag name=\"CardName\" "))
                {
                    de = 0;
                    continue;
                }
                if (s.Contains("<Tag name=\"CardTextInHand\" "))
                {
                    de = 1;
                    continue;
                }
                if (s.Contains("<Tag name=\"TargetingArrowText\" "))
                {
                    c.target = true;
                    de = 2;
                    continue;
                }

                if (s.Contains("<enUS>"))
                {
                    string temp = s.Replace("<enUS>", "");

                    temp = temp.Replace("</enUS>", "");
                    temp = temp.Replace("&lt;", "");
                    temp = temp.Replace("b&gt;", "");
                    temp = temp.Replace("/b&gt;", "");
                    temp = temp.ToLower();
                    if (de == 0)
                    {
                        temp = temp.Replace("'", "");
                        temp = temp.Replace(" ", "");
                        temp = temp.Replace(":", "");
                        temp = temp.Replace(".", "");
                        temp = temp.Replace("!", "");
                        temp = temp.Replace("-", "");
                        //temp = temp.Replace("ß", "ss");
                        //temp = temp.Replace("ü", "ue");
                        //temp = temp.Replace("ä", "ae");
                        //temp = temp.Replace("ö", "oe");

                        //Helpfunctions.Instance.logg(temp);
                        c.name = this.cardNamestringToEnum(temp);
                        name = temp;


                    }
                    if (de == 1)
                    {
                        //c.description = temp;
                        //if (c.description.Contains("choose one"))
                        if (temp.Contains("choose one"))
                        {
                            c.choice = true;
                            //Helpfunctions.Instance.logg(c.name + " is choice");
                        }
                    }
                    if (de == 2)
                    {
                        //c.targettext = temp;
                    }
                    de = -1;
                    continue;
                }
                if (s.Contains("<Tag name=\"Poisonous\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.poisionous = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Enrage\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Enrage = true;
                    continue;
                }

                if (s.Contains("<Tag name=\"OneTurnEffect\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.oneTurnEffect = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Aura\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Aura = true;
                    continue;
                }


                if (s.Contains("<Tag name=\"Taunt\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.tank = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Battlecry\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.battlecry = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Windfury\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.windfury = true;
                    continue;
                }

                if (s.Contains("<Tag name=\"Deathrattle\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.deathrattle = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Durability\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.Durability = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("<Tag name=\"Elite\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Elite = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Combo\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Combo = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Recall\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Recall = true;
                    c.recallValue = 1;
                    if (c.name == CardDB.cardName.forkedlightning) c.recallValue = 2;
                    if (c.name == CardDB.cardName.dustdevil) c.recallValue = 2;
                    if (c.name == CardDB.cardName.lightningstorm) c.recallValue = 2;
                    if (c.name == CardDB.cardName.lavaburst) c.recallValue = 2;
                    if (c.name == CardDB.cardName.feralspirit) c.recallValue = 2;
                    if (c.name == CardDB.cardName.doomhammer) c.recallValue = 2;
                    if (c.name == CardDB.cardName.earthelemental) c.recallValue = 3;
                    continue;
                }

                if (s.Contains("<Tag name=\"ImmuneToSpellpower\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.immuneToSpellpowerg = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Stealth\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Stealth = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Secret\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Secret = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Freeze\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Freeze = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"AdjacentBuff\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.AdjacentBuff = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Divine Shield\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Shield = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Charge\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Charge = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Silence\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Silence = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Morph\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Morph = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"Spellpower\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.Spellpower = true;
                    c.spellpowervalue = 1;
                    if (c.name == CardDB.cardName.ancientmage) c.spellpowervalue = 0;
                    if (c.name == CardDB.cardName.malygos) c.spellpowervalue = 5;
                    continue;
                }
                if (s.Contains("<Tag name=\"GrantCharge\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.GrantCharge = true;
                    continue;
                }
                if (s.Contains("<Tag name=\"HealTarget\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) c.HealTarget = true;
                    continue;
                }
                if (s.Contains("<PlayRequirement"))
                {
                    string temp = s.Split(new string[] { "reqID=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    ErrorType2 et2 = (ErrorType2)Convert.ToInt32(temp);
                    c.playrequires.Add(et2);
                }


                if (s.Contains("<PlayRequirement reqID=\"12\" param=\""))
                {
                    string temp = s.Split(new string[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needEmptyPlacesForPlaying = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("PlayRequirement reqID=\"41\" param=\""))
                {
                    string temp = s.Split(new string[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needWithMinAttackValueOf = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("PlayRequirement reqID=\"8\" param=\""))
                {
                    string temp = s.Split(new string[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needWithMaxAttackValueOf = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("PlayRequirement reqID=\"10\" param=\""))
                {
                    string temp = s.Split(new string[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needRaceForPlaying = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("PlayRequirement reqID=\"23\" param=\""))
                {
                    string temp = s.Split(new string[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needMinNumberOfEnemy = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("PlayRequirement reqID=\"45\" param=\""))
                {
                    string temp = s.Split(new string[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needMinTotalMinions = Convert.ToInt32(temp);
                    continue;
                }
                if (s.Contains("PlayRequirement reqID=\"19\" param=\""))
                {
                    string temp = s.Split(new string[] { "param=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    c.needMinionsCapIfAvailable = Convert.ToInt32(temp);
                    continue;
                }



                if (s.Contains("<Tag name="))
                {
                    string temp = s.Split(new string[] { "<Tag name=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    /*
                    if (temp != "DevState" && temp != "FlavorText" && temp != "ArtistName" && temp != "Cost" && temp != "EnchantmentIdleVisual" && temp != "EnchantmentBirthVisual" && temp != "Collectible" && temp != "CardSet" && temp != "AttackVisualType" && temp != "CardName" && temp != "Class" && temp != "CardTextInHand" && temp != "Rarity" && temp != "TriggerVisual" && temp != "Faction" && temp != "HowToGetThisGoldCard" && temp != "HowToGetThisCard" && temp != "CardTextInPlay")
                        Helpfunctions.Instance.logg(s);*/
                }


            }

            this.teacherminion = this.getCardDataFromID(CardDB.cardIDEnum.NEW1_026t);
            this.illidanminion = this.getCardDataFromID(CardDB.cardIDEnum.EX1_614t);

        }

        public Card getCardData(CardDB.cardName cardname)
        {

            foreach (Card ca in this.cardlist)
            {
                if (ca.name == cardname)
                {
                    return ca;
                }
            }

            return unknownCard;
        }

        public Card getCardDataFromID(cardIDEnum id)
        {
            return this.cardidToCardList.ContainsKey(id) ? this.cardidToCardList[id] : this.unknownCard;
        }

        public SimTemplate getSimCard(cardIDEnum id)
        {
            switch (id)
            {
                case cardIDEnum.NEW1_007b:
                    return new Sim_NEW1_007b();
                case cardIDEnum.EX1_613:
                    return new Sim_EX1_613();
                case cardIDEnum.EX1_133:
                    return new Sim_EX1_133();
                case cardIDEnum.NEW1_018:
                    return new Sim_NEW1_018();
                case cardIDEnum.EX1_012:
                    return new Sim_EX1_012();
                case cardIDEnum.EX1_178a:
                    return new Sim_EX1_178a();
                case cardIDEnum.CS2_231:
                    return new Sim_CS2_231();
                case cardIDEnum.CS2_179:
                    return new Sim_CS2_179();
                case cardIDEnum.EX1_244:
                    return new Sim_EX1_244();
                case cardIDEnum.EX1_178b:
                    return new Sim_EX1_178b();
                case cardIDEnum.EX1_573b:
                    return new Sim_EX1_573b();
                case cardIDEnum.NEW1_007a:
                    return new Sim_NEW1_007a();
                case cardIDEnum.EX1_345t:
                    return new Sim_EX1_345t();
                case cardIDEnum.FP1_007t:
                    return new Sim_FP1_007t();
                case cardIDEnum.EX1_025:
                    return new Sim_EX1_025();
                case cardIDEnum.EX1_396:
                    return new Sim_EX1_396();
                case cardIDEnum.NEW1_017:
                    return new Sim_NEW1_017();
                case cardIDEnum.NEW1_008a:
                    return new Sim_NEW1_008a();
                case cardIDEnum.EX1_533:
                    return new Sim_EX1_533();
                case cardIDEnum.EX1_522:
                    return new Sim_EX1_522();

                // case CardDB.cardIDEnum.NAX11_04: return new Sim_NAX11_04();
                case cardIDEnum.NEW1_026:
                    return new Sim_NEW1_026();
                case cardIDEnum.EX1_398:
                    return new Sim_EX1_398();

                // case CardDB.cardIDEnum.NAX4_04: return new Sim_NAX4_04();
                case cardIDEnum.EX1_007:
                    return new Sim_EX1_007();
                case cardIDEnum.CS1_112:
                    return new Sim_CS1_112();
                case cardIDEnum.NEW1_036:
                    return new Sim_NEW1_036();
                case cardIDEnum.EX1_258:
                    return new Sim_EX1_258();
                case cardIDEnum.HERO_01:
                    return new Sim_HERO_01();
                case cardIDEnum.CS2_087:
                    return new Sim_CS2_087();
                case cardIDEnum.DREAM_05:
                    return new Sim_DREAM_05();
                case cardIDEnum.CS2_092:
                    return new Sim_CS2_092();
                case cardIDEnum.CS2_022:
                    return new Sim_CS2_022();
                case cardIDEnum.EX1_046:
                    return new Sim_EX1_046();
                case cardIDEnum.PRO_001b:
                    return new Sim_PRO_001b();
                case cardIDEnum.PRO_001a:
                    return new Sim_PRO_001a();
                case cardIDEnum.CS2_103:
                    return new Sim_CS2_103();
                case cardIDEnum.NEW1_041:
                    return new Sim_NEW1_041();
                case cardIDEnum.EX1_360:
                    return new Sim_EX1_360();
                case cardIDEnum.FP1_023:
                    return new Sim_FP1_023();
                case cardIDEnum.NEW1_038:
                    return new Sim_NEW1_038();
                case cardIDEnum.CS2_009:
                    return new Sim_CS2_009();
                case cardIDEnum.EX1_010:
                    return new Sim_EX1_010();
                case cardIDEnum.CS2_024:
                    return new Sim_CS2_024();
                case cardIDEnum.EX1_565:
                    return new Sim_EX1_565();
                case cardIDEnum.CS2_076:
                    return new Sim_CS2_076();
                case cardIDEnum.FP1_004:
                    return new Sim_FP1_004();
                case cardIDEnum.CS2_162:
                    return new Sim_CS2_162();
                case cardIDEnum.EX1_110t:
                    return new Sim_EX1_110t();
                case cardIDEnum.CS2_181:
                    return new Sim_CS2_181();
                case cardIDEnum.EX1_309:
                    return new Sim_EX1_309();
                case cardIDEnum.EX1_354:
                    return new Sim_EX1_354();
                case cardIDEnum.EX1_023:
                    return new Sim_EX1_023();
                case cardIDEnum.NEW1_034:
                    return new Sim_NEW1_034();
                case cardIDEnum.CS2_003:
                    return new Sim_CS2_003();
                case cardIDEnum.HERO_06:
                    return new Sim_HERO_06();
                case cardIDEnum.CS2_201:
                    return new Sim_CS2_201();
                case cardIDEnum.EX1_508:
                    return new Sim_EX1_508();
                case cardIDEnum.EX1_259:
                    return new Sim_EX1_259();
                case cardIDEnum.EX1_341:
                    return new Sim_EX1_341();
                case cardIDEnum.EX1_103:
                    return new Sim_EX1_103();
                case cardIDEnum.FP1_021:
                    return new Sim_FP1_021();
                case cardIDEnum.EX1_411:
                    return new Sim_EX1_411();
                case cardIDEnum.CS2_053:
                    return new Sim_CS2_053();
                case cardIDEnum.CS2_182:
                    return new Sim_CS2_182();
                case cardIDEnum.CS2_008:
                    return new Sim_CS2_008();
                case cardIDEnum.CS2_233:
                    return new Sim_CS2_233();
                case cardIDEnum.EX1_626:
                    return new Sim_EX1_626();
                case cardIDEnum.EX1_059:
                    return new Sim_EX1_059();
                case cardIDEnum.EX1_334:
                    return new Sim_EX1_334();
                case cardIDEnum.EX1_619:
                    return new Sim_EX1_619();
                case cardIDEnum.NEW1_032:
                    return new Sim_NEW1_032();
                case cardIDEnum.EX1_158t:
                    return new Sim_EX1_158t();
                case cardIDEnum.EX1_006:
                    return new Sim_EX1_006();
                case cardIDEnum.NEW1_031:
                    return new Sim_NEW1_031();
                case cardIDEnum.DREAM_04:
                    return new Sim_DREAM_04();
                case cardIDEnum.EX1_004:
                    return new Sim_EX1_004();
                case cardIDEnum.EX1_095:
                    return new Sim_EX1_095();
                case cardIDEnum.NEW1_007:
                    return new Sim_NEW1_007();
                case cardIDEnum.EX1_275:
                    return new Sim_EX1_275();
                case cardIDEnum.EX1_245:
                    return new Sim_EX1_245();
                case cardIDEnum.EX1_383:
                    return new Sim_EX1_383();
                case cardIDEnum.FP1_016:
                    return new Sim_FP1_016();
                case cardIDEnum.EX1_016t:
                    return new Sim_EX1_016t();
                case cardIDEnum.CS2_125:
                    return new Sim_CS2_125();
                case cardIDEnum.EX1_137:
                    return new Sim_EX1_137();
                case cardIDEnum.DS1_185:
                    return new Sim_DS1_185();
                case cardIDEnum.FP1_010:
                    return new Sim_FP1_010();
                case cardIDEnum.EX1_598:
                    return new Sim_EX1_598();
                case cardIDEnum.EX1_304:
                    return new Sim_EX1_304();
                case cardIDEnum.EX1_302:
                    return new Sim_EX1_302();
                case cardIDEnum.EX1_614t:
                    return new Sim_EX1_614t();
                case cardIDEnum.CS2_108:
                    return new Sim_CS2_108();
                case cardIDEnum.CS2_046:
                    return new Sim_CS2_046();
                case cardIDEnum.EX1_014t:
                    return new Sim_EX1_014t();
                case cardIDEnum.NEW1_005:
                    return new Sim_NEW1_005();
                case cardIDEnum.EX1_062:
                    return new Sim_EX1_062();
                case cardIDEnum.Mekka1:
                    return new Sim_Mekka1();
                case cardIDEnum.tt_010a:
                    return new Sim_tt_010a();
                case cardIDEnum.CS2_072:
                    return new Sim_CS2_072();
                case cardIDEnum.EX1_tk28:
                    return new Sim_EX1_tk28();
                case cardIDEnum.FP1_014:
                    return new Sim_FP1_014();
                case cardIDEnum.EX1_409t:
                    return new Sim_EX1_409t();
                case cardIDEnum.EX1_507:
                    return new Sim_EX1_507();
                case cardIDEnum.EX1_144:
                    return new Sim_EX1_144();
                case cardIDEnum.CS2_038:
                    return new Sim_CS2_038();
                case cardIDEnum.EX1_093:
                    return new Sim_EX1_093();
                case cardIDEnum.CS2_080:
                    return new Sim_CS2_080();
                case cardIDEnum.EX1_005:
                    return new Sim_EX1_005();
                case cardIDEnum.EX1_382:
                    return new Sim_EX1_382();
                case cardIDEnum.CS2_028:
                    return new Sim_CS2_028();
                case cardIDEnum.EX1_538:
                    return new Sim_EX1_538();
                case cardIDEnum.DREAM_02:
                    return new Sim_DREAM_02();
                case cardIDEnum.EX1_581:
                    return new Sim_EX1_581();
                case cardIDEnum.EX1_131t:
                    return new Sim_EX1_131t();
                case cardIDEnum.CS2_147:
                    return new Sim_CS2_147();
                case cardIDEnum.CS1_113:
                    return new Sim_CS1_113();
                case cardIDEnum.CS2_161:
                    return new Sim_CS2_161();
                case cardIDEnum.CS2_031:
                    return new Sim_CS2_031();
                case cardIDEnum.EX1_166b:
                    return new Sim_EX1_166b();
                case cardIDEnum.EX1_066:
                    return new Sim_EX1_066();
                case cardIDEnum.EX1_355:
                    return new Sim_EX1_355();
                case cardIDEnum.EX1_534:
                    return new Sim_EX1_534();
                case cardIDEnum.EX1_162:
                    return new Sim_EX1_162();
                case cardIDEnum.EX1_363:
                    return new Sim_EX1_363();
                case cardIDEnum.EX1_164a:
                    return new Sim_EX1_164a();
                case cardIDEnum.CS2_188:
                    return new Sim_CS2_188();
                case cardIDEnum.EX1_016:
                    return new Sim_EX1_016();
                case cardIDEnum.EX1_603:
                    return new Sim_EX1_603();
                case cardIDEnum.EX1_238:
                    return new Sim_EX1_238();
                case cardIDEnum.EX1_166:
                    return new Sim_EX1_166();
                case cardIDEnum.DS1h_292:
                    return new Sim_DS1h_292();
                case cardIDEnum.DS1_183:
                    return new Sim_DS1_183();
                case cardIDEnum.EX1_076:
                    return new Sim_EX1_076();
                case cardIDEnum.EX1_048:
                    return new Sim_EX1_048();
                case cardIDEnum.FP1_026:
                    return new Sim_FP1_026();
                case cardIDEnum.CS2_074:
                    return new Sim_CS2_074();
                case cardIDEnum.FP1_027:
                    return new Sim_FP1_027();
                case cardIDEnum.EX1_323w:
                    return new Sim_EX1_323w();
                case cardIDEnum.EX1_129:
                    return new Sim_EX1_129();
                case cardIDEnum.EX1_405:
                    return new Sim_EX1_405();
                case cardIDEnum.EX1_317:
                    return new Sim_EX1_317();
                case cardIDEnum.EX1_606:
                    return new Sim_EX1_606();
                case cardIDEnum.FP1_006:
                    return new Sim_FP1_006();
                case cardIDEnum.NEW1_008:
                    return new Sim_NEW1_008();
                case cardIDEnum.CS2_119:
                    return new Sim_CS2_119();
                case cardIDEnum.CS2_121:
                    return new Sim_CS2_121();
                case cardIDEnum.CS1h_001:
                    return new Sim_CS1h_001();
                case cardIDEnum.EX1_tk34:
                    return new Sim_EX1_tk34();
                case cardIDEnum.NEW1_020:
                    return new Sim_NEW1_020();
                case cardIDEnum.CS2_196:
                    return new Sim_CS2_196();
                case cardIDEnum.EX1_312:
                    return new Sim_EX1_312();
                case cardIDEnum.FP1_022:
                    return new Sim_FP1_022();
                case cardIDEnum.EX1_160b:
                    return new Sim_EX1_160b();
                case cardIDEnum.EX1_563:
                    return new Sim_EX1_563();
                case cardIDEnum.FP1_031:
                    return new Sim_FP1_031();
                case cardIDEnum.NEW1_029:
                    return new Sim_NEW1_029();
                case cardIDEnum.CS1_129:
                    return new Sim_CS1_129();
                case cardIDEnum.HERO_03:
                    return new Sim_HERO_03();
                case cardIDEnum.Mekka4t:
                    return new Sim_Mekka4t();
                case cardIDEnum.EX1_158:
                    return new Sim_EX1_158();
                case cardIDEnum.NEW1_025:
                    return new Sim_NEW1_025();
                case cardIDEnum.FP1_012t:
                    return new Sim_FP1_012t();
                case cardIDEnum.EX1_083:
                    return new Sim_EX1_083();
                case cardIDEnum.EX1_295:
                    return new Sim_EX1_295();
                case cardIDEnum.EX1_407:
                    return new Sim_EX1_407();
                case cardIDEnum.NEW1_004:
                    return new Sim_NEW1_004();
                case cardIDEnum.FP1_019:
                    return new Sim_FP1_019();
                case cardIDEnum.PRO_001at:
                    return new Sim_PRO_001at();
                case cardIDEnum.EX1_625t:
                    return new Sim_EX1_625t();
                case cardIDEnum.EX1_014:
                    return new Sim_EX1_014();
                case cardIDEnum.CS2_097:
                    return new Sim_CS2_097();
                case cardIDEnum.EX1_558:
                    return new Sim_EX1_558();
                case cardIDEnum.EX1_tk29:
                    return new Sim_EX1_tk29();
                case cardIDEnum.CS2_186:
                    return new Sim_CS2_186();
                case cardIDEnum.EX1_084:
                    return new Sim_EX1_084();
                case cardIDEnum.NEW1_012:
                    return new Sim_NEW1_012();
                case cardIDEnum.FP1_014t:
                    return new Sim_FP1_014t();
                case cardIDEnum.EX1_578:
                    return new Sim_EX1_578();
                case cardIDEnum.CS2_221:
                    return new Sim_CS2_221();
                case cardIDEnum.EX1_019:
                    return new Sim_EX1_019();
                case cardIDEnum.FP1_019t:
                    return new Sim_FP1_019t();
                case cardIDEnum.EX1_132:
                    return new Sim_EX1_132();
                case cardIDEnum.EX1_284:
                    return new Sim_EX1_284();
                case cardIDEnum.EX1_105:
                    return new Sim_EX1_105();
                case cardIDEnum.NEW1_011:
                    return new Sim_NEW1_011();
                case cardIDEnum.EX1_017:
                    return new Sim_EX1_017();
                case cardIDEnum.EX1_249:
                    return new Sim_EX1_249();
                case cardIDEnum.FP1_002t:
                    return new Sim_FP1_002t();
                case cardIDEnum.EX1_313:
                    return new Sim_EX1_313();
                case cardIDEnum.EX1_155b:
                    return new Sim_EX1_155b();
                case cardIDEnum.NEW1_033:
                    return new Sim_NEW1_033();
                case cardIDEnum.CS2_106:
                    return new Sim_CS2_106();
                case cardIDEnum.FP1_018:
                    return new Sim_FP1_018();
                case cardIDEnum.DS1_233:
                    return new Sim_DS1_233();
                case cardIDEnum.DS1_175:
                    return new Sim_DS1_175();
                case cardIDEnum.NEW1_024:
                    return new Sim_NEW1_024();
                case cardIDEnum.CS2_189:
                    return new Sim_CS2_189();
                case cardIDEnum.NEW1_037:
                    return new Sim_NEW1_037();
                case cardIDEnum.EX1_414:
                    return new Sim_EX1_414();
                case cardIDEnum.EX1_538t:
                    return new Sim_EX1_538t();
                case cardIDEnum.EX1_586:
                    return new Sim_EX1_586();
                case cardIDEnum.EX1_310:
                    return new Sim_EX1_310();
                case cardIDEnum.NEW1_010:
                    return new Sim_NEW1_010();
                case cardIDEnum.EX1_534t:
                    return new Sim_EX1_534t();
                case cardIDEnum.FP1_028:
                    return new Sim_FP1_028();
                case cardIDEnum.EX1_604:
                    return new Sim_EX1_604();
                case cardIDEnum.EX1_160:
                    return new Sim_EX1_160();
                case cardIDEnum.EX1_165t1:
                    return new Sim_EX1_165t1();
                case cardIDEnum.CS2_062:
                    return new Sim_CS2_062();
                case cardIDEnum.CS2_155:
                    return new Sim_CS2_155();
                case cardIDEnum.CS2_213:
                    return new Sim_CS2_213();
                case cardIDEnum.CS2_004:
                    return new Sim_CS2_004();
                case cardIDEnum.CS2_023:
                    return new Sim_CS2_023();
                case cardIDEnum.EX1_164:
                    return new Sim_EX1_164();
                case cardIDEnum.EX1_009:
                    return new Sim_EX1_009();
                case cardIDEnum.FP1_007:
                    return new Sim_FP1_007();
                case cardIDEnum.EX1_345:
                    return new Sim_EX1_345();
                case cardIDEnum.EX1_116:
                    return new Sim_EX1_116();
                case cardIDEnum.EX1_399:
                    return new Sim_EX1_399();
                case cardIDEnum.EX1_587:
                    return new Sim_EX1_587();
                case cardIDEnum.EX1_571:
                    return new Sim_EX1_571();
                case cardIDEnum.EX1_335:
                    return new Sim_EX1_335();
                case cardIDEnum.HERO_08:
                    return new Sim_HERO_08();
                case cardIDEnum.EX1_166a:
                    return new Sim_EX1_166a();
                case cardIDEnum.EX1_finkle:
                    return new Sim_EX1_finkle();
                case cardIDEnum.EX1_164b:
                    return new Sim_EX1_164b();
                case cardIDEnum.EX1_283:
                    return new Sim_EX1_283();
                case cardIDEnum.EX1_339:
                    return new Sim_EX1_339();
                case cardIDEnum.EX1_531:
                    return new Sim_EX1_531();
                case cardIDEnum.EX1_134:
                    return new Sim_EX1_134();
                case cardIDEnum.EX1_350:
                    return new Sim_EX1_350();
                case cardIDEnum.EX1_308:
                    return new Sim_EX1_308();
                case cardIDEnum.CS2_197:
                    return new Sim_CS2_197();
                case cardIDEnum.skele21:
                    return new Sim_skele21();
                case cardIDEnum.FP1_013:
                    return new Sim_FP1_013();
                case cardIDEnum.NEW1_006:
                    return new Sim_NEW1_006();
                case cardIDEnum.EX1_509:
                    return new Sim_EX1_509();
                case cardIDEnum.EX1_612:
                    return new Sim_EX1_612();
                case cardIDEnum.EX1_021:
                    return new Sim_EX1_021();
                case cardIDEnum.CS2_226:
                    return new Sim_CS2_226();
                case cardIDEnum.EX1_608:
                    return new Sim_EX1_608();
                case cardIDEnum.EX1_624:
                    return new Sim_EX1_624();
                case cardIDEnum.EX1_616:
                    return new Sim_EX1_616();
                case cardIDEnum.EX1_008:
                    return new Sim_EX1_008();
                case cardIDEnum.PlaceholderCard:
                    return new Sim_PlaceholderCard();
                case cardIDEnum.EX1_045:
                    return new Sim_EX1_045();
                case cardIDEnum.EX1_015:
                    return new Sim_EX1_015();
                case cardIDEnum.CS2_171:
                    return new Sim_CS2_171();
                case cardIDEnum.CS2_041:
                    return new Sim_CS2_041();
                case cardIDEnum.EX1_128:
                    return new Sim_EX1_128();
                case cardIDEnum.CS2_112:
                    return new Sim_CS2_112();
                case cardIDEnum.HERO_07:
                    return new Sim_HERO_07();
                case cardIDEnum.EX1_412:
                    return new Sim_EX1_412();
                case cardIDEnum.CS2_117:
                    return new Sim_CS2_117();
                case cardIDEnum.EX1_562:
                    return new Sim_EX1_562();
                case cardIDEnum.EX1_055:
                    return new Sim_EX1_055();
                case cardIDEnum.FP1_012:
                    return new Sim_FP1_012();
                case cardIDEnum.EX1_317t:
                    return new Sim_EX1_317t();
                case cardIDEnum.EX1_278:
                    return new Sim_EX1_278();
                case cardIDEnum.CS2_tk1:
                    return new Sim_CS2_tk1();
                case cardIDEnum.EX1_590:
                    return new Sim_EX1_590();
                case cardIDEnum.CS1_130:
                    return new Sim_CS1_130();
                case cardIDEnum.NEW1_008b:
                    return new Sim_NEW1_008b();
                case cardIDEnum.EX1_365:
                    return new Sim_EX1_365();
                case cardIDEnum.CS2_141:
                    return new Sim_CS2_141();
                case cardIDEnum.PRO_001:
                    return new Sim_PRO_001();
                case cardIDEnum.CS2_173:
                    return new Sim_CS2_173();
                case cardIDEnum.CS2_017:
                    return new Sim_CS2_017();
                case cardIDEnum.EX1_392:
                    return new Sim_EX1_392();
                case cardIDEnum.EX1_593:
                    return new Sim_EX1_593();
                case cardIDEnum.EX1_049:
                    return new Sim_EX1_049();
                case cardIDEnum.EX1_002:
                    return new Sim_EX1_002();
                case cardIDEnum.CS2_056:
                    return new Sim_CS2_056();
                case cardIDEnum.EX1_596:
                    return new Sim_EX1_596();
                case cardIDEnum.EX1_136:
                    return new Sim_EX1_136();
                case cardIDEnum.EX1_323:
                    return new Sim_EX1_323();
                case cardIDEnum.CS2_073:
                    return new Sim_CS2_073();
                case cardIDEnum.EX1_001:
                    return new Sim_EX1_001();
                case cardIDEnum.EX1_044:
                    return new Sim_EX1_044();
                case cardIDEnum.Mekka4:
                    return new Sim_Mekka4();
                case cardIDEnum.CS2_142:
                    return new Sim_CS2_142();
                case cardIDEnum.EX1_573:
                    return new Sim_EX1_573();
                case cardIDEnum.FP1_009:
                    return new Sim_FP1_009();
                case cardIDEnum.CS2_050:
                    return new Sim_CS2_050();
                case cardIDEnum.EX1_390:
                    return new Sim_EX1_390();
                case cardIDEnum.EX1_610:
                    return new Sim_EX1_610();
                case cardIDEnum.hexfrog:
                    return new Sim_hexfrog();
                case cardIDEnum.CS2_082:
                    return new Sim_CS2_082();
                case cardIDEnum.NEW1_040:
                    return new Sim_NEW1_040();
                case cardIDEnum.DREAM_01:
                    return new Sim_DREAM_01();
                case cardIDEnum.EX1_595:
                    return new Sim_EX1_595();
                case cardIDEnum.CS2_013:
                    return new Sim_CS2_013();
                case cardIDEnum.CS2_077:
                    return new Sim_CS2_077();
                case cardIDEnum.NEW1_014:
                    return new Sim_NEW1_014();
                case cardIDEnum.GAME_002:
                    return new Sim_GAME_002();
                case cardIDEnum.EX1_165:
                    return new Sim_EX1_165();
                case cardIDEnum.CS2_013t:
                    return new Sim_CS2_013t();
                case cardIDEnum.EX1_tk11:
                    return new Sim_EX1_tk11();
                case cardIDEnum.EX1_591:
                    return new Sim_EX1_591();
                case cardIDEnum.EX1_549:
                    return new Sim_EX1_549();
                case cardIDEnum.CS2_045:
                    return new Sim_CS2_045();
                case cardIDEnum.CS2_237:
                    return new Sim_CS2_237();
                case cardIDEnum.CS2_027:
                    return new Sim_CS2_027();
                case cardIDEnum.CS2_101t:
                    return new Sim_CS2_101t();
                case cardIDEnum.CS2_063:
                    return new Sim_CS2_063();
                case cardIDEnum.EX1_145:
                    return new Sim_EX1_145();
                case cardIDEnum.EX1_110:
                    return new Sim_EX1_110();
                case cardIDEnum.EX1_408:
                    return new Sim_EX1_408();
                case cardIDEnum.EX1_544:
                    return new Sim_EX1_544();
                case cardIDEnum.CS2_151:
                    return new Sim_CS2_151();
                case cardIDEnum.CS2_088:
                    return new Sim_CS2_088();
                case cardIDEnum.EX1_057:
                    return new Sim_EX1_057();
                case cardIDEnum.FP1_020:
                    return new Sim_FP1_020();
                case cardIDEnum.CS2_169:
                    return new Sim_CS2_169();
                case cardIDEnum.EX1_573t:
                    return new Sim_EX1_573t();
                case cardIDEnum.EX1_323h:
                    return new Sim_EX1_323h();
                case cardIDEnum.EX1_tk9:
                    return new Sim_EX1_tk9();
                case cardIDEnum.CS2_037:
                    return new Sim_CS2_037();
                case cardIDEnum.CS2_007:
                    return new Sim_CS2_007();
                case cardIDEnum.CS2_227:
                    return new Sim_CS2_227();
                case cardIDEnum.NEW1_003:
                    return new Sim_NEW1_003();
                case cardIDEnum.GAME_006:
                    return new Sim_GAME_006();
                case cardIDEnum.EX1_320:
                    return new Sim_EX1_320();
                case cardIDEnum.EX1_097:
                    return new Sim_EX1_097();
                case cardIDEnum.tt_004:
                    return new Sim_tt_004();
                case cardIDEnum.EX1_096:
                    return new Sim_EX1_096();
                case cardIDEnum.EX1_126:
                    return new Sim_EX1_126();
                case cardIDEnum.EX1_577:
                    return new Sim_EX1_577();
                case cardIDEnum.EX1_319:
                    return new Sim_EX1_319();
                case cardIDEnum.EX1_611:
                    return new Sim_EX1_611();
                case cardIDEnum.CS2_146:
                    return new Sim_CS2_146();
                case cardIDEnum.EX1_154b:
                    return new Sim_EX1_154b();
                case cardIDEnum.skele11:
                    return new Sim_skele11();
                case cardIDEnum.EX1_165t2:
                    return new Sim_EX1_165t2();
                case cardIDEnum.CS2_172:
                    return new Sim_CS2_172();
                case cardIDEnum.CS2_114:
                    return new Sim_CS2_114();
                case cardIDEnum.CS1_069:
                    return new Sim_CS1_069();
                case cardIDEnum.EX1_173:
                    return new Sim_EX1_173();
                case cardIDEnum.CS1_042:
                    return new Sim_CS1_042();
                case cardIDEnum.EX1_506a:
                    return new Sim_EX1_506a();
                case cardIDEnum.EX1_298:
                    return new Sim_EX1_298();
                case cardIDEnum.CS2_104:
                    return new Sim_CS2_104();
                case cardIDEnum.FP1_001:
                    return new Sim_FP1_001();
                case cardIDEnum.HERO_02:
                    return new Sim_HERO_02();
                case cardIDEnum.CS2_051:
                    return new Sim_CS2_051();
                case cardIDEnum.NEW1_016:
                    return new Sim_NEW1_016();
                case cardIDEnum.EX1_033:
                    return new Sim_EX1_033();
                case cardIDEnum.EX1_028:
                    return new Sim_EX1_028();
                case cardIDEnum.EX1_621:
                    return new Sim_EX1_621();
                case cardIDEnum.EX1_554:
                    return new Sim_EX1_554();
                case cardIDEnum.EX1_091:
                    return new Sim_EX1_091();
                case cardIDEnum.FP1_017:
                    return new Sim_FP1_017();
                case cardIDEnum.EX1_409:
                    return new Sim_EX1_409();
                case cardIDEnum.EX1_410:
                    return new Sim_EX1_410();
                case cardIDEnum.CS2_039:
                    return new Sim_CS2_039();
                case cardIDEnum.EX1_557:
                    return new Sim_EX1_557();
                case cardIDEnum.DS1_070:
                    return new Sim_DS1_070();
                case cardIDEnum.CS2_033:
                    return new Sim_CS2_033();
                case cardIDEnum.EX1_536:
                    return new Sim_EX1_536();
                case cardIDEnum.EX1_559:
                    return new Sim_EX1_559();
                case cardIDEnum.CS2_052:
                    return new Sim_CS2_052();
                case cardIDEnum.EX1_539:
                    return new Sim_EX1_539();
                case cardIDEnum.EX1_575:
                    return new Sim_EX1_575();
                case cardIDEnum.CS2_083b:
                    return new Sim_CS2_083b();
                case cardIDEnum.CS2_061:
                    return new Sim_CS2_061();
                case cardIDEnum.NEW1_021:
                    return new Sim_NEW1_021();
                case cardIDEnum.DS1_055:
                    return new Sim_DS1_055();
                case cardIDEnum.EX1_625:
                    return new Sim_EX1_625();
                case cardIDEnum.CS2_026:
                    return new Sim_CS2_026();
                case cardIDEnum.EX1_294:
                    return new Sim_EX1_294();
                case cardIDEnum.EX1_287:
                    return new Sim_EX1_287();
                case cardIDEnum.EX1_625t2:
                    return new Sim_EX1_625t2();
                case cardIDEnum.CS2_118:
                    return new Sim_CS2_118();
                case cardIDEnum.CS2_124:
                    return new Sim_CS2_124();
                case cardIDEnum.Mekka3:
                    return new Sim_Mekka3();
                case cardIDEnum.EX1_112:
                    return new Sim_EX1_112();
                case cardIDEnum.FP1_011:
                    return new Sim_FP1_011();
                case cardIDEnum.HERO_04:
                    return new Sim_HERO_04();
                case cardIDEnum.EX1_607:
                    return new Sim_EX1_607();
                case cardIDEnum.DREAM_03:
                    return new Sim_DREAM_03();
                case cardIDEnum.FP1_003:
                    return new Sim_FP1_003();
                case cardIDEnum.CS2_105:
                    return new Sim_CS2_105();
                case cardIDEnum.FP1_002:
                    return new Sim_FP1_002();
                case cardIDEnum.EX1_567:
                    return new Sim_EX1_567();
                case cardIDEnum.FP1_008:
                    return new Sim_FP1_008();
                case cardIDEnum.DS1_184:
                    return new Sim_DS1_184();
                case cardIDEnum.CS2_029:
                    return new Sim_CS2_029();
                case cardIDEnum.GAME_005:
                    return new Sim_GAME_005();
                case cardIDEnum.CS2_187:
                    return new Sim_CS2_187();
                case cardIDEnum.EX1_020:
                    return new Sim_EX1_020();
                case cardIDEnum.EX1_011:
                    return new Sim_EX1_011();
                case cardIDEnum.CS2_057:
                    return new Sim_CS2_057();
                case cardIDEnum.EX1_274:
                    return new Sim_EX1_274();
                case cardIDEnum.EX1_306:
                    return new Sim_EX1_306();
                case cardIDEnum.EX1_170:
                    return new Sim_EX1_170();
                case cardIDEnum.EX1_617:
                    return new Sim_EX1_617();
                case cardIDEnum.CS2_101:
                    return new Sim_CS2_101();
                case cardIDEnum.FP1_015:
                    return new Sim_FP1_015();
                case cardIDEnum.CS2_005:
                    return new Sim_CS2_005();
                case cardIDEnum.EX1_537:
                    return new Sim_EX1_537();
                case cardIDEnum.EX1_384:
                    return new Sim_EX1_384();
                case cardIDEnum.EX1_362:
                    return new Sim_EX1_362();
                case cardIDEnum.EX1_301:
                    return new Sim_EX1_301();
                case cardIDEnum.CS2_235:
                    return new Sim_CS2_235();
                case cardIDEnum.EX1_029:
                    return new Sim_EX1_029();
                case cardIDEnum.CS2_042:
                    return new Sim_CS2_042();
                case cardIDEnum.EX1_155a:
                    return new Sim_EX1_155a();
                case cardIDEnum.CS2_102:
                    return new Sim_CS2_102();
                case cardIDEnum.EX1_609:
                    return new Sim_EX1_609();
                case cardIDEnum.NEW1_027:
                    return new Sim_NEW1_027();
                case cardIDEnum.EX1_165a:
                    return new Sim_EX1_165a();
                case cardIDEnum.EX1_570:
                    return new Sim_EX1_570();
                case cardIDEnum.EX1_131:
                    return new Sim_EX1_131();
                case cardIDEnum.EX1_556:
                    return new Sim_EX1_556();
                case cardIDEnum.EX1_543:
                    return new Sim_EX1_543();
                case cardIDEnum.NEW1_009:
                    return new Sim_NEW1_009();
                case cardIDEnum.EX1_100:
                    return new Sim_EX1_100();
                case cardIDEnum.EX1_573a:
                    return new Sim_EX1_573a();
                case cardIDEnum.CS2_084:
                    return new Sim_CS2_084();
                case cardIDEnum.EX1_582:
                    return new Sim_EX1_582();
                case cardIDEnum.EX1_043:
                    return new Sim_EX1_043();
                case cardIDEnum.EX1_050:
                    return new Sim_EX1_050();
                case cardIDEnum.FP1_005:
                    return new Sim_FP1_005();
                case cardIDEnum.EX1_620:
                    return new Sim_EX1_620();
                case cardIDEnum.EX1_303:
                    return new Sim_EX1_303();
                case cardIDEnum.HERO_09:
                    return new Sim_HERO_09();
                case cardIDEnum.EX1_067:
                    return new Sim_EX1_067();
                case cardIDEnum.EX1_277:
                    return new Sim_EX1_277();
                case cardIDEnum.Mekka2:
                    return new Sim_Mekka2();
                case cardIDEnum.FP1_024:
                    return new Sim_FP1_024();
                case cardIDEnum.FP1_030:
                    return new Sim_FP1_030();
                case cardIDEnum.EX1_178:
                    return new Sim_EX1_178();
                case cardIDEnum.CS2_222:
                    return new Sim_CS2_222();
                case cardIDEnum.EX1_160a:
                    return new Sim_EX1_160a();
                case cardIDEnum.CS2_012:
                    return new Sim_CS2_012();
                case cardIDEnum.EX1_246:
                    return new Sim_EX1_246();
                case cardIDEnum.EX1_572:
                    return new Sim_EX1_572();
                case cardIDEnum.EX1_089:
                    return new Sim_EX1_089();
                case cardIDEnum.CS2_059:
                    return new Sim_CS2_059();
                case cardIDEnum.EX1_279:
                    return new Sim_EX1_279();
                case cardIDEnum.CS2_168:
                    return new Sim_CS2_168();
                case cardIDEnum.tt_010:
                    return new Sim_tt_010();
                case cardIDEnum.NEW1_023:
                    return new Sim_NEW1_023();
                case cardIDEnum.CS2_075:
                    return new Sim_CS2_075();
                case cardIDEnum.EX1_316:
                    return new Sim_EX1_316();
                case cardIDEnum.CS2_025:
                    return new Sim_CS2_025();
                case cardIDEnum.CS2_234:
                    return new Sim_CS2_234();
                case cardIDEnum.EX1_130:
                    return new Sim_EX1_130();
                case cardIDEnum.CS2_064:
                    return new Sim_CS2_064();
                case cardIDEnum.EX1_161:
                    return new Sim_EX1_161();
                case cardIDEnum.CS2_049:
                    return new Sim_CS2_049();
                case cardIDEnum.EX1_154:
                    return new Sim_EX1_154();
                case cardIDEnum.EX1_080:
                    return new Sim_EX1_080();
                case cardIDEnum.NEW1_022:
                    return new Sim_NEW1_022();
                case cardIDEnum.EX1_251:
                    return new Sim_EX1_251();
                case cardIDEnum.FP1_025:
                    return new Sim_FP1_025();
                case cardIDEnum.EX1_371:
                    return new Sim_EX1_371();
                case cardIDEnum.CS2_mirror:
                    return new Sim_CS2_mirror();
                case cardIDEnum.EX1_594:
                    return new Sim_EX1_594();
                case cardIDEnum.EX1_560:
                    return new Sim_EX1_560();
                case cardIDEnum.CS2_236:
                    return new Sim_CS2_236();
                case cardIDEnum.EX1_402:
                    return new Sim_EX1_402();
                case cardIDEnum.EX1_506:
                    return new Sim_EX1_506();
                case cardIDEnum.DS1_178:
                    return new Sim_DS1_178();
                case cardIDEnum.EX1_315:
                    return new Sim_EX1_315();
                case cardIDEnum.CS2_094:
                    return new Sim_CS2_094();
                case cardIDEnum.NEW1_040t:
                    return new Sim_NEW1_040t();
                case cardIDEnum.CS2_131:
                    return new Sim_CS2_131();
                case cardIDEnum.EX1_082:
                    return new Sim_EX1_082();
                case cardIDEnum.CS2_093:
                    return new Sim_CS2_093();
                case cardIDEnum.CS2_boar:
                    return new Sim_CS2_boar();
                case cardIDEnum.NEW1_019:
                    return new Sim_NEW1_019();
                case cardIDEnum.EX1_289:
                    return new Sim_EX1_289();
                case cardIDEnum.EX1_025t:
                    return new Sim_EX1_025t();
                case cardIDEnum.EX1_398t:
                    return new Sim_EX1_398t();
                case cardIDEnum.CS2_091:
                    return new Sim_CS2_091();
                case cardIDEnum.EX1_241:
                    return new Sim_EX1_241();
                case cardIDEnum.EX1_085:
                    return new Sim_EX1_085();
                case cardIDEnum.CS2_200:
                    return new Sim_CS2_200();
                case cardIDEnum.CS2_034:
                    return new Sim_CS2_034();
                case cardIDEnum.EX1_583:
                    return new Sim_EX1_583();
                case cardIDEnum.EX1_584:
                    return new Sim_EX1_584();
                case cardIDEnum.EX1_155:
                    return new Sim_EX1_155();
                case cardIDEnum.EX1_622:
                    return new Sim_EX1_622();
                case cardIDEnum.CS2_203:
                    return new Sim_CS2_203();
                case cardIDEnum.EX1_124:
                    return new Sim_EX1_124();
                case cardIDEnum.EX1_379:
                    return new Sim_EX1_379();
                case cardIDEnum.EX1_032:
                    return new Sim_EX1_032();
                case cardIDEnum.EX1_391:
                    return new Sim_EX1_391();
                case cardIDEnum.EX1_366:
                    return new Sim_EX1_366();
                case cardIDEnum.EX1_400:
                    return new Sim_EX1_400();
                case cardIDEnum.EX1_614:
                    return new Sim_EX1_614();
                case cardIDEnum.EX1_561:
                    return new Sim_EX1_561();
                case cardIDEnum.EX1_332:
                    return new Sim_EX1_332();
                case cardIDEnum.HERO_05:
                    return new Sim_HERO_05();
                case cardIDEnum.CS2_065:
                    return new Sim_CS2_065();
                case cardIDEnum.ds1_whelptoken:
                    return new Sim_ds1_whelptoken();
                case cardIDEnum.CS2_032:
                    return new Sim_CS2_032();
                case cardIDEnum.CS2_120:
                    return new Sim_CS2_120();
                case cardIDEnum.EX1_247:
                    return new Sim_EX1_247();
                case cardIDEnum.EX1_154a:
                    return new Sim_EX1_154a();
                case cardIDEnum.EX1_554t:
                    return new Sim_EX1_554t();
                case cardIDEnum.NEW1_026t:
                    return new Sim_NEW1_026t();
                case cardIDEnum.EX1_623:
                    return new Sim_EX1_623();
                case cardIDEnum.EX1_383t:
                    return new Sim_EX1_383t();
                case cardIDEnum.EX1_597:
                    return new Sim_EX1_597();
                case cardIDEnum.EX1_130a:
                    return new Sim_EX1_130a();
                case cardIDEnum.CS2_011:
                    return new Sim_CS2_011();
                case cardIDEnum.EX1_169:
                    return new Sim_EX1_169();
                case cardIDEnum.EX1_tk33:
                    return new Sim_EX1_tk33();
                case cardIDEnum.EX1_250:
                    return new Sim_EX1_250();
                case cardIDEnum.EX1_564:
                    return new Sim_EX1_564();
                case cardIDEnum.EX1_349:
                    return new Sim_EX1_349();
                case cardIDEnum.EX1_102:
                    return new Sim_EX1_102();
                case cardIDEnum.EX1_058:
                    return new Sim_EX1_058();
                case cardIDEnum.EX1_243:
                    return new Sim_EX1_243();
                case cardIDEnum.PRO_001c:
                    return new Sim_PRO_001c();
                case cardIDEnum.EX1_116t:
                    return new Sim_EX1_116t();
                case cardIDEnum.FP1_029:
                    return new Sim_FP1_029();
                case cardIDEnum.CS2_089:
                    return new Sim_CS2_089();
                case cardIDEnum.EX1_248:
                    return new Sim_EX1_248();
                case cardIDEnum.CS2_122:
                    return new Sim_CS2_122();
                case cardIDEnum.EX1_393:
                    return new Sim_EX1_393();
                case cardIDEnum.CS2_232:
                    return new Sim_CS2_232();
                case cardIDEnum.EX1_165b:
                    return new Sim_EX1_165b();
                case cardIDEnum.NEW1_030:
                    return new Sim_NEW1_030();
                case cardIDEnum.CS2_150:
                    return new Sim_CS2_150();
                case cardIDEnum.CS2_152:
                    return new Sim_CS2_152();
                case cardIDEnum.EX1_160t:
                    return new Sim_EX1_160t();
                case cardIDEnum.CS2_127:
                    return new Sim_CS2_127();
                case cardIDEnum.DS1_188:
                    return new Sim_DS1_188();
            }

            return new SimTemplate();
        }

        private void enumCreator()
        {
            //call this, if carddb.txt was changed, to get latest public enum cardIDEnum
            Helpfunctions.Instance.logg("public enum cardIDEnum");
            Helpfunctions.Instance.logg("{");
            Helpfunctions.Instance.logg("None,");
            foreach (string cardid in this.allCardIDS)
            {
                Helpfunctions.Instance.logg(cardid + ",");
            }
            Helpfunctions.Instance.logg("}");



            Helpfunctions.Instance.logg("public cardIDEnum cardIdstringToEnum(string s)");
            Helpfunctions.Instance.logg("{");
            foreach (string cardid in this.allCardIDS)
            {
                Helpfunctions.Instance.logg("if(s==\"" + cardid + "\") return CardDB.cardIDEnum." + cardid + ";");
            }
            Helpfunctions.Instance.logg("return CardDB.cardIDEnum.None;");
            Helpfunctions.Instance.logg("}");

            List<string> namelist = new List<string>();

            foreach (string cardid in this.namelist)
            {
                if (namelist.Contains(cardid)) continue;
                namelist.Add(cardid);
            }


            Helpfunctions.Instance.logg("public enum cardName");
            Helpfunctions.Instance.logg("{");
            foreach (string cardid in namelist)
            {
                Helpfunctions.Instance.logg(cardid + ",");
            }
            Helpfunctions.Instance.logg("}");

            Helpfunctions.Instance.logg("public cardName cardNamestringToEnum(string s)");
            Helpfunctions.Instance.logg("{");
            foreach (string cardid in namelist)
            {
                Helpfunctions.Instance.logg("if(s==\"" + cardid + "\") return CardDB.cardName." + cardid + ";");
            }
            Helpfunctions.Instance.logg("return CardDB.cardName.unknown;");
            Helpfunctions.Instance.logg("}");

            // simcard creator:

            Helpfunctions.Instance.logg("public SimTemplate getSimCard(cardIDEnum id)");
            Helpfunctions.Instance.logg("{");
            foreach (string cardid in this.allCardIDS)
            {
                Helpfunctions.Instance.logg("if(id == CardDB.cardIDEnum." + cardid + ") return new Sim_" + cardid + "();");
            }
            Helpfunctions.Instance.logg("return new SimTemplate();");
            Helpfunctions.Instance.logg("}");

        }

        private void setAdditionalData()
        {
            PenalityManager pen = PenalityManager.Instance;

            foreach (Card c in this.cardlist)
            {
                if (pen.cardDrawBattleCryDatabase.ContainsKey(c.name))
                {
                    c.isCarddraw = pen.cardDrawBattleCryDatabase[c.name];
                }

                if (pen.DamageTargetSpecialDatabase.ContainsKey(c.name))
                {
                    c.damagesTargetWithSpecial = true;
                }

                if (pen.DamageTargetDatabase.ContainsKey(c.name))
                {
                    c.damagesTarget = true;
                }

                if (pen.priorityTargets.ContainsKey(c.name))
                {
                    c.targetPriority = pen.priorityTargets[c.name];
                }

                if (pen.specialMinions.ContainsKey(c.name))
                {
                    c.isSpecialMinion = true;
                }
            }
        }

    }

}